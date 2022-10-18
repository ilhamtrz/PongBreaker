using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    [SerializeField][Range(1,2)] private int id;
    [SerializeField] private float speed;
    
    // Wall
    [SerializeField] private GameObject topWall, bottomWall;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: move paddle up and down
        // use player input
        // give value from -1f to 1f
        var verticalInput = Input.GetAxis("VerticalPlayer" + id);
        transform.Translate(Vector3.up * (Time.deltaTime * speed * verticalInput));
        
        // TODO: dash maju

        // TODO: kembali seperti semula setelah dash
        
        // TODO: Menjaga paddle tetap pada layar/di antara dinding
        
    }
}
