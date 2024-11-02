using UnityEngine;

[System.Serializable]
public class ItemRecord
{
    public string name;
    public uint id;
    public Vector2Int dimensions;
    public Texture2D texture;

    public ItemRecord(string name, uint id, Vector2Int dimensions, Texture2D texture)
    {
        this.name = name;
        this.id = id;
        this.dimensions = dimensions;
        this.texture = texture;
    }
}
