using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;

public class LoginManger : MonoBehaviourPunCallbacks
{
    public TMP_InputField PlayerName_InputName;
    public TextMeshProUGUI myTextField; 
    public TextMeshProUGUI infoDisplay; 
    public Button JoinWithOldNameButton;
    public Button JoinWithNewNameButton;

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
            infoDisplay.text = $"Address is a valid entity. Proceed to join MetaVerse.\n Do you want to connect with existing name: {savedName}?";
        }
        else
        {
            JoinWithOldNameButton.gameObject.SetActive(false);
            infoDisplay.text = "No saved name found for you. Please connect with a new name or connect anonymously.";
        }
    }

    #region UI Callback Methods

    public void ConnectAnonymously()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void ConnectToPhotonServerWithOldName() 
    {
        string savedName = PlayerPrefs.GetString(eventNamePrefKey, string.Empty);

        if (!string.IsNullOrEmpty(savedName))
        {
            PhotonNetwork.NickName = savedName;
            PhotonNetwork.ConnectUsingSettings();    
        }
        else
        {
            infoDisplay.text = "No saved name found. Please connect with a new name.";
        }
    }

    public void ConnectToPhotonServerWithNewName() 
    {   
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
            infoDisplay.text = "Please enter a valid name.";
        }
    }

    #endregion

    #region Photon Callback Methods

    public override void OnConnectedToMaster()
    {
        myTextField.text = "office load invoked";
        Debug.Log("Connected to Master Server with player name! "+ PhotonNetwork.NickName);
        PhotonNetwork.LoadLevel("MainOffice");
        myTextField.text = "office load invoked";
    }

    public override void OnConnected()
    {
        Debug.Log("OnConnected is called. The server is available!");
    }

    #endregion
}


// public class LoginManger : MonoBehaviourPunCallbacks
// {
//     public TMP_InputField PlayerName_InputName;
//     public TextMeshProUGUI myTextField; // The reference to your TextMeshPro component

//     private string eventNamePrefKey = "EventName"; // Declare and assign a value to this variable

//     #region Unity Methods
//     // Start is called before the first frame update
//     void Start()
//     {
//         // PhotonNetwork.ConnectUsingSettings();
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
//     #endregion

//     #region UI Callback Methods
//     public void ConnectAnonymously()
//     {
//         PhotonNetwork.ConnectUsingSettings();
//         // This method will be called when the button is clicked
//         // myTextField.text = "code tested mandem"; // Change the text
//     }

//     public void ConnectToPhotonServer() 
//     {
//         string savedName = PlayerPrefs.GetString(eventNamePrefKey); // Set savedName here
//         Debug.Log(eventNamePrefKey);

//         if (!string.IsNullOrEmpty(savedName)) // Use lowercase 'string'
//         {
//             PhotonNetwork.NickName = savedName;
//             PhotonNetwork.ConnectUsingSettings(); 
//             Debug.Log("printed SAved name");
//             Debug.Log("!string.IsNullOrEmpty(savedName) is called") ;    
//         }
//         else 
//         {
//             if(!string.IsNullOrEmpty(PlayerName_InputName.text))
//             {
//             PhotonNetwork.NickName = PlayerName_InputName.text;
//             PlayerPrefs.SetString("eventNamePrefKey", PlayerName_InputName.text);
//             PlayerPrefs.Save();
//             PhotonNetwork.ConnectUsingSettings(); 
//             Debug.Log("below function is called");
//             }
//         }
        
//     }
//     #endregion

//     #region Photon Callback Methods
//     public override void OnConnected()
//     {
//        Debug.Log("OnConnected is called. The server is available!");
//     }

//     public override void OnConnectedToMaster()
//     {
//         myTextField.text = "office load invoked";
//         Debug.Log("Connected to Master Server with player name! "+ PhotonNetwork.NickName);
//         PhotonNetwork.LoadLevel("MainOffice");
//         myTextField.text = "office load invoked";
//     }
//     #endregion
// }

// public class LoginManger : MonoBehaviourPunCallbacks
// {
//     public TMP_InputField PlayerName_InputName;
//     public TextMeshProUGUI myTextField; 
//     public TextMeshProUGUI infoDisplay; 
//     public Button JoinWithOldNameButton;
//     public Button JoinWithNewNameButton;

    

//     private string eventNamePrefKey = "EventName";

//     // void Start()
//     // {
//     //     CheckPreviousName();
//     // }

//     #region UI Callback Methods

//     public void ConnectAnonymously()
//     {
//         PhotonNetwork.ConnectUsingSettings();
//     }

//     // public void ConnectToPhotonServer() 
//     // {
//     //     string savedName = PlayerPrefs.GetString(eventNamePrefKey);
//     //     Debug.Log(eventNamePrefKey);

