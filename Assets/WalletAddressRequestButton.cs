using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class WalletAddressRequestButton : MonoBehaviour
{
    [SerializeField] private string serverUrl;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(GetWalletAddress);
    }

    public void GetWalletAddress()
    {
        StartCoroutine(GetWalletAddressCoroutine());
    }

    private IEnumerator GetWalletAddressCoroutine()
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
