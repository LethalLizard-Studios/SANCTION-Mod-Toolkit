/* All Rights Reserved to LethalLizard Studios
-- Created By: Leland T L Carter
-- DATE: 11/03/2024
*/

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class ItemSerializer
{
    public static void Save(List<ItemRecord> items, string filePath)
    {
        List<SerializableItem> serializableItems = new List<SerializableItem>();

        if (items == null)
            return;

        if (items.Count <= 0)
        {
            File.WriteAllText(filePath, "");
            return;
        }

        for (int i = 0; i < items.Count; i++)
        {
            serializableItems.Add(new SerializableItem(items[i]));
        }

        ItemListWrapper wrapper = new ItemListWrapper(serializableItems);
        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(filePath, json);
    }

    public static List<ItemRecord> Load(string filePath)
    {
        if (!File.Exists(filePath))
            return new List<ItemRecord>();

        string json = File.ReadAllText(filePath);
        ItemListWrapper wrapper = JsonUtility.FromJson<ItemListWrapper>(json);
        List<ItemRecord> items = new List<ItemRecord>();

        if (wrapper == null)
            return null;

        for (int i = 0; i < wrapper.Items.Count; i++)
        {
            SerializableItem serializableItem = wrapper.Items[i];

            Type functionalityType = Type.GetType(serializableItem.ItemFunctionality);

            if (functionalityType == null)
                return items;

            ItemRecord item = (ItemRecord)JsonUtility.FromJson(serializableItem.ItemJson, functionalityType);
            items.Add(item);
        }

        return items;
    }
}
