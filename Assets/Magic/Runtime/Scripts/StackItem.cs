using System.Collections.Generic;
using VRC.SDKBase;
using UnityEngine;
using VRC.SDK3.Data;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public enum ItemType {
        Null,
        Vector,
        Number,
        Player,
        List,
    }

    public class StackItem {
        public readonly ItemType Type;
        public readonly object Value;

        public StackItem(Vector3 data) {
            Type = ItemType.Vector;
            Value = data;
        }

        public StackItem(float data) {
            Type = ItemType.Number;
            Value = data;
        }

        public StackItem(VRCPlayerApi data) {
            Type = ItemType.Player;
            Value = data;
        }

        public StackItem(List<StackItem> data) {
            Type = ItemType.List;
            Value = data;
        }

        public StackItem(DataDictionary serializedData) {
            Type = (ItemType)(int)serializedData["t"].Number;
            Value = null;

            switch (Type) {
                case ItemType.Vector:
                    DataList vectorList = serializedData["t"].DataList;
                    Value = new Vector3((float)vectorList[0].Number, (float)vectorList[1].Number,
                        (float)vectorList[2].Number);
                    break;
                case ItemType.Number:
                    Value = (float)serializedData["t"].Number;
                    break;
                case ItemType.Player:
                    VRCPlayerApi player = VRCPlayerApi.GetPlayerById((int)serializedData["t"].Number);
                    if (!Utilities.IsValid(player))
                        Type = ItemType.Null;
                    else
                        Value = player;

                    break;
                case ItemType.List:
                    DataList serializedList = serializedData["t"].DataList;
                    List<StackItem> list = new List<StackItem>(serializedList.Count);

                    for (int i = 0; i < serializedList.Count; i++)
                        list.Add(new StackItem(serializedList[i].DataDictionary));

                    Value = list;
                    break;

                case ItemType.Null:
                default:
                    Type = ItemType.Null;
                    break;
            }
        }

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
                
                case ItemType.Null:
                default:
                    dict["t"] = (int)ItemType.Null;
                    break;
            }

            if (VRCJson.TrySerializeToJson(dict, JsonExportType.Minify, out DataToken token))
                return token.String;
            return token.ToString();
        }
    }
}