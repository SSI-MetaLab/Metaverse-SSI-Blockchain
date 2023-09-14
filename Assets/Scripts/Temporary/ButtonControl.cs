using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add this to use TextMeshPro

public class ButtonControl : MonoBehaviour
{
    public Button loadWalletButton;
    public Button readCertificateButton;
    public GameObject ConnectOptionsPanelGameobject;
    public GameObject ConnectWithNamePanelGameobject;    
    public GameObject LoadWalletGameobject;
    public GameObject ReadCertificateGameobject;
    public TextMeshProUGUI infoDisplay; // Use TextMeshProUGUI instead of Text

    private void Start()
    {
        // Initially disable all buttons except for the Load Wallet button
        loadWalletButton.interactable = true;
        ReadCertificateGameobject.SetActive(false);
        ConnectOptionsPanelGameobject.SetActive(false);
        ConnectWithNamePanelGameobject.SetActive(false);
    }

    public void LoadWallet()
    {
        // The loadWalletButton onClick() function
        // Enable the Read Certificate button
         LoadWalletGameobject.SetActive(false);
        ReadCertificateGameobject.SetActive(true);
        infoDisplay.text = "Wallet Loaded, \n 0x71c7656ec7ab88b098defb751b7401b5f6d8976f";
    }

    public void ReadCertificate()
    {
        // The readCertificateButton onClick() function
        // Enable the other two buttons
        ConnectOptionsPanelGameobject.SetActive(true);
        ConnectWithNamePanelGameobject.SetActive(true);
       
        ReadCertificateGameobject.SetActive(false);
        infoDisplay.text = "Certificate Read, Now you can access other options";
    }

    // Add corresponding functions for button3 and button4 as needed
}
