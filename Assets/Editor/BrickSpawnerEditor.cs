using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BrickSpawner))]
public class BrickSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        var myBrickSpawner = (BrickSpawner) target;

        if (myBrickSpawner.xSize < 1) myBrickSpawner.xSize = 1;
        if (myBrickSpawner.ySize < 1) myBrickSpawner.ySize = 1;
        
        GUILayout.Space(20);
        if (GUILayout.Button("Generate"))
        {
            DestroyAllBrick();
            myBrickSpawner.GenerateBrick();
        }

    }

    void DestroyAllBrick()
    {
        var brickManager = Selection.activeGameObject;
        
        for (int i = brickManager.transform.childCount; i > 0; i--)
        {
            DestroyImmediate(brickManager.transform.GetChild(i-1).gameObject);
        }
    }
}
