using System.Collections.Generic;
using UnityEngine;

public class ItemListContainer : MonoBehaviour
{
    [SerializeField] private GameObject itemViewPrefab;
    [SerializeField] private Transform itemViewContentHolder;

    [SerializeField] private EditItem editItem;
    [SerializeField] private ItemInProgress itemInProgress;

    private Dictionary<ItemRecord, ItemContentView> _currentItems 
        = new Dictionary<ItemRecord, ItemContentView>();

    public void RemoveItem(ItemRecord itemRecord)
    {
        if (_currentItems.ContainsKey(itemRecord))
            _currentItems[itemRecord].Delete();
    }

    public void LoadEditInspector(ItemRecord itemRecord, ItemContentView itemContentView)
    {
        editItem.LoadItem(itemRecord, itemContentView);
    }

    public void EditItem(ItemRecord originalItemRecord, ItemRecord newItemRecord)
    {
        if (_currentItems.ContainsKey(originalItemRecord))
            _currentItems[originalItemRecord].Build(newItemRecord, itemInProgress, this);
    }

    public void AddItems(List<ItemRecord> itemRecords)
    {
        foreach (ItemRecord item in itemRecords)
            AddItem(item);
    }

    public void AddItem(ItemRecord itemRecord)
    {
        GameObject itemPrefab = Instantiate(itemViewPrefab, itemViewContentHolder);

        ItemContentView itemContentView = itemPrefab.GetComponent<ItemContentView>();
        itemContentView.Build(itemRecord, itemInProgress, this);

        _currentItems.Add(itemRecord, itemContentView);
    }
}
