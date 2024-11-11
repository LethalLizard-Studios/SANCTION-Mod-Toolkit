using UnityEngine;


[CreateAssetMenu(fileName = "Nutrition_Default", menuName = "Items/Nutrition", order = 2)]
public class ScriptableNutrition : ScriptableObject
{
    public int calories = 0;

    [Space(8)]
    public FoodGroup foodGroup = FoodGroup.Mixture;
    public int healingAmount = 0;
}