using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float delayDestroy = 0.1f;
    
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        sr.sprite = null;
        StartCoroutine(Breaking());
    }

    IEnumerator Breaking()
    {
        FindObjectOfType<AudioManager>().Play("brick");
        yield return new WaitForSeconds(delayDestroy);
        Destroy(gameObject);
    }
}
