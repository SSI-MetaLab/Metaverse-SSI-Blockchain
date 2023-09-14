using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class TestObject : MonoBehaviour
{
    [SerializeField] private string serverUrl;
    private WebSocket webSocket;

    public void Start()
    {
        webSocket = new WebSocket(serverUrl);

        webSocket.OnOpen += (sender, e) =>
        {
            Debug.Log("WebSocket connected to the server");
            webSocket.Send("unity_client");
        };

        webSocket.OnMessage += (sender, e) =>
        {
            if (e.IsText)
            {
                if (e.Data.StartsWith("wallet_address:"))
                {
                    string walletAddress = e.Data.Split(':')[1];
                    Debug.Log("Wallet Address: " + walletAddress);
                }
            }
        };

        webSocket.OnClose += (sender, e) =>
        {
            Debug.Log("WebSocket disconnected from the server");
        };

        webSocket.ConnectAsync();
    }

    public void OnButtonClick()
    {
        if (webSocket.ReadyState == WebSocketState.Open)
        {
            webSocket.Send("unity_client");
        }
    }

    void OnDestroy()
    {
        if (webSocket != null)
        {
            webSocket.CloseAsync();
        }
    }
}
