using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public static class ListHelpers {
        
        // Resharper restore Unity.PerformanceCriticalContext
        public static void InsertList<T>(ref List<T> target, List<T> list, int index) {
            T[] targetArray = target.ToArray();
            T[] listArray = list.ToArray();
            int targetSize = targetArray.Length;
            int listSize = listArray.Length;
            T[] replacement = new T[targetSize + listSize];
            int remainingToCopy = targetSize - index;
            Array.Copy(targetArray, 0, replacement, 0, index);
            Array.Copy(listArray, 0, replacement, index, listSize);
            if (index < targetSize)
                Array.Copy(targetArray, index, replacement, index + listSize, remainingToCopy);

            target = new List<T>(replacement);
        }
    }
}