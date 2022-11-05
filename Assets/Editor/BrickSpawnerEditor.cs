using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BrickSpawner))]
public class BrickSpawnerEditor : Editor
{
    bool canGenerate = false;
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();

        
        var myBrickSpawner = (BrickSpawner) target;

        if (myBrickSpawner.xSize < 1) myBrickSpawner.xSize = 1;
        if (myBrickSpawner.ySize < 1) myBrickSpawner.ySize = 1;
        
        GUILayout.Space(20);
        canGenerate = EditorGUILayout.Toggle("Can Generate", canGenerate);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Generate") && myBrickSpawner.Generate && canGenerate )
        {
            myBrickSpawner.GenerateBrick();
            myBrickSpawner.Generate = false;
        }

        if (GUILayout.Button("Clear") && !myBrickSpawner.Generate)
        {
            Clear();
            myBrickSpawner.Generate = true;
        }
        GUILayout.EndHorizontal();

    }

    void Clear()
    {
        var brickManager = Selection.activeGameObject;
        
        for (int i = brickManager.transform.childCount; i > 0; i--)
        {
            DestroyImmediate(brickManager.transform.GetChild(i-1).gameObject);
        }
    }
}
