// using System;
// using System.Threading.Tasks;
// using Nethereum.Web3;
// using Nethereum.Contracts;
// using Nethereum.ABI.FunctionEncoding.Attributes;
// using UnityEngine;

// [Function("readCertificate", "string")]
// public class ReadCertificateFunction : FunctionMessage
// {
//     [Parameter("address", "_address", 1)]
//     public string Address { get; set; }

//     [Parameter("string", "_certName", 2)]
//     public string CertName { get; set; }
// }

// public class LoginBlockChain : MonoBehaviour
// {
//     string contractAddress = "0x03bBC24e6B4fcae5fC263337C0584E07c4F66E83";
//     string rpcUrl = "https://sepolia.infura.io/v3/4107cda8b09e4bf1bfba32c03068e9af";
//     string abi = @"[
// 	{
// 		'inputs': [
// 			{
// 				'internalType': 'string',
// 				'name': '_certificateName',
// 				'type': 'string'
// 			}
// 		],
// 		'name': 'addCertificate',
// 		'outputs': [
// 			{
// 				'internalType': 'string',
// 				'name': '',
// 				'type': 'string'
// 			}
// 		],
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
// 			}
// 		],
// 		'name': 'addEntity',
// 		'outputs': [
// 			{
// 				'internalType': 'string',
// 				'name': '',
// 				'type': 'string'
// 			}
// 		],
// 		'stateMutability': 'nonpayable',
// 		'type': 'function'
// 	},
// 	{
// 		'inputs': [
// 			{
// 				'internalType': 'address',
// 				'name': '_trustedEntity',
// 				'type': 'address'
// 			}
// 		],
// 		'name': 'addTrustedEntity',
// 		'outputs': [
// 			{
// 				'internalType': 'string',
// 				'name': '',
// 				'type': 'string'
// 			}
// 		],
// 		'stateMutability': 'nonpayable',
// 		'type': 'function'
// 	},
// 	{
// 		'inputs': [],
// 		'name': 'deleteEntity',
// 		'outputs': [],
// 		'stateMutability': 'nonpayable',
// 		'type': 'function'
// 	},
// 	{
// 		'inputs': [
// 			{
// 				'internalType': 'address',
// 				'name': '_trustedEntity',
// 				'type': 'address'
// 			}
// 		],
// 		'name': 'removeTrustedEntity',
// 		'outputs': [],
// 		'stateMutability': 'nonpayable',
// 		'type': 'function'
// 	},
// 	{
// 		'inputs': [
// 			{
// 				'internalType': 'string',
// 				'name': '_certificateName',
// 				'type': 'string'
// 			},
// 			{
// 				'internalType': 'string',
// 				'name': '_encryptedCertificate',
// 				'type': 'string'
// 			},
// 			{
// 				'internalType': 'string',
// 				'name': '_issuer',
// 				'type': 'string'
// 			},
// 			{
// 				'internalType': 'address',
// 				'name': '_entityAddress',
// 				'type': 'address'
// 			},
// 			{
// 				'internalType': 'uint256',
// 				'name': '_expiryDate',
// 				'type': 'uint256'
// 			}
// 		],
// 		'name': 'SignCertificate',
// 		'outputs': [
// 			{
// 				'internalType': 'string',
// 				'name': '',
// 				'type': 'string'
// 			}
// 		],
// 		'stateMutability': 'nonpayable',
// 		'type': 'function'
// 	},
// 	{
// 		'inputs': [],
// 		'stateMutability': 'nonpayable',
// 		'type': 'constructor'
// 	},
// 	{
// 		'inputs': [],
// 		'name': 'contractName',
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
// 				'internalType': 'uint256',
// 				'name': '',
// 				'type': 'uint256'
// 			}
// 		],
// 		'name': 'entityList',
// 		'outputs': [
// 			{
// 				'internalType': 'address',
// 				'name': '',
// 				'type': 'address'
// 			}
// 		],
// 		'stateMutability': 'view',
// 		'type': 'function'
// 	},
// 	{
// 		'inputs': [
// 			{
// 				'internalType': 'address',
// 				'name': '_trustedEntity',
// 				'type': 'address'
// 			},
// 			{
// 				'internalType': 'uint256',
// 				'name': 'start',
// 				'type': 'uint256'
// 			},
// 			{
// 				'internalType': 'uint256',
// 				'name': 'count',
// 				'type': 'uint256'
// 			}
// 		],
// 		'name': 'getTrustingEntities',
// 		'outputs': [
// 			{
// 				'internalType': 'address[]',
// 				'name': '',
// 				'type': 'address[]'
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
// 		'name': 'isEntity',
// 		'outputs': [
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
// 		'inputs': [],
// 		'name': 'MAX_TRUSTING_ENTITIES',
// 		'outputs': [
// 			{
// 				'internalType': 'uint256',
// 				'name': '',
// 				'type': 'uint256'
// 			}
// 		],
// 		'stateMutability': 'view',
// 		'type': 'function'
// 	},
// 	{
// 		'inputs': [],
// 		'name': 'owner',
// 		'outputs': [
// 			{
// 				'internalType': 'address',
// 				'name': '',
// 				'type': 'address'
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
// 			},
// 			{
// 				'internalType': 'string',
// 				'name': '_certName',
// 				'type': 'string'
// 			}
// 		],
// 		'name': 'readCertificate',
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
// 				'name': '',
// 				'type': 'address'
// 			},
// 			{
// 				'internalType': 'uint256',
// 				'name': '',
// 				'type': 'uint256'
// 			}
// 		],
// 		'name': 'trustiesOf',
// 		'outputs': [
// 			{
// 				'internalType': 'address',
// 				'name': '',
// 				'type': 'address'
// 			}
// 		],
// 		'stateMutability': 'view',
// 		'type': 'function'
// 	}
// ]";  // your contract ABI
//     Web3 web3;
//     Contract contract;

