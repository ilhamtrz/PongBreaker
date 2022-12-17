using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    public Transform paddleTop;
    public Transform paddleBottom;

    void LateUpdate()
    {
        var y = transform.localScale.y / 2 + 0.1f;
        paddleTop.position    = LocalToWorld(transform, new Vector2(0, y));
        paddleBottom.position = LocalToWorld(transform, new Vector2(0, -y));
    }

    Vector2 LocalToWorld(Transform root ,Vector2 local)
    {
        var worldPos = root.position;
        worldPos += root.right * local.x;
        worldPos += root.up * local.y;
        
        return worldPos;
    }
}
