using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] gameplayTracks;
    private List<AudioSource> audioSources;
    [SerializeField] private float fadeStart;
    private AudioSource currentTrack;

    [SerializeField] private float timeLeft;
    

    private void Start()
    {
        audioSources = new List<AudioSource>(new AudioSource[gameplayTracks.Length]);

        // creates an audio source component for each track in gameplayTracks and sets default settings 
        for (int i = 0; i < gameplayTracks.Length; i++)
        {
            audioSources[i] = gameObject.AddComponent<AudioSource>();
            audioSources[i].clip = gameplayTracks[i];
            audioSources[i].loop = true;
            audioSources[i].playOnAwake = false;
            audioSources[i].volume = 0;
        }
        // Sets the current track to be the first audio source and enables it
        currentTrack = audioSources[0];
        currentTrack.volume = 1;
        currentTrack.Play();

    }

    private void Update()
    {
        timeLeft = currentTrack.clip.length - currentTrack.time;
        if (timeLeft <= fadeStart)
        {
            StopAllCoroutines();
            StartCoroutine(LerpTracks());
        }
    }

    private IEnumerator LerpTracks()
    {
        var nextTrackIndex = audioSources.IndexOf(currentTrack) + 1;
        float timeToFade = 1.25f;
        float timeElapsed = 0;
        if (nextTrackIndex >= audioSources.Count)
        {
            nextTrackIndex = 0;
        }
        
        var nextTrack = audioSources[nextTrackIndex];

        while (timeElapsed < timeToFade)
        {
            currentTrack.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
            nextTrack.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;
        }
        currentTrack.Stop();
        nextTrack.Play();
        currentTrack = nextTrack;
        yield return null;

    }
}
