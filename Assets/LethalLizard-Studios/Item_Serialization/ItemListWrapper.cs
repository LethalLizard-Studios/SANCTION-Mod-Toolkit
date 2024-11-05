/* All Rights Reserved to LethalLizard Studios
-- Created By: Leland T L Carter
-- DATE: 11/03/2024
*/

using System.Collections.Generic;

[System.Serializable]
public class ItemListWrapper
{
    public List<SerializableItem> Items;

    public ItemListWrapper(List<SerializableItem> items)
    {
        this.Items = items;
    }
}
