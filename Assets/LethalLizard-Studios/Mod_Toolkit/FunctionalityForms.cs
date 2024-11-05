using TMPro;
using UnityEngine;

public class FunctionalityForms : MonoBehaviour
{
    [SerializeField] private ItemInProgress ItemInProgress;

    private ItemRecord _item;

    public void SetBasicItem(ItemRecord itemRecord)
    {
        _item = itemRecord;
    }

    public void SubmitNoFunctions()
    {
        ItemInProgress.SetItem(_item);
        Submit();
    }

    [SerializeField] private GameObject[] forms;

    public void Submit()
    {
        for (int i = 0; i < forms.Length; i++)
            forms[i].SetActive(false);

        ItemInProgress.BuildItem();
    }

    [Header("Food")]
    [SerializeField] private TMP_InputField CaloriesInput;
    [SerializeField] private TMP_InputField HealAmountInput;
    [SerializeField] private TMP_Dropdown FoodGroupDrop;

    public void SubmitFood()
    {
        FoodGroup foodGroup = FoodGroup.Mixture;

        FoodItem foodItem = new FoodItem(_item.name, _item.id, _item.dimensions,
            _item.texturePath, _item.sellValue, _item.purchaseValue,
            uint.Parse(CaloriesInput.text), uint.Parse(HealAmountInput.text), foodGroup);

        ItemInProgress.SetItem(foodItem);
        Submit();
    }

    [Header("Drink")]
    [SerializeField] private TMP_InputField QuenchAmountInput;
    [SerializeField] private TMP_InputField AlcoholProofInput;

    public void SubmitDrink()
    {
        DrinkItem drinkItem = new DrinkItem(_item.name, _item.id, _item.dimensions,
            _item.texturePath, _item.sellValue, _item.purchaseValue,
            uint.Parse(QuenchAmountInput.text), uint.Parse(AlcoholProofInput.text));

        ItemInProgress.SetItem(drinkItem);
        Submit();
    }

    [Header("Health")]
    [SerializeField] private TMP_InputField HealAmountHealthInput;

    public void SubmitHealth()
    {
        HealthItem healthItem = new HealthItem(_item.name, _item.id, _item.dimensions,
            _item.texturePath, _item.sellValue, _item.purchaseValue,
            uint.Parse(HealAmountHealthInput.text));

        ItemInProgress.SetItem(healthItem);
        Submit();
    }

    [Header("Air Filter")]
    [SerializeField] private TMP_InputField DurationInput;

    public void SubmitAirFilter()
    {
        AirFilterItem airFilterItem = new AirFilterItem(_item.name, _item.id, _item.dimensions,
            _item.texturePath, _item.sellValue, _item.purchaseValue,
            uint.Parse(DurationInput.text));

        ItemInProgress.SetItem(airFilterItem);
        Submit();
    }

    [Header("Anomalous")]
    [SerializeField] private TMP_InputField SpiritualInput;

    public void SubmitAnomalous()
    {
        AnomalousItem anomalousItem = new AnomalousItem(_item.name, _item.id, _item.dimensions,
            _item.texturePath, _item.sellValue, _item.purchaseValue,
            uint.Parse(SpiritualInput.text));

        ItemInProgress.SetItem(anomalousItem);
        Submit();
    }
}
