using System;
using System.Collections.Generic;
using System.Text;
using UdonSharp;
using VRC.SDKBase;
using UnityEngine;
using VRC.SDK3.Data;

/*
 * serialized format
 * [
 *  type, 1b
 *  size, 4b only if size isn't known by type
 *  serialized_data
 * ]
 */


// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public enum ItemType : byte {
        Null,
        Vector,
        Number,
        Boolean,
        Player,
        Instruction,
        List,
        Any,
        Drone,
        Garbage,
        Entity
    }

    public enum ItemTypeSizes {
        Null = 0,
        Vector = sizeof(float) * 3,
        Number = sizeof(float),
        Boolean = 1,
        Player = -1,
        Instruction = -1,
        List = -1,
        Any = -1,
        Drone = -1,
        Garbage = 0,
        Entity = sizeof(int)
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
            if (typeof(Entity).IsAssignableFrom(type))
                return ItemType.Entity;
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

        public StackItem(Entity data) {
            Type = Utilities.IsValid(data) ? ItemType.Entity : ItemType.Null;
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
        public static StackItem Deserialize(byte[] data) {
            int dataSize = data.Length;
            if (dataSize < 1)
                return new StackItem();
            
            ItemType deserializedType = (ItemType)data[0];

            switch (deserializedType) {
                case ItemType.Vector:
                    Vector3[] tempVectorArray = new Vector3[1];
                    Buffer.BlockCopy(data, 1, tempVectorArray, 0, (int)ItemTypeSizes.Vector);
                    return new StackItem(tempVectorArray[0]);
                case ItemType.Number:
                    return new StackItem(BitConverter.ToSingle(data, 1));
                case ItemType.Player:
                    string playerName = Encoding.UTF8.GetString(data, 5, data.Length - 5);
                    VRCPlayerApi[] players = new VRCPlayerApi[VRCPlayerApi.GetPlayerCount()];
                    VRCPlayerApi.GetPlayers(players);
                    foreach (VRCPlayerApi player in players) {
                        if (player.IsValid() &&
                            player.displayName.Equals(playerName,
                                StringComparison.InvariantCultureIgnoreCase))
                            return new StackItem(player);
                    }

                    return new StackItem();
                case ItemType.List:
                    int size = BitConverter.ToInt32(data, 1);
                    StackItem[] arr = new StackItem[size];

                    int currentOffset = 5;
                    for (int i = 0; i < size; i++) {
                        int itemByteSize = BitConverter.ToInt32(data, currentOffset);
                        byte[] subArray = new byte[itemByteSize];
                        
                        Buffer.BlockCopy(data, currentOffset + sizeof(int), subArray, 0, subArray.Length);
                        
                        currentOffset += subArray.Length + sizeof(int);
                        arr[i] = Deserialize(subArray);
                    }

                    return new StackItem(new List<StackItem>(arr));
                case ItemType.Instruction:
                    size = BitConverter.ToInt32(data, 1);
                    char[] path = new char[size];
                    
                    for (int i = 0; i < size; i++) {
                        int index = i / 2;
                        byte value = (byte)(data[index + 5] >> (i % 2 == 0 ? 0 : 3) & 0b0000_0111);
                        switch (value) {
                            case 0:
                                path[i] = 'a';
                                break;
                            case 1:
                                path[i] = 'q';
                                break;
                            case 2:
                                path[i] = 'w';
                                break;
                            case 3:
                                path[i] = 'e';
                                break;
                            case 4:
                                path[i] = 'd';
                                break;
                            default:
                                path[i] = '?';
                                break;
                        }
                    }

                    return new StackItem(new Instruction(new string(path)));
                case ItemType.Boolean:
                    return new StackItem(BitConverter.ToBoolean(data, 1));
                case ItemType.Drone:
                    playerName = Encoding.UTF8.GetString(data, 5, data.Length - 5);
                    players = new VRCPlayerApi[VRCPlayerApi.GetPlayerCount()];
                    VRCPlayerApi.GetPlayers(players);
                    foreach (VRCPlayerApi player in players) {
                        if (player.IsValid() &&
                            player.displayName.Equals(playerName,
                                StringComparison.InvariantCultureIgnoreCase))
                            return new StackItem(player.GetDrone());
                    }
                    
                    return new StackItem();
                case ItemType.Entity:
                    int entityIndex = BitConverter.ToInt32(data, 1);
                    if (entityIndex == -1)
                        return new StackItem();

                    EntityManager entityManager = GameObject.Find("EntityManager").GetComponent<EntityManager>();
                    if (!Utilities.IsValid(entityManager)) {
                        UnityEngine.Debug.LogError("Failed to get EntityManager");
                        return new StackItem();
                    }

                    Dictionary<int, Entity> entities = entityManager.Entities;
                    // ReSharper disable once CanSimplifyDictionaryLookupWithTryGetValue
                    if (entities.ContainsKey(
                            entityIndex)) // can't use try get, because udon doesn't support it in recursive functions
                        return new StackItem(entities[entityIndex]);

                    UnityEngine.Debug.LogError("Entity index out of range");
                    return new StackItem();
                case ItemType.Garbage:
                    return new StackItem("");
                case ItemType.Any:
                case ItemType.Null:
                default:
                    break;
            }

            return new StackItem();
        }

        [RecursiveMethod]
        public byte[] Serialize() {
            bool appendSize;
            int valueSize;
            byte[] valueBytes;

            switch (Type) {
                case ItemType.Vector:
                    appendSize = false;
                    valueSize = (int)ItemTypeSizes.Vector;
                    Vector3[] tempVectorArray = new Vector3[] { (Vector3)Value };
                    valueBytes = new byte[(int)ItemTypeSizes.Vector];
                    Buffer.BlockCopy(tempVectorArray, 0, valueBytes, 0, valueSize);
                    break;
                case ItemType.Number:
                    appendSize = false;
                    valueSize = (int)ItemTypeSizes.Number;
                    valueBytes = BitConverter.GetBytes((float)Value);
                    //dict["v"] = new DataToken((float)Value);
                    break;
                case ItemType.Player:
                    VRCPlayerApi player = (VRCPlayerApi)Value;
                    if (!Utilities.IsValid(player) || !player.IsValid())
                        valueBytes = Encoding.UTF8.GetBytes("");
                    else
                        valueBytes = Encoding.UTF8.GetBytes(player.displayName);

                    valueSize = valueBytes.Length;
                    appendSize = true;
                    break;
                case ItemType.List:
                    List<StackItem> list = (List<StackItem>)Value;
                    valueSize = list.Count;
                    byte[][] temporaryArrayOfSerializedItems = new byte[valueSize][];

                    appendSize = true;
                    int listByteSize = 0;

                    for (int i = 0; i < valueSize; i++) {
                        StackItem item = list[i];
                        byte[] serializedItem = item.Serialize();

                        temporaryArrayOfSerializedItems[i] = serializedItem;
                        listByteSize += serializedItem.Length;
                    }

                    valueBytes = new byte[listByteSize + valueSize * sizeof(int)];
                    int currentOffset = sizeof(int);
                    for (int i = 0; i < valueSize; i++) {
                        byte[] arr = temporaryArrayOfSerializedItems[i];
                        Buffer.BlockCopy(arr, 0, valueBytes, currentOffset, arr.Length);
                        Buffer.BlockCopy(BitConverter.GetBytes(arr.Length), 0, valueBytes, currentOffset-sizeof(int), sizeof(int));
                        currentOffset += arr.Length + sizeof(int);
                    }

                    break;
                case ItemType.Instruction:
                    string path = ((Instruction)Value).Path;
                    appendSize = true;
                    valueSize = path.Length;
                    valueBytes = new byte[Mathf.CeilToInt(valueSize / 2f)];
                    for (int i = 0; i < valueSize; i++) {
                        int index = i / 2;
                        byte dir;
                        switch (path[i]) {
                            case 'a':
                                dir = 0;
                                break;
                            case 'q':
                                dir = 1;
                                break;
                            case 'w':
                                dir = 2;
                                break;
                            case 'e':
                                dir = 3;
                                break;
                            case 'd':
                                dir = 4;
                                break;
                            default:
                                dir = 5;
                                break;
                        }

                        valueBytes[index] |= (byte)(dir << (i % 2 == 0 ? 0 : 3));
                    }

                    break;
                case ItemType.Boolean:
                    appendSize = false;
                    valueSize = (int)ItemTypeSizes.Boolean;
                    valueBytes = BitConverter.GetBytes((bool)Value);
                    break;
                case ItemType.Drone:
                    appendSize = true;
                    VRCDroneApi drone = (VRCDroneApi)Value;
                    if (!Utilities.IsValid(drone)) {
                        valueBytes = Encoding.UTF8.GetBytes("");
                        valueSize = valueBytes.Length;
                        break;
                    }

                    player = drone.GetPlayer();
                    if (!Utilities.IsValid(player) || !player.IsValid())
                        valueBytes = Encoding.UTF8.GetBytes("");
                    else
                        valueBytes = Encoding.UTF8.GetBytes(player.displayName);
                    valueSize = valueBytes.Length;
                    break;
                case ItemType.Entity:
                    appendSize = false;
                    valueSize = (int)ItemTypeSizes.Entity;
                    valueBytes = BitConverter.GetBytes(((Entity)Value).GetId());
                    break;
                case ItemType.Garbage:
                case ItemType.Any:
                case ItemType.Null:
                default:
                    appendSize = false;
                    valueSize = (int)ItemTypeSizes.Null;
                    valueBytes = new byte[0];
                    break;
            }

            int dataSize = valueBytes.Length + sizeof(byte);
            int dataOffset = sizeof(byte);
            if (appendSize) {
                dataOffset += sizeof(int);
                dataSize += sizeof(int);
            }

            byte[] data = new byte[dataSize];
            data[0] = (byte)Type;
            if (appendSize)
                Buffer.BlockCopy(BitConverter.GetBytes(valueSize), 0, data, 1, sizeof(int));
            Buffer.BlockCopy(valueBytes, 0, data, dataOffset, valueBytes.Length);

            return data;
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

                    if (list.Count > 100) {
                        sb.Append("List too long to display!");
                    }
                    else {
                        for (int i = 0; i < list.Count; i++) {
                            if (i > 0)
                                sb.Append(", ");
                            list[i].ToString(sb);
                        }
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
                case ItemType.Entity:
                    sb.Append("Entity (");
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