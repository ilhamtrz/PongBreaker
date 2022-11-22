using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePU : MonoBehaviour
{
    public PowerUpManager manager;
    public GameObject paddle1;
    public GameObject paddle2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Paddle"))
        {
            manager.RemovePowerUp(gameObject);
        }
    }
}
