using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenPU : BasePU
{
    protected override void PowerUpPayload()
    {
        base.PowerUpPayload();
        
        manager.brickSpawner.ReGenerateBrickDestroyed();
        
        Debug.Log("Regenerasi brick");
    }
}
