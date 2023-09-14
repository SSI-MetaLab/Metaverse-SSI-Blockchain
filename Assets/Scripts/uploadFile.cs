using System.IO;
using System.Text.RegularExpressions; // Add this line to use Regex
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uploadFile : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private string fileName;
    public GameObject ConnectOptionsPanelGameobject;
    public GameObject ConnectWithNamePanelGameobject;
    public GameObject ReadFile_Canvas;

    [System.Serializable]
    public class JSONData
    {
        public string title;
        public string description;
        public string address; // added this line
    }
//comment this section later
    void Start()
    {
        ConnectOptionsPanelGameobject.SetActive(false);
        ConnectWithNamePanelGameobject.SetActive(false);
    }

    public void makeButtonsVisible()
    {
        // ConnectOptionsPanelGameobject.SetActive(true);
        // ConnectWithNamePanelGameobject.SetActive(false);
        ReadFile_Canvas.SetActive(false);
    }

    public void ReadFile()
    {
        ReadAndDisplayJSON();
    }

    private bool IsValidEthereumAddress(string address)
    {
        if (address.Length != 42) return false;
        if (!address.StartsWith("0x")) return false;

        const string hexPattern = @"\A\b[0-9a-fA-F]+\b\Z";

        Regex rgx = new Regex(hexPattern);

        string remainingCharacters = address.Substring(2);

        if (rgx.IsMatch(remainingCharacters)) return true;
        else return false;
    }

    public void ReadAndDisplayJSON()
    {
        string filePath = "C:/Users/ayueb/Desktop/AronFolder/Testing_Reading_Json_File_From_Oculus/data.json";
        string jsonData = File.ReadAllText(filePath);
        JSONData data = JsonUtility.FromJson<JSONData>(jsonData);

        // Check if the address from the JSON file is valid
        if (!IsValidEthereumAddress(data.address))
        {
            textMeshPro.text = "The provided address is not valid.";
            return;
        }


        UpdateTextMeshPro(data);
        Debug.Log("JSON data: " + jsonData);

        // Call makeButtonsVisible here since the address is valid
        if (IsValidEthereumAddress(data.address))
        {makeButtonsVisible();};
    }

    private void UpdateTextMeshPro(JSONData data)
    {
        textMeshPro.text = $"Address: {data.address}";
    }

}
