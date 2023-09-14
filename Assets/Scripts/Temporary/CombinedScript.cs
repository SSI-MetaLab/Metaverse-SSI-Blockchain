// using System;
using System.Text.RegularExpressions;
// using System.Threading.Tasks;
// using Nethereum.Web3;
// using Nethereum.Contracts;
// using Nethereum.ABI.FunctionEncoding.Attributes;
// using Nethereum.Signer;
// using Nethereum.Hex.HexConvertors.Extensions;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
// using Nethereum.Util;
// using UnityEngine.Networking;
// using System.Collections;
// using System.Text;
// using Nethereum.JsonRpc.UnityClient;
// using Nethereum.RPC.Eth.DTOs;
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

// New function to check if user is an entity
[Function("isEntity", "bool")]
public class IsEntityFunction : FunctionMessage
{
    [Parameter("address", "_user", 1)]
    public string User { get; set; }
}

public class CombinedScript : MonoBehaviour
{
    public Button loadWalletButton;
	public GameObject loadWalletButtonWithExistingAddressButton;

	public GameObject ConnectToPhotonServerButton;
	public GameObject ConnectOptionsPanelGameobject;
	public GameObject ConnectWithNamePanelGameobject;    
	public GameObject LoadWalletGameobject;
	public GameObject CheckEligibilityGameObject;
	public TextMeshProUGUI infoDisplay;
	public TMP_InputField walletAddressInput; 
	public GameObject PasteFromClipboardGameObject;
	public GameObject connectanonymously; 
	public TextMeshProUGUI walletAddressDisplay;
	public TextMeshProUGUI walletBalanceDisplay;
	public TMP_InputField eventNameInput;
	public GameObject ConnectAnonymouslyButton;
	string eventNamePrefKey = "eventName"; // Key for saving/loading event name
	public GameObject UseNewWalletAddress;
	public GameObject SavedWalletAddressButton;
	public TMP_InputField InputFieldPlayerName;

	public loginManagerpermanent loingCheck;



    string contractAddress = "0xb104D14C2CdfF7f28DDd6b5869Ac4cc0643E2C94";
    public static string WalletAddress { get; set; } = string.Empty;
    string rpcUrl = "https://sepolia.infura.io/v3/4107cda8b09e4bf1bfba32c03068e9af";
    string abi;
    Web3 web3;
    Contract contract;



   private void Start()
	{
	// 	PlayerPrefs.DeleteKey("walletAddress");

		
		SavedWalletAddressButton.SetActive(false);
		UseNewWalletAddress.SetActive(false);
		ConnectAnonymouslyButton.SetActive(false);
		eventNameInput.gameObject.SetActive(false);
		walletBalanceDisplay.gameObject.SetActive(true);
		PasteFromClipboardGameObject.SetActive(false);
		walletAddressInput.gameObject.SetActive(false);
		infoDisplay.gameObject.SetActive(true);
		infoDisplay.text = "Welcome";
		CheckEligibilityGameObject.SetActive(false);
		LoadWalletGameobject.SetActive(false);
		ConnectWithNamePanelGameobject.SetActive(false);
		ConnectOptionsPanelGameobject.SetActive(false);
		ConnectToPhotonServerButton.SetActive(false);
		loadWalletButtonWithExistingAddressButton.SetActive(false);
		loadWalletButton.gameObject.SetActive(false);
		loadWalletButton.gameObject.SetActive(false);
		InputFieldPlayerName.gameObject.SetActive(false);

		loingCheck = this.GetComponent<loginManagerpermanent>();

		
    	loadWalletButton.interactable = true;   
        abi = @"[
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
		Debug.Log("abi is set");
        eventNameInput.text = ""; // Clear the event name field

        web3 = new Web3(rpcUrl);
        contract = web3.Eth.GetContract(abi, contractAddress);

		if (PlayerPrefs.HasKey("walletAddress"))
		{
			string savedWalletAddress = PlayerPrefs.GetString("walletAddress");
			if (!string.IsNullOrEmpty(savedWalletAddress))
			{
				Debug.Log("am getting printed = there is saved one");
				// Enable the buttons for saved and new wallet options
				SavedWalletAddressButton.SetActive(true);
				UseNewWalletAddress.SetActive(true);

				// Display the message with the saved wallet address
				infoDisplay.gameObject.SetActive(true); // You have to access the gameObject property for TextMeshProUGUI components 
				infoDisplay.text = $"Do you want to continue with the saved address: {savedWalletAddress}";
			}
			else
			{
				Debug.Log("am getting printed = there nonono is saved one");
				UseNewWalletAddress.SetActive(true);
				infoDisplay.text = "Please, press the Use new wallet Address";
				
			}
		}
		else
		{
			Debug.Log("am getting printed = there nonono is saved one");
			UseNewWalletAddress.SetActive(true);
			infoDisplay.text = "Please, press the Use new wallet Address";
			
		}

       

    }

