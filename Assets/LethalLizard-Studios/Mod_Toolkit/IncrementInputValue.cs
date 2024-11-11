using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_InputField))]
public class IncrementInputValue : MonoBehaviour
{
    private TMP_InputField _inputField;

    private void Awake()
    {
        _inputField = GetComponent<TMP_InputField>();
    }

    public void Activate()
    {
        if (_inputField.text.Length <= 0)
            return;

        int value = int.Parse(_inputField.text);
        value += 1;

        _inputField.text = value.ToString();
    }
}
