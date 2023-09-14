
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using Photon.Realtime; // Added for DisconnectCause
public class loginManagerpermanent : MonoBehaviourPunCallbacks
{
    public TMP_InputField PlayerName_InputName;
    public TextMeshProUGUI myTextField;
    public TextMeshProUGUI infoDisplay;
    public Button JoinWithOldNameButton;
    public Button JoinWithNewNameButton;
    public Button connectAnonumsly;

    private string eventNamePrefKey = "EventName";

    private void Start()
    {
        CheckAndHandleSavedName();
    }

    private void CheckAndHandleSavedName()
    {
        string savedName = PlayerPrefs.GetString(eventNamePrefKey, string.Empty);

        if (!string.IsNullOrEmpty(savedName))
        {
            infoDisplay.text = $"WellCome back: {savedName}";
        }
        else
        {
            JoinWithOldNameButton.gameObject.SetActive(false);
            infoDisplay.text = "No saved name found for you. Please connect with a new name or connect anonymously.";
        }
    }

    // Utility function to disable all UI elements while connecting
    private void DisableUI()
    {
        PlayerName_InputName.gameObject.SetActive(false);
        JoinWithOldNameButton.gameObject.SetActive(false);
        JoinWithNewNameButton.gameObject.SetActive(false);
        connectAnonumsly.gameObject.SetActive(false);
    }

    // Utility function to enable all UI elements if needed (when connection fails, etc.)
    private void EnableUI()
    {
        PlayerName_InputName.gameObject.SetActive(true);
        JoinWithOldNameButton.gameObject.SetActive(true);
        JoinWithNewNameButton.gameObject.SetActive(true);
        connectAnonumsly.gameObject.SetActive(true);
    }

    #region UI Callback Methods

    public void ConnectAnonymously()
    {
            Debug.Log("ConnectAnonymously called");

        DisableUI();
        infoDisplay.text = "Loading wait a Sec ...";
        PhotonNetwork.ConnectUsingSettings();
    }

    public void ConnectToPhotonServerWithOldName()
    {
        DisableUI();
        infoDisplay.text = "Loading wait a Sec ...";
        string savedName = PlayerPrefs.GetString(eventNamePrefKey, string.Empty);

        if (!string.IsNullOrEmpty(savedName))
        {
            PhotonNetwork.NickName = savedName;
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            EnableUI();
            infoDisplay.text = "No saved name found. Please connect with a new name.";
        }
    }

    public void ConnectToPhotonServerWithNewName()
    {
            Debug.Log("ConnectToPhotonServerWithOldName called");

        DisableUI();
        infoDisplay.text = "Loading wait a Sec ...";
        string newName = PlayerName_InputName.text.Trim();

        if (!string.IsNullOrEmpty(newName))
        {
            PhotonNetwork.NickName = newName;
            PlayerPrefs.SetString(eventNamePrefKey, newName);
            PlayerPrefs.Save();
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            EnableUI();
            infoDisplay.text = "Please enter a valid name.";
        }
    }

    #endregion

    #region Photon Callback Methods

    public override void OnConnectedToMaster()
    {
        myTextField.text = "office load invoked";
        Debug.Log("Connected to Master Server with player name! " + PhotonNetwork.NickName);
        PhotonNetwork.LoadLevel("MainOffice");
        myTextField.text = "office load invoked";
    }

    public override void OnConnected()
    {
        Debug.Log("OnConnected is called. The server is available!");
    }

    // Handle connection failure to re-enable UI and inform the user
    public override void OnDisconnected(DisconnectCause cause)
    {
        EnableUI();
        infoDisplay.text = $"Disconnected. Reason: {cause.ToString()}";
    }

    #endregion
}
