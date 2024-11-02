using TMPro;
using UnityEngine;

public class MessagePopup : MonoBehaviour
{
    [SerializeField] private GameObject messageBox;

    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private TextMeshProUGUI bodyText;

    public void Show(string header, string body)
    {
        headerText.text = header;
        bodyText.text = body;

        messageBox.SetActive(true);
    }
}
