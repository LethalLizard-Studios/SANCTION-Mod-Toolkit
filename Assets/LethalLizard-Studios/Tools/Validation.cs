/* All Rights Reserved to LethalLizard Studios
-- Created By: Leland T L Carter
-- DATE: 11/13/2024
*/

using TMPro;
using UnityEngine.UI;

public static class Validation
{
    public static bool CheckInputNullOrEmpty(TMP_InputField input)
    {
        bool isValid = true;

        if (string.IsNullOrEmpty(input.text))
        {
            SetErrorOutlineState(input, true);
            isValid = false;
        }

        return isValid;
    }

    public static bool CheckInputGreaterThan(TMP_InputField input, int value)
    {
        bool isValid = true;

        if (int.TryParse(input.text, out int inputValue))
        {
            if (inputValue <= value)
            {
                SetErrorOutlineState(input, true);
                isValid = false;
            }
        }
        else
        {
            SetErrorOutlineState(input, true);
            isValid = false;
        }

        return isValid;
    }

    public static bool CheckInputRange(TMP_InputField input, int minInclusive, int maxInclusive)
    {
        bool isValid = true;

        if (int.TryParse(input.text, out int value))
        {
            if (value < minInclusive || value > maxInclusive)
            {
                SetErrorOutlineState(input, true);
                isValid = false;
            }
        }
        else
        {
            SetErrorOutlineState(input, true);
            isValid = false;
        }

        return isValid;
    }

    public static void SetErrorOutlineState(TMP_InputField inputField, bool state)
    {
        inputField.GetComponent<Outline>().enabled = state;
    }
}
