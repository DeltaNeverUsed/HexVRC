using System;
using UdonSharp;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class Glyph : UdonSharpBehaviour {
        public LineRenderer lineRenderer;

        public Gradient successColor = new Gradient();
        public Gradient failureColor = new Gradient();

        private Vector3[] _points = Array.Empty<Vector3>();

        public void RenderPoints(Vector3[] points) {
            _points = points;
            
            if (_points.Length > 0)
                lineRenderer.transform.position = _points[0];

            lineRenderer.SetPositions(_points);
            lineRenderer.positionCount = _points.Length;
            lineRenderer.SetPositions(_points);
        }
        
        public Texture2D CreateTextureFromGradient(Gradient gradient, int width = 64, int height = 1)
        {
            Texture2D tex = new Texture2D(width, height, TextureFormat.RGBA32, false);
            tex.wrapMode = TextureWrapMode.Repeat;
            tex.filterMode = FilterMode.Bilinear;

            for (int x = 0; x < width; x++)
            {
                Color color = gradient.Evaluate(x / (width - 1f));
                for (int y = 0; y < height; y++)
                    tex.SetPixel(x, y, color);
            }

            tex.Apply();
            return tex;
        }

        public void UpdateState(bool success, string msg) {
            lineRenderer.colorGradient = success ? successColor : failureColor;
        }
    }
}