using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    [SerializeField][Range(1,2)] private int id;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // use player 1 input
        // give value from -1f to 1f
        var verticalInput = Input.GetAxis("VerticalPlayer" + id); 
        
        // TODO: move paddle up and down
        transform.Translate(Vector3.up * (Time.deltaTime * speed * verticalInput));
    }
}
