using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceDashBack : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        transform.parent.GetComponent<Dash>().collide = true;
    }
}
