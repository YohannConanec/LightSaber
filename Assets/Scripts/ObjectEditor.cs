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
        AddObjects func = (AddObjects)target;

        if (GUILayout.Button("Add Object"))
        {
            func.InstanciateObject();
        }
    }
    
}
