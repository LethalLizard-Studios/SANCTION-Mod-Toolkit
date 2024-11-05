using TMPro;
using UnityEngine;

public class FunctionalitySelector : MonoBehaviour
{
    [SerializeField] private FunctionalityForms Forms;

    [SerializeField] private GameObject SelectorMenu;

    [SerializeField] private TMP_Dropdown PropertyDropdown;
    [SerializeField] private GameObject[] FormOptions;

    public void SubmitSelection()
    {
        int index = PropertyDropdown.value;

        if (index == 0)
        {
            Forms.SubmitNoFunctions();
            SelectorMenu.SetActive(false);
            return;
        }

        for (int i = 0; i < FormOptions.Length; i++)
            FormOptions[i].SetActive(false);

        FormOptions[index].SetActive(true);

        SelectorMenu.SetActive(false);
    }
}
