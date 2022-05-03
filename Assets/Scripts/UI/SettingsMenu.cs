using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI
{
    public class SettingsMenu : MonoBehaviour
    {
        // Start is called before the first frame update
        public Dropdown resolutionDropdown;
        Resolution[] resolutions;
        public AudioMixer audioMixer;
        [SerializeField] private Slider audioSlider;

        void Start()
        {
        
            if (PlayerPrefs.HasKey("volume"))
            {
                var savedVolume = PlayerPrefs.GetFloat("volume");
                SetVolume(savedVolume);
                audioSlider.value = savedVolume;
            }
            else
            {
                SetVolume(audioSlider.value);
            }
        
        }

        public void SetQuality()
        {
            SetResolution();
        }
        public void SetResolution()
        {
            //getting the name of what was pressed
            string index = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
            switch (index)
            {
                case "Res1":
                    Screen.SetResolution(420, 380, true);
                    break;

                case "Res2":
                    Screen.SetResolution(1440, 1080, true);
                    break;

                case "Res3":
                    Screen.SetResolution(1920, 1080, true);
                    break;
            }
        }

        public void SetVolume (float volume)
        {
            audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("volume", volume);
            PlayerPrefs.Save();
        }

        public void SetFullscreen (bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }
    }
}
