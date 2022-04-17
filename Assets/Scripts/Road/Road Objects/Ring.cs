using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : SpeedBoost
{
    [SerializeField] private float liftForce;
    
    protected override void OnTriggerEnter(Collider col)
    {
        base.OnTriggerEnter(col);
        Debug.Log("Ring trigger works");
        Player.Instance.playerRB.AddForce(Vector3.up * liftForce, ForceMode.Impulse);
    }
}
