using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Workspace : MonoBehaviour
{
    [SerializeField] private ItemInProgress progress;
    [SerializeField] private GameObject modControllers;
    [SerializeField] private GameObject workspaceButtonPrefab;
    [SerializeField] private Transform buttonContent;

    [SerializeField] private Sprite missingSprite;

    void Start()
    {
        LoadWorkspaces();
    }

    private void LoadWorkspaces()
    {
        string[] workspaceFolders = Directory.GetDirectories(ModPath.HoldingDirectory);

        for (int i = 0; i < workspaceFolders.Length; i++)
        {
            DirectoryInfo dir = new DirectoryInfo(workspaceFolders[i]);
            string workspaceName = dir.Name;

            Sprite icon = SpriteBuilder.FromTexturePath("Thumbnail.png", workspaceName, new Vector2Int(1, 1));

            if (icon == null)
                icon = missingSprite;

            Transform button = Instantiate(workspaceButtonPrefab, buttonContent).transform;
            button.GetComponent<WorkspaceButton>().Setup(this, workspaceName, icon);
        }
    }

    public void StartWorkspace(string modpackName)
    {
        progress.currentModpack = modpackName;
        modControllers.SetActive(true);
        gameObject.SetActive(false);
    }

    public void CreateNewWorkspace(TMP_InputField input)
    {
        string newModName = input.text;

        if (string.IsNullOrEmpty(newModName))
            return;

        Directory.CreateDirectory(ModPath.HoldingDirectory+"/"+ newModName);
        Transform button = Instantiate(workspaceButtonPrefab, buttonContent).transform;
        button.GetChild(0).GetComponent<TextMeshProUGUI>().text = newModName;
        button.GetComponent<WorkspaceButton>().Setup(this, newModName, missingSprite);
    }
}
