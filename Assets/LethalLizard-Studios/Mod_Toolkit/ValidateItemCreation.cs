/* All Rights Reserved to LethalLizard Studios
-- Created By: Leland T L Carter
-- DATE: 11/12/2024
*/

using TMPro;
using UnityEngine;

public class ValidateItemCreation : MonoBehaviour
{
    [SerializeField] private FunctionalityForms forms;

    [SerializeField] private GameObject importIconPage;
    [SerializeField] private GameObject itemCreationPage;

    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private TextMeshProUGUI requiredResolutionText;

    [System.Serializable]
    public class ItemFields
    {
        public TMP_InputField displayNameInput;
        public TMP_InputField IDInput;
        public TMP_InputField slotSizeWidthInput;
        public TMP_InputField slotSizeHeightInput;
        public TMP_InputField sellInput;
        public TMP_InputField purchaseInput;
    }
    [SerializeField] private ItemFields itemFields;

    [System.Serializable]
    public class OptionalItemFields
    {
        public TMP_InputField merchantIndex;
        public TMP_InputField merchantRepRequired;
        public TMP_InputField lootIndex;
        public TMP_InputField lootChancePercentage;
    }
    [SerializeField] private OptionalItemFields optionalItemFields;

    public void OnEnable()
    {
        headerText.text = "Create Item";
    }

    public void SubmitForm()
    {
        if (!ErrorCheck())
            return;

        headerText.text = $"[{itemFields.IDInput.text}] {itemFields.displayNameInput.text}";

        UpdateResolutionText();

        importIconPage.SetActive(true);
        itemCreationPage.SetActive(false);

        ItemRecord itemRecord = CreateItemRecord();

        SetOptionalItemFields(itemRecord);

        forms.SetBasicItem(itemRecord);
    }

    private void UpdateResolutionText()
    {
        int width = int.Parse(itemFields.slotSizeWidthInput.text);
        int height = int.Parse(itemFields.slotSizeHeightInput.text);

        requiredResolutionText.text = $"Must be .png and {width * 256}px X {height * 256}px";
    }

    private ItemRecord CreateItemRecord()
    {
        return new ItemRecord(
            itemFields.displayNameInput.text,
            uint.Parse(itemFields.IDInput.text),
            new Vector2Int(int.Parse(itemFields.slotSizeWidthInput.text), int.Parse(itemFields.slotSizeHeightInput.text)),
            null,
            int.Parse(itemFields.sellInput.text),
            int.Parse(itemFields.purchaseInput.text)
        );
    }

    private void SetOptionalItemFields(ItemRecord itemRecord)
    {
        if (!string.IsNullOrEmpty(optionalItemFields.merchantIndex.text) 
            && !string.IsNullOrEmpty(optionalItemFields.merchantRepRequired.text))
        {
            itemRecord.merchantID = new Vector2Int(
                int.Parse(optionalItemFields.merchantIndex.text),
                int.Parse(optionalItemFields.merchantRepRequired.text)
            );
        }
        if (!string.IsNullOrEmpty(optionalItemFields.lootIndex.text) 
            && !string.IsNullOrEmpty(optionalItemFields.lootChancePercentage.text))
        {
            itemRecord.lootID = new Vector2Int(
                int.Parse(optionalItemFields.lootIndex.text),
                int.Parse(optionalItemFields.lootChancePercentage.text)
            );
        }
    }

    private bool ErrorCheck()
    {
        bool result = true;

        ClearInputOutlines();

        result &= Validation.CheckInputNullOrEmpty(itemFields.displayNameInput);
        result &= Validation.CheckInputNullOrEmpty(itemFields.IDInput);

        result &= Validation.CheckInputNullOrEmpty(itemFields.purchaseInput);
        result &= Validation.CheckInputNullOrEmpty(itemFields.sellInput);

        // ID is 4-digitsat 
        result &= Validation.CheckInputGreaterThan(itemFields.IDInput, 999);

        // Slot size is 1-4
        result &= Validation.CheckInputRange(itemFields.slotSizeWidthInput, 1, 4);
        result &= Validation.CheckInputRange(itemFields.slotSizeHeightInput, 1, 4);

        return result;
    }

    private void ClearInputOutlines()
    {
        Validation.SetErrorOutlineState(itemFields.displayNameInput, false);
        Validation.SetErrorOutlineState(itemFields.IDInput, false);
        Validation.SetErrorOutlineState(itemFields.slotSizeWidthInput, false);
        Validation.SetErrorOutlineState(itemFields.slotSizeHeightInput, false);
        Validation.SetErrorOutlineState(itemFields.sellInput, false);
        Validation.SetErrorOutlineState(itemFields.purchaseInput, false);

        Validation.SetErrorOutlineState(optionalItemFields.merchantIndex, false);
        Validation.SetErrorOutlineState(optionalItemFields.merchantRepRequired, false);
        Validation.SetErrorOutlineState(optionalItemFields.lootIndex, false);
        Validation.SetErrorOutlineState(optionalItemFields.lootChancePercentage, false);
    }
}
