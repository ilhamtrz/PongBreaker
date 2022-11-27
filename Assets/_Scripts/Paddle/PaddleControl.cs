using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    [Header("Movement")]
    public float speed;

    [Header("Paddle Settings")] 
    public bool isPlayer1;
    public GameObject paddleTop;
    public GameObject paddleBase;
    public GameObject paddleBottom;
    public int size = 1;

    public TopDownBorder topBorder, botBorder;

    private void Start()
    {
        ReSizePaddle(size);
        topBorder = paddleTop.GetComponent<TopDownBorder>();
        botBorder = paddleBottom.GetComponent<TopDownBorder>();
    }

    void Update()
    {
        // TODO: move paddle up and down
        // use player input
        // give value from -1f to 1f
        if (isPlayer1)
        {
            var verticalInput = Input.GetAxis("VerticalPlayer1");
            verticalInput = BorderInput(verticalInput);
            
            transform.Translate(Vector3.up * (Time.deltaTime * speed * verticalInput), Space.World);
        }
        else
        {
           var verticalInput = Input.GetAxis("VerticalPlayer2");
           verticalInput = BorderInput(verticalInput);
           
            transform.Translate(Vector3.up * (Time.deltaTime * speed * verticalInput), Space.World); 
        }
    }

    public void ReSizePaddle(int newSize)
    {
        var scale = Vector3.one;
        scale.y *= newSize;
        paddleBase.transform.localScale = scale;

        var paddleTopPos = paddleBase.transform.position + (Vector3.up * (paddleBase.transform.localScale.y *
                                                                          (paddleTop.transform.localScale.y / 2)));
        paddleTopPos.y += (paddleTop.transform.localScale.y / 2);
        paddleTop.transform.position = paddleTopPos;
        
        var paddleBotPos = paddleBase.transform.position + (Vector3.up * (-1 * paddleBase.transform.localScale.y *
                                                                          (paddleBottom.transform.localScale.y / 2)));
        paddleBotPos.y -= (paddleBottom.transform.localScale.y / 2);
        paddleBottom.transform.position = paddleBotPos;
        
        // Vfx shape size
        GetComponent<Dash>().trail.transform.localScale = new Vector3(size, 1, 1);

    }

    public float BorderInput(float verticalInput)
    {
        if (topBorder.onWall) return verticalInput * 0.5f - 0.5f;
        
        if (botBorder.onWall) return verticalInput * 0.5f + 0.5f;
        
        return verticalInput;
    }

}
