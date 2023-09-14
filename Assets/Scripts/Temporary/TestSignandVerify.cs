using UnityEngine;
using Nethereum.Util;
using Nethereum.Signer;
using System;
using Nethereum.Hex.HexConvertors.Extensions;

public class TestSignandVerify : MonoBehaviour
{
    private void Start()
    {
        string originalMessage = "Random Message";
        var message = originalMessage;

        // Replace with the base64 signature generated from the Dart code.
        var signedMessageBase64 = "jJIWZ/t+4BkewnZiCptUxdgeBDifn5eRUPZ9ArIHZhNqPxY50QQx3fgCE5fPb1MbIHrUheqS4Bl9IH6JFVRYSBw=";
        
        var signedMessageBytes = Convert.FromBase64String(signedMessageBase64);
        var signedMessage = signedMessageBytes.ToHex();

        var signer = new EthereumMessageSigner();
        var addressRecovered = signer.EncodeUTF8AndEcRecover(message, signedMessage).ToLower();
        var expectedAddress = "0x89eb58bc7229a397696ade51e369aa6b4d7123ca";
        Debug.Log(addressRecovered);

        if (addressRecovered == expectedAddress)
        {
            Debug.Log("Signature is valid");
        }
        else
        {
            Debug.Log("Signature is not valid");
        }
    }
}
