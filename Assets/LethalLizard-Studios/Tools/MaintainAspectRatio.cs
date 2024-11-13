/* All Rights Reserved to LethalLizard Studios
-- Created By: Leland T L Carter
-- DATE: 11/13/2024
*/

using UnityEngine;

public static class MaintainAspectRatio
{
    public static void UpdateSize(RectTransform rectTransform, Vector2Int dimensions, Vector2Int desiredDimensions)
    {
        float aspectRatio = (float)dimensions.x / dimensions.y;

        if (desiredDimensions.x > 0)
        {
            rectTransform.sizeDelta = new Vector2(desiredDimensions.x, desiredDimensions.x / aspectRatio);
        }
        else if (desiredDimensions.y > 0)
        {
            rectTransform.sizeDelta = new Vector2(desiredDimensions.y * aspectRatio, desiredDimensions.y);
        }
    }
}
