// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Profiling;

// public class ProfileRecorderExample : MonoBehaviour
// {
//     private Recorder cpuRecorder;
//     private Recorder gpuRecorder;
//     private Recorder memoryRecorder;
//     private Recorder renderingRecorder;
//     private Recorder audioRecorder;
//     private Recorder uiRecorder;
//     private Recorder realtimeGIRecorder;
    
//     void Start()
//     {
//         cpuRecorder = Recorder.Get("CPU.Usage");
//         gpuRecorder = Recorder.Get("GPU.Frame");
//         memoryRecorder = Recorder.Get("Memory.Allocated");
//         renderingRecorder = Recorder.Get("Rendering");
//         audioRecorder = Recorder.Get("Audio");
//         uiRecorder = Recorder.Get("UI");
//         realtimeGIRecorder = Recorder.Get("Realtime GI");
//     }

//     void Update()
//     {
//         string timestamp = System.DateTime.Now.ToString();
//         string cpuUsage = cpuRecorder.CurrentValue.ToString();
//         string gpuFrameTime = gpuRecorder.CurrentValue.ToString();
//         string memoryAllocated = memoryRecorder.CurrentValue.ToString();
//         string rendering = renderingRecorder.CurrentValue.ToString();
//         string audio = audioRecorder.CurrentValue.ToString();
//         string ui = uiRecorder.CurrentValue.ToString();
//         string realtimeGI = realtimeGIRecorder.CurrentValue.ToString();

//         string csvString = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}\n", 
//             timestamp, cpuUsage, gpuFrameTime, memoryAllocated, rendering, audio, ui, realtimeGI);
//         System.IO.File.AppendAllText("metrics.csv", csvString);
//     }
// }
