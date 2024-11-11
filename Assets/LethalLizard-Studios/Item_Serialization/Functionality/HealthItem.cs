/* All Rights Reserved to LethalLizard Studios
-- Created By: Leland T L Carter
-- DATE: 11/03/2024
*/

using UnityEngine;

[System.Serializable]
public class HealthItem : ItemRecord
{
    public uint HealAmount;

    public HealthItem(string name, uint id, Vector2Int dimensions, string texturePath,
        int sellValue, int purchaseValue, uint healAmount)
        : base(name, id, dimensions, texturePath, sellValue, purchaseValue)
    {
        this.HealAmount = healAmount;

        base.savedValue = healAmount;
        base.functionality = Functionality.Health;
    }
}