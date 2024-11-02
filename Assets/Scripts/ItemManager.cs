using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject noItemsTutorial;

    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform contentHolder;

    [SerializeField] private MessagePopup messagePopup;

    public List<ItemRecord> items = new List<ItemRecord>();

    private List<GameObject> _itemViews = new List<GameObject>();

    private string savePath;

    private void Start()
    {
        savePath = Path.Combine(Application.dataPath+"/mods", "unamed_mod.mlf");

        LoadMod();
    }

    public void SaveMod()
    {
        using (FileStream fileStream = new FileStream(savePath, FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            List<ItemData> itemDataList = new List<ItemData>();

            ClearViewList();

            foreach (var item in items)
            {
                itemDataList.Add(new ItemData(item));

                ItemContentView contentView = Instantiate(itemPrefab, contentHolder).GetComponent<ItemContentView>();
                contentView.Build(item.name, item.id, item.texture);
            }

            formatter.Serialize(fileStream, itemDataList);
        }
    }

    private void ClearViewList()
    {
        for (int i = 0; i < _itemViews.Count; i++)
            Destroy(_itemViews[i]);
        _itemViews.Clear();
    }

    public void LoadMod()
    {
        if (File.Exists(savePath) && new FileInfo(savePath).Length > 0)
        {
            ClearViewList();

            using (FileStream fileStream = new FileStream(savePath, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                try
                {
                    List<ItemData> itemDataList = (List<ItemData>)formatter.Deserialize(fileStream);
                    items.Clear();

                    foreach (var itemData in itemDataList)
                    {
                        ItemRecord itemRecord = itemData.ToItem();

                        items.Add(itemRecord);

                        ItemContentView contentView = Instantiate(itemPrefab, contentHolder).GetComponent<ItemContentView>();
                        contentView.Build(itemRecord.name, itemRecord.id, itemRecord.texture);
                    }
                }
                catch (SerializationException ex)
                {
                    messagePopup.Show("Deserialization Error"
                        , "This could mean your .mlf mod file is corrupt." +
                        " Always make backups to import just incase.");
                }
            }
        }

        noItemsTutorial.SetActive(items.Count <= 0);
    }

    [System.Serializable]
    private class ItemData
    {
        public string name;
        public uint id;
        public int width;
        public int height;
        public byte[] textureData;

        public ItemData(ItemRecord item)
        {
            name = item.name;
            id = item.id;
            width = item.dimensions.x;
            height = item.dimensions.y;
            textureData = item.texture ? TextureToByteArray(item.texture) : null;
        }

        public ItemRecord ToItem()
        {
            Texture2D texture = ByteArrayToTexture(textureData, width * 512, height * 512);
            return new ItemRecord(name, id, new Vector2Int(width, height), texture);
        }

        private byte[] TextureToByteArray(Texture2D texture)
        {
            return texture.EncodeToPNG();
        }

        private Texture2D ByteArrayToTexture(byte[] data, int width, int height)
        {
            Texture2D texture = new Texture2D(width, height);
            texture.LoadImage(data);
            return texture;
        }
    }
}