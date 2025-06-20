using System;
using System.Collections.Generic;
using UdonSharp;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class HuffmanNode {
        public HuffmanNode() { }

        public HuffmanNode(byte symbol, int frequency) {
            Symbol = symbol;
            Frequency = frequency;
        }

        public HuffmanNode(int frequency, HuffmanNode left, HuffmanNode right) : this() {
            Frequency = frequency;
            Left = left;
            Right = right;
        }

        public byte Symbol { get; set; }
        public int Frequency { get; set; }
        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set; }

        public int CompareTo(HuffmanNode other) {
            if (ReferenceEquals(this, other)) return 0;
            return Utilities.IsValid(other) ? Frequency.CompareTo(other.Frequency) : 1;
        }
    }

    public class Code {
        public int Length;
        public uint HuffmanCode;

        public Code(uint huffmanCode, int length) {
            HuffmanCode = huffmanCode;
            Length = length;
        }
    }

    internal class PriorityQueue {
        private List<HuffmanNode> list = new List<HuffmanNode>();
        public int Count => list.Count;

        public void Enqueue(HuffmanNode item) {
            list.Add(item);
            int i = list.Count - 1;
            while (i > 0) {
                int parent = (i - 1) / 2;
                if (list[i].CompareTo(list[parent]) >= 0)
                    break;
                Swap(i, parent);
                i = parent;
            }
        }

        public HuffmanNode Dequeue() {
            HuffmanNode front = list[0];
            list[0] = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            int current = 0;
            while (true) {
                int left = 2 * current + 1;
                int right = 2 * current + 2;
                int smallest = current;
                if (left < list.Count && list[left].CompareTo(list[smallest]) < 0)
                    smallest = left;
                if (right < list.Count && list[right].CompareTo(list[smallest]) < 0)
                    smallest = right;
                if (smallest == current)
                    break;
                Swap(current, smallest);
                current = smallest;
            }

            return front;
        }

        private void Swap(int i, int j) {
            HuffmanNode temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    public static class Compressor {
        public static void DeltaEncode(ref byte[] data) {
            int len = data.Length;
            byte last = 0;
            for (int i = 0; i < len; i++) {
                byte current = data[i];
                data[i] = Convert.ToByte((current - last) & 0xFF);
                last = current;
            }
        }

        public static void DeltaDecode(ref byte[] data) {
            int len = data.Length;
            byte last = 0;
            for (int i = 0; i < len; i++) {
                byte current = data[i];
                current = Convert.ToByte((current + last) & 0xFF);
                last = current;
                data[i] = current;
            }
        }

        public static HuffmanNode CreateHuffmanTree(byte[] data) {
            Dictionary<byte, int> frequencies = new Dictionary<byte, int>();
            foreach (byte value in data) {
                if (frequencies.TryGetValue(value, out int token))
                    frequencies[value] = token + 1;
                else
                    frequencies[value] = 1;
            }

            for (int i = 0; i < 256; i++) {
                byte b = (byte)i;
                if (frequencies.TryGetValue(b, out int token))
                    frequencies[b] = token + 1;
                else
                    frequencies[b] = 1;
            }

            PriorityQueue priorityQueue = new PriorityQueue();
            foreach (KeyValuePair<byte, int> kvp in frequencies) {
                priorityQueue.Enqueue(new HuffmanNode(kvp.Key, kvp.Value));
            }

            while (priorityQueue.Count > 1) {
                HuffmanNode left = priorityQueue.Dequeue();
                HuffmanNode right = priorityQueue.Dequeue();
                HuffmanNode parent =
                    new HuffmanNode(frequency: left.Frequency + right.Frequency, left: left, right: right);
                priorityQueue.Enqueue(parent);
            }

            HuffmanNode root = priorityQueue.Dequeue();
            return root;
            //Dictionary<byte, Code> codes = GenerateHuffmanCodes(root);
        }

        public static byte[] HuffmanEncode(byte[] data, Dictionary<byte, Code> codes) {
            List<byte> compressed = new List<byte>();
            compressed.Add(0);
            byte currentByte = 0;
            int bitsLeft = 7;
            foreach (byte c in data) {
                Code code = codes[c];
                int length = code.Length;
                uint huffmanCode = code.HuffmanCode;
                for (int i = length - 1; i >= 0; i--) {
                    currentByte |= (byte)(((huffmanCode >> i) & 0b1) << bitsLeft);
                    bitsLeft--;

                    if (bitsLeft == -1) {
                        compressed.Add(currentByte);
                        currentByte = 0;
                        bitsLeft = 7;
                    }
                }
            }

            if (bitsLeft > 0)
                compressed.Add(currentByte);
            compressed[0] = (byte)bitsLeft;

            return compressed.ToArray();
        }

        public static byte[] HuffmanDecode(byte[] compressed, HuffmanNode root) {
            List<byte> decoded = new List<byte>();

            int bitsLeft = compressed[0]; // bits *unused* in last byte
            int totalBits = (compressed.Length - 1) * 8 - bitsLeft;

            HuffmanNode current = root;
            int bitIndex = 0;

            for (int i = 1; i < compressed.Length; i++) {
                byte b = compressed[i];
                for (int bit = 7; bit >= 0; bit--) {
                    if (bitIndex >= totalBits)
                        break;

                    int bitVal = (b >> bit) & 1;

                    current = bitVal == 0 ? current.Left : current.Right;

                    decoded.Add(current.Symbol);
                    current = root;

                    bitIndex++;
                }
            }

            return decoded.ToArray();
        }

        public static Dictionary<byte, Code> GenerateHuffmanCodes(HuffmanNode root) {
            Dictionary<byte, Code> codes = new Dictionary<byte, Code>();
            GenerateHuffmanCodes(root, new Code(0, 0), codes);
            return codes;
        }

        [RecursiveMethod]
        private static void GenerateHuffmanCodes(HuffmanNode node, Code code, Dictionary<byte, Code> codes) {
            while (true) {
                if (!Utilities.IsValid(node))
                    return;

                codes[node.Symbol] = code;

                GenerateHuffmanCodes(node.Left, new Code((code.HuffmanCode << 1), code.Length + 1), codes);
                node = node.Right;
                code = new Code((code.HuffmanCode << 1) | 0b1, code.Length + 1);
            }
        }
    }
}