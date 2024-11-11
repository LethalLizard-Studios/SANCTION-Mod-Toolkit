using UnityEngine;

public class WorkspaceButton : MonoBehaviour
{
    private Workspace _workspace;
    private string _modName;

    public void Setup(Workspace workspace, string modName)
    {
        _workspace = workspace;
        _modName = modName;
    }

    public void OnClick()
    {
        _workspace.StartWorkspace(_modName);
    }
}
