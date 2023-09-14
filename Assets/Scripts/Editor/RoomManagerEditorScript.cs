using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomManager))] 

public class RoomManagerEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This script is responsible for creating and joining rooms", MessageType.Info);
        
        RoomManager roomManager = (RoomManager)target;

        if(GUILayout.Button("Join Random Room"))
        {
            roomManager.JoinRandomRoom();
        }
        //  if(GUILayout.Button("Join Office1 Room"))
        // {
        //     roomManager.OnButtonClickedOffice1();
        // }
         if(GUILayout.Button("Join Office2 Room"))
        {
            roomManager.OnButtonClickedOffice2();
        }
    }
}