//     private async void Start()
//     {
//         web3 = new Web3(rpcUrl);
//         contract = web3.Eth.GetContract(abi, contractAddress);

//         await ReadCertificate("0x2221a1B2363F39F00FEE78d9b453e2f817D7082E", "MBZUAIConference");  // specify entity address and certificate name here
//     }

//     private async Task ReadCertificate(string entityAddress, string certName)
//     {
//         var readCertificateFunction = new ReadCertificateFunction()
//         {
//             Address = entityAddress,
//             CertName = certName,
//         };

//         var handler = web3.Eth.GetContractQueryHandler<ReadCertificateFunction>();
//         var result = await handler.QueryAsync<string>(contractAddress, readCertificateFunction);

//         UnityEngine.Debug.Log("Encrypted Certificate: " + result);
//     }
// }


// // using System.Collections;
// // using UnityEngine;
// // using Nethereum.Web3;
// // using Nethereum.ABI.FunctionEncoding.Attributes;
// // using Nethereum.Contracts;
// // using System;
// // using System.IO;
// // using System.Diagnostics;
// // using Nethereum.RPC.Eth.DTOs;
// // using System.Threading.Tasks;
// // using System.Numerics;
// // using System.Collections.Generic;

// // public class LoginBlockChain : MonoBehaviour
// // {
// //     [Function("get", "uint256")]
// //     public class GetFunction : FunctionMessage { }

// //     string contractAddress = "0x09A74945643e1ad0e4aA049791869d3D2f0fAF49";
// //     List<Dictionary<string, string>> metricsList = new List<Dictionary<string, string>>();

// //     string rpcUrl = "https://sepolia.infura.io/v3/4107cda8b09e4bf1bfba32c03068e9af";
// //     string abi = @"";

// //     Web3 web3;
// //     Contract contract;
// //     float recordingDuration = 3600f; // Duration in seconds (1 hour)
// //     float elapsedTime = 0f;
// //     Stopwatch stopwatch;

// //     private async void Start()
// //     {
// //         web3 = new Web3(rpcUrl);
// //         contract = web3.Eth.GetContract(abi, contractAddress);

// //         // Start the metrics recording routine
// //         StartCoroutine(RecordMetrics());
// //     }

// //     private IEnumerator RecordMetrics()
// //     {
// //         Dictionary<string, string> metrics = new Dictionary<string, string>();
// //         stopwatch = new Stopwatch();

// //         while (elapsedTime < recordingDuration)
// //         {
// //             // Record the timestamp
// //             string timestamp = DateTime.Now.ToString();

// //             // Begin a new Profiler sample
// //             UnityEngine.Profiling.Profiler.BeginSample("My Sample");

