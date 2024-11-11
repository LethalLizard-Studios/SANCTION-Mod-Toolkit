using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemContentView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private TextMeshProUGUI idText;
    [SerializeField] private Image iconImage;

    private ItemRecord _itemRecord;
    private ItemInProgress _itemInProgress;

    public void Build(ItemRecord item, ItemInProgress itemInProgress)
    {
        _itemRecord = item;

        displayNameText.text = item.name;
        idText.text = "ID: "+ item.ID;
        iconImage.sprite = item.FetchTexture();

        _itemInProgress = itemInProgress;
    }

    public void Delete()
    {
        _itemInProgress.RemoveItemFromMod(_itemRecord);
        Destroy(gameObject);
    }
}
