using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    public bool dash = true;
    
    [SerializeField][Range(1,2)] private int id;
    [SerializeField] private float speed, lerpDuration;
    
    // Wall
    [SerializeField] private GameObject topWall, bottomWall;
    
    // Start and end position dash
    [SerializeField] private Vector3 startPos, endPos;

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
        if (Input.GetButtonDown("DashPlayer1"))
        {
            if (dash)
            {
                startPos = transform.position;
                StartCoroutine(Dash(startPos, endPos));
            }
        }
        
        // TODO: Menjaga paddle tetap pada layar/di antara dinding
        // Dengan constrain rigidbody freeze X Y & rotation Z
    }
    
    IEnumerator Dash(Vector3 start, Vector3 dest)
    {
        dash = false;
        var timeElapsed = 0f;
        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(start, dest, timeElapsed/lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = dest;

        timeElapsed = 0f;
        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(dest, start, timeElapsed/lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = start;
        dash = true;
    }
}
