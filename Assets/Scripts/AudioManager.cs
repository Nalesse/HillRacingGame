using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] gameplayTracks;
    private List<AudioSource> _audioSources;

    private void Start()
    {
        for (int i = 0; i < gameplayTracks.Length; i++)
        {
            _audioSources[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        
    }
}
