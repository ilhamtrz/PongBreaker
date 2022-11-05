using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    [SerializeField] private float speed;
    
    void Update()
    {
        // TODO: move paddle up and down
        // use player input
        // give value from -1f to 1f
        var verticalInput = Input.GetAxis("VerticalPlayer1");
        transform.Translate(Vector3.up * (Time.deltaTime * speed * verticalInput), Space.World);
    }
}
