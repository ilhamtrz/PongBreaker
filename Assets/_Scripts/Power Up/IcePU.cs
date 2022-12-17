using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePU : MonoBehaviour
{
    public PowerUpManagerNew manager;
    public GameObject paddle1;
    public GameObject paddle2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PaddleLeft") || collision.CompareTag("PaddleRight"))
        {
            manager.RemovePowerUp(gameObject);
        }
    }
}