	public void LoadWalletwithNewWAlletAddress()
	{
		// Deletes the "certificate" key from PlayerPrefs
		PlayerPrefs.DeleteKey("certificate");

		UseNewWalletAddress.SetActive(false);
		SavedWalletAddressButton.SetActive(false);
		loadWalletButton.gameObject.SetActive(true);
		PasteFromClipboardGameObject.SetActive(true);
		walletAddressInput.gameObject.SetActive(true);
	

		var placeholder = walletAddressInput.placeholder as TextMeshProUGUI;
		if (placeholder != null)
		{
			placeholder.text = "Enter wallet address...";
		}

		infoDisplay.text = "Please, Enter your new Wallet Address";
	}

	public async void LoadWalletwithExistingWalletAddress()
	{
		  // Get a reference to the loginManagerpermanent script
    	loginManagerpermanent loginManager = FindObjectOfType<loginManagerpermanent>();
    
		UseNewWalletAddress.SetActive(false);
		loadWalletButtonWithExistingAddressButton.SetActive(false);
		if (!PlayerPrefs.HasKey("walletAddress"))
		{
			string savedWalletAddress = PlayerPrefs.GetString("walletAddress");
			if (!string.IsNullOrEmpty(savedWalletAddress))
			{
				infoDisplay.text = "Error: No saved wallet address found.";
				// loadWalletButtonWithExistingAddressButton.SetActive(false); // Set the button inactive.
				UseNewWalletAddress.SetActive(true);
				return; // Exit the function early if there's no saved address.
			}
		}
		else
		{


			string savedWalletAddress = PlayerPrefs.GetString("walletAddress");
			try{
				walletAddressInput.text = savedWalletAddress;
				CheckEligibilityGameObject.SetActive(false);
				walletAddressDisplay.text = "Address: " + savedWalletAddress; // Display the loaded wallet address
				walletBalanceDisplay.text = "Balance: " + Web3.Convert.FromWei(await web3.Eth.GetBalance.SendRequestAsync(savedWalletAddress)).ToString(); //
				var result = await GetEntityEligibilityFromBlockchain(savedWalletAddress); 
				Debug.Log($"result is ________________________________________________:{result} ");
				loginManager.ConnectToPhotonServerWithOldName();
				return;
			}
			catch(Exception e)
			{
					Debug.LogError($"An error occurred: {e.Message}");
					infoDisplay.text = "An error occurred. Please try again.";
			}


			// // Log the address to the console for debugging.
			// Debug.Log("Address being used: " + savedWalletAddress);
			
			
			// LoadWallet();
			// Debug.Log("wallet called");
			// infoDisplay.text = "Please check your eligibility.";
			// CheckEligibilityGameObject.SetActive(true); // Assuming this is the UI element you want to activate for eligibility check.
		}
	}

    public async void GetWalletAddress()
    {
        Debug.Log("GetWalletAddress called.");
        string address = walletAddressInput.text;
        Debug.Log($"Input field value: {address}");

        if (!await IsValidEthereumAddressAndHasBalance(address))
        {
            infoDisplay.text = "The provided address is not valid or has no balance.";
            return;
        }

        WalletAddress = address;
        Debug.Log($"Set WalletAddress to {WalletAddress}");
        infoDisplay.text = $"Successfully loaded address: {WalletAddress}";

        LoadWalletGameobject.SetActive(false);
        CheckEligibilityGameObject.SetActive(true);
        var placeholder = walletAddressInput.placeholder as TextMeshProUGUI;
        if (placeholder != null)
        {
            placeholder.text = "Enter event name";
        }

        walletAddressInput.gameObject.SetActive(false);        
		walletAddressDisplay.gameObject.SetActive(true);      
		walletBalanceDisplay.gameObject.SetActive(true);
        walletAddressDisplay.text = "Address: " + WalletAddress; // Display the loaded wallet address
		walletBalanceDisplay.text = "Balance: " + Web3.Convert.FromWei(await web3.Eth.GetBalance.SendRequestAsync(address)).ToString(); // Display the balance
		PasteFromClipboardGameObject.SetActive(false);

    }

	public void LoadWallet()
	{

		GetWalletAddress();
	}

