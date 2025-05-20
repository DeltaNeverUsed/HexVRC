using System;
using System.Collections.Generic;
using System.Text;
using UdonSharp;
using VRC.SDKBase;
using UnityEngine;
using VRC.SDK3.Data;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public enum ItemType {
        Null,
        Vector,
        Number,
        Boolean,
        Player,
        Instruction,
        List,
    }

    public class StackItem {
        public readonly ItemType Type;
        public readonly object Value;
        
        #if !UDONSHARP_COMPILER

        public static ItemType GetItemType(Type type) {
            if (type == null)
                return ItemType.Null;
            if (typeof(Vector3).IsAssignableFrom(type))
                return ItemType.Vector;
            if (typeof(float).IsAssignableFrom(type))
                return ItemType.Number;
            if (typeof(bool).IsAssignableFrom(type))
                return ItemType.Boolean;
            if (typeof(VRCPlayerApi).IsAssignableFrom(type))
                return ItemType.Player;
            if (typeof(Instruction).IsAssignableFrom(type))
                return ItemType.Instruction;
            if (typeof(List<StackItem>).IsAssignableFrom(type))
                return ItemType.List;
            return ItemType.Null;
        }
            
        #endif

        public StackItem() {
            Type = ItemType.Null;
        }

        public StackItem(Vector3 data) {
            Type = Utilities.IsValid(data) ? ItemType.Vector : ItemType.Null;
            Value = data;
        }

        public StackItem(float data) {
            Type = Utilities.IsValid(data) ? ItemType.Number : ItemType.Null;
            Value = data;
        }
        
        public StackItem(bool data) {
            Type = Utilities.IsValid(data) ? ItemType.Boolean : ItemType.Null;
            Value = data;
        }

        public StackItem(VRCPlayerApi data) {
            Type = Utilities.IsValid(data) ? ItemType.Player : ItemType.Null;
            Value = data;
        }

        public StackItem(List<StackItem> data) {
            Type = Utilities.IsValid(data) ? ItemType.List : ItemType.Null;
            Value = data;
        }

        public StackItem(Instruction data) {
            Type = Utilities.IsValid(data) ? ItemType.Instruction : ItemType.Null;
            Value = data;
        }
        private StackItem(StackItem data) {
            Type = Utilities.IsValid(data) ? data.Type : ItemType.Null;
            if (Type != ItemType.Null)
                Value = data.Value;
        }

        public StackItem Copy() {
            return new StackItem(this);
        }
        

        [RecursiveMethod]
        public static StackItem Deserialize(DataDictionary serializedData) {
            ItemType type = (ItemType)(int)serializedData["t"].Number;

            switch (type) {
                case ItemType.Vector:
                    DataList vectorList = serializedData["t"].DataList;
                    return new StackItem(new Vector3((float)vectorList[0].Number, (float)vectorList[1].Number,
                        (float)vectorList[2].Number));
                case ItemType.Number:
                    return new StackItem((float)serializedData["t"].Number);
                case ItemType.Player:
                    VRCPlayerApi player = VRCPlayerApi.GetPlayerById((int)serializedData["t"].Number);
                    return !Utilities.IsValid(player) ? new StackItem() : new StackItem(player);
                case ItemType.List:
                    DataList serializedList = serializedData["t"].DataList;
                    List<StackItem> list = new List<StackItem>(serializedList.Count);

                    for (int i = 0; i < serializedList.Count; i++)
                        list.Add(Deserialize(serializedList[i].DataDictionary));

                    return new StackItem(list);

                case ItemType.Instruction:
                    return new StackItem(new Instruction(serializedData["t"].String));
                case ItemType.Boolean:
                    return new StackItem(serializedData["t"].Boolean);
                case ItemType.Null:
                default:
                    return new StackItem();
            }
        }

        [RecursiveMethod]
        public string Serialize() {
            DataDictionary dict = new DataDictionary();
            dict["t"] = (int)Type;

            switch (Type) {
                case ItemType.Vector:
                    Vector3 tempVector = (Vector3)Value;
                    DataList tempList = new DataList();
                    tempList.Add(tempVector.x);
                    tempList.Add(tempVector.y);
                    tempList.Add(tempVector.z);
                    dict["v"] = tempList;
                    break;
                case ItemType.Number:
                    dict["v"] = (float)Value;
                    break;
                case ItemType.Player:
                    VRCPlayerApi player = (VRCPlayerApi)Value;
                    if (!Utilities.IsValid(player) || !player.IsValid())
                        dict["v"] = -1;
                    else
                        dict["v"] = player.playerId;
                    break;
                case ItemType.List:
                    List<StackItem> list = (List<StackItem>)Value;
                    tempList = new DataList();

                    foreach (StackItem item in list)
                        tempList.Add(item.Serialize());

                    dict["v"] = tempList;
                    break;

                case ItemType.Instruction:
                    dict["v"] = ((Instruction)Value).Path;
                    break;
                case ItemType.Boolean:
                    dict["v"] = (bool)Value;
                    break;
                case ItemType.Null:
                default:
                    dict["t"] = (int)ItemType.Null;
                    break;
            }

            return VRCJson.TrySerializeToJson(dict, JsonExportType.Minify, out DataToken token)
                ? token.String
                : token.ToString();
        }

        [RecursiveMethod]
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            
            UnityEngine.Debug.Log($"Type is null? {!Utilities.IsValid(Type)}");
            UnityEngine.Debug.Log($"Type is {Type}");
            
            UnityEngine.Debug.Log($"Value is null? {!Utilities.IsValid(Value)}");
            UnityEngine.Debug.Log($"Value is {Value}");

            switch (Type) {
                case ItemType.Null:
                    sb.Append("Null");
                    break;
                case ItemType.Vector:
                    Vector3 tempVector = (Vector3)Value;
                    sb.Append('(');
                    sb.Append(tempVector.x);
                    sb.Append(", ");
                    sb.Append(tempVector.y);
                    sb.Append(", ");
                    sb.Append(tempVector.z);
                    sb.Append(')');
                    break;
                case ItemType.Number:
                    sb.Append((float)Value);
                    break;
                case ItemType.Player:
                    if (!Utilities.IsValid(Value)) {
                        sb.Append("Invalid Player");
                        break;
                    }
                    VRCPlayerApi player = (VRCPlayerApi)Value;
                    if (!player.IsValid())
                        sb.Append("Invalid Player");
                    else {
                        sb.Append(player.displayName);
                        sb.Append(", ");
                        sb.Append(player.playerId.ToString());
                    }

                    break;
                case ItemType.Instruction:
                    sb.Append(((Instruction)Value).Path);
                    break;
                case ItemType.List:
                    List<StackItem> list = (List<StackItem>)Value;
                    sb.Append('[');
                    for (int i = 0; i < list.Count; i++) {
                        if (i > 0)
                            sb.Append(", ");
                        sb.Append(list[i].ToString());
                    }
                    sb.Append(']');
                    break;
                case ItemType.Boolean:
                    sb.Append(((bool)Value).ToString());
                    break;
                default:
                    sb.Append("Invalid item type");
                    break;
            }

            return sb.ToString();
        }
    }
}