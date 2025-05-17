using System;
using System.Collections.Generic;
using System.Text;
using BefuddledLabs.Magic.Debug.VUdon;
using UdonSharp;
using UnityEngine;
using Varneon.VUdon.Logger;
using VRC.SDKBase;
using VRC.Udon.Common.Enums;
using VRC.Udon.Common.Interfaces;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public enum RotationDirection {
        Straight,
        Left,
        HardLeft,
        Right,
        HardRight
    }

    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class Wand : UdonSharpBehaviour {
        public GlyphSpace glyphSpace;
        public VMManager vmManager;
        public UdonConsole _console;

        public VRC_Pickup pickup;
        public Transform grid;
        public Transform gridSnapPoint;

        public LineRenderer lineRenderer;

        public bool forceVRMode;

        public int dotCount = 16;

        private List<Vector2Int> _points = new List<Vector2Int>();
        private int _shaderId = -1;
        private int _pointCount;

        private bool _gridFrozen;

        private bool _desktopInput;
        
        private StringBuilder _notation = new StringBuilder();

        private static Vector2Int GetNextAxial(Vector2Int previous, Vector2Int current, RotationDirection direction) {
            return current + RotateVector(current - previous, GetRotationAngle(direction));
        }

        private static Vector2Int RotateVector(Vector2Int vec, int degrees) {
            // Convert degrees to hexagonal rotation steps (60° increments)
            int steps = degrees / 60;
            for (int i = 0; i < Mathf.Abs(steps); i++) {
                vec = steps > 0 ? Rotate60CCW(vec) : Rotate60CW(vec);
            }

            return vec;
        }

        private static int GetRotationAngle(RotationDirection direction) {
            switch (direction) {
                case RotationDirection.Straight:
                    return 0;
                case RotationDirection.Left:
                    return -60;
                case RotationDirection.HardLeft:
                    return -120;
                case RotationDirection.Right:
                    return 60;
                case RotationDirection.HardRight:
                    return 120;
                default:
                    return 0;
            }
        }

        private static Vector2Int Rotate60CCW(Vector2Int vec) {
            return new Vector2Int(-vec.y, vec.x + vec.y);
        }

        private static Vector2Int Rotate60CW(Vector2Int vec) {
            return new Vector2Int(vec.x + vec.y, -vec.x);
        }

        public void Start() {
            if (Networking.IsOwner(gameObject))
                SendCustomEventDelayedFrames(nameof(LocalUpdateLoop), 1);
            else {
                lineRenderer.gameObject.SetActive(false);
                grid.gameObject.SetActive(false);
                pickup.pickupable = false;
            }

            _shaderId = VRCShader.PropertyToID("_UdonWandLocation");

#if !UNITY_ANDROID
            _desktopInput = !Networking.LocalPlayer.IsUserInVR() && !forceVRMode;
#endif
        }

        private void ResetDesktop() {
            _points.Clear();
            _points.Add(new Vector2Int(0, 0));
            _points.Add(new Vector2Int(1, 0));
        }

        private void ResetVR() {
            _points.Clear();
            _points.Add(new Vector2Int(0, 0));
        }

        private void ResetGrid() {
            _notation.Clear();
            if (_desktopInput)
                ResetDesktop();
            else
                ResetVR();
        }

        private bool CheckValidPoint(Vector2Int qr) {
            int pointCount = _points.Count;

            var points = _points.ToArray();

            Vector2Int lastQr = points[pointCount - 1];
            if (qr == lastQr)
                return false;
            if (!IsNeighbor(qr, lastQr))
                return false;

            if (pointCount > 1) {
                Vector2Int lastPoint = _points[pointCount - 1];
                int currentPoint = Array.IndexOf(points, lastPoint, 0, pointCount - 1);

                while (currentPoint >= 0) {
                    // checking for edge intersections
                    if (currentPoint + 1 < pointCount)
                        if (points[currentPoint + 1] == qr)
                            return false;
                    if (currentPoint - 1 >= 0)
                        if (points[currentPoint - 1] == qr)
                            return false;
                    currentPoint = Array.IndexOf(points, lastPoint, currentPoint + 1, pointCount - 1 - currentPoint);
                }
            }

            return true;
        }

        private bool TryAddPoint(Vector2Int qr, char direction) {
            if (!CheckValidPoint(qr))
                return false;

            if (direction == ' ' && _points.Count >= 2) {
                Vector2Int lastPoint = _points[_points.Count - 2];
                Vector2Int currentPoint = _points[_points.Count - 1];
                Vector2 forward = (AxialTo2DPosition(lastPoint.x, lastPoint.y) - AxialTo2DPosition(currentPoint.x, currentPoint.y)).normalized;
                Vector2 next = (AxialTo2DPosition(currentPoint.x, currentPoint.y) - AxialTo2DPosition(qr.x, qr.y)).normalized;

                int angle = Mathf.RoundToInt(Vector2.SignedAngle(forward, next) / 60f);
                switch (angle) {
                    case -2:
                        direction = 'a';
                        break;
                    case -1:
                        direction = 'q';
                        break;
                    case 0:
                        direction = 'w';
                        break;
                    case 1:
                        direction = 'e';
                        break;
                    case 2:
                        direction = 'd';
                        break;
                }
            }
            
            _points.Add(qr);
            if (direction != ' ')
                _notation.Append(direction);
            
            return true;
        }

        private void DesktopInput() {
            if (Input.GetKeyDown(KeyCode.R))
                ResetGrid();

            if (_points.Count >= 2) {
                if (Input.GetKeyDown(KeyCode.W))
                    TryAddPoint(GetNextAxial(_points[_points.Count - 2], _points[_points.Count - 1],
                        RotationDirection.Straight), 'w');
                if (Input.GetKeyDown(KeyCode.Q))
                    TryAddPoint(GetNextAxial(_points[_points.Count - 2], _points[_points.Count - 1],
                        RotationDirection.Left), 'q');
                if (Input.GetKeyDown(KeyCode.A))
                    TryAddPoint(GetNextAxial(_points[_points.Count - 2], _points[_points.Count - 1],
                        RotationDirection.HardLeft), 'a');
                if (Input.GetKeyDown(KeyCode.E))
                    TryAddPoint(GetNextAxial(_points[_points.Count - 2], _points[_points.Count - 1],
                        RotationDirection.Right), 'e');
                if (Input.GetKeyDown(KeyCode.D))
                    TryAddPoint(GetNextAxial(_points[_points.Count - 2], _points[_points.Count - 1],
                        RotationDirection.HardRight), 'd');
                if (Input.GetKeyDown(KeyCode.S) && _points.Count >= 3) {
                    _points.RemoveAt(_points.Count - 1);
                    _notation.Remove(_notation.Length - 1, 1);
                }
            }
            else {
                ResetGrid();
            }
        }


        private void VRInput() {
            Vector2Int qr = WorldPositionToAxialInt(gridSnapPoint.position, grid);

            int pointCount = _points.Count;
            if (pointCount > 1 && qr == _points[pointCount - 2]) {
                _points.RemoveAt(pointCount - 1);
                if (_points.Count >= 2)
                    _notation.Remove(_notation.Length - 1, 1);
            }
            else
                TryAddPoint(qr, ' ');
        }

        public void LocalUpdateLoop() {
            SendCustomEventDelayedFrames(nameof(LocalUpdateLoop), 1, EventTiming.LateUpdate);

            if (!_gridFrozen) {
                grid.transform.position = gridSnapPoint.position;
                grid.transform.LookAt(
                    Networking.LocalPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).position, Vector3.up);
            }

            VRCShader.SetGlobalVector(_shaderId,
                new Vector4(gridSnapPoint.position.x, gridSnapPoint.position.y, gridSnapPoint.position.z, 0));

            if (_gridFrozen) {
                if (_desktopInput)
                    DesktopInput();
                else
                    VRInput();
            }

            RenderPoints(_points);
        }

        public void Drop() {
            if (_gridFrozen)
                PickupUseUp();
            ResetGrid();
            _points.Clear();
        }

        public void PickupUseUp() {
            vmManager.localVM.glyphSpace = glyphSpace;
            _gridFrozen = !_gridFrozen;
            if (!_gridFrozen && _points.Count >= 2) {
                Vector3[] arr = new Vector3[_points.Count];
                for (int i = 0; i < _points.Count; i++) {
                    arr[i] = AxialToWorldPosition(_points[i].x, _points[i].y, grid);
                }

                glyphSpace.SendCustomNetworkEvent(NetworkEventTarget.Others, nameof(glyphSpace.InstantiateGlyph), arr);
                int glyphIndex = glyphSpace.InstantiateGlyph(arr);
                
                List<Instruction> instructions = new List<Instruction>(1);
                instructions.Add(new Instruction(_notation.ToString(), glyphIndex));
                ExecutionState result = vmManager.localVM.Execute(instructions);
                
                this.Log("execution state was " + result.ToString());
            }

            ResetGrid();
            if (_desktopInput)
                Networking.LocalPlayer.Immobilize(_gridFrozen);
        }

        private bool IsNeighbor(Vector2Int qr1, Vector2Int qr2) {
            return Mathf.Max(Mathf.Abs(qr1.x - qr2.x), Mathf.Abs(qr1.y - qr2.y)) < 2;
        }

        public Vector2 AxialTo2DPosition(int q, int r) {
            float hexSize = 1f / dotCount;
            float x = hexSize * Mathf.Sqrt(3f) * (q + r / 2f);
            float y = hexSize * 1.5f * r;

            return new Vector2(x, y);
        }

        public Vector3 AxialToWorldPosition(int q, int r, Transform quadTransform) {
            Vector2 pos = AxialTo2DPosition(q, r);
            return quadTransform.TransformPoint(new Vector3(-pos.x, -pos.y, 0));
        }

        public Vector2Int WorldPositionToAxialInt(Vector3 worldPosition, Transform quadTransform) {
            // Convert world position to local hex grid space
            Vector3 localPos = quadTransform.InverseTransformPoint(worldPosition);

            // Calculate axial coordinates (floats)
            float r_float = (-localPos.y) * 2f * dotCount / 3f;
            float q_float = (-localPos.x * dotCount / Mathf.Sqrt(3f)) + (localPos.y * dotCount / 3f);

            // Convert to cube coordinates
            float cubeX = q_float;
            float cubeZ = r_float;
            float cubeY = -cubeX - cubeZ;

            // Round cube coordinates
            int rx = Mathf.RoundToInt(cubeX);
            int ry = Mathf.RoundToInt(cubeY);
            int rz = Mathf.RoundToInt(cubeZ);

            // Check and maintain cube coordinate constraint (x + y + z = 0)
            int sum = rx + ry + rz;
            if (sum != 0) {
                // Calculate rounding differences
                float dx = Mathf.Abs(rx - cubeX);
                float dy = Mathf.Abs(ry - cubeY);
                float dz = Mathf.Abs(rz - cubeZ);

                // Adjust the coordinate with the largest difference
                if (dx > dy && dx > dz) {
                    rx = -ry - rz;
                }
                else if (dy > dz) {
                    ry = -rx - rz;
                }
                else {
                    rz = -rx - ry;
                }
            }

            // Convert back to axial coordinates (q, r)
            return new Vector2Int(rx, rz);
        }

        public void RenderPoints(List<Vector2Int> points) {
            _pointCount = points.Count;
            bool snapToWand = !_desktopInput && _gridFrozen;
            if (snapToWand)
                _pointCount += 1;

            Vector3[] arr = new Vector3[_pointCount];
            for (int i = 0; i < points.Count; i++) {
                arr[i] = AxialToWorldPosition(points[i].x, points[i].y, grid);
            }

            if (snapToWand)
                arr[_pointCount - 1] = gridSnapPoint.position;

            lineRenderer.SetPositions(arr);
            SendCustomEventDelayedFrames(nameof(LateUpdateRenderer), 1);
        }

        public void LateUpdateRenderer() {
            lineRenderer.positionCount = _pointCount;
        }
    }
}