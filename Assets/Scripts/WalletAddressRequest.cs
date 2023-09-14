using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class WalletAddressRequest : MonoBehaviour
{
    [SerializeField] private string serverUrl;


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GetWalletAddress());
        }
    }

    public IEnumerator GetWalletAddress()
    {
        WWWForm form = new WWWForm();
        // Add any necessary data to the form

        using (UnityWebRequest www = UnityWebRequest.Post(serverUrl, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string walletAddress = www.downloadHandler.text;
                Debug.Log("Wallet Address: " + walletAddress);
                // Use the walletAddress here
            }
        }
    }
}
