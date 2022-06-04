using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
 public class MapEditor : EditorWindow
 {
    [MenuItem("Window/Edit Map")]
    public static void ShowWindow()
    {
        GetWindow<MapEditor>("Map Editor");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Run Function"))
        {
            FunctionToRun();
        }
    }

    private void FunctionToRun()
    {
        Debug.Log("The function ran.");
    }
 }
