using System.Collections.Generic;
using UnityEngine;
using B83.Win32;
using UnityEngine.UI;
using System.IO;


public class FileDragAndDrop : MonoBehaviour
{
    [SerializeField] private ItemInProgress itemInProgress;

    public GameObject dragMenu;
    public GameObject previewMenu;

    public RawImage previewImage;

    Texture2D texture;
    DropInfo dropInfo = null;

    class DropInfo
    {
        public string file;
        public Vector2 pos;
    }

    void OnEnable ()
    {
        // must be installed on the main thread to get the right thread id.
        UnityDragAndDropHook.InstallHook();
        UnityDragAndDropHook.OnDroppedFiles += OnFiles;
    }
    void OnDisable()
    {
        UnityDragAndDropHook.UninstallHook();
    }

    void OnFiles(List<string> aFiles, POINT aPos)
    {
        string file = "";

        // scan through dropped files and filter out supported image types
        foreach (var f in aFiles)
        {
            var fi = new System.IO.FileInfo(f);
            var ext = fi.Extension.ToLower();
            if (ext == ".png")
            {
                file = f;
                break;
            }
        }

        // If the user dropped a supported file, create a DropInfo
        if (file != "")
        {
            var info = new DropInfo
            {
                file = file,
                pos = new Vector2(aPos.x, aPos.y)
            };
            dropInfo = info;

            LoadImage(dropInfo);
        }
    }

    void LoadImage(DropInfo aInfo)
    {
        if (aInfo == null)
            return;

        var data = System.IO.File.ReadAllBytes(aInfo.file);
        var tex = new Texture2D(1, 1);
        tex.LoadImage(data);

        texture = tex;

        previewImage.texture = texture;
        itemInProgress.SetTexture(Path.GetFileName(aInfo.file));

        previewMenu.SetActive(true);
        dragMenu.SetActive(false);
    }
}
