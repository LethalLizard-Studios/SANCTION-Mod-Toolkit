using TMPro;
using UnityEngine;

public class EditItem : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputID;
    [SerializeField] private TMP_InputField inputDisplayName;
    [SerializeField] private TMP_InputField inputWidth;
    [SerializeField] private TMP_InputField inputHeight;
    [SerializeField] private TMP_InputField inputSell;
    [SerializeField] private TMP_InputField inputPurchase;

    private ItemRecord _currentItem;

    public void LoadItem(ItemRecord itemRecord)
    {
        _currentItem = itemRecord;

        inputID.text = itemRecord.ID.ToString();
        inputDisplayName.text = itemRecord.name.ToString();

        inputWidth.text = itemRecord.dimensions.x.ToString();
        inputHeight.text = itemRecord.dimensions.y.ToString();

        inputSell.text = itemRecord.sellValue.ToString();
        inputPurchase.text = itemRecord.purchaseValue.ToString();
    }

    public void SaveItem()
    {
        _currentItem.ID = uint.Parse(inputID.text);
        _currentItem.name = inputDisplayName.text;

        _currentItem.dimensions = new Vector2Int(int.Parse(inputWidth.text), int.Parse(inputHeight.text));

        _currentItem.sellValue = int.Parse(inputSell.text);
        _currentItem.purchaseValue = int.Parse(inputPurchase.text);
    }
}
