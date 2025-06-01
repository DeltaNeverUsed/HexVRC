using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.UI {
    public class ForceUpdateTransforms : UdonSharpBehaviour {
        public RectTransform rect;

        public void OnEnable() => SendCustomEventDelayedFrames(nameof(DelayedRebuild), 1);
        public void OnDisable() => DelayedRebuild();

        public void DelayedRebuild() {
            LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
        }
    }
}