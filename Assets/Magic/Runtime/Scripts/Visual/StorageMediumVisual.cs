using System;
using BefuddledLabs.Magic.Debug.VUdon;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Visual {
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    public class StorageMediumVisual : UdonSharpBehaviour {
        public Renderer visual;
        public int materialIndex;

        private StorageMedium _storageMedium;
        private Material _material;

        private Color _onColor;
        private Color _offColor;

        private bool _animating;
        private Color _targetColor;

        private int _emissionColor;
        public void Start() {
            _emissionColor = VRCShader.PropertyToID("_EmissionColor");
            
            _storageMedium = GetComponent<StorageMedium>();
            _material = visual.materials[materialIndex];

            _onColor = _material.GetColor(_emissionColor);
            _offColor = _onColor / 10;
            
            sm_DataUpdated();
        }

        public void Animate() {
            Color currentColor = _material.GetColor(_emissionColor);
            _material.SetColor(_emissionColor, Color.Lerp(currentColor, _targetColor, 1 * Time.deltaTime));
            

            _animating = Mathf.Abs(currentColor.grayscale - _targetColor.grayscale) > 0.01f;
            if (_animating)
                SendCustomEventDelayedFrames(nameof(Animate), 1);
        }

        public void sm_DataUpdated() {
            bool isNull = _storageMedium.Read().Type == ItemType.Null;
            _targetColor = isNull ? _offColor : _onColor;

            if (!_animating) {
                _animating = true;
                Animate();
            }
        }
    }
}