	public async void CheckEligibilityFunction()
{
    try
    {
        Debug.Log($"ReadCertificate called with WalletAddress {WalletAddress}");
        string address = WalletAddress;

        var isEntityFunction = new IsEntityFunction
        {
            User = address
        };

        var result = await GetEntityEligibilityFromBlockchain(address); // Create this method similar to GetEntityDetailsFromBlockchain

        if (result) // Assume this is a boolean result
        {
				Debug.Log($"Eligibility checked: {address}");
				PlayerPrefs.SetString("walletAddress", WalletAddress);
				PlayerPrefs.Save();

				// Perform UI changes
				ConnectOptionsPanelGameobject.SetActive(true);
				ConnectWithNamePanelGameobject.SetActive(true);
				CheckEligibilityGameObject.SetActive(false);
				ConnectAnonymouslyButton.SetActive(true);

				walletAddressInput.gameObject.SetActive(false);
				InputFieldPlayerName.gameObject.SetActive(true);

				var placeholder = InputFieldPlayerName.placeholder as TextMeshProUGUI;
				InputFieldPlayerName.text = "";
				if (placeholder != null)
				{
					placeholder.text = "Enter your name (optional)";
				}
				infoDisplay.text = $"Eligibility checked: {address}";

            // eligibility checked
            Debug.Log($"eligibility checked: {address}");
            PlayerPrefs.SetString("walletAddress", WalletAddress);
            PlayerPrefs.Save();

            // Do other UI updates as in your original code
            infoDisplay.text = $"Successfully loaded address and Checked Eligibility for: {WalletAddress}";
        }
        else
        {
            infoDisplay.text = "Please enter a correct address which is a member of the entity.";
        }
    }
    catch (Exception e)
    {
        Debug.LogError($"An error occurred: {e.Message}");
        infoDisplay.text = "An error occurred. Please try again.";
    }
}

private async Task<bool> GetEntityEligibilityFromBlockchain(string entityAddress)
{
    var isEntityFunction = contract.GetFunction("isEntity");
    var functionInput = new object[] { entityAddress };
    var result = await isEntityFunction.CallAsync<bool>(functionInput);
    return result;
}



	// public async void OnButtonPressCheckEligibility()
	// {
	// 	try
	// 	{
	// 		Debug.Log($"ReadCertificate called with WalletAddress {WalletAddress}");
	// 		string address = WalletAddress;

	// 		// Checking if the user is an entity
	// 		var addressUtil = new AddressUtil();
	// 		if (!addressUtil.IsChecksumAddress(address))
	// 		{
	// 			throw new Exception("Invalid Ethereum Address: " + address);
	// 			infoDisplay.text("invalid ethereum address");
	// 		}

	// 		var isEntityFunction = new IsEntityFunction
	// 		{
	// 			User = address
	// 		};

	// 		var handler = web3.Eth.GetContractQueryHandler<IsEntityFunction>();
	// 		var isEntity = await handler.QueryAsync<bool>(contractAddress, isEntityFunction);

	// 		if (isEntity)
	// 		{
				// Debug.Log($"Eligibility checked: {address}");
				// PlayerPrefs.SetString("walletAddress", WalletAddress);
				// PlayerPrefs.Save();

				// // Perform UI changes
				// ConnectOptionsPanelGameobject.SetActive(true);
				// ConnectWithNamePanelGameobject.SetActive(true);
				// CheckEligibilityGameObject.SetActive(false);
				// ConnectAnonymouslyButton.SetActive(true);

				// walletAddressInput.gameObject.SetActive(false);
				// InputFieldPlayerName.gameObject.SetActive(true);

				// var placeholder = InputFieldPlayerName.placeholder as TextMeshProUGUI;
				// InputFieldPlayerName.text = "";
				// if (placeholder != null)
				// {
				// 	placeholder.text = "Enter your name (optional)";
				// }
				// infoDisplay.text = $"Successfully loaded address and Checked Eligibility for: {WalletAddress}";
	// 		}
	// 		else
	// 		{
	// 			infoDisplay.text = "Please enter a correct address which is a member of the entity";
	// 		}
	// 	}
	// 	catch (Exception e)
	// 	{
	// 		// Log technical details for debugging
	// 		Debug.Log($"Error: {e.Message}");

