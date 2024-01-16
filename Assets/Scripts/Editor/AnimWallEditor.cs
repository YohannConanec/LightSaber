using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AnimGoDown))]
public class AnimWallEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        AnimGoDown anim = (AnimGoDown)target;

        if (GUILayout.Button("Launch Anim")) 
        {
            anim.AnimMenuDown();
        }






    }
}
