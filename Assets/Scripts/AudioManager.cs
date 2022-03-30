using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] gameplayTracks;
    [SerializeField] private float maxVolume = 1f;
    [SerializeField] private float fadeDuration;
    [SerializeField] private float timeLeft;
    [SerializeField] private float fadeStart;
    
    private AudioSource currentTrack;
    private AudioSource nextTrack;
    private List<AudioSource> audioSources;
    private float minVolume = 0f;
    



    private void Start()
    {
        CreateAudioSources();
        // Removes fade functionality if there is only one song
        if (audioSources.Count < 2)
        {
            GameEvents.TimerCompleted.RemoveListener(StartFade);
            return;
        }
        nextTrack = audioSources[1];
    }

    private void Update()
    {
        timeLeft = currentTrack.clip.length - currentTrack.time;
        if (timeLeft <= fadeStart)
        {
            if (doFade)
            {
                StartCoroutine(FadeOut(currentTrack, 2f, 0));
                StartCoroutine(FadeIn(nextTrack, 2f, maxVolume));
                doFade = false;
            }
        }
    }

    // Timer Event Listener
    private void OnEnable() => GameEvents.TimerCompleted.AddListener(StartFade);
    private void OnDisable() => GameEvents.TimerCompleted.RemoveListener(StartFade);

    #region BGMFade

    private void CreateAudioSources()
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
        currentTrack.volume = maxVolume;
        currentTrack.Play();
    }

    private void StartFade()
    {
        StartCoroutine(FadeOut(currentTrack, fadeDuration, 0));
        StartCoroutine(FadeIn(nextTrack, fadeDuration, maxVolume));
    }


    // Fades the track in and sets the next track to be the next song
    IEnumerator FadeIn(AudioSource track, float duration, float targetVolume)
    {
        float timer = 0f;
        float currentVolume = track.volume;
        float targetValue = Mathf.Clamp(targetVolume, minVolume, maxVolume);

        track.Play();
        while (timer < duration)
        {
            timer += Time.deltaTime;
            var newVolume = Mathf.Lerp(currentVolume, targetValue, timer / duration);
            track.volume = newVolume;
            yield return null;
        }

        currentTrack = nextTrack;
        var nextTrackIndex = audioSources.IndexOf(nextTrack) + 1;
        if (nextTrackIndex >= audioSources.Count)
        {
            nextTrackIndex = 0;
        }
        nextTrack = audioSources[nextTrackIndex];

    }
    
    IEnumerator FadeOut(AudioSource track, float duration, float targetVolume)
    {
        float timer = 0f;
        float currentVolume = track.volume;
        float targetValue = Mathf.Clamp(targetVolume, minVolume, maxVolume);

        while (track.volume > 0)
        {
            timer += Time.deltaTime;
            var newVolume = Mathf.Lerp(currentVolume, targetValue, timer / duration);
            track.volume = newVolume;
            yield return null;
        }
        track.Stop();

    }
    
    #endregion

    
}
