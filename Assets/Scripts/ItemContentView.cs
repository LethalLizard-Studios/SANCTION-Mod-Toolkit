using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemContentView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private TextMeshProUGUI idText;
    [SerializeField] private RawImage iconImage;

    public void Build(string displayName, uint id, Texture2D icon)
    {
        displayNameText.text = displayName;
        idText.text = "ID: "+id;
        iconImage.texture = icon;
    }
}
