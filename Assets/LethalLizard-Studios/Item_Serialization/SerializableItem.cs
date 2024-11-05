/* All Rights Reserved to LethalLizard Studios
-- Created By: Leland T L Carter
-- DATE: 11/03/2024
*/

using UnityEngine;

[System.Serializable]
public class SerializableItem
{
    public string ItemJson;
    public string ItemFunctionality;

    public SerializableItem(ItemRecord item)
    { 
        ItemJson = JsonUtility.ToJson(item);
        ItemFunctionality = item.GetType().AssemblyQualifiedName;
    }
}