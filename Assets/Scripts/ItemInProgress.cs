using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemInProgress : MonoBehaviour
{
    public string currentModpack = "Test";

    [SerializeField] private GameObject Homepage;

    [SerializeField] private GameObject TutorialPrompts;
    [SerializeField] private GameObject ItemPrefab;
    [SerializeField] private Transform ItemContainer;

    private List<ItemRecord> _currentModsItems = new List<ItemRecord>();
    private ItemRecord _item;

    private string _texture = null;

    private void OnEnable()
    {
        string _filePath = ModPath.HoldingDirectory + currentModpack;

        if (!Directory.Exists(_filePath))
        {
            Debug.Log("Mod does not exist!");
            return;
        }

        string[] jsonFiles = Directory.GetFiles(_filePath, "*.json");

        for (int i = 0; i < jsonFiles.Length; i++)
        {
            _currentModsItems = ItemSerializer.Load(jsonFiles[i]);
        }

        if (_currentModsItems != null && _currentModsItems.Count > 0)
        {
            TutorialPrompts.SetActive(false);

            for (int i = 0; i < _currentModsItems.Count; i++)
            {
                Instantiate(ItemPrefab, ItemContainer).GetComponent<ItemContentView>()
                    .Build(_currentModsItems[i], this);
            }
        }
    }

    public void RemoveItemFromMod(ItemRecord item)
    {
        if (_currentModsItems.Contains(item))
            _currentModsItems.Remove(item);

        SaveMod();
    }

    public void SetTexture(string texture)
    {
        _texture = texture;
    }

    public void SetItem(ItemRecord item)
    {
        _item = item;
    }

    public void BuildItem()
    {
        _item.texturePath = _texture;
        _item.modPackName = currentModpack;

        if (_currentModsItems == null)
            _currentModsItems = new List<ItemRecord>();

        _currentModsItems.Add(_item);

        SaveMod();

        Homepage.SetActive(true);
    }

    public void SaveMod()
    {
        ItemSerializer.Save(_currentModsItems, ModPath.HoldingDirectory + currentModpack + "/items.json");
    }
}
