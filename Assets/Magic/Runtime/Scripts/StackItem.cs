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
        Any,
        Drone,
        Garbage
    }

    public class StackItem : IEquatable<StackItem> {
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
            if (typeof(VRCDroneApi).IsAssignableFrom(type))
                return ItemType.Drone;
            if (typeof(string).IsAssignableFrom(type))
                return ItemType.Garbage;
            if (typeof(StackItem).IsAssignableFrom(type))
                return ItemType.Any;
            return ItemType.Null;
        }

#endif
        
        public StackItem() {
            Type = ItemType.Null;
        }
        
        public StackItem(string error) {
            Type = ItemType.Garbage;
            Value = error;
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
        
        public StackItem(VRCDroneApi data) {
            Type = Utilities.IsValid(data) ? ItemType.Drone : ItemType.Null;
            Value = data;
        }

        private StackItem(StackItem data) {
            Type = Utilities.IsValid(data) ? data.Type : ItemType.Null;
            if (Type != ItemType.Null)
                Value = data.Value;
        }

        public List<Instruction> ToInstructionList() {
            List<Instruction> instructions = new List<Instruction>();
            if (Type != ItemType.List)
                return instructions;
            
            List<StackItem> list = (List<StackItem>)Value;
            foreach (StackItem value in list) {
                if (value.Type == ItemType.Instruction)
                    instructions.Add((Instruction)value.Value);
            }
            
            return instructions;
        }


        [RecursiveMethod]
        public static StackItem Deserialize(string json) {
            bool deserialize = VRCJson.TryDeserializeFromJson(json, out DataToken token);
            if (!deserialize || token.TokenType != TokenType.DataDictionary)
                return new StackItem();

            DataDictionary serializedData = token.DataDictionary;
            ItemType type = (ItemType)(int)serializedData["t"].Number;

            switch (type) {
                case ItemType.Vector:
                    DataList vectorList = serializedData["v"].DataList;
                    return new StackItem(new Vector3((float)vectorList[0].Number, (float)vectorList[1].Number,
                        (float)vectorList[2].Number));
                case ItemType.Number:
                    return new StackItem((float)serializedData["v"].Number);
                case ItemType.Player:
                    VRCPlayerApi[] players = new VRCPlayerApi[VRCPlayerApi.GetPlayerCount()];
                    VRCPlayerApi.GetPlayers(players);
                    foreach (VRCPlayerApi player in players) {
                        if (player.IsValid() &&
                            player.displayName.Equals(serializedData["v"].String, StringComparison.InvariantCultureIgnoreCase))
                            return new StackItem(player);
                    }

                    return new StackItem();
                case ItemType.List:
                    DataList serializedList = serializedData["v"].DataList;
                    List<StackItem> list = new List<StackItem>(serializedList.Count);

                    for (int i = 0; i < serializedList.Count; i++)
                        list.Add(Deserialize(serializedList[i].String));

                    return new StackItem(list);

                case ItemType.Instruction:
                    return new StackItem(new Instruction(serializedData["v"].String));
                case ItemType.Boolean:
                    return new StackItem(serializedData["v"].Boolean);
                case ItemType.Drone:
                    players = new VRCPlayerApi[VRCPlayerApi.GetPlayerCount()];
                    VRCPlayerApi.GetPlayers(players);
                    foreach (VRCPlayerApi player in players) {
                        if (player.IsValid() &&
                            player.displayName.Equals(serializedData["v"].String, StringComparison.InvariantCultureIgnoreCase))
                            return new StackItem(player.GetDrone());
                    }

                    return new StackItem();
                case ItemType.Garbage:
                    return new StackItem(serializedData["v"].ToString());
                case ItemType.Any:
                case ItemType.Null:
                default:
                    return new StackItem();
            }
        }

        [RecursiveMethod]
        public string Serialize() {
            DataDictionary dict = new DataDictionary();
            dict["t"] = new DataToken((int)Type);

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
                    dict["v"] = new DataToken((float)Value);
                    break;
                case ItemType.Player:
                    VRCPlayerApi player = (VRCPlayerApi)Value;
                    if (!Utilities.IsValid(player) || !player.IsValid())
                        dict["v"] = new DataToken("");
                    else
                        dict["v"] = new DataToken(player.displayName);
                    break;
                case ItemType.List:
                    List<StackItem> list = (List<StackItem>)Value;
                    tempList = new DataList();

                    foreach (StackItem item in list)
                        tempList.Add(item.Serialize());

                    dict["v"] = tempList;
                    break;

                case ItemType.Instruction:
                    dict["v"] = new DataToken(((Instruction)Value).Path);
                    break;
                case ItemType.Boolean:
                    dict["v"] = new DataToken((bool)Value);
                    break;
                case ItemType.Drone:
                    VRCDroneApi drone = (VRCDroneApi)Value;
                    if (!Utilities.IsValid(drone)) {
                        dict["t"] = new DataToken((int)ItemType.Null);
                        break;
                    }

                    player = drone.GetPlayer();
                    
                    if (!Utilities.IsValid(player) || !player.IsValid())
                        dict["v"] = new DataToken("");
                    else
                        dict["v"] = new DataToken(player.displayName);
                    break;
                case ItemType.Garbage:
                    dict["v"] = (string)Value;
                    break;
                case ItemType.Any:
                case ItemType.Null:
                default:
                    dict["t"] = new DataToken((int)ItemType.Null);
                    break;
            }

            return VRCJson.TrySerializeToJson(dict, JsonExportType.Minify, out DataToken token)
                ? token.String
                : token.ToString();
        }

        [RecursiveMethod]
        public void ToString(StringBuilder sb) {
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
                        list[i].ToString(sb);
                    }

                    sb.Append(']');
                    break;
                case ItemType.Boolean:
                    sb.Append(((bool)Value).ToString());
                    break;
                case ItemType.Any:
                    sb.Append("This value should not be possible to get. please report this to me @deltaneverused");
                    break;
                case ItemType.Drone:
                    sb.Append(Value.ToString());
                    break;
                case ItemType.Garbage:
                    sb.Append("Garbage (");
                    sb.Append(Value.ToString());
                    sb.Append(")");
                    break;
                default:
                    sb.Append("Invalid item type. please report this to me @deltaneverused");
                    break;
            }
        }

        public bool Equals(StackItem other) {
            if (!Utilities.IsValid(other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Type == other.Type && Equals(Value, other.Value);
        }

        public override bool Equals(object obj) {
            if (!Utilities.IsValid(obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((StackItem)obj);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)Type, Value);
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            ToString(sb);

            return sb.ToString();
        }

        public StackItem Clone() {
            if (Type != ItemType.List)
                return this;
            
            // if it's a list we do a shallow clone of the whole list
            // would have been nice if we could do a deep clone, but that's not really possibly in a performant manner
            List<StackItem> currentList = (List<StackItem>)Value;
            StackItem[] newArray = new StackItem[currentList.Count];
            Array.Copy(currentList.ToArray(), newArray, currentList.Count);
            return new StackItem(new List<StackItem>(newArray));

        }
    }
}