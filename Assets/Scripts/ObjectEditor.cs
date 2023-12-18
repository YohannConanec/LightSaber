using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AddObjects))]
public class ObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        AddObjects ao = (AddObjects)target;

        if (GUILayout.Button("Add Object L")) //to click on play mode
        {
            ao.InstanciateObject(true);
        }
        
        if (GUILayout.Button("Add Object R")) //to click on play mode
        {
            ao.InstanciateObject(false);
        }

        if (GUILayout.Button("Clear JSON")) //to click off play mode
        {
            ao.ClearJSON();
        }

        if (GUILayout.Button("INSERT OBJECTS")) //to click off play mode
        {
            ao.InsertObjects();
        }

        


    }
    
}