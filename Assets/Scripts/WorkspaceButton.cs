using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkspaceButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image iconImage;

    private Workspace _workspace;
    private string _modName;

    public void Setup(Workspace workspace, string modName, Sprite icon)
    {
        _workspace = workspace;
        _modName = modName;

        nameText.text = modName;
        iconImage.sprite = icon;
    }

    public void OnClick()
    {
        _workspace.StartWorkspace(_modName);
    }
}
