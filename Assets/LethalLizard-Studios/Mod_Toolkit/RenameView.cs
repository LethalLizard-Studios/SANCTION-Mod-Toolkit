/* All Rights Reserved to LethalLizard Studios
-- Created By: Leland T L Carter
-- DATE: 11/13/2024
*/

using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class RenameView : MonoBehaviour
{
    [SerializeField] private UnityEvent onRename;

    [SerializeField] private TMP_InputField renameInput;

    public void SetInputText(string text)
    {
        renameInput.text = text;
    }

    public void ClosePrompt()
    {
        gameObject.SetActive(false);
    }

    public void SubmitPrompt()
    {
        onRename.Invoke();
    }
}
