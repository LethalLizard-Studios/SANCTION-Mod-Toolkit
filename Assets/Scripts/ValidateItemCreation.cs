using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ValidateItemCreation : MonoBehaviour
{
    [SerializeField] private FunctionalityForms forms;

    public GameObject dragMenu;
    public GameObject newItemMenu;

    public TextMeshProUGUI headerTitle;
    public TextMeshProUGUI requiredResolutionText;

    public TMP_InputField displayNameInput;
    public TMP_InputField IDInput;
    public TMP_InputField slotSizeWidthInput;
    public TMP_InputField slotSizeHeightInput;
    public TMP_InputField sellInput;
    public TMP_InputField purchaseInput;

    [SerializeField] private Outline displayNameOutline;
    [SerializeField] private Outline IDInputOutline;
    [SerializeField] private Outline slotSizeWidthOutline;
    [SerializeField] private Outline slotSizeHeightOutline;
    [SerializeField] private Outline sellOutline;
    [SerializeField] private Outline purchaseOutline;

    public void OnEnable()
    {
        headerTitle.text = "Create Item";
    }

    public void SubmitForm()
    {
        if (!ErrorCheck())
            return;

        headerTitle.text = "["+IDInput.text+"] "+displayNameInput.text;

        requiredResolutionText.text = 
            "Must be .png and " + int.Parse(slotSizeWidthInput.text) * 256
            + "px X " + int.Parse(slotSizeHeightInput.text) * 256 + "px";

        dragMenu.SetActive(true);
        newItemMenu.SetActive(false);

        forms.SetBasicItem(new ItemRecord(displayNameInput.text, uint.Parse(IDInput.text),
            new Vector2Int(int.Parse(slotSizeWidthInput.text), int.Parse(slotSizeHeightInput.text)),
            null, float.Parse(sellInput.text), float.Parse(purchaseInput.text)));
    }

    private bool ErrorCheck()
    {
        bool result = true;

        displayNameOutline.enabled = false;
        IDInputOutline.enabled = false;
        slotSizeWidthOutline.enabled = false;
        slotSizeHeightOutline.enabled = false;
        sellOutline.enabled = false;
        purchaseOutline.enabled = false;

        if (displayNameInput.text.Length <= 0)
        {
            displayNameOutline.enabled = true;
            result = false;
        }
        if (IDInput.text.Length <= 0)
        {
            IDInputOutline.enabled = true;
            result = false;
        }
        if (slotSizeWidthInput.text.Length != 1)
        {
            slotSizeWidthOutline.enabled = true;
            result = false;
        }
        if (slotSizeHeightInput.text.Length != 1)
        {
            slotSizeHeightOutline.enabled = true;
            result = false;
        }
        if (sellInput.text.Length <= 0)
        {
            sellOutline.enabled = true;
            result = false;
        }
        if (purchaseInput.text.Length <= 0)
        {
            purchaseOutline.enabled = true;
            result = false;
        }

        return result;
    }
}
