using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LoginManger))]

public class LoginManagerEditorScript : Editor
{
//     // Start is called before the first frame update
    public override void OnInspectorGUI() 
    {
        // base.OnInspectorGUI();
    //     base.On;
    // }
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This script is responsible for connecting to Photon Server.", MessageType.Info);

        LoginManger loginManager = (LoginManger)target;

        if(GUILayout.Button("Connect Anonymously"))
        {
            loginManager.ConnectAnonymously();
        }
    }
}
