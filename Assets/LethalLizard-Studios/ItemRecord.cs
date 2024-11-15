using UnityEngine;

[System.Serializable]
public class ItemRecord
{
    public string name;
    public uint ID;
    public Vector2Int dimensions;
    public string texturePath;
    public int sellValue;
    public int purchaseValue;

    public int rarity = -1;

    public uint savedValue = 0;

    public Vector2Int merchantID = new Vector2Int(-1, -1); // x = merchant, y = required reputation
    public Vector2Int lootID = new Vector2Int(-1, -1); // x = loot ID, y = loot chance (%)

    public string modPackName;
    public Sprite icon;

    public Functionality functionality;

    public ItemRecord(string name, uint id, Vector2Int dimensions, string texturePath,
        int sellValue, int purchaseValue)
    {
        this.name = name;
        this.ID = id;
        this.dimensions = dimensions;
        this.texturePath = texturePath;
        this.sellValue = sellValue;
        this.purchaseValue = purchaseValue;

        functionality = Functionality.Basic;
    }

    public Sprite FetchTexture()
    {
        if (icon == null)
        {
            return SpriteBuilder.FromTexturePath(texturePath, modPackName, dimensions);
        }

        return null;
    }
}