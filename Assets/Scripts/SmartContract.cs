// using Nethereum.JsonRpc;
// using Nethereum.Web3;
// using System;
// using System.Collections;
// using UnityEngine;
// using System.Threading.Tasks;


// public class SmartContractInteraction : MonoBehaviour
// {
//     private string abi = @"[
// 	{
// 		'inputs': [
// 			{
// 				'internalType': 'string',
// 				'name': 'certName',
// 				'type': 'string'
// 			},
// 			{
// 				'internalType': 'string',
// 				'name': 'certificate',
// 				'type': 'string'
// 			},
// 			{
// 				'internalType': 'uint256',
// 				'name': 'issueDate',
// 				'type': 'uint256'
// 			},
// 			{
// 				'internalType': 'string',
// 				'name': 'issuer',
// 				'type': 'string'
// 			},
// 			{
// 				'internalType': 'address',
// 				'name': 'issuerEthAddress',
// 				'type': 'address'
// 			},
// 			{
// 				'internalType': 'string',
// 				'name': 'hash',
// 				'type': 'string'
// 			}
// 		],
// 		'name': 'addCertificate',
// 		'outputs': [],
// 		'stateMutability': 'nonpayable',
// 		'type': 'function'
// 	},
// 	{
// 		'inputs': [
// 			{
// 				'internalType': 'string',
// 				'name': '_pubKey',
// 				'type': 'string'
// 			}
// 		],
// 		'name': 'setPublicKey',
// 		'outputs': [],
// 		'stateMutability': 'nonpayable',
// 		'type': 'function'
// 	},
// 	{
// 		'inputs': [
// 			{
// 				'internalType': 'string',
// 				'name': '_pubKey',
// 				'type': 'string'
// 			},
// 			{
// 				'internalType': 'string',
// 				'name': '_username',
// 				'type': 'string'
// 			},
// 			{
// 				'internalType': 'bool',
// 				'name': '_someBoolean',
// 				'type': 'bool'
// 			}
// 		],
// 		'name': 'setStructData',
// 		'outputs': [],
// 		'stateMutability': 'nonpayable',
// 		'type': 'function'
// 	},
// 	{
// 		'inputs': [
// 			{
// 				'internalType': 'string',
// 				'name': '_username',
// 				'type': 'string'
// 			}
// 		],
// 		'name': 'setUserName',
// 		'outputs': [],
// 		'stateMutability': 'nonpayable',
// 		'type': 'function'
// 	},
// 	{
// 		'inputs': [
// 			{
// 				'internalType': 'address',
// 				'name': 'ethAddress',
// 				'type': 'address'
// 			}
// 		],
// 		'name': 'getCertificates',
// 		'outputs': [
// 			{
// 				'internalType': 'string',
// 				'name': '',
// 				'type': 'string'
// 			}
// 		],
// 		'stateMutability': 'view',
// 		'type': 'function'
// 	},
// 	{
// 		'inputs': [
// 			{
// 				'internalType': 'address',
// 				'name': '_ethAddress',
// 				'type': 'address'
// 			}
// 		],
// 		'name': 'getPublicKey',
// 		'outputs': [
// 			{
// 				'internalType': 'string',
// 				'name': '',
// 				'type': 'string'
// 			}
// 		],
// 		'stateMutability': 'view',
// 		'type': 'function'
// 	},
// 	{
// 		'inputs': [
// 			{
// 				'internalType': 'address',
// 				'name': '_address',
// 				'type': 'address'
// 			}
// 		],
// 		'name': 'getStructData',
// 		'outputs': [
// 			{
// 				'internalType': 'string',
// 				'name': '',
// 				'type': 'string'
// 			},
// 			{
// 				'internalType': 'string',
// 				'name': '',
// 				'type': 'string'
// 			},
// 			{
// 				'internalType': 'uint256',
// 				'name': '',
// 				'type': 'uint256'
// 			},
// 			{
// 				'internalType': 'bool',
// 				'name': '',
// 				'type': 'bool'
// 			}
// 		],
// 		'stateMutability': 'view',
// 		'type': 'function'
// 	},
// 	{
// 		'inputs': [
// 			{
// 				'internalType': 'address',
// 				'name': '_ethAddress',
// 				'type': 'address'
// 			}
// 		],
// 		'name': 'getUserName',
// 		'outputs': [
// 			{
// 				'internalType': 'string',
// 				'name': '',
// 				'type': 'string'
// 			}
// 		],
// 		'stateMutability': 'view',
// 		'type': 'function'
// 	}
// ]";
//     private string contractAddress = "0xbF3169Ee2606e8587C9BBf6E9BEa83aC86BebDE3";

//     void Start()
//     {
//         string address = "0x89eB58Bc7229a397696AdE51E369AA6B4D7123ca"; // Replace with the desired Ethereum address.
//         StartCoroutine(GetUserName(address, (username) => {
//             Debug.Log("Username: " + username);
//         }));
//     }
// public IEnumerator GetUserName(string address, Action<string> callback)
//     {
//         var web3 = new Web3("https://sepolia.infura.io/v3/4107cda8b09e4bf1bfba32c03068e9af");
//         var getUserFunction = web3.Eth.GetContract(abi, contractAddress).GetFunction("getUserName");
//         var query = new EthCallUnityRequest(web3.Client);
//         yield return query.SendRequest(new CallInput(getUserFunction.CreateCallInput(address), contractAddress));
//         string result = getUserFunction.DecodeDTOTypeOutput<string, string>(query.Result);
//         callback(result);
//     }
// }

// public static class TaskExtensions
// {
//     public static async void FireAndForget(this Task task)
//     {
//         await task;
//     }
// }



