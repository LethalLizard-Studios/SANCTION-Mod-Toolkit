using DG.Tweening;
using TMPro;
using UnityEngine;

public class EditItem : MonoBehaviour
{
    [SerializeField] private GameObject editPage;
    [SerializeField] private RectTransform itemListTransform;

    [SerializeField] private TMP_InputField inputID;
    [SerializeField] private TMP_InputField inputDisplayName;
    [SerializeField] private TMP_InputField inputWidth;
    [SerializeField] private TMP_InputField inputHeight;
    [SerializeField] private TMP_InputField inputSell;
    [SerializeField] private TMP_InputField inputPurchase;

    private ItemRecord _currentItem;
    private ItemContentView _view = null;

    public void LoadItem(ItemRecord itemRecord, ItemContentView view)
    {
        if (_view != null)
        {
            _view.Highlight(false);
        }

        itemListTransform.DOLocalMoveX(120, 0.15f);

        _currentItem = itemRecord;
        _view = view;

        inputID.text = itemRecord.ID.ToString();
        inputDisplayName.text = itemRecord.name.ToString();

        inputWidth.text = itemRecord.dimensions.x.ToString();
        inputHeight.text = itemRecord.dimensions.y.ToString();

        inputSell.text = itemRecord.sellValue.ToString();
        inputPurchase.text = itemRecord.purchaseValue.ToString();

        editPage.SetActive(true);
    }

    public void SaveItem()
    {
        _currentItem.ID = uint.Parse(inputID.text);
        _currentItem.name = inputDisplayName.text;

        _currentItem.dimensions = new Vector2Int(int.Parse(inputWidth.text), int.Parse(inputHeight.text));

        _currentItem.sellValue = int.Parse(inputSell.text);
        _currentItem.purchaseValue = int.Parse(inputPurchase.text);

        CloseMenu();

        _view.SaveEdit();
        _view = null;
    }

    public void DeleteItem()
    {
        _view.Delete();
        _view = null;
        CloseMenu();
    }

    public void CancelItem()
    {
        CloseMenu();
        _view.Highlight(false);
    }

    private void CloseMenu()
    {
        itemListTransform.DOLocalMoveX(0, 0.3f);
        editPage.SetActive(false);
    }
}