	// 		// User-friendly error message
	// 		 infoDisplay.text = $"Error: {e.Message}";
	// 		// infoDisplay.text = "An error occurred while checking eligibility. Please try again.";
	// 	}
	// }


//  public async void CheckEligibilityFunction()
// 	{
//     Debug.Log($"ReadCertificate called with WalletAddress {WalletAddress}");
//     string address = WalletAddress;
// 	if (await CheckIfEntity(address))
// 	{
// 		Debug.Log($"eligibility checked: {address}");
// 		PlayerPrefs.SetString("walletAddress", WalletAddress);
// 		PlayerPrefs.Save();

// 		// Only activate these GameObjects if the wallet address is valid and the entity is eligible
// 		ConnectOptionsPanelGameobject.SetActive(true);
// 		ConnectWithNamePanelGameobject.SetActive(true);
// 		CheckEligibilityGameObject.SetActive(false);
// 		ConnectAnonymouslyButton.SetActive(true);

// 		walletAddressInput.gameObject.SetActive(false);
// 		InputFieldPlayerName.gameObject.SetActive(true);
		
// 		var placeholder = InputFieldPlayerName.placeholder as TextMeshProUGUI;
// 		InputFieldPlayerName.text = "";
// 		if (placeholder != null)
// 		{
// 			placeholder.text = "Enter your name (optional)";
// 		}
// 		infoDisplay.text = $"Successfully loaded address and Checked Eligibility for: {WalletAddress}";
// 	}
// 	else{
// 		infoDisplay.text = "Please enter a correct address which is member of the entity";

// 	}


// }

	public void ResetUI()
	{
		// Disable all UI elements
		SavedWalletAddressButton.SetActive(false);
		UseNewWalletAddress.SetActive(false);
		loadWalletButton.gameObject.SetActive(false);
		PasteFromClipboardGameObject.SetActive(false);
		walletAddressInput.gameObject.SetActive(false);
		infoDisplay.gameObject.SetActive(false);
		CheckEligibilityGameObject.SetActive(false);
		LoadWalletGameobject.SetActive(false);
		ConnectWithNamePanelGameobject.SetActive(false);
		ConnectOptionsPanelGameobject.SetActive(false);
		ConnectToPhotonServerButton.SetActive(false);
		loadWalletButtonWithExistingAddressButton.SetActive(false);
		InputFieldPlayerName.gameObject.SetActive(false);
		connectanonymously.gameObject.SetActive(false); 


		// Enable only the ones you want to keep
		UseNewWalletAddress.SetActive(true);
		SavedWalletAddressButton.SetActive(true);
		infoDisplay.gameObject.SetActive(true);
		walletAddressDisplay.gameObject.SetActive(true); 
		walletBalanceDisplay.gameObject.SetActive(true);
	}

    // // New function to check if the user is an entity
    // private async Task<bool> CheckIfEntity(string userAddress)
    // {
    //     var addressUtil = new AddressUtil();
    //     if (!addressUtil.IsChecksumAddress(userAddress))
    //     {
    //         throw new Exception("Invalid Ethereum Address: " + userAddress);
    //     }

    //     var isEntityFunction = new IsEntityFunction
    //     {
    //         User = userAddress
    //     };

    //     var handler = web3.Eth.GetContractQueryHandler<IsEntityFunction>();
    //     var result = await handler.QueryAsync<bool>(contractAddress, isEntityFunction);

    //     return result;
    // }

	private async Task<bool> IsValidEthereumAddressAndHasBalance(string address)
	{
		// Check if the provided address is a valid Ethereum address format
		if (!IsValidEthereumAddress(address))
		{
			return false;
		}

		// Check if web3 is not null
		if (web3 == null)
		{
			Debug.LogError("Web3 is not initialized");
			return false;
		}

		// Check if the address is a wallet address by checking its balance
		var balance = await web3.Eth.GetBalance.SendRequestAsync(address);
		// if (balance.Value == 0) return false;

		// Display the balance
		walletBalanceDisplay.text = Web3.Convert.FromWei(balance.Value).ToString();

		return true;
	}

	public void PasteFromClipboard()
    {
        string clipboardText = GUIUtility.systemCopyBuffer;

        // If there is text in the clipboard, display it in the TextMeshProUGUI
        if (!string.IsNullOrEmpty(clipboardText))
        {
			if(IsValidEthereumAddress(clipboardText))
			{
				infoDisplay.text = $"Copied From ClipBoard\n{clipboardText}";
				walletAddressInput.text = clipboardText;
			}
			else
			{
				Debug.Log("Text not in the correct format");
				infoDisplay.text = "Text not in the correct format";
			}
        }
        else
        {
            Debug.LogError("No text in the clipboard!");
            infoDisplay.text = "No text in the clipboard!";
        }
    }
	

    private bool IsValidEthereumAddress(string address)
    {
        if (address.Length != 42) return false;
        if (!address.StartsWith("0x")) return false;

        const string hexPattern = @"\A\b[0-9a-fA-F]+\b\Z";

        Regex rgx = new Regex(hexPattern);

        string remainingCharacters = address.Substring(2);

        return rgx.IsMatch(remainingCharacters);
    }
	}