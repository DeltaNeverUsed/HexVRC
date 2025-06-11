using System;
using System.Collections.Generic;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class PickupGlyphRevealer : UdonSharpBehaviour {
        public StorageMedium storageMedium;
        public GlyphSpace localGlyphSpace;

        public float startingDistance = 0.2f;
        public float distancePerRotation = 0.2f;
        public float distancePerGlyph = 10f;
        public float lineSize = 0.01f;

        private bool _displaying;
        private readonly List<Instruction> _instructions = new List<Instruction>();
        private int _instructionIndex;
        private float _size;
        private float _rotation;

        public override void OnPickup() {
            _instructions.Clear();
            StackItem item = storageMedium.Read();
            if (item.Type != ItemType.List)
                return;

            _displaying = true;
            _instructionIndex = 0;
            _size = startingDistance;
            _rotation = 0;
            List<StackItem> stackItems = (List<StackItem>)item.Value;
            foreach (StackItem i in stackItems) {
                if (i.Type == ItemType.Instruction)
                    _instructions.Add((Instruction)i.Value);
            }
            
            localGlyphSpace.transform.LookAt(Networking.GetOwner(gameObject).GetTrackingData(VRCPlayerApi.TrackingDataType.Head).position);
            SendCustomEventDelayedFrames(nameof(DisplayLoop), 1);
        }
        
        private Vector3[] GetLinePoints(string notation, Quaternion rotation, float distance) {
            List<Vector2Int> points = new();
            points.Add(new Vector2Int(0, 0));
            points.Add(new Vector2Int(-1, 0));
            foreach (char c in notation) {
                switch (c) {
                    case 'w':
                        points.Add(Wand.GetNextAxial(points[points.Count - 2], points[points.Count - 1],
                            RotationDirection.Straight));
                        break;
                    case 'q':
                        points.Add(Wand.GetNextAxial(points[points.Count - 2], points[points.Count - 1],
                            RotationDirection.Left));
                        break;
                    case 'a':
                        points.Add(Wand.GetNextAxial(points[points.Count - 2], points[points.Count - 1],
                            RotationDirection.HardLeft));
                        break;
                    case 'e':
                        points.Add(Wand.GetNextAxial(points[points.Count - 2], points[points.Count - 1],
                            RotationDirection.Right));
                        break;
                    case 'd':
                        points.Add(Wand.GetNextAxial(points[points.Count - 2], points[points.Count - 1],
                            RotationDirection.HardRight));
                        break;
                }
            }

            Vector3 offset = rotation * Vector3.up * distance; 

            Vector3[] newPoints = new Vector3[points.Count];
            Vector3 min = Vector2.zero;
            Vector3 max = Vector2.zero;
            for (int index = 0; index < points.Count; index++) {
                Vector2Int point = points[index];
                Vector2 transformedPoint = AxialTo2DPosition(point.x, point.y);
                
                Vector3 p = new Vector3(transformedPoint.x, transformedPoint.y, 0);
                min = Vector2.Min(min, p);
                max = Vector2.Max(max, p);
                newPoints[index] = p;
            }

            Vector3 center = (min + max) / 2f;
            float scale = 1f / Mathf.Abs(Mathf.Min(min.x, min.y) - Mathf.Max(max.x, max.y)) * lineSize;
            for (int i = 0; i < points.Count; i++)
                newPoints[i] = (newPoints[i] - center) * scale + offset;

            return newPoints;
        }

        private static Vector2 AxialTo2DPosition(int q, int r) {
            const float hexSize = 10f;
            float x = hexSize * Mathf.Sqrt(3f) * (q + r / 2f);
            float y = hexSize * 1.5f * r;

            return new Vector2(x, y);
        }
        
        public void DisplayLoop() {
            if (_instructionIndex >= _instructions.Count)
                _displaying = false;
            if (!_displaying)
                return;

            float cosTheta = 1 - (distancePerGlyph * distancePerGlyph) / (2 * _size * _size);
            // Clamp to [-1, 1] to avoid NaN due to floating point errors
            cosTheta = Mathf.Max(-1.0f, Mathf.Min(1.0f, cosTheta));
            float angleRadians = Mathf.Acos(cosTheta);
            float angleDegrees = angleRadians * (180.0f / Mathf.PI);

            _rotation += angleDegrees;

            Quaternion rotationQuat = Quaternion.AngleAxis(_rotation, Vector3.forward);
            _size += angleDegrees * distancePerRotation / 360f;
            
            Vector3[] points = GetLinePoints(_instructions[_instructionIndex].Path, rotationQuat, _size);
            localGlyphSpace.InstantiateGlyph(points);

            _instructionIndex++;
            
            SendCustomEventDelayedSeconds(nameof(DisplayLoop), 0.1f);
        }

        public override void OnDrop() {
            _displaying = false;
            localGlyphSpace.SendCustomNetworkEvent(NetworkEventTarget.All, nameof(localGlyphSpace.Clear));
        }
    }
}