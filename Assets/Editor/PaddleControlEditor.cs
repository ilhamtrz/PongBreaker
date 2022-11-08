using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PaddleControl))]
public class PaddleControlEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();

        var myPaddleControl = (PaddleControl) target;
        
        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Generate") )
        {
            myPaddleControl.ResetPadle(myPaddleControl.PaddleBases);
            myPaddleControl.UpdatePaddle(myPaddleControl.size, myPaddleControl.PaddleBases);
        }

        if (GUILayout.Button("Reset"))
        {
            myPaddleControl.ResetPadle(myPaddleControl.PaddleBases);
            myPaddleControl.size = 1;
        }
        GUILayout.EndHorizontal();
    }
}
