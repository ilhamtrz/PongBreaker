using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    [Header("References")] 
    public GameObject titikAwal;
    public GameObject titikAkhir;
    public Transform paddleTop;
    public Transform paddleBottom;
    
    [Header("Key Code")]
    public KeyCode keyDash;
    
    [Header("Movement")]
    public float speed;
    public float dashSpeed;
    public float coolDownDash;
    
    [Header("Powerup")]
    public PowerupState powerupState;
    public bool isTerbakar = false;
    
    protected float VerticalMove;
    protected Rigidbody2D Rb2D;

    private DashState _dashState;

    protected void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        ChangeDashState(DashState.Ready);
    }

    protected void Update()
    {
        SetVerticalMove();
        if (Input.GetKeyDown(keyDash) && _dashState == DashState.Ready)
        {
            ChangeDashState(DashState.Dashing);
        }
    }

    protected void FixedUpdate()
    {
        switch (_dashState)
        {
            case DashState.Ready:
                MoveUpDown();
                break;
            case DashState.Dashing:
                DashForward();
                break;
            case DashState.DashingBack:
                DashBack();
                break;
            case DashState.Cooldown:
                MoveUpDown();
                break;
        }
    }

    protected void LateUpdate()
    {
        LintasanDaseMengikuti(transform.position);
        PaddleTopDownMengikuti(transform);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        // Memaksa dash balik jika benturan dengan bola
        if (col.collider.CompareTag("Ball") && _dashState == DashState.Dashing)
        {
            ChangeDashState(DashState.DashingBack);
        }

        if (col.collider.CompareTag("Ball") && powerupState == PowerupState.Fire)
        {
            isTerbakar = true;
        }

    }

    private void MoveUpDown()
    {
        Rb2D.velocity = new Vector2(0, VerticalMove) * speed;
    }

    protected virtual void SetVerticalMove()
    {
        // di override Left dan Right
    }
    
    protected virtual void DashForward()
    {
        // di override Left dan Right
    }

    protected virtual void DashBack()
    {
        // di override Left dan Right
    }

    
    private void LintasanDaseMengikuti(Vector3 pos)
    {
        titikAwal.transform.position = 
            new Vector3(
                titikAwal.transform.position.x,
                pos.y,
                0
            );
        
        titikAkhir.transform.position = 
            new Vector3(
                titikAkhir.transform.position.x,
                pos.y,
                0
            );
    }

    private void PaddleTopDownMengikuti(Transform root)
    {
        var y = root.localScale.y / 2 + 0.1f;
        
        paddleTop.position    = LocalToWorld(root, new Vector2(0, y));
        paddleBottom.position = LocalToWorld(root, new Vector2(0, -y));
    }

    public IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDownDash);
        ChangeDashState(DashState.Ready);
    }

    public void ChangeDashState(DashState value)
    {
        _dashState = value;
    }
    
    private Vector2 LocalToWorld(Transform root ,Vector2 local)
    {
        var worldPos = root.position;
        worldPos += root.right * local.x;
        worldPos += root.up * local.y;
        
        return worldPos;
    }
}

// State untuk Dash
public enum DashState 
{
    Ready,
    Dashing,
    DashingBack,
    Cooldown
}