// //             // Fetch and record the data retrieval time
// //             yield return GetRetrievalTime(time =>
// //             {
// //                 string retrievalTimeString = time.ToString();
// //                 UnityEngine.Debug.Log("Data retrieval time: " + retrievalTimeString);

// //                 // Store the metrics in the dictionary
// //                 metrics.Add(timestamp, retrievalTimeString);
// //             });

// //             // End the Profiler sample
// //             UnityEngine.Profiling.Profiler.EndSample();

// //             // Wait for 1 second before the next measurement
// //             yield return new WaitForSeconds(1f);

// //             elapsedTime += 1f;
// //         }

// //         metricsList.Add(metrics);

// //         UnityEngine.Debug.Log("Metrics recorded!");

// //         // Print the metrics to the console
// //         PrintMetrics();

// //         // Optionally, you can copy the metrics to clipboard
// //         CopyMetricsToClipboard();
// //     }


//     // private IEnumerator RecordMetrics()
//     // {
//     //     Dictionary<string, string> metrics = new Dictionary<string, string>();
//     //     stopwatch = new Stopwatch();

//     //     while (elapsedTime < recordingDuration)
//     //     {
//     //         // Record the timestamp
//     //         string timestamp = DateTime.Now.ToString();

//     //         // Fetch and record the data retrieval time
//     //         yield return GetRetrievalTime(time =>
//     //         {
//     //             string retrievalTimeString = time.ToString();
//     //             UnityEngine.Debug.Log("Data retrieval time: " + retrievalTimeString);

//     //             // Store the metrics in the dictionary
//     //             metrics.Add(timestamp, retrievalTimeString);
//     //         });

//     //         // Wait for 1 second before the next measurement
//     //         yield return new WaitForSeconds(1f);

//     //         elapsedTime += 1f;
//     //     }

//     //     metricsList.Add(metrics);

//     //     UnityEngine.Debug.Log("Metrics recorded!");

//     //     // Print the metrics to the console
//     //     PrintMetrics();

//     //     // Optionally, you can copy the metrics to clipboard
//     //     CopyMetricsToClipboard();
//     // }

// //     private IEnumerator GetRetrievalTime(System.Action<long> callback)
// //     {
// //         var function = contract.GetFunction("retrieve");

// //         stopwatch.Reset();
// //         stopwatch.Start();

// //         // Make a request to fetch the data
// //         var request = function.CallAsync<BigInteger>();

// //         // Wait until the request is completed
// //         yield return new WaitUntil(() => request.IsCompleted);

// //         stopwatch.Stop();

// //         callback(stopwatch.ElapsedMilliseconds);
// //     }

// //     private void PrintMetrics()
// //     {
// //         foreach (var metrics in metricsList)
// //         {
// //             foreach (var metric in metrics)
// //             {
// //                 UnityEngine.Debug.Log(metric.Key + "," + metric.Value);
// //             }
// //         }
// //     }

// //     private void CopyMetricsToClipboard()
// //     {
// //         string metricsText = "";

// //         foreach (var metrics in metricsList)
// //         {
// //             foreach (var metric in metrics)
// //             {
// //                 metricsText += metric.Key + "," + metric.Value + "\n";
// //             }
// //         }

// //         GUIUtility.systemCopyBuffer = metricsText;

// //         UnityEngine.Debug.Log("Metrics copied to clipboard!");
// //     }
// // }


// // // using System.Collections;
// // // using UnityEngine;
// // // using Nethereum.Web3;
// // // using Nethereum.ABI.FunctionEncoding.Attributes;
// // // using Nethereum.Contracts;
// // // using System;
// // // using System.IO;
// // // using System.Diagnostics;
// // // using Nethereum.RPC.Eth.DTOs;
// // // using System.Threading.Tasks;
// // // using System.Numerics;
// // // using System.Collections.Generic;

// // // public class LoginBlockChain : MonoBehaviour
// // // {
// // //     [Function("get", "uint256")]
// // //     public class GetFunction : FunctionMessage { }

// // //     string contractAddress = "0x09A74945643e1ad0e4aA049791869d3D2f0fAF49";
// // //     List<Dictionary<string, string>> metricsList = new List<Dictionary<string, string>>();

