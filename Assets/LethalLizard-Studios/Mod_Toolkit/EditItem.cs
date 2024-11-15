/* All Rights Reserved to LethalLizard Studios
-- Created By: Leland T L Carter
-- DATE: 11/12/2024
*/

using DG.Tweening;
using TMPro;
using UnityEngine;

public class EditItem : MonoBehaviour
{
    [SerializeField] private GameObject editPage;
    [SerializeField] private RectTransform itemListTransform;

    [System.Serializable]
    public class ItemFields
    {
        public TMP_InputField inputID;
        public TMP_InputField inputDisplayName;
        public TMP_InputField inputWidth;
        public TMP_InputField inputHeight;
        public TMP_InputField inputSell;
        public TMP_InputField inputPurchase;
    }
    [SerializeField] private ItemFields itemFields;

    [System.Serializable]
    public class OptionalItemFields
    {
        public TMP_InputField inputLootID;
        public TMP_InputField inputLootChance;
        public TMP_InputField inputMerchantID;
        public TMP_InputField inputMerchantRep;
    }
    [SerializeField] private OptionalItemFields optionalItemFields;

    private ItemRecord _currentItem;
    private ItemContentView _currentView;

    // Method to load item data into the edit page UI
    public void LoadItem(ItemRecord itemRecord, ItemContentView view)
    {
        // Deselect the previous view if any
        _currentView?.Highlight(false);

        // Animate the item list sliding
        itemListTransform.DOLocalMoveX(120, 0.15f);

        // Assign current item and view
        _currentItem = itemRecord;
        _currentView = view;

        // Populate input fields with item data
        itemFields.inputID.text = itemRecord.ID.ToString();
        itemFields.inputDisplayName.text = itemRecord.name;
        itemFields.inputWidth.text = itemRecord.dimensions.x.ToString();
        itemFields.inputHeight.text = itemRecord.dimensions.y.ToString();
        itemFields.inputSell.text = itemRecord.sellValue.ToString();
        itemFields.inputPurchase.text = itemRecord.purchaseValue.ToString();

        optionalItemFields.inputLootID.text = itemRecord.lootID.x.ToString();
        optionalItemFields.inputLootChance.text = itemRecord.lootID.y.ToString();
        optionalItemFields.inputMerchantID.text = itemRecord.merchantID.x.ToString();
        optionalItemFields.inputMerchantRep.text = itemRecord.merchantID.y.ToString();

        // Show the edit page
        editPage.SetActive(true);
    }

    // Method to save the edited item
    public void SaveItem()
    {
        // Update current item with input field data
        _currentItem.ID = uint.Parse(itemFields.inputID.text);
        _currentItem.name = itemFields.inputDisplayName.text;
        _currentItem.dimensions = new Vector2Int(int.Parse(itemFields.inputWidth.text)
            , int.Parse(itemFields.inputHeight.text));
        _currentItem.sellValue = int.Parse(itemFields.inputSell.text);
        _currentItem.purchaseValue = int.Parse(itemFields.inputPurchase.text);

        _currentItem.lootID = new Vector2Int(int.Parse(optionalItemFields.inputLootID.text)
            , int.Parse(optionalItemFields.inputLootChance.text));
        _currentItem.merchantID = new Vector2Int(int.Parse(optionalItemFields.inputMerchantID.text)
            , int.Parse(optionalItemFields.inputMerchantRep.text));

        // Close the edit menu and save changes to the view
        CloseMenu();
        _currentView.SaveEdit(_currentItem);

        // Reset the current view
        _currentView = null;
    }

    // Method to delete the current item
    public void DeleteItem()
    {
        _currentView?.Delete();
        _currentView = null;
        CloseMenu();
    }

    // Method to cancel changes and close the menu
    public void CancelItem()
    {
        CloseMenu();
        _currentView?.Highlight(false);
    }

    // Helper method to close the edit menu with an animation
    private void CloseMenu()
    {
        itemListTransform.DOLocalMoveX(0, 0.3f);
        editPage.SetActive(false);
    }
}
