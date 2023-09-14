using UnityEngine;
using Nethereum.Util;
using Nethereum.Signer;
using System;
using Nethereum.Hex.HexConvertors.Extensions;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Threading.Tasks;
using System.Numerics;
using Nethereum.Web3;
using Nethereum.Contracts;
using System.Linq;
using Nethereum.ABI.FunctionEncoding.Attributes;




[FunctionOutput]
public class EntityDetails
{
    [Parameter("string", "SignedMessage", 1)]
    public string SignedMessage { get; set; }

    [Parameter("address", "issuer", 2)]
    public string Issuer { get; set; }

    [Parameter("string", "issueDate", 3)]
    public string IssueDate { get; set; }

    [Parameter("string", "expiryDate", 4)]
    public string ExpiryDate { get; set; }
}



public class VerifyUser : MonoBehaviour
{
    public RoomManager roomManager;

    // UI elements
    public TMP_InputField eventNameInput;
    public Button fetchButton;
    public Button verifyNeworOld;
    public Button backButton;
    public Button resetUIButton;
    public Button gobacktologin;
    public TextMeshProUGUI infoDisplay;

    
    private string signedMessageFromBlockchain;
    private string issuerAddress;

    private string abi = @"[
	{
		'inputs': [],
		'stateMutability': 'nonpayable',
		'type': 'constructor'
	},
	{
		'inputs': [
			{
				'internalType': 'string',
				'name': '_certificateName',
				'type': 'string'
			}
		],
		'name': 'addCertificate',
		'outputs': [
			{
				'internalType': 'string',
				'name': '',
				'type': 'string'
			}
		],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'string',
				'name': '_pubKey',
				'type': 'string'
			},
			{
				'internalType': 'string',
				'name': '_username',
				'type': 'string'
			}
		],
		'name': 'addEntity',
		'outputs': [
			{
				'internalType': 'string',
				'name': '',
				'type': 'string'
			}
		],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'address',
				'name': '_trustedEntity',
				'type': 'address'
			}
		],
		'name': 'addTrustedEntity',
		'outputs': [
			{
				'internalType': 'string',
				'name': '',
				'type': 'string'
			}
		],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'inputs': [],
		'name': 'contractName',
		'outputs': [
			{
				'internalType': 'string',
				'name': '',
				'type': 'string'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [],
		'name': 'deleteEntity',
		'outputs': [],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'uint256',
				'name': '',
				'type': 'uint256'
			}
		],
		'name': 'entityList',
		'outputs': [
			{
				'internalType': 'address',
				'name': '',
				'type': 'address'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'address',
				'name': '_entityAddress',
				'type': 'address'
			},
			{
				'internalType': 'string',
				'name': '_certificateName',
				'type': 'string'
			}
		],
		'name': 'getEntityDetails',
		'outputs': [
			{
				'internalType': 'string',
				'name': '',
				'type': 'string'
			},
			{
				'internalType': 'address',
				'name': '',
				'type': 'address'
			},
			{
				'internalType': 'string',
				'name': '',
				'type': 'string'
			},
			{
				'internalType': 'string',
				'name': '',
				'type': 'string'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'address',
				'name': '_address',
				'type': 'address'
			}
		],
		'name': 'isEntity',
		'outputs': [
			{
				'internalType': 'bool',
				'name': '',
				'type': 'bool'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [],
		'name': 'owner',
		'outputs': [
			{
				'internalType': 'address',
				'name': '',
				'type': 'address'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'string',
				'name': '_certificateName',
				'type': 'string'
			}
		],
		'name': 'removeCertificate',
		'outputs': [],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'string',
				'name': '_certificateName',
				'type': 'string'
			},
			{
				'internalType': 'string',
				'name': '_SignedMessage',
				'type': 'string'
			},
			{
				'internalType': 'address',
				'name': '_entityAddress',
				'type': 'address'
			},
			{
				'internalType': 'string',
				'name': '_expiryDate',
				'type': 'string'
			}
		],
		'name': 'signAndAssignCertificate',
		'outputs': [
			{
				'internalType': 'string',
				'name': '',
				'type': 'string'
			}
		],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'address',
				'name': '',
				'type': 'address'
			},
			{
				'internalType': 'uint256',
				'name': '',
				'type': 'uint256'
			}
		],
		'name': 'trustiesOf',
		'outputs': [
			{
				'internalType': 'address',
				'name': '',
				'type': 'address'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	}
]";
    private string contractAddress = "0xb104D14C2CdfF7f28DDd6b5869Ac4cc0643E2C94";
    private Web3 web3;
    private Contract contract;

        void Start()    
        {
        // Initially, only fetch button and eventNameInput are active
		eventNameInput.gameObject.SetActive(false);

        fetchButton.gameObject.SetActive(false);
        resetUIButton.gameObject.SetActive(false);
		verifyNeworOld.gameObject.SetActive(false);
		gobacktologin.gameObject.SetActive(false);

        web3 = new Web3("https://sepolia.infura.io/v3/4107cda8b09e4bf1bfba32c03068e9af");
        contract = web3.Eth.GetContract(abi, contractAddress);
		if (useSavedCertificate() && checkwalletaddress())
		{
			eventNameInput.gameObject.SetActive(false);
			verifyNeworOld.gameObject.SetActive(false);
			fetchButton.gameObject.SetActive(true);
			resetUIButton.gameObject.SetActive(true);
			string certificateName = PlayerPrefs.GetString("certificate");
			string savedAddress = PlayerPrefs.GetString("walletAddress");
			infoDisplay.text = $"This Certificate is for Aron. Address is {savedAddress} and Certificate name is {certificateName}";	
			
		}
		else{
			eventNameInput.gameObject.SetActive(true);
			verifyNeworOld.gameObject.SetActive(true);
		}

    }

	public bool checkwalletaddress()
	{
		if(!string.IsNullOrEmpty(PlayerPrefs.GetString("walletAddress")))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	public bool useSavedCertificate()
	{
		if (!string.IsNullOrEmpty(PlayerPrefs.GetString("certificate")))
        {
			eventNameInput.text = PlayerPrefs.GetString("certificate");  // Set the input field to the saved certificate
			return true;
		}
		else
		{
			infoDisplay.text = "There is no saved Certificate";
			eventNameInput.gameObject.SetActive(true);

			fetchButton.gameObject.SetActive(false);  // Hide the button after use
			verifyNeworOld.gameObject.SetActive(false);  // Hide the button after use
			return false;
		}
    }

    // Called by fetchButton
	public void resetUIToNew(){
		    eventNameInput.gameObject.SetActive(true);
			fetchButton.gameObject.SetActive(false);
			verifyNeworOld.gameObject.SetActive(true);
			backButton.gameObject.SetActive(false);
			resetUIButton.gameObject.SetActive(false);
			gobacktologin.gameObject.SetActive(false);
			infoDisplay.gameObject.SetActive(false);

			eventNameInput.text="";

	}
	public async void verifyAgainorNew()
	{
		try{
			(signedMessageFromBlockchain, issuerAddress) = await GetEntityDetailsFromBlockchain(eventNameInput.text);
		}
		catch
		{
			Debug.Log("please go back to login page or retry with an address that has a valid certificate signed by attestor");
			gobacktologin.gameObject.SetActive(true);
			infoDisplay.text = "please go back to login page or retry with an address that has a valid certificate signed by attestor";
			return;
		}

		// Printing values on the console
		Debug.Log("Signed message: " + signedMessageFromBlockchain);
		Debug.Log("Issuer address: " + issuerAddress);


		//
		string savedAddress = PlayerPrefs.GetString("walletAddress");
        string certificateName = eventNameInput.text;
        string expectedMessage = $"This Certificate is for Aron. Address is {savedAddress} and Certificate name is {certificateName}";

        string addressRecovered = VerifyMessage(expectedMessage, signedMessageFromBlockchain);
    if (addressRecovered.ToLower() == issuerAddress.ToLower()) {
        RoomManager roomManager = FindObjectOfType<RoomManager>();
        roomManager.OnButtonClickedOffice2();
        infoDisplay.text = $"You succcessfully joined \n\nAddress: {savedAddress}\nCertificate: {certificateName} \n";
        
        verifyNeworOld.gameObject.SetActive(false);
        resetUIButton.gameObject.SetActive(true); // Activate the button to join a random room
    } else {
        infoDisplay.text = "Verification failed. The issuer's address does not match the recovered address.";
    }
		infoDisplay.text = "Loading ...";

        verifyNeworOld.gameObject.SetActive(false);
		resetUIButton.gameObject.SetActive(false);  // Assuming this is the ButtonJoinARandomRoom you mentioned
		PlayerPrefs.SetString("certificate", eventNameInput.text);
        PlayerPrefs.Save();
		fetchButton.gameObject.SetActive(false);
		verifyNeworOld.gameObject.SetActive(false);
		eventNameInput.gameObject.SetActive(false);
	}


public async void FetchDetailsFromBlockchain()
{
    string savedAddress = PlayerPrefs.GetString("walletAddress");
    string certificateName = PlayerPrefs.GetString("certificate");
    string expectedMessage = $"This Certificate is for Aron. Address is {savedAddress} and Certificate name is {certificateName}";

    try {
        // Fetch details from Blockchain
        (signedMessageFromBlockchain, issuerAddress) = await GetEntityDetailsFromBlockchain(eventNameInput.text);
        
        // Log details
        Debug.Log("Signed message: " + signedMessageFromBlockchain);
        Debug.Log("Issuer address: " + issuerAddress);
        
        infoDisplay.text = "Details fetched from the blockchain but not verified yet. Please click verify";
    } catch {
        Debug.Log("please go back to login page or retry with an address that has a valid certificate signed by attestor");
        infoDisplay.text = "please go back to login page or retry with an address that has a valid certificate signed by attestor";
        gobacktologin.gameObject.SetActive(true);
		verifyNeworOld.gameObject.SetActive(false);
        return;
    }

    // Verify Message
    string addressRecovered = VerifyMessage(expectedMessage, signedMessageFromBlockchain);
    if (addressRecovered.ToLower() == issuerAddress.ToLower()) {
        RoomManager roomManager = FindObjectOfType<RoomManager>();
        roomManager.OnButtonClickedOffice2();
        infoDisplay.text = $"You succcessfully joined \n\nAddress: {savedAddress}\nCertificate: {certificateName} \n";
        
        verifyNeworOld.gameObject.SetActive(false);
        resetUIButton.gameObject.SetActive(true); // Activate the button to join a random room
    } else {
        infoDisplay.text = "Verification failed. The issuer's address does not match the recovered address.";
    }
}

    // Called by backButton
  public void GoBack()
	{
		if (resetUIButton.gameObject.activeSelf)
		{
			resetUIButton.gameObject.SetActive(false);
			verifyNeworOld.gameObject.SetActive(true);
		}
		else if (verifyNeworOld.gameObject.activeSelf)
		{
			verifyNeworOld.gameObject.SetActive(false);
			fetchButton.gameObject.SetActive(true);
			eventNameInput.gameObject.SetActive(true);
		}
	}

 private string VerifyMessage(string message, string signedMessage)
    {
		var signedMessageBytes = Convert.FromBase64String(signedMessage);
        var LocalsignedMessage = signedMessageBytes.ToHex();
        var signer = new EthereumMessageSigner();
        return signer.EncodeUTF8AndEcRecover(message, LocalsignedMessage);
    }

   private async Task<(string, string)> GetEntityDetailsFromBlockchain(string eventName)
    {
        string entityAddress = PlayerPrefs.GetString("walletAddress");
        var getEntityDetailsFunction = contract.GetFunction("getEntityDetails");
        var result = await getEntityDetailsFunction.CallAsync<EntityDetails>(entityAddress, eventName);

        string signedMessage = result.SignedMessage;
        string issuerAddress = result.Issuer;

        return (signedMessage, issuerAddress);
    }
}
