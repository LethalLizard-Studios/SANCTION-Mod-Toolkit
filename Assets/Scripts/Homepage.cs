using TMPro;
using UnityEngine;

public class Homepage : MonoBehaviour
{
    [SerializeField] private int versionNumber = 1;

    [SerializeField] private TextMeshProUGUI headerTitle;

    [SerializeField] private GameObject homepageMenu;
    [SerializeField] private GameObject newItemMenu;

    public void OnEnable()
    {
        headerTitle.text = "Modding Toolkit V" + versionNumber;
    }

    public void CreateNew()
    {
        newItemMenu.SetActive(true);
        homepageMenu.SetActive(false);
    }
}
