using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.UI {
    public class ForceUpdateTransforms : UdonSharpBehaviour {
        public RectTransform rect;

        public void OnEnable() => LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
        public void OnDisable() => LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
    }
}