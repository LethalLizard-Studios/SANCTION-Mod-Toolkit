using UnityEngine;
using UnityEngine.Events;

/* All rights reserved to Leland T Carter of LethalLizard Studios.
 * @status COMPLETE
 * @date 2024-07-11
*/

public enum Functionality
{
    Basic,
    Ammo,
    Health,
    Food,
    Drink,
    Weapon,
    Attachment,
    SprayPaint,
    AirFilter,
    Breedable,
    Anomalous
}

public enum Rarity
{
    None,
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    Anomalous,
    Unique
}

public enum SoundGroup
{
    Generic,
    Bottle,
    Bag,
    Cloth,
    LooseMetal,
    Can,
    Bug
}

[CreateAssetMenu(fileName = "It_", menuName = "Items/ItemObject", order = 1)]
public class ScriptableItem : ScriptableObject
{
    public string displayName;
    public int ID;

    public Vector2 merchantID = new Vector2(-1, -1);

    [Space(8)]
    public Functionality functionality = Functionality.Basic;

    public ScriptableNutrition nutrition;
    public Rarity rarity = Rarity.None;

    public int useAmount = 0;
    public int sellValue = 1;
    public int costValue = 0;
    public GameObject[] contextOptions = new GameObject[0];

    [Header("SFX")]
    public SoundGroup soundGroup;

    [Header("UI")]
    public Vector2 dimensions = new Vector2();
    public Sprite icon;

    public UnityEvent onEquip;
}