// // //     string rpcUrl = "https://sepolia.infura.io/v3/4107cda8b09e4bf1bfba32c03068e9af";
// // //     string abi = @"[
// // //         {
// // //             ""inputs"": [
// // //                 {
// // //                     ""internalType"": ""uint256"",
// // //                     ""name"": ""num"",
// // //                     ""type"": ""uint256""
// // //                 }
// // //             ],
// // //             ""name"": ""store"",
// // //             ""outputs"": [],
// // //             ""stateMutability"": ""nonpayable"",
// // //             ""type"": ""function""
// // //         },
// // //         {
// // //             ""inputs"": [],
// // //             ""name"": ""retrieve"",
// // //             ""outputs"": [
// // //                 {
// // //                     ""internalType"": ""uint256"",
// // //                     ""name"": """",
// // //                     ""type"": ""uint256""
// // //                 }
// // //             ],
// // //             ""stateMutability"": ""view"",
// // //             ""type"": ""function""
// // //         }
// // //     ]";

// // //     Web3 web3;
// // //     Contract contract;
// // //     float recordingDuration = 60f; // Duration in seconds
// // //     float elapsedTime = 0f;
// // //     Stopwatch stopwatch;

// // //     private async void Start()
// // //     {
// // //         web3 = new Web3(rpcUrl);
// // //         contract = web3.Eth.GetContract(abi, contractAddress);

// // //         // Start the metrics recording routine
// // //         StartCoroutine(RecordMetrics());
// // //     }

// // //     private IEnumerator RecordMetrics()
// // //     {
// // //         Dictionary<string, string> metrics = new Dictionary<string, string>();
// // //         stopwatch = new Stopwatch();

// // //         while (elapsedTime < recordingDuration)
// // //         {
// // //             // Record the timestamp
// // //             string timestamp = DateTime.Now.ToString();

// // //             // Fetch and record the data retrieval time
// // //             StartCoroutine(GetRetrievalTime(time =>
// // //             {
// // //                 string retrievalTimeString = time.ToString();
// // //                 UnityEngine.Debug.Log("Data retrieval time: " + retrievalTimeString);

// // //                 // Store the metrics in the dictionary
// // //                 metrics.Add(timestamp, retrievalTimeString);
// // //             }));

// // //             // Wait for 1 second before the next measurement
// // //             yield return new WaitForSeconds(1f);

// // //             elapsedTime += 1f;
// // //         }

// // //         metricsList.Add(metrics);

// // //         UnityEngine.Debug.Log("Metrics recorded!");

// // //         // Print the metrics to the console
// // //         PrintMetrics();

// // //         // Optionally, you can copy the metrics to clipboard
// // //         CopyMetricsToClipboard();
// // //     }

// // //     private IEnumerator GetRetrievalTime(System.Action<long> callback)
// // //     {
// // //         var function = contract.GetFunction("retrieve");

// // //         stopwatch.Reset();
// // //         stopwatch.Start();

// // //         // Make a request to fetch the data
// // //         var request = function.CallAsync<BigInteger>();

// // //         // Wait until the request is completed
// // //         while (!request.IsCompleted)
// // //             yield return null;

// // //         stopwatch.Stop();

// // //         callback(stopwatch.ElapsedMilliseconds);
// // //     }

// // //     private void PrintMetrics()
// // //     {
// // //         foreach (var metrics in metricsList)
// // //         {
// // //             foreach (var metric in metrics)
// // //             {
// // //                 UnityEngine.Debug.Log(metric.Key + "," + metric.Value);
// // //             }
// // //         }
// // //     }

// // //     private void CopyMetricsToClipboard()
// // //     {
// // //         string metricsText = "";

// // //         foreach (var metrics in metricsList)
// // //         {
// // //             foreach (var metric in metrics)
// // //             {
// // //                 metricsText += metric.Key + "," + metric.Value + "\n";
// // //             }
// // //         }

// // //         GUIUtility.systemCopyBuffer = metricsText;

// // //         UnityEngine.Debug.Log("Metrics copied to clipboard!");
// // //     }
// // // }

// // // using System.Collections;
// // // using UnityEngine;
// // // using Nethereum.Web3;
// // // using Nethereum.ABI.FunctionEncoding.Attributes;
// // // using Nethereum.Contracts;
// // // using System;
// // // using System.IO;
// // // using System.Diagnostics;
// // // using Nethereum.RPC.Eth.DTOs;
// // // using System.Threading.Tasks;
// // // using System.Numerics; 
// // // using System.Collections.Generic;

