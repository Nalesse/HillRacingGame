using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] gameplayTracks;
    [SerializeField] private float timeLeft;
    [SerializeField] private AudioMixer mainMixer;
    public AudioManager Instance { get; private set; }
    private AudioSource musicSource;
    private AudioClip currentTrack;
    private int currentTrackIndex;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
        musicSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        MusicSetup();
    }

    

    private void Update()
    {
        timeLeft = musicSource.clip.length - musicSource.time;
        if (timeLeft <= 0)
        {
            ChangeTracks();
        }
    }

    #region Music


    private void ChangeTracks()
    {
        musicSource.Stop();
        currentTrackIndex++;
        
        if (currentTrackIndex >= gameplayTracks.Length)
        {
            currentTrackIndex = 0;
        }
        
        currentTrack = gameplayTracks[currentTrackIndex];
        musicSource.clip = currentTrack;
        musicSource.Play();
    }
    
    private void MusicSetup()
    {
        var volume = PlayerPrefs.GetFloat("volume");

        currentTrackIndex = 0;
        currentTrack = gameplayTracks[currentTrackIndex];
        musicSource.clip = currentTrack;
        mainMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        musicSource.Play();
    }
    
    
    #endregion

    

}
