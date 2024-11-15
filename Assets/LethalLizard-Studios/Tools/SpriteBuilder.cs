using System.IO;
using UnityEngine;

public static class SpriteBuilder
{
    public static Sprite FromTexturePath(string texturePath, string modPackName, Vector2Int dimensions)
    {
        Texture2D texture = null;

        if (!string.IsNullOrEmpty(texturePath))
        {
            try
            {
                string filePath = Application.dataPath + "/mods/" + modPackName + "/" + texturePath;
                byte[] fileData = File.ReadAllBytes(filePath);

                texture = new Texture2D(256 * dimensions.x, 256 * dimensions.y);
                texture.LoadImage(fileData);
            }
            catch (System.IO.FileNotFoundException ex)
            {

            }
            catch (System.UnauthorizedAccessException ex)
            {
                MessagePopup.Instance.Show("Error", "Access Denied: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                MessagePopup.Instance.Show("Error", "Reading the file: " + ex.Message);
            }
        }

        if (texture != null)
            return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        else
            return null;
    }
}
