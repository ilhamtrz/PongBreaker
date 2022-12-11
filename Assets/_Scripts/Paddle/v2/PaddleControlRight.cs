using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControlRight : MonoBehaviour
{
    public GameObject titkAwal, titikAkhir;
    
    [Header("Key Code")]
    public KeyCode keyDash;
    
    [Header("Movement")]
    public float speed;

    public float dashSpeed;

    public float coolDownDash;

    private float verticalMove;
    
    private Rigidbody2D rb2D;

    public DashState dashState;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        dashState = DashState.Ready;
    }

    private void Update()
    {
        verticalMove = Input.GetAxis("VerticalPlayer1");
        if (Input.GetKeyDown(keyDash) && dashState == DashState.Ready)
        {
            dashState = DashState.Dashing;
            Debug.Log("Dashes!");
        }
    }

    void FixedUpdate()
    {
        switch (dashState)
        {
            case DashState.Ready:
                rb2D.velocity = new Vector2(0, verticalMove) * speed;
                break;
            case DashState.Dashing:
                DashForward();
                break;
            case DashState.DashingBack:
                DashBack();
                break;
            case DashState.Cooldown:
                rb2D.velocity = new Vector2(0, verticalMove) * speed;
                break;
        }
    }

    private void LateUpdate()
    {
        titkAwal.transform.position = new Vector3(
            titkAwal.transform.position.x,
            transform.position.y,
            0
        );
        
        titikAkhir.transform.position = new Vector3(
            titikAkhir.transform.position.x,
            transform.position.y,
            0
        );
    }
    
    void DashForward()
    {
        if (transform.position.x < titikAkhir.transform.position.x)
        {
            rb2D.velocity = new Vector2(0, 0);
            transform.position = titikAkhir.transform.position;
            dashState = DashState.DashingBack;
            return;
        }
        
        rb2D.velocity = new Vector2(-1, verticalMove) * dashSpeed;

    }

    void DashBack()
    {
        if (transform.position.x > titkAwal.transform.position.x)
        {
            rb2D.velocity = new Vector2(0, 0);
            transform.position = titkAwal.transform.position;
            dashState = DashState.Cooldown;
            StartCoroutine(CoolDown());
            return;
        }
        
        rb2D.velocity = new Vector2(1, verticalMove) * dashSpeed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ball") && dashState == DashState.Dashing)
        {
            dashState = DashState.DashingBack;
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDownDash);
        dashState = DashState.Ready;
    }
}   
