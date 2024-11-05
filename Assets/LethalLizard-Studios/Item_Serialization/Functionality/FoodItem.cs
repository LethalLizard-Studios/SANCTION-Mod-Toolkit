/* All Rights Reserved to LethalLizard Studios
-- Created By: Leland T L Carter
-- DATE: 11/03/2024
*/

using UnityEngine;

public enum FoodGroup
{
    Fruits,
    Vegetables,
    Grains,
    Protiens,
    Dairy,
    Pickled,
    Mixture
}

[System.Serializable]
public class FoodItem : ItemRecord
{
    public uint Calories;
    public uint HealAmount;
    public FoodGroup FoodGroup;

    public FoodItem(string name, uint id, Vector2Int dimensions, string texturePath,
        float sellValue, float purchaseValue, uint calories, uint healAmount, FoodGroup foodGroup) 
        : base(name, id, dimensions, texturePath, sellValue, purchaseValue)
    {
        this.Calories = calories;
        this.HealAmount = healAmount;
        this.FoodGroup = foodGroup;
    }
}
