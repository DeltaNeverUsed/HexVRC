#if !UDONSHARP_COMPILER && UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UdonSharpEditor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.UI {
    [CustomEditor(typeof(UIGenerator))]
    public class UIGeneratorInspector : Editor {
        private Dictionary<string, List<Type>> _patterns = new Dictionary<string, List<Type>>();

        private static string GetPath(Type instructionType) {
            return instructionType.GetField("Path", BindingFlags.Static | BindingFlags.Public)
                ?.GetRawConstantValue().ToString();
        }

        public static List<Vector3> ScaleToFitXY(List<Vector3> points) {
            if (points.Count == 0) return new List<Vector3>();

            // Step 1: Get bounds
            float minX = float.MaxValue, maxX = float.MinValue;
            float minY = float.MaxValue, maxY = float.MinValue;

            foreach (Vector3 p in points) {
                if (p.x < minX) minX = p.x;
                if (p.x > maxX) maxX = p.x;
                if (p.y < minY) minY = p.y;
                if (p.y > maxY) maxY = p.y;
            }

            Vector2 center = new Vector2((minX + maxX) / 2f, (minY + maxY) / 2f);
            float width = maxX - minX;
            float height = maxY - minY;

            // Step 2: Compute scale factor to fit in -40 to +40
            float maxOriginalSize = Mathf.Max(width, height);
            float scaleFactor = 95f / maxOriginalSize; // since -40 to 40 is 80 units

            // Step 3: Scale and translate

            return (from p in points select new Vector2(p.x, p.y) - center into shifted select shifted * scaleFactor into scaled select new Vector3(scaled.x, scaled.y, 0)).ToList();
        }

        private static Vector3[] GetLinePoints(string notation) {
            List<Vector2Int> points = new() {
                new Vector2Int(0, 0),
                new Vector2Int(0, 1),
            };
            foreach (char c in notation) {
                switch (c) {
                    case 'w':
                        points.Add(Wand.GetNextAxial(points[^2], points[^1],
                            RotationDirection.Straight));
                        break;
                    case 'q':
                        points.Add(Wand.GetNextAxial(points[^2], points[^1],
                            RotationDirection.Left));
                        break;
                    case 'a':
                        points.Add(Wand.GetNextAxial(points[^2], points[^1],
                            RotationDirection.HardLeft));
                        break;
                    case 'e':
                        points.Add(Wand.GetNextAxial(points[^2], points[^1],
                            RotationDirection.Right));
                        break;
                    case 'd':
                        points.Add(Wand.GetNextAxial(points[^2], points[^1],
                            RotationDirection.HardRight));
                        break;
                }
            }

            Vector3[] newPoints = new Vector3[points.Count];
            for (int index = 0; index < points.Count; index++) {
                Vector2Int point = points[index];
                Vector2 transformedPoint = AxialTo2DPosition(point.x, point.y);
                newPoints[index] = -new Vector3(transformedPoint.x, transformedPoint.y, 0f);
            }

            return newPoints;
        }

        private static Vector2 AxialTo2DPosition(int q, int r) {
            const float hexSize = 10f;
            float x = hexSize * Mathf.Sqrt(3f) * (q + r / 2f);
            float y = hexSize * 1.5f * r;

            return new Vector2(x, y);
        }

        public override void OnInspectorGUI() {
            DrawDefaultInspector();

            UIGenerator data = target as UIGenerator;
            if (GUILayout.Button("Clear"))
                foreach (Transform children in data.groupParent)
                    DestroyImmediate(children.gameObject);

            if (GUILayout.Button("Generate Doc UI")) {
                if (!data) return;

                foreach (Transform children in data.groupParent)
                    DestroyImmediate(children.gameObject);

                _patterns = new Dictionary<string, List<Type>>();
                List<Type> classes = Assembly.GetAssembly(typeof(PlayerVM))
                    .GetTypes()
                    .Where(t => t.IsClass && t.Namespace != null &&
                                t.Namespace.StartsWith("BefuddledLabs.Magic.Instructions")).ToList();
                foreach (Type t in classes) {
                    if (t.Namespace != null) {
                        string group = t.Namespace.Replace("BefuddledLabs.Magic.Instructions.", "")
                            .Replace("BefuddledLabs.Magic.Instructions", "");
                        if (!_patterns.ContainsKey(group)) {
                            _patterns[group] = new List<Type>();
                        }

                        _patterns[group].Add(t);
                        UnityEngine.Debug.Log($"{group}, {t.FullName}");
                    }
                }

                foreach (KeyValuePair<string, List<Type>> p in _patterns) {
                    GameObject group = Instantiate(data.groupPrefab, data.groupParent);
                    group.GetComponentInChildren<Text>().text = p.Key;

                    Transform content = group.transform.Find("Content");
                    foreach (Type patternClass in p.Value) {
                        GameObject pattern = Instantiate(data.patternPrefab, content);

                        TextMeshProUGUI name = pattern.transform.Find("PatternInfo/PatternName")
                            .GetComponent<TextMeshProUGUI>();
                        TextMeshProUGUI notation = pattern.transform.Find("PatternInfo/PatternNotation")
                            .GetComponent<TextMeshProUGUI>();
                        TextMeshProUGUI description = pattern.transform.Find("PatternDescription")
                            .GetComponent<TextMeshProUGUI>();

                        LineRenderer line = pattern.GetComponentInChildren<LineRenderer>();
                        notation.text = GetPath(patternClass);
                        Vector3[] points = GetLinePoints(notation.text);

                        line.positionCount = points.Length;
                        line.SetPositions(ScaleToFitXY(points.ToList()).ToArray());

                        name.text = patternClass.Name;
                    }
                }
            }

            if (GUILayout.Button("Assign")) {
                RectTransform rectTransform = data.groupParent.GetComponent<RectTransform>();
                ForceUpdateTransforms[] componentsToAssign =
                    data.groupParent.GetComponentsInChildren<ForceUpdateTransforms>(true);
                foreach (ForceUpdateTransforms component in componentsToAssign) {
                    component.rect = rectTransform;
                    UdonSharpEditorUtility.CopyProxyToUdon(component);
                    EditorUtility.SetDirty(component);
                }
            }
        }
    }

    public class UIGenerator : MonoBehaviour {
        public GameObject groupPrefab;
        public GameObject patternPrefab;

        public Transform groupParent;
    }
}

#endif