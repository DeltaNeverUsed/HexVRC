using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Editor {
    public class DocGenerator : EditorWindow {
        private string _notation;
        private int _pixelsPerUnit = 100;
        private Gradient _gradient;
        private Material _material = new Material(Shader.Find("Sprites/Default"));

        [MenuItem("Tools/Magic/Generators/Docs")]
        public static void ShowWindow() {
            GetWindow<DocGenerator>("LineRenderer Exporter");
        }

        private void OnGUI() {
            _notation = EditorGUILayout.TextField("String notation", _notation);

            _gradient = EditorGUILayout.GradientField("gradient", _gradient);
            _pixelsPerUnit = EditorGUILayout.IntField("Pixels Per Unit", _pixelsPerUnit);

            if (!GUILayout.Button("Render and Save as PNG"))
                return;

            GameObject lineRendererObject = new GameObject("TempRenderer") {
                layer = LayerMask.NameToLayer("reserved7")
            };
            LineRenderer lineRenderer = lineRendererObject.AddComponent<LineRenderer>();

            List<Vector2Int> points = new() {
                new Vector2Int(0, 0),
                new Vector2Int(0, 1),
            };
            foreach (char c in _notation) {
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

            lineRenderer.material = _material;
            lineRenderer.colorGradient = _gradient;
            lineRenderer.textureMode = LineTextureMode.Stretch;
            lineRenderer.widthMultiplier = 0.1f;
            lineRenderer.numCapVertices = 16;
            lineRenderer.numCornerVertices = 16;
            lineRenderer.positionCount = points.Count;
            for (int index = 0; index < points.Count; index++) {
                Vector2Int point = points[index];
                Vector2 transformedPoint = AxialTo2DPosition(point.x, point.y);
                lineRenderer.SetPosition(index, -new Vector3(transformedPoint.x, transformedPoint.y, 0f));
            }


            Texture2D texture = RenderLineRendererToTexture(lineRenderer, _pixelsPerUnit);
            SaveTextureAsAsset(texture,
                EditorUtility.SaveFilePanel("Save PNG", Application.dataPath, "LineRendererTexture", "png"));

            DestroyImmediate(lineRendererObject);
        }

        private Vector2 AxialTo2DPosition(int q, int r) {
            const float hexSize = 1f;
            float x = hexSize * Mathf.Sqrt(3f) * (q + r / 2f);
            float y = hexSize * 1.5f * r;

            return new Vector2(x, y);
        }

        private Texture2D RenderLineRendererToTexture(LineRenderer lr, int ppu) {
            // Get bounds
            Vector3[] positions = new Vector3[lr.positionCount];
            lr.GetPositions(positions);
            Bounds bounds = new Bounds(positions[0], Vector3.zero);
            foreach (var pos in positions) bounds.Encapsulate(pos);
            bounds.Expand(0.1f); // padding

            int width = Mathf.CeilToInt(bounds.size.x * ppu);
            int height = Mathf.CeilToInt(bounds.size.y * ppu);

            // Create temp camera
            GameObject camGo = new GameObject("TempRenderCam");
            Camera cam = camGo.AddComponent<Camera>();
            cam.clearFlags = CameraClearFlags.Color;
            cam.backgroundColor = Color.clear;
            cam.orthographic = true;
            cam.orthographicSize = bounds.size.y / 2f;
            cam.transform.position = new Vector3(bounds.center.x, bounds.center.y, -10f);
            cam.cullingMask = 1 << lr.gameObject.layer;

            // Create render texture
            RenderTexture rt = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32);
            cam.targetTexture = rt;
            cam.Render();

            // Convert to Texture2D
            RenderTexture.active = rt;
            Texture2D tex = new Texture2D(width, height, TextureFormat.ARGB32, false);
            tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);

            Color[] pixels = tex.GetPixels();
            for (int i = 0; i < pixels.Length; i++) {
                if (pixels[i].a == 0 && (pixels[i].r > 0 || pixels[i].g > 0 || pixels[i].b > 0))
                    pixels[i].a = 1; // or compute based on brightness
            }

            tex.SetPixels(pixels);
            tex.Apply();

            // Cleanup
            RenderTexture.active = null;
            cam.targetTexture = null;
            DestroyImmediate(rt);
            DestroyImmediate(camGo);

            return tex;
        }

        void SaveTextureAsAsset(Texture2D texture, string assetRelativePath) {
            // Ensure directory exists
            string fullPath = Path.Combine(Application.dataPath, assetRelativePath.Substring(7)); // Remove "Assets/"

            // Encode texture to PNG
            byte[] pngData = texture.EncodeToPNG();
            File.WriteAllBytes(fullPath, pngData);

            // Refresh the asset database
            AssetDatabase.ImportAsset(assetRelativePath, ImportAssetOptions.ForceUpdate);

            // Modify import settings
            TextureImporter importer = AssetImporter.GetAtPath(assetRelativePath) as TextureImporter;
            if (importer) {
                importer.textureType = TextureImporterType.GUI;
                importer.alphaSource = TextureImporterAlphaSource.FromInput;
                importer.alphaIsTransparency = true;
                importer.textureCompression = TextureImporterCompression.CompressedHQ;
                importer.maxTextureSize = 512;
                importer.filterMode = FilterMode.Point; // or Bilinear, Trilinear
                importer.mipmapEnabled = false;

                EditorUtility.SetDirty(importer);
                importer.SaveAndReimport();
            }

            UnityEngine.Debug.Log($"Saved and imported texture at: {assetRelativePath}");
        }
    }
}