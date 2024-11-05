using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PackageMod : MonoBehaviour
{
    [SerializeField] private List<ScriptableItem> baseItems = new List<ScriptableItem>();

    private string _filePath;

    private Dictionary<uint, ItemRecord> _itemDatabase = new Dictionary<uint, ItemRecord>();

    void Start()
    {
        //List<ItemRecord> itemsToSave = new List<ItemRecord>
        //{
        //    new FoodItem("Apple", 501, new Vector2Int(1, 1), null, 1, 3, 95, 5, FoodGroup.Fruits),
        //    new DrinkItem("Apple Juice", 502, new Vector2Int(1, 2), null, 1, 3, 25, 0)
        //};

        //_filePath = Path.Combine(Application.dataPath, "mods/test.json");
        //ItemSerializer.Save(itemsToSave, _filePath);

        BuildItemDatabase();
    }

    public void BuildItemDatabase()
    {
        _itemDatabase = RetrieveBaseItemRecords();

        _filePath = Path.Combine(Application.dataPath, "mods");

        if (!Directory.Exists(_filePath))
        {
            Debug.Log("Mods Folder does not exist!");
            return;
        }

        Debug.Log("Mods Folder found!");

        string[] jsonFiles = Directory.GetFiles(_filePath, "*.json");

        for (int i = 0; i < jsonFiles.Length; i++)
        {
            Debug.Log("LOADING MOD: " + Path.GetFileName(jsonFiles[i]));

            List<ItemRecord> loadedItems = ItemSerializer.Load(jsonFiles[i]);
            foreach (var item in loadedItems)
            {
                if (_itemDatabase.ContainsKey(item.id))
                {
                    Debug.Log($"Uh Oh! {item.name} doesn't have a unique item ID.");
                    continue;
                }

                Debug.Log($"Loaded item: {item.name} of type {item.GetType()}");
                _itemDatabase.Add(item.id, item);
            }
        }
    }

    private Dictionary<uint, ItemRecord> RetrieveBaseItemRecords()
    {
        Dictionary<uint, ItemRecord> baseItemRecord = new Dictionary<uint, ItemRecord>();

        for (int i = 0; i < baseItems.Count; i++)
        {
            baseItemRecord.Add(baseItems[i].id, ScriptableItemToRecord.Convert(baseItems[i]));
        }

        return baseItemRecord;
    }

}
