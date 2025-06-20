using System;
using System.Collections.Generic;
using System.Diagnostics;
using BefuddledLabs.Magic.Debug.VUdon;
using UdonSharp;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class CompressorData : UdonSharpBehaviour {
        [NonSerialized] public HuffmanNode Root;
        [NonSerialized] public Dictionary<byte, Code> Codes;

        [Header("Double delta encoded")]
        public string sampleData = "";

        private byte[] _data;
        private Stopwatch _timer;

        private void Start() {
            _timer = Stopwatch.StartNew();
            _data = Convert.FromBase64String(sampleData);
            _timer.Stop();
            
            SendCustomEventDelayedFrames(nameof(CreateTree), 1);
            SendCustomEventDelayedFrames(nameof(CreateCodes), 2);
        }

        public void CreateTree() {
            _timer.Start();
            Root = Compressor.CreateHuffmanTree(_data);
            _timer.Stop();
            _data = new byte[0];
        }

        public void CreateCodes() {
            _timer.Start();
            Codes = Compressor.GenerateHuffmanCodes(Root);
            _timer.Stop();
            this.Log($"Compressor Data took: {_timer.Elapsed.TotalMilliseconds} ms");
        }

        public static CompressorData Get() => GameObject.Find("CompressorData").GetComponent<CompressorData>();
    }
}