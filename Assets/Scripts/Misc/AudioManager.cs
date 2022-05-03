using UnityEngine;
using UnityEngine.Audio;

namespace Misc
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip[] gameplayTracks;
        [SerializeField] private float timeLeft;
        [SerializeField] private AudioMixer mainMixer;
   
        public AudioSource musicSource;
        private AudioClip currentTrack;
        private int currentTrackIndex;

        private void Awake()
        {
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

            //sometimes the music just randomly does not play so just putting this here as fix
            if (!musicSource.isPlaying && !Player.Player.Instance.gameOver)
            {
                ChangeTracks();
            }
        }

        #region Music


        private void ChangeTracks()
        {
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
}
