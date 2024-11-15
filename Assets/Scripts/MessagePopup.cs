using TMPro;
using UnityEngine;

public class MessagePopup : MonoBehaviour
{
    public static MessagePopup Instance { get; private set; }

    [SerializeField] private GameObject messageBox;

    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private TextMeshProUGUI bodyText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Show(string header, string body)
    {
        headerText.text = header;
        bodyText.text = body;

        messageBox.SetActive(true);
    }
}
