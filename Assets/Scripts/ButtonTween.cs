using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class ButtonTween : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform _rectTransform;

    private Image _image;
    private TextMeshProUGUI _text;

    private Color _originalColor;
    private Vector3 _originalScale;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();

        _originalScale = _rectTransform.localScale;

        if (TryGetComponent<Image>(out _image))
            _originalColor = _image.color;
        else if (TryGetComponent<TextMeshProUGUI>(out _text))
            _originalColor = _text.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _rectTransform.DOScale(_originalScale * 1.2f, 0.1f).SetUpdate(true);

        if (_image != null)
            _image.DOColor(Color.white, 0.1f).SetUpdate(true);
        else if (_text != null)
            _text.DOColor(Color.white, 0.1f).SetUpdate(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _rectTransform.DOScale(_originalScale, 0.3f).SetUpdate(true);

        if (_image != null)
            _image.DOColor(_originalColor, 0.3f).SetUpdate(true);
        else if (_text != null)
            _text.DOColor(_originalColor, 0.3f).SetUpdate(true);
    }
}
