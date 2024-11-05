using UnityEngine;

public static class ScriptableItemToRecord
{
    public static ItemRecord Convert(ScriptableItem item)
    {
        ItemRecord record = new ItemRecord("Missing", 999, new Vector2Int(1, 1), null, 1.0f, 1.0f);
        record.texture = item.texture;
        record.modPackName = "Base";

        switch (item.functionality)
        {
            case Functionality.Basic:
                record = new ItemRecord(item.displayName, item.id, item.dimensions, "",
                    item.sellValue, item.purchaseValue);
                break;
            case Functionality.Food:
                record = new FoodItem(item.displayName, item.id, item.dimensions, "",
                    item.sellValue, item.purchaseValue, item.calories, item.healAmount, item.foodGroup);
                break;
            case Functionality.Drink:
                record = new DrinkItem(item.displayName, item.id, item.dimensions, "",
                    item.sellValue, item.purchaseValue, item.quenchAmount, item.alcoholProof);
                break;
            case Functionality.Health:
                record = new HealthItem(item.displayName, item.id, item.dimensions, "",
                    item.sellValue, item.purchaseValue, item.healAmount);
                break;
            case Functionality.AirFilter:
                record = new AirFilterItem(item.displayName, item.id, item.dimensions, "",
                    item.sellValue, item.purchaseValue, item.duration);
                break;
            case Functionality.Anomalous:
                record = new AnomalousItem(item.displayName, item.id, item.dimensions, "",
                    item.sellValue, item.purchaseValue, item.spiritualPower);
                break;
            case Functionality.Breedable:
                record = new BreedableItem(item.displayName, item.id, item.dimensions, "",
                    item.sellValue, item.purchaseValue, item.combinations, item.itemDrops, item.rarity);
                break;
            case Functionality.WeaponCamo:
                record = new WeaponCamoItem(item.displayName, item.id, item.dimensions, "",
                    item.sellValue, item.purchaseValue, item.weaponID, "");
                break;
        }

        return record;
    }
}
