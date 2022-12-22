using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform ball;
    public Paddle paddle;
    public float ballPosition;
    public Transform enemy;
    public Rigidbody enemyRB;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball").transform;
        enemy = gameObject.transform;
        enemyRB = gameObject.GetComponent<Rigidbody>();
        speed = paddle.speed;
    }

    // Update is called once per frame
    void Update()
    {
        speed = paddle.speed;
        ballPosition = ball.position.y;

        if(ballPosition > enemy.position.y + 0.2f)
        {
            enemyRB.velocity = new Vector3(0f, speed);
        }
        else if(ballPosition < enemy.position.y - 0.2f)
        {
            enemyRB.velocity = new Vector3(0f, -speed);
        }
        else
        {
            enemyRB.velocity = new Vector3(0f, 0f);
        }
    }
}
