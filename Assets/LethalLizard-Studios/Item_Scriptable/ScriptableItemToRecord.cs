using UnityEngine;

public static class ScriptableItemToRecord
{
    public static ItemRecord Convert(ScriptableItem item)
    {
        ItemRecord record = new ItemRecord(item.displayName, (uint)item.ID,
            new Vector2Int(Mathf.RoundToInt(item.dimensions.x), Mathf.RoundToInt(item.dimensions.y)), "", item.sellValue, item.costValue);

        switch (item.functionality)
        {
            case Functionality.Basic:
                record = new ItemRecord(item.displayName, (uint)item.ID, new Vector2Int(Mathf.RoundToInt(item.dimensions.x), Mathf.RoundToInt(item.dimensions.y)), "",
                    item.sellValue, item.costValue);
                break;
            case Functionality.Food:
                if (item.nutrition == null)
                    break;

                record = new FoodItem(item.displayName, (uint)item.ID, new Vector2Int(Mathf.RoundToInt(item.dimensions.x), Mathf.RoundToInt(item.dimensions.y)), "",
                    item.sellValue, item.costValue, (uint)item.nutrition.calories, (uint)item.nutrition.healingAmount, item.nutrition.foodGroup);
                break;
            case Functionality.Drink:
                record = new DrinkItem(item.displayName, (uint)item.ID, new Vector2Int(Mathf.RoundToInt(item.dimensions.x), Mathf.RoundToInt(item.dimensions.y)), "",
                    item.sellValue, item.costValue, (uint)item.useAmount, 0);
                break;
            case Functionality.Health:
                record = new HealthItem(item.displayName, (uint)item.ID, new Vector2Int(Mathf.RoundToInt(item.dimensions.x), Mathf.RoundToInt(item.dimensions.y)), "",
                    item.sellValue, item.costValue, (uint)item.useAmount);
                break;
            case Functionality.AirFilter:
                record = new AirFilterItem(item.displayName, (uint)item.ID, new Vector2Int(Mathf.RoundToInt(item.dimensions.x), Mathf.RoundToInt(item.dimensions.y)), "",
                    item.sellValue, item.costValue, (uint)item.useAmount);
                break;
        }

        record.icon = item.icon;
        record.modPackName = "Base Game";
        record.savedValue = (uint)item.useAmount;
        record.functionality = item.functionality;
        record.rarity = (int)item.rarity;
        record.merchantID = new Vector2Int(Mathf.RoundToInt(item.merchantID.x), Mathf.RoundToInt(item.merchantID.y));

        return record;
    }
}