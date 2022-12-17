using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PaddleControlOld))]
public class PaddleControlEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();

        var myPaddleControl = (PaddleControlOld) target;

        if (myPaddleControl.size < 0) myPaddleControl.size = 0;
        myPaddleControl.ReSizePaddle(myPaddleControl.size);
        
        GUILayout.Space(20);
        if (GUILayout.Button("Reset"))
        {
            myPaddleControl.size = 1;
        }
    }
}
