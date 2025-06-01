using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class Glyph : UdonSharpBehaviour {
        public LineRenderer lineRenderer;
        public ParticleSystem particleSystem;
        
        public GameObject messageDisplayPrefab;

        public Gradient successColor = new Gradient();
        public Gradient failureColor = new Gradient();

        [NonSerialized] public int Status = -1;

        public Vector3[] points = Array.Empty<Vector3>();

        public void RenderPoints(Vector3[] p) {
            points = p;
            
            if (points.Length > 0)
                lineRenderer.transform.position = points[0];

            lineRenderer.SetPositions(points);
            lineRenderer.positionCount = points.Length;
            lineRenderer.SetPositions(points);
            
            Mesh bakedMesh = new Mesh();
            lineRenderer.BakeMesh(bakedMesh, true);
            ParticleSystem.ShapeModule shape = particleSystem.shape;
            shape.mesh = bakedMesh;
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
            Status = success ? 1 : 0;
            if (success)
                lineRenderer.colorGradient = successColor;
            else {
                lineRenderer.colorGradient = failureColor;
                particleSystem.Play();

                Vector3 middle = points[0];
                for (int i = 1; i < points.Length; i++)
                    middle += points[i];
                middle /= points.Length;
                
                if (string.IsNullOrWhiteSpace(msg))
                    return;
                
                GameObject message = Instantiate(messageDisplayPrefab, middle, Quaternion.identity);
                message.transform.rotation = Quaternion.LookRotation( middle - Networking.LocalPlayer.GetBonePosition(HumanBodyBones.Head), Vector3.up);
                TimedMessageDisplayer messageDisplayer = message.GetComponent<TimedMessageDisplayer>();
                messageDisplayer.Display(msg, 0.5f, 5, 2);
            }
        }
    }
}