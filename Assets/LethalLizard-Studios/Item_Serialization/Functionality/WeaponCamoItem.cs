/* All Rights Reserved to LethalLizard Studios
-- Created By: Leland T L Carter
-- DATE: 11/03/2024
*/

using UnityEngine;

[System.Serializable]
public class WeaponCamoItem : ItemRecord
{
    public uint WeaponID;
    public string MainTexturePath;

    public WeaponCamoItem(string name, uint id, Vector2Int dimensions, string texturePath,
        float sellValue, float purchaseValue, uint weaponID, string mainTexturePath) 
        : base(name, id, dimensions, texturePath, sellValue, purchaseValue)
    {
        this.WeaponID = weaponID;
        this.MainTexturePath = mainTexturePath;
    }
}
