/* All Rights Reserved to LethalLizard Studios
-- Created By: Leland T L Carter
-- DATE: 11/03/2024
*/

using UnityEngine;

[System.Serializable]
public class DrinkItem : ItemRecord
{
    public uint QuenchAmount;
    public uint AlcoholProof;

    public DrinkItem(string name, uint id, Vector2Int dimensions, string texturePath,
        float sellValue, float purchaseValue, uint quenchAmount, uint alcoholProof) 
        : base(name, id, dimensions, texturePath, sellValue, purchaseValue)
    {
        this.QuenchAmount = quenchAmount;
        this.AlcoholProof = alcoholProof;
    }
}
