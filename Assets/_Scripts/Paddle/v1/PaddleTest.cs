using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleTest : MonoBehaviour
{
    public GameObject top;
    public GameObject bottom;
    public GameObject mid;
    
    public Vector3 midPos;
    public float distance;

    private void OnDrawGizmos()
    {
        top.transform.position = bottom.transform.position + Vector3.up * distance;
        // distance = Vector3.Distance(top.transform.position, bottom.transform.position);
        midPos = Vector3.Lerp(top.transform.position, bottom.transform.position, 0.5f);
        mid.transform.position = midPos;
        mid.transform.localScale = new Vector3(1, distance, 1);
    }
}
