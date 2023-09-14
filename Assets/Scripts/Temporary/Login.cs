using System;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Contracts;
using Nethereum.ABI.FunctionEncoding.Attributes;
using UnityEngine;
using Nethereum.Util;

[Function("readCertificate", "string")]
public class ReadCertificateFunction : FunctionMessage
{
    [Parameter("address", "_address", 1)]
    public string Address { get; set; }

    [Parameter("string", "_certName", 2)]
    public string CertName { get; set; }
}



public class Login : MonoBehaviour
{
     // Declare these variables for input fields
    public string inputAddress;
    public string inputCertName;
    string contractAddress = "0xbe805Df89d51d622638C809C256b4b2D933c491d";
    string rpcUrl = "https://sepolia.infura.io/v3/4107cda8b09e4bf1bfba32c03068e9af";
    string abi = @"[
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
		'name': 'deleteEntity',
		'outputs': [],
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
		'name': 'removeTrustedEntity',
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
				'name': '_encryptedCertificate',
				'type': 'string'
			},
			{
				'internalType': 'string',
				'name': '_issuer',
				'type': 'string'
			},
			{
				'internalType': 'address',
				'name': '_entityAddress',
				'type': 'address'
			},
			{
				'internalType': 'uint256',
				'name': '_expiryDate',
				'type': 'uint256'
			}
		],
		'name': 'SignCertificate',
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
		'stateMutability': 'nonpayable',
		'type': 'constructor'
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
				'name': '_trustedEntity',
				'type': 'address'
			},
			{
				'internalType': 'uint256',
				'name': 'start',
				'type': 'uint256'
			},
			{
				'internalType': 'uint256',
				'name': 'count',
				'type': 'uint256'
			}
		],
		'name': 'getTrustingEntities',
		'outputs': [
			{
				'internalType': 'address[]',
				'name': '',
				'type': 'address[]'
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
		'name': 'MAX_TRUSTING_ENTITIES',
		'outputs': [
			{
				'internalType': 'uint256',
				'name': '',
				'type': 'uint256'
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
				'internalType': 'address',
				'name': '_address',
				'type': 'address'
			},
			{
				'internalType': 'string',
				'name': '_certName',
				'type': 'string'
			}
		],
		'name': 'readCertificate',
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
    Web3 web3;
    Contract contract;

	public async void login(){
		web3 = new Web3(rpcUrl);
        contract = web3.Eth.GetContract(abi, contractAddress);
                await ReadCertificate(inputAddress, inputCertName);  // Use the values from the input fields
 // specify entity address and certificate name here
	}

	private async Task ReadCertificate(string entityAddress, string certName)
	{
		var addressUtil = new Nethereum.Util.AddressUtil();

		if (addressUtil.IsValidAddressLength(entityAddress) && addressUtil.IsChecksumAddress(entityAddress))
		{
			var readCertificateFunction = new ReadCertificateFunction()
			{
				Address = entityAddress,
				CertName = certName,
			};

			var handler = web3.Eth.GetContractQueryHandler<ReadCertificateFunction>();
			var result = await handler.QueryAsync<string>(contractAddress, readCertificateFunction);

			UnityEngine.Debug.Log("Encrypted Certificate: " + result);
		}
		else
		{
			UnityEngine.Debug.LogError("Invalid Ethereum Address: " + entityAddress);
		}
	}

    private void Start()
    {
        login();
    }
}
