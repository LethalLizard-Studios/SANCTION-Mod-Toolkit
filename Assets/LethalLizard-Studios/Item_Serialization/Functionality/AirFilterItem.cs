/* All Rights Reserved to LethalLizard Studios
-- Created By: Leland T L Carter
-- DATE: 11/03/2024
*/

using UnityEngine;

[System.Serializable]
public class AirFilterItem : ItemRecord
{
    public uint Duration;

    public AirFilterItem(string name, uint id, Vector2Int dimensions, string texturePath,
        float sellValue, float purchaseValue, uint duration) 
        : base(name, id, dimensions, texturePath, sellValue, purchaseValue)
    {
        this.Duration = duration;
    }
}
