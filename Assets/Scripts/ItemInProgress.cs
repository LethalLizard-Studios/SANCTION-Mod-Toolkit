using UnityEngine;

public class ItemInProgress : MonoBehaviour
{
    public ItemManager itemManager;

    private string _name;
    private uint _id;
    private Vector2Int _dimensions;
    private Texture2D _texture = null;

    public void SetTexture(Texture2D texture)
    {
        _texture = texture;
    }

    public void SetData(string name, uint id, Vector2Int dimensions)
    {
        _name = name;
        _id = id;
        _dimensions = dimensions;
    }

    public void BuildItem()
    {
        itemManager.items.Add(new ItemRecord(_name, _id, _dimensions, _texture));
        itemManager.SaveMod();
    }
}
