using System;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class StackItem {
        public readonly Type ItemType;
        public readonly object Item;

        public StackItem(Type itemType, object item) {
            ItemType = itemType;
            Item = item;
        }

        public override string ToString() {
            return $"Type: {ItemType.ToString()}, Item: {Item.ToString()}";
        }

        public static StackItem CreateStackItem<T>(T item) => new StackItem(typeof(T), item);
        public static StackItem CreateNullStackItem() => new StackItem(null, null);
    }
}