// // // public class LoginBlockChain : MonoBehaviour
// // // {
// // //     [Function("get", "uint256")]
// // //     public class GetFunction : FunctionMessage {}

// // //     string contractAddress = "0x09A74945643e1ad0e4aA049791869d3D2f0fAF49";
// // //     Dictionary<string, string> metrics = new Dictionary<string, string>();
    
// // //     string rpcUrl = "https://sepolia.infura.io/v3/4107cda8b09e4bf1bfba32c03068e9af";
// // //     string abi = @"[
// // //         {
// // //             ""inputs"": [
// // //                 {
// // //                     ""internalType"": ""uint256"",
// // //                     ""name"": ""num"",
// // //                     ""type"": ""uint256""
// // //                 }
// // //             ],
// // //             ""name"": ""store"",
// // //             ""outputs"": [],
// // //             ""stateMutability"": ""nonpayable"",
// // //             ""type"": ""function""
// // //         },
// // //         {
// // //             ""inputs"": [],
// // //             ""name"": ""retrieve"",
// // //             ""outputs"": [
// // //                 {
// // //                     ""internalType"": ""uint256"",
// // //                     ""name"": """",
// // //                     ""type"": ""uint256""
// // //                 }
// // //             ],
// // //             ""stateMutability"": ""view"",
// // //             ""type"": ""function""
// // //         }
// // //         ]";

// // //     Web3 web3;
// // //     Contract contract;
// // //     string filePath = "C:/Users/ayueb/Desktop/AronFolder/Testing_Reading_Json_File_From_Oculus/metrics.csv";

// // //     private async void Start()
// // //     {
// // //         web3 = new Web3(rpcUrl);
// // //         contract = web3.Eth.GetContract(abi, contractAddress);

// // //         // Start the metrics recording routine
// // //         StartCoroutine(RecordMetrics());
// // //     }

// // //     // private IEnumerator RecordMetrics()
// // //     // {
// // //     //     while (true)
// // //     //     {
// // //     //         // Record the timestamp
// // //     //         string timestamp = DateTime.Now.ToString();

// // //     //         // Fetch and record the data retrieval time
// // //     //         StartCoroutine(GetRetrievalTime(time => {
// // //     //             string retrievalTimeString = time.ToString();
// // //     //             UnityEngine.Debug.Log("Data retrieval time: " + retrievalTimeString);

// // //     //             string line = $"{timestamp},{retrievalTimeString}\n";
// // //     //             File.AppendAllText(filePath, line);

// // //     //             UnityEngine.Debug.Log("Recorded metrics: " + line);
// // //     //         }));

// // //     //         // Wait for an hour before the next measurement
// // //     //         yield return new WaitForSeconds(1);
// // //     //     }
// // //     // }

// // //     private IEnumerator RecordMetrics()
// // //     {
// // //         while (true)
// // //         {
// // //             // Record the timestamp
// // //             string timestamp = DateTime.Now.ToString();

// // //             // Fetch and record the data retrieval time
// // //             StartCoroutine(GetRetrievalTime(time => {
// // //                 string retrievalTimeString = time.ToString();
// // //                 UnityEngine.Debug.Log("Data retrieval time: " + retrievalTimeString);

// // //                 // Store the metrics in the dictionary
// // //                 metrics.Add(timestamp, retrievalTimeString);

// // //                 UnityEngine.Debug.Log("Recorded metrics: " + timestamp + "," + retrievalTimeString);
// // //             }));

// // //             // Wait for 1 second before the next measurement
// // //             yield return new WaitForSeconds(1f);
// // //         }
// // //     }

// // //     private IEnumerator GetRetrievalTime(System.Action<long> callback)
// // //     {
// // //         var function = contract.GetFunction("retrieve");
        
// // //         Stopwatch stopwatch = new Stopwatch();
// // //         stopwatch.Start();

// // //         // Make a request to fetch the data
// // //         var request = function.CallAsync<BigInteger>();

// // //         // Wait until the request is completed
// // //         while (!request.IsCompleted)
// // //             yield return null;

