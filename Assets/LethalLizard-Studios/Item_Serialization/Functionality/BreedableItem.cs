/* All Rights Reserved to LethalLizard Studios
-- Created By: Leland T L Carter
-- DATE: 11/03/2024
*/

using System.Collections.Generic;
using UnityEngine;

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    Anomalous,
    Unique
}

[System.Serializable]
public class BreedableItem : ItemRecord
{
    public List<Vector2Int> Combinations;
    public List<uint> ItemDrops;
    public Rarity Rarity;

    public BreedableItem(string name, uint id, Vector2Int dimensions, string texturePath,
        float sellValue, float purchaseValue, List<Vector2Int> combinations, List<uint> itemDrops, Rarity rarity) 
        : base(name, id, dimensions, texturePath, sellValue, purchaseValue)
    {
        this.Combinations = combinations;
        this.ItemDrops = itemDrops;
        this.Rarity = rarity;
    }
}
