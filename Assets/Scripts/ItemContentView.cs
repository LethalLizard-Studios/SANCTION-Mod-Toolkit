using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ItemContentView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private TextMeshProUGUI idText;
    [SerializeField] private Image iconImage;

    private Image _image;
    private Color _originalColor;

    private const float HIGHLIGHT_STRENGTH = 0.2f;

    private ItemRecord _itemRecord;
    private ItemInProgress _itemInProgress;

    private ItemListContainer _itemListContainer;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _originalColor = _image.color;
    }

    public void Build(ItemRecord item, ItemInProgress itemInProgress, ItemListContainer itemListContainer)
    {
        _itemRecord = item;
        _itemListContainer = itemListContainer;

        displayNameText.text = item.name;
        idText.text = "ID: "+ item.ID;
        iconImage.sprite = item.FetchTexture();

        RectTransform rectTransform = iconImage.GetComponent<RectTransform>();
        MaintainAspectRatio.UpdateSize(rectTransform, item.dimensions, new Vector2Int(0, 60));

        _itemInProgress = itemInProgress;
    }

    public void Highlight(bool activate)
    {
        if (activate) {
            _image.DOColor(_originalColor + (Color.yellow * HIGHLIGHT_STRENGTH), 0.25f).SetUpdate(true);
        }
        else
        {
            _image.DOColor(_originalColor, 0.25f).SetUpdate(true);
        }
    }

    public void SaveEdit(ItemRecord newItemRecord)
    {
        _itemListContainer.EditItem(_itemRecord, newItemRecord);
        _itemInProgress.SaveMod();
        Highlight(false);
    }

    public void Delete()
    {
        _itemInProgress.RemoveItemFromMod(_itemRecord);
        Destroy(gameObject);
    }

    public void Edit()
    {
        _itemListContainer.LoadEditInspector(_itemRecord, this);
        Highlight(true);
    }
}