//     //     if (!string.IsNullOrEmpty(savedName))
//     //     {
//     //         Debug.Log("User has a saved name: " + savedName);
//     //         PhotonNetwork.NickName = savedName;
//     //         PhotonNetwork.ConnectUsingSettings();    
//     //     }
//     //     else if (!string.IsNullOrEmpty(PlayerName_InputName.text))
//     //     {
//     //         Debug.Log("User does not have a saved name. Creating new name: " + PlayerName_InputName.text);
//     //         PhotonNetwork.NickName = PlayerName_InputName.text;
//     //         PlayerPrefs.SetString(eventNamePrefKey, PlayerName_InputName.text);
//     //         PlayerPrefs.Save();
//     //         Debug.Log("Saving user name: " + PlayerName_InputName.text);
//     //         PhotonNetwork.ConnectUsingSettings(); 
//     //     }
//     //     else
//     //     {
//     //         Debug.Log("PlayerName_InputName.text is empty or null.");
//     //     }
//     // }
//     private int connectionState = 0;

//     public void ConnectToPhotonServerWithOldName() 
//     {
//         string savedName = PlayerPrefs.GetString(eventNamePrefKey);
//         Debug.Log(eventNamePrefKey);

//         switch (connectionState)
//         {
//             case 0:
//                 if (!string.IsNullOrEmpty(savedName))
//                 {
//                     infoDisplay.text = $"Address is a valid entity. Proceed to join MetaVerse.\n Do you want to connect with existing name: {savedName}?";   
//                     connectionState = 1;
//                 }
//                 else
//                 {
//                     Debug.Log("No saved name found for the user.");
//                     infoDisplay.text = "No saved name found for you. Please connect with a new name.";
//                     connectionState = 0; // Reset or handle accordingly.
//                 }
//                 break;
            
//             case 1:
//                 if (!string.IsNullOrEmpty(savedName)){
//                     infoDisplay.text = $"User has a saved name: {savedName}";
//                     Debug.Log(savedName);
//                     PhotonNetwork.NickName = savedName;
//                     PhotonNetwork.ConnectUsingSettings();    
//                     connectionState = 0; // Reset the state after connection.
//                 }
//                 else{
//                     infoDisplay.text = "Please, the saved name is empty so preceed with new name";
//                 }
//                 break;

//             default:
//                 Debug.LogError("Unexpected connectionState value.");
//                 break;
//         }
//     }

//     public void ConnectToPhotonServerWithNewName() 
//     {   
//         JoinWithOldNameButton.gameObject.SetActive(false); // Corrected this line
//         JoinWithNewNameButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 16.4f);

//         // Activate the PlayerName_InputName and set its properties.
//         PlayerName_InputName.gameObject.SetActive(true); // makes it active
       

//         // Proceed with the logic for connecting using the new name.
//         if (!string.IsNullOrEmpty(PlayerName_InputName.text))
//         {
//             Debug.Log("User does not have a saved name. Creating new name: " + PlayerName_InputName.text);
//             PhotonNetwork.NickName = PlayerName_InputName.text;
//             PlayerPrefs.SetString(eventNamePrefKey, PlayerName_InputName.text);
//             PlayerPrefs.Save();
//             Debug.Log("Saving user name: " + PlayerName_InputName.text);
//             PhotonNetwork.ConnectUsingSettings(); 
//         }
//         else
//         {
//             Debug.Log("Player Name is empty.");
//         }
//     }


//     #endregion

//     #region Photon Callback Methods

//     public override void OnConnectedToMaster()
//     {
//         myTextField.text = "office load invoked";
//         Debug.Log("Connected to Master Server with player name! "+ PhotonNetwork.NickName);
//         PhotonNetwork.LoadLevel("MainOffice");
//         myTextField.text = "office load invoked";
//     }

//     // If "OnConnected" is not the correct callback, this may throw an error
//     public override void OnConnected()
//     {
//         Debug.Log("OnConnected is called. The server is available!");
//     }

//     #endregion

    // #region Helper Methods

    // private void CheckPreviousName()
    // {
    //     string savedName = PlayerPrefs.GetString(eventNamePrefKey);
    //     if (!string.IsNullOrEmpty(savedName))
    //     {
            // infoDisplay.text = $"Do you want to connect with existing name {savedName}?";
    //     }
    // }

    // private IEnumerator ConnectWithSavedName(string savedName)
    // {
    //     PhotonNetwork.NickName = savedName;
    //     yield return new WaitForSeconds(0.1f);
    //     PhotonNetwork.ConnectUsingSettings();    
    // }

    // private IEnumerator ConnectWithNewName(string newName)
    // {
    //     PhotonNetwork.NickName = newName;
    //     PlayerPrefs.SetString(eventNamePrefKey, newName);
    //     yield return new WaitForSeconds(0.1f);
    //     PhotonNetwork.ConnectUsingSettings();
    // }

    // #endregion
// }
