// using System;
// using System.Text;
// using System.Threading.Tasks;
// using Nethereum.Web3;
// using Nethereum.Contracts;
// using Nethereum.ABI.FunctionEncoding.Attributes;
// using Nethereum.Signer;
// using Nethereum.Hex.HexConvertors.Extensions;
// using UnityEngine;

// [Function("getMessage", typeof(MessageEntry))]
// public class GetMessageFunction : FunctionMessage
// {
//     [Parameter("address", "_address", 1)]
//     public string Address { get; set; }
// }

// [FunctionOutput]
// public class MessageEntry
// {
//     [Parameter("string", "message", 1)]
//     public string Message { get; set; }

//     [Parameter("bytes", "signature", 2)]
//     public byte[] Signature { get; set; }  // Here we declare it as byte[]
// }

// public class EncrypedRead : MonoBehaviour
// {
//     string contractAddress = "0xeFF154afaDAB794cD7046b5be789a385874428A6";
//     string rpcUrl = "https://sepolia.infura.io/v3/4107cda8b09e4bf1bfba32c03068e9af";

//     string abi = @"[
//                     {
//                         ""inputs"": [
//                             {
//                                 ""internalType"": ""string"",
//                                 ""name"": ""message"",
//                                 ""type"": ""string""
//                             },
//                             {
//                                 ""internalType"": ""bytes"",
//                                 ""name"": ""signature"",
//                                 ""type"": ""bytes""
//                             }
//                         ],
//                         ""name"": ""storeMessage"",
//                         ""outputs"": [],
//                         ""stateMutability"": ""nonpayable"",
//                         ""type"": ""function""
//                     },
//                     {
//                         ""inputs"": [
//                             {
//                                 ""internalType"": ""address"",
//                                 ""name"": """",
//                                 ""type"": ""address""
//                             }
//                         ],
//                         ""name"": ""entries"",
//                         ""outputs"": [
//                             {
//                                 ""internalType"": ""string"",
//                                 ""name"": ""message"",
//                                 ""type"": ""string""
//                             },
//                             {
//                                 ""internalType"": ""bytes"",
//                                 ""name"": ""signature"",
//                                 ""type"": ""bytes""
//                             }
//                         ],
//                         ""stateMutability"": ""view"",
//                         ""type"": ""function""
//                     },
//                     {
//                         ""inputs"": [
//                             {
//                                 ""internalType"": ""address"",
//                                 ""name"": ""owner"",
//                                 ""type"": ""address""
//                             }
//                         ],
//                         ""name"": ""getMessage"",
//                         ""outputs"": [
//                             {
//                                 ""internalType"": ""string"",
//                                 ""name"": """",
//                                 ""type"": ""string""
//                             },
//                             {
//                                 ""internalType"": ""bytes"",
//                                 ""name"": """",
//                                 ""type"": ""bytes""
//                             }
//                         ],
//                         ""stateMutability"": ""view"",
//                         ""type"": ""function""
//                     }
//                 ]";

//     Web3 web3;
//     Contract contract;

//     private async void Start()
//     {
//         web3 = new Web3(rpcUrl);
//         contract = web3.Eth.GetContract(abi, contractAddress);

//         await GetAndVerifyMessage("0x89eB58Bc7229a397696AdE51E369AA6B4D7123ca");  // specify entity address here
//     }

//     private async Task GetAndVerifyMessage(string entityAddress)
//     {
//         var getMessageFunction = contract.GetFunction("getMessage");
//         var result = await getMessageFunction.CallDeserializingToObjectAsync<MessageEntry>(new GetMessageFunction() { Address = entityAddress });

//         UnityEngine.Debug.Log("Message: " + result.Message);

//         string hexSignature = result.Signature.ToHex();  // Convert byte[] to Hex string
//         UnityEngine.Debug.Log("Signature: " + hexSignature);

//         // Verify the signature
//         var signerAddress = new EthereumMessageSigner().EcRecover(Encoding.UTF8.GetBytes(result.Message), hexSignature.RemoveHexPrefix());
//         var isValid = signerAddress.ToLower() == entityAddress.ToLower();

//         UnityEngine.Debug.Log("Is valid: " + isValid);
//     }
// }