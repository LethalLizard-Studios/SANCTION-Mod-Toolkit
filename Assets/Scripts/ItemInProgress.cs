using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ItemInProgress : MonoBehaviour
{
    [HideInInspector] public string currentModpack = "Test";

    [SerializeField] private ItemListContainer itemListContainer;

    [SerializeField] private GameObject renamePrompt;
    [SerializeField] private GameObject dashboardPage;
    [SerializeField] private GameObject emptyGuide;

    private List<ItemRecord> _currentModsItems = new List<ItemRecord>();
    private ItemRecord _item;

    private string _texture;

    private void OnEnable()
    {
        string modPath = ModPath.HoldingDirectory + currentModpack;

        if (!Directory.Exists(modPath))
        {
            Debug.LogError("Mod does not exist!");
            return;
        }

        LoadAndBuildItems(modPath);
    }

    private void LoadAndBuildItems(string filePath)
    {
        string[] jsonFiles = Directory.GetFiles(filePath, "*.json");

        foreach (string jsonFile in jsonFiles)
        {
            _currentModsItems.AddRange(ItemSerializer.Load(jsonFile));
        }

        if (_currentModsItems.Count > 0)
        {
            emptyGuide.SetActive(false);
            itemListContainer.AddItems(_currentModsItems);
        }
    }

    public void OpenRenamePrompt()
    {
        renamePrompt.SetActive(true);
        renamePrompt.GetComponent<RenameView>().SetInputText(currentModpack);
    }

    public void SubmitRename(TMP_InputField nameInput)
    {
        renamePrompt.SetActive(false);
        RenameModpack(nameInput.text);
    }

    private void RenameModpack(string newName)
    {
        if (newName.Length <= 1) return;

        string oldModpackPath = ModPath.HoldingDirectory + currentModpack;
        string newModpackPath = ModPath.HoldingDirectory + newName;

        Directory.Move(oldModpackPath, newModpackPath);
        currentModpack = newName;

        foreach (ItemRecord item in _currentModsItems)
        {
            item.modPackName = newName;
        }
    }

    public void RemoveItemFromMod(ItemRecord item)
    {
        if (_currentModsItems.Contains(item))
        {
            _currentModsItems.Remove(item);
            itemListContainer.RemoveItem(item);
            SaveMod();
        }
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
        if (_item == null) return;

        _item.texturePath = _texture;
        _item.modPackName = currentModpack;

        _currentModsItems.Add(_item);
        itemListContainer.AddItem(_item);
        SaveMod();

        dashboardPage.SetActive(true);
    }

    public void SaveMod()
    {
        ItemSerializer.Save(_currentModsItems, ModPath.HoldingDirectory + currentModpack + "/items.json");
    }
}