// // //         stopwatch.Stop();

// // //         callback(stopwatch.ElapsedMilliseconds);
// // //     }
// // // }



// // // // // using System;
// // // // // using System.Collections;
// // // // // using System.IO;
// // // // // using System.Numerics;
// // // // // using System.Threading.Tasks;
// // // // // using Nethereum.ABI.FunctionEncoding.Attributes;
// // // // // using Nethereum.Contracts;
// // // // // using Nethereum.Web3;
// // // // // using UnityEngine;

// // // // // public class LoginBlockChain : MonoBehaviour
// // // // // {
// // // // //     [Function("get", "uint256")]
// // // // //     public class GetFunction : FunctionMessage {}

// // // // //     private string rpcUrl = "https://sepolia.infura.io/v3/4107cda8b09e4bf1bfba32c03068e9af";
// // // // //     private string contractAddress = "0x1fD0340B981262bC57C03A84e43C507BB5e0b826";
// // // // //     private Web3 web3;
// // // // //     private IContractQueryHandler<GetFunction> contractHandler;

// // // // //     private void Start()
// // // // //     {
// // // // //         web3 = new Web3(rpcUrl);
// // // // //         contractHandler = web3.Eth.GetContractQueryHandler<GetFunction>();

// // // // //         StartCoroutine(RecordMetrics());
// // // // //     }

// // // // //     private IEnumerator RecordMetrics()
// // // // //     {
// // // // //         while (true)
// // // // //         {
// // // // //             string line = $"{DateTime.Now},{GetNetworkBandwidth()},{GetCPUUsage()},{GetMemoryUsage()}\n";
// // // // //             File.AppendAllText("metrics.csv", line);

// // // // //             Debug.Log("Recorded metrics: " + line);

// // // // //             yield return new WaitForSeconds(3600);
// // // // //         }
// // // // //     }

// // // // //     private async void UpdateStoredValueAndGasPrice()
// // // // //     {
// // // // //         var getFunctionMessage = new GetFunction();
// // // // //         var storedValue = await contractHandler.QueryAsync<BigInteger>(getFunctionMessage, contractAddress);

// // // // //         Debug.Log("Stored value from the smart contract: " + storedValue);

// // // // //         var gasPrice = await web3.Eth.GasPrice.SendRequestAsync();
// // // // //         string gasPriceString = gasPrice.Value.ToString();

// // // // //         Debug.Log("Gas price: " + gasPriceString);
// // // // //     }

// // // // //     private float GetNetworkBandwidth()
// // // // //     {
// // // // //         // TODO: Implement this method to return the current network bandwidth
// // // // //         throw new NotImplementedException();
// // // // //     }

// // // // //     private float GetCPUUsage()
// // // // //     {
// // // // //         // TODO: Implement this method to return the current CPU usage
// // // // //         throw new NotImplementedException();
// // // // //     }

// // // // //     private float GetMemoryUsage()
// // // // //     {
// // // // //         // TODO: Implement this method to return the current memory usage
// // // // //         throw new NotImplementedException();
// // // // //     }
// // // // // }



// // // // using System.Collections;
// // // // using System.Collections.Generic;
// // // // using UnityEngine;
// // // // using Nethereum.Web3;
// // // // using Nethereum.ABI.FunctionEncoding.Attributes;
// // // // using Nethereum.Contracts;
// // // // using System.Numerics;

// // // // public class LoginBlockChain : MonoBehaviour
// // // // {
// // // //     [Function("get", "uint256")]
// // // //     public class GetFunction : FunctionMessage {}

// // // //     private async void Start()
// // // //     {
// // // //         string contractAddress = "0x1fD0340B981262bC57C03A84e43C507BB5e0b826";
// // // //         string rpcUrl = "https://sepolia.infura.io/v3/4107cda8b09e4bf1bfba32c03068e9af";

// // // //         var web3 = new Web3(rpcUrl);
// // // //         var contractHandler = web3.Eth.GetContractHandler(contractAddress);

// // // //         // Get the stored value
// // // //         var getFunctionMessage = new GetFunction();
// // // //         var storedValue = await contractHandler.QueryAsync<GetFunction, BigInteger>(getFunctionMessage);

// // // //         Debug.Log("Stored value from the smart contract: " + storedValue);
// // // //     }
// // // // }
