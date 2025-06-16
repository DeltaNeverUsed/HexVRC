#if !UDONSHARP_COMPILER && UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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

        private static string GetAssetPathFromPath(string path) {
            return "Assets/Magic/Runtime/GeneratedDocTextures/" + path + ".png";
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
            float scaleFactor = 1f / maxOriginalSize; // since -40 to 40 is 80 units

            // Step 3: Scale and translate

            return (from p in points
                select new Vector2(p.x, p.y) - center
                into shifted
                select shifted * scaleFactor
                into scaled
                select new Vector3(scaled.x, scaled.y, 0)).ToList();
        }

        private static Vector3[] GetLinePoints(string notation) {
            List<Vector2Int> points = new() {
                new Vector2Int(0, 0),
                new Vector2Int(-1, 0),
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
                newPoints[index] = new Vector3(-transformedPoint.x, transformedPoint.y, 0f);
            }

            return newPoints;
        }

        private static Vector2 AxialTo2DPosition(int q, int r) {
            const float hexSize = 10f;
            float x = hexSize * Mathf.Sqrt(3f) * (q + r / 2f);
            float y = hexSize * 1.5f * r;

            return new Vector2(x, y);
        }

        private void GeneratePathImages(string[] paths) {
            GameObject lineRendererObject = new GameObject("TempRenderer") {
                layer = LayerMask.NameToLayer("reserved7")
            };
            LineRenderer lineRenderer = lineRendererObject.AddComponent<LineRenderer>();

            lineRenderer.material = ((UIGenerator)target).lineMaterial;
            lineRenderer.colorGradient = ((UIGenerator)target).lineGradient;
            lineRenderer.textureMode = LineTextureMode.Stretch;
            lineRenderer.widthMultiplier = 0.01f;
            lineRenderer.numCapVertices = 16;
            lineRenderer.numCornerVertices = 16;

            GameObject camGo = new GameObject("TempRenderCam");
            Camera cam = camGo.AddComponent<Camera>();
            cam.clearFlags = CameraClearFlags.Color;
            cam.backgroundColor = Color.clear;
            cam.orthographic = true;
            cam.orthographicSize = 0.52f;
            cam.transform.position = new Vector3(0, 0, -10);
            cam.cullingMask = 1 << lineRenderer.gameObject.layer;

            const int res = 256;

            RenderTexture rt = new RenderTexture(res, res, 24, RenderTextureFormat.ARGB32);
            rt.antiAliasing = 16;
            cam.targetTexture = rt;
            RenderTexture.active = rt;

            List<string> filesToSetImportsFor = new List<string>();

            char[] validCharacters = { 'a', 'q', 'w', 'e', 'd' };

            foreach (string path in paths) {
                if (path.Count(c => validCharacters.Contains(c)) != path.Length)
                    continue; // invalid path
                
                Vector3[] points = GetLinePoints(path);

                lineRenderer.positionCount = points.Length;
                lineRenderer.SetPositions(ScaleToFitXY(points.ToList()).ToArray());

                cam.Render();

                Texture2D tex = new Texture2D(res, res, TextureFormat.ARGB32, false);
                tex.ReadPixels(new Rect(0, 0, res, res), 0, 0);

                Color[] pixels = tex.GetPixels();
                for (int i = 0; i < pixels.Length; i++) {
                    if (pixels[i].a == 0 && (pixels[i].r > 0 || pixels[i].g > 0 || pixels[i].b > 0))
                        pixels[i].a = 1; // or compute based on brightness
                }

                tex.SetPixels(pixels);
                tex.Apply();

                string relativePath = "/Magic/Runtime/GeneratedDocTextures/";
                string fullPath = Application.dataPath + relativePath;
                string fullFilePath = fullPath + path + ".png";

                if (!Directory.Exists(fullPath))
                    Directory.CreateDirectory(fullPath);

                byte[] pngData = tex.EncodeToPNG();
                File.WriteAllBytes(fullFilePath, pngData);

                filesToSetImportsFor.Add(GetAssetPathFromPath(path));
            }

            AssetDatabase.Refresh();

            foreach (TextureImporter importer in filesToSetImportsFor.Select(file => AssetImporter.GetAtPath(file) as TextureImporter).Where(importer => importer)) {
                importer.textureType = TextureImporterType.Sprite;
                importer.alphaSource = TextureImporterAlphaSource.FromInput;
                importer.alphaIsTransparency = true;
                importer.textureCompression = TextureImporterCompression.Compressed;
                importer.crunchedCompression = true;
                importer.maxTextureSize = 512;
                importer.filterMode = FilterMode.Bilinear;
                importer.mipmapEnabled = false;

                EditorUtility.SetDirty(importer);
                importer.SaveAndReimport();
            }

            RenderTexture.active = null;
            cam.targetTexture = null;
            DestroyImmediate(rt);
            DestroyImmediate(camGo);
            DestroyImmediate(lineRendererObject);
        }

        public override void OnInspectorGUI() {
            DrawDefaultInspector();

            UIGenerator data = target as UIGenerator;
            if (GUILayout.Button("Clear")) {
                int nbChildren = data.groupParent.childCount;
                for (int i = nbChildren - 1; i >= 0; i--)
                    DestroyImmediate(data.groupParent.GetChild(i).gameObject);
            }

            if (GUILayout.Button("Generate Images")) {
                string[] paths = Assembly.GetAssembly(typeof(PlayerVM))
                    .GetTypes()
                    .Where(t => t.IsClass && t.Namespace != null &&
                                t.Namespace.StartsWith("BefuddledLabs.Magic.Instructions"))
                    .Select(c => GetPath(c).Replace("*", "")).Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();
                GeneratePathImages(paths);
            }

            if (GUILayout.Button("Generate Doc UI")) {
                if (!data) return;

                int nbChildren = data.groupParent.childCount;
                for (int i = nbChildren - 1; i >= 0; i--)
                    DestroyImmediate(data.groupParent.GetChild(i).gameObject);

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
                    group.name = p.Key;

                    Transform content = group.transform.Find("Content");
                    foreach (Type patternClass in p.Value) {
                        GameObject pattern = Instantiate(data.patternPrefab, content);
                        pattern.name = patternClass.Name;

                        
                        Image pathImage = pattern.transform.Find("PatternInfo/PathVisual")
                            .GetComponent<Image>();
                        TextMeshProUGUI name = pattern.transform.Find("PatternInfo/PatternName")
                            .GetComponent<TextMeshProUGUI>();
                        TextMeshProUGUI notation = pattern.transform.Find("PatternInfo/PatternNotation")
                            .GetComponent<TextMeshProUGUI>();
                        TextMeshProUGUI description = pattern.transform.Find("PatternDescription")
                            .GetComponent<TextMeshProUGUI>();

                        StringBuilder descriptionBuilder = new StringBuilder();
                        descriptionBuilder.Append(patternClass
                            .GetField("Description", BindingFlags.Static | BindingFlags.Public)
                            ?.GetRawConstantValue().ToString());

                        foreach (MethodInfo method in patternClass.GetMethods()
                                     .Where(m => string.Equals(m.Name, "Execute", StringComparison.OrdinalIgnoreCase))
                                     .ToList()) {
                            descriptionBuilder.AppendLine("\n");

                            descriptionBuilder.Append("Inputs: ");
                            for (int i = 1; i < method.GetParameters().Length; i++) {
                                if (i != 1)
                                    descriptionBuilder.Append(", ");
                                descriptionBuilder.Append("<color=#f097eb>");
                                descriptionBuilder.Append(Enum.GetName(typeof(ItemType),
                                    StackItem.GetItemType(method.GetParameters()[i].ParameterType)));
                                descriptionBuilder.Append("</color>");
                            }
                        }
                        
                        notation.text = GetPath(patternClass);

                        descriptionBuilder.Append("\nOutputs: ");
                        descriptionBuilder.AppendLine(patternClass
                            .GetField("Output", BindingFlags.Static | BindingFlags.Public)
                            ?.GetRawConstantValue().ToString());


                        description.text = descriptionBuilder.ToString();

                        Sprite pathSprite = AssetDatabase.LoadAssetAtPath<Sprite>(GetAssetPathFromPath(notation.text.Replace("*", "")));
                        if (pathSprite)
                            pathImage.sprite = pathSprite;

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

        public Material lineMaterial;
        public Gradient lineGradient;
    }
}

#endif