using TMPro;
using UnityEngine;

public class qrScanner : MonoBehaviour 
{
    public TextMeshProUGUI infoDisplay;

    private void Update()
    {
        string clipboardText = GUIUtility.systemCopyBuffer;

        // If there is text in the clipboard, display it in the TextMeshProUGUI
        if (!string.IsNullOrEmpty(clipboardText))
        {
            infoDisplay.text = $"Copied From ClipBoard\n{clipboardText}";
        }
        else
        {
            Debug.LogError("No text in the clipboard!");
            infoDisplay.text = "No text in the clipboard!";
        }
    }
}
