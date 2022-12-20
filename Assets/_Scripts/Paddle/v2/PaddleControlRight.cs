using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControlRight : PaddleControl
{
    protected override void SetVerticalMove()
    {
        VerticalMove = Input.GetAxis("VerticalPlayer2");
    }
    
    protected override void DashForward()
    {
        if (transform.position.x < titikAkhir.transform.position.x)
        {
            Rb2D.velocity = new Vector2(0, 0);
            transform.position = titikAkhir.transform.position;
            ChangeDashState(DashState.DashingBack);
            return;
        }

        Rb2D.velocity = new Vector2(-1, VerticalMove) * dashSpeed;

    }

    protected override void DashBack()
    {
        if (transform.position.x > titikAwal.transform.position.x)
        {
            Rb2D.velocity = new Vector2(0, 0);
            transform.position = titikAwal.transform.position;
            ChangeDashState(DashState.Cooldown);
            StartCoroutine(CoolDown());
            return;
        }

        Rb2D.velocity = new Vector2(1, VerticalMove) * dashSpeed;
    }

}