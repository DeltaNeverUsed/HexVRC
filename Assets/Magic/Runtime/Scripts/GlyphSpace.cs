using System.Collections.Generic;
using UdonSharp;
using UnityEngine;
using VRC.SDK3.UdonNetworkCalling;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;
using Random = UnityEngine.Random;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class GlyphSpace : UdonSharpBehaviour {
        public Transform glyphContainer;
        public GameObject glyphTemplate;

        Dictionary<int, Glyph> _glyphs = new Dictionary<int, Glyph>();
        
        private Stack<int> _ids = new Stack<int>();

        public override void OnPlayerJoined(VRCPlayerApi player) {
            if (!Networking.IsOwner(gameObject) && !player.isLocal)
                return;
            if (_glyphs.Count <= 0)
                return;
            _ids.Clear();
            foreach (KeyValuePair<int, Glyph> valuePair in _glyphs)
                _ids.Push(valuePair.Key);
            LateGlyphUpdate();
        }

        public void LateGlyphUpdate() {
            if (_ids.Count <= 0)
                return;

            int glyphId = _ids.Pop();
            Glyph glyph = _glyphs[glyphId];

            SendCustomNetworkEvent(NetworkEventTarget.Others, nameof(NetworkInstantiateGlyph), glyph.points, glyphId);
            if (glyph.Status != -1)
                SendCustomNetworkEvent(NetworkEventTarget.Others, nameof(UpdateGlyphStatus), new int[] {glyphId}, new bool[] {glyph.Status == 1}, new string[] {""});
            
            SendCustomEventDelayedSeconds(nameof(LateGlyphUpdate), 0.1f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns>Glyph Index</returns>
        [NetworkCallable]
        private void NetworkInstantiateGlyph(Vector3[] points, int id) {
            if (_glyphs.ContainsKey(id))
                return;
            GameObject glyph = Instantiate(glyphTemplate, glyphContainer);
            Glyph glyphComponent = glyph.GetComponent<Glyph>();
            glyphComponent.RenderPoints(points);
            _glyphs.Add(id, glyphComponent);
        }
        
        public int InstantiateGlyph(Vector3[] points) {
            int id = Random.Range(0, int.MaxValue);
            while (_glyphs.ContainsKey(id))
                id = Random.Range(0, int.MaxValue);
            
            SendCustomNetworkEvent(NetworkEventTarget.Others, nameof(NetworkInstantiateGlyph), points, id);
            NetworkInstantiateGlyph(points, id);
            return id;
        }

        [NetworkCallable]
        public void Clear() {
            foreach (Transform child in glyphContainer.transform)
                Destroy(child.gameObject);
            _glyphs.Clear();
        }
        
        [NetworkCallable]
        public void UpdateGlyphStatus(int[] glyphId, bool[] success, string[] msg) {
            for (int i = 0; i < glyphId.Length; i++) {
                if (!_glyphs.TryGetValue(glyphId[i], out Glyph glyph))
                    return;
                glyph.UpdateState(success[i], msg[i]);
            }
        }
        
        [NetworkCallable]
        public void DestroyGlyph(int glyphId) {
            if (!_glyphs.Remove(glyphId, out Glyph glyph))
                return;
            Destroy(glyph.gameObject);
        }
    }
}