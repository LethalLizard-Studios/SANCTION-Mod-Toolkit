using System.IO;
using UnityEngine;

[System.Serializable]
public class ItemRecord
{
    public string name;
    public uint id;
    public Vector2Int dimensions;
    public string texturePath;
    public float sellValue;
    public float purchaseValue;

    public string modPackName;
    public Texture2D texture;

    public ItemRecord(string name, uint id, Vector2Int dimensions, string texturePath,
        float sellValue, float purchaseValue)
    {
        this.name = name;
        this.id = id;
        this.dimensions = dimensions;
        this.texturePath = texturePath;
        this.sellValue = sellValue;
        this.purchaseValue = purchaseValue;
    }

    public Texture2D FetchTexture()
    {
        if (texture == null && !string.IsNullOrEmpty(texturePath))
        {
            byte[] fileData = File.ReadAllBytes(Application.dataPath+"/mods/"+modPackName+"/"+texturePath);

            texture = new Texture2D(256 * dimensions.x, 256 * dimensions.y);
            texture.LoadImage(fileData);
        }

        return texture;
    }
}
