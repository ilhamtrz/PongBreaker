using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMove : MonoBehaviour
{
    [SerializeField] private Vector2 ballPos;

    private GameObject _brick;
    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1,1) * 10;
    }

    // Update is called once per frame
    void Update()
    {
        // ubah posisi bola di world menjadi posisi di screen
        ballPos = Camera.main.WorldToScreenPoint(transform.position);

        // jika bola keluar dari layar
        // maka muat ulang scene
        if (ballPos.x < -10 || ballPos.x > Screen.width + 10)
        {
            SceneManager.LoadScene("Main");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("trigger enter");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("collision enter");
        if (col.collider.CompareTag("Brick"))
        {
            _brick = col.collider.gameObject;
            Invoke("DestroyBrick", Time.deltaTime * 6);
        }
    }

    void DestroyBrick()
    {
        Debug.Log("Destroy " + _brick.name);
        Destroy(_brick);
    }
}
