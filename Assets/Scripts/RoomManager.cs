using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviourPunCallbacks
{

    private string mapType;
    public TextMeshProUGUI OccupancyRateText_Office_1;
    public TextMeshProUGUI OccupancyRateText_Office_2;
    public Button gobacktologin;

    // Start is called before the first frame update
    void Start() {   

 
        PhotonNetwork.AutomaticallySyncScene = true;

        if (!PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.ConnectUsingSettings();

        }
        else{
            PhotonNetwork.JoinLobby();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region UI Callback Methods 

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    // public void OnButtonClickedOffice1() 
    // {
    //     // mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_OFFICE1;
    //     ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() {
    //         {MultiplayerVRConstants.MAP_TYPE_KEY,mapType}
    //     };
    //     PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0 );

    // }
    public void OnButtonClickedOffice2()
    {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_OFFICE2;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() {
            {MultiplayerVRConstants.MAP_TYPE_KEY,mapType}
        };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0 );
    }
    #endregion

    #region Photon Callback Methods

    
    // public GameObject Canvas;
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message+ "message error");
        CreateAndJoinRoom();
        // Canvas.SetActive(false);
        
    }
    // Start is called before the first frame update

    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to server again. ");
        PhotonNetwork.JoinLobby();
    }
    

    public override void OnCreatedRoom()
    {
        Debug.Log("A room is created with the name: " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("The Local Player: " + PhotonNetwork.NickName + "Joined To " + PhotonNetwork.CurrentRoom.Name + " Player count " + PhotonNetwork.CurrentRoom.PlayerCount);

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(MultiplayerVRConstants.MAP_TYPE_KEY)) {
            object mapType; 
            if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue(MultiplayerVRConstants.MAP_TYPE_KEY, out mapType)) {
                Debug.Log("Joined room with the map:" + (string)mapType);
                // if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_OFFICE1) {
                //     //load maptype office1
                //     PhotonNetwork.LoadLevel("Office1");
                // } else 
                if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_OFFICE2 ){
                    //Load Office 2
                    PhotonNetwork.LoadLevel("Office2");
                }
            }
        }
    }
    public void BackToLoginScene()
    {
        // Leave the room
        PhotonNetwork.LeaveRoom();

        // Go back to Login Scene
        SceneManager.LoadScene("LoginScene");
    }
 
     public override void OnLeftRoom()
    {
        // This callback function will be triggered when successfully left the room
        Debug.Log("Successfully left the room.");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) 
    {
        Debug.Log(newPlayer.NickName+ " Player count: " + PhotonNetwork.CurrentRoom.PlayerCount);    
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList) 
    {
        if (roomList.Count== 0) 
        {
            // OccupancyRateText_Office_1.text = 0+"/" +20;
            OccupancyRateText_Office_2.text = 0+"/" +20;
        }

        foreach (RoomInfo room in roomList) 
        {
            Debug.Log(room.Name);
            // if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_OFFICE1)) {
            //     Debug.Log("Room is a Office_2. Player Count is: "+ room.PlayerCount);
            //     OccupancyRateText_Office_1.text = room.PlayerCount + " / " + 20;
            // }else 
            if(room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_OFFICE2)) {
                Debug.Log("Room is a Office_2. Player Count is: "+ room.PlayerCount);
                OccupancyRateText_Office_2.text = room.PlayerCount + " / " + 20;
            }
        }
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined the lobby!");
    }
    #endregion 

    #region Private Methods
    private void CreateAndJoinRoom()
    {
        string randomRoomName = "Room_" + mapType + Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;

        string[] roomPropsInLobby = {MultiplayerVRConstants.MAP_TYPE_KEY};

        ExitGames.Client.Photon.Hashtable customRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
        roomOptions.CustomRoomPropertiesForLobby = roomPropsInLobby;
        roomOptions.CustomRoomProperties = customRoomProperties;
        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
    }

    #endregion
   
}
