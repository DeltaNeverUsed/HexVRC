using System.Collections.Generic;
using UdonSharp;
using UnityEngine;
using VRC.SDK3.UdonNetworkCalling;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class GlyphSpace : UdonSharpBehaviour {
        public Transform glyphContainer;
        public GameObject glyphTemplate;

        List<Glyph> _glyphs = new List<Glyph>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns>Glyph Index</returns>
        [NetworkCallable]
        public int InstantiateGlyph(Vector3[] points) {
            GameObject glyph = Instantiate(glyphTemplate, glyphContainer);
            Glyph glyphComponent = glyph.GetComponent<Glyph>();
            glyphComponent.RenderPoints(points);
            _glyphs.Add(glyphComponent);

            return _glyphs.Count - 1;
        }

        [NetworkCallable]
        public void Clear() {
            foreach (Transform child in glyphContainer.transform)
                Destroy(child.gameObject);
            _glyphs.Clear();
        }
    }
}