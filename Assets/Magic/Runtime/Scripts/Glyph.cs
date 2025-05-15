using System;
using UdonSharp;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class Glyph : UdonSharpBehaviour {
        public LineRenderer lineRenderer;
        
        private Vector3[] _points = Array.Empty<Vector3>();
        public void RenderPoints(Vector3[] points) {
            _points = points;
            
            lineRenderer.SetPositions(_points);
            lineRenderer.positionCount = _points.Length;
            lineRenderer.SetPositions(_points);
        }
    }
}