using System.Collections.Generic;
using UnityEngine;

public enum Functionality
{
    Basic,
    Food,
    Drink,
    Health,
    AirFilter,
    Anomalous,
    Breedable,
    WeaponCamo
}

[CreateAssetMenu(fileName = "It_", menuName = "Item/ScriptableItem", order = 1)]
public class ScriptableItem : ScriptableObject
{
    public string displayName;
    public uint id;
    public Vector2Int dimensions;
    public Texture2D texture;
    public float sellValue;
    public float purchaseValue;

    public Functionality functionality;

    //FOOD
    public uint calories;
    public FoodGroup foodGroup;

    //DRINK
    public uint quenchAmount;
    public uint alcoholProof;

    //HEALTH
    public uint healAmount;

    //AIR FILTER
    public uint duration;

    //ANOMALOUS
    public uint spiritualPower;

    //BREEDABLE
    public List<Vector2Int> combinations;
    public List<uint> itemDrops;
    public Rarity rarity;

    //WEAPON CAMO
    public uint weaponID;
    public Texture2D mainTexture;
}
