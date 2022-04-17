using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpeedBoost : MonoBehaviour
{
    [field: SerializeField] protected float speedBoost;
    protected AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.Instance.speed = speedBoost;
            audioSource.Play();
        }
    }
}
