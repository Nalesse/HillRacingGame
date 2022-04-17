using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public AudioMixer audioMixer;
    [SerializeField] private Slider audioSlider;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        string[] option =  {420 + " x " + 380, 1440 + " x " + 1080, 1920 + " x " + 1080};
        options.Add(option[0]);
        options.Add(option[1]);
        options.Add(option[2]);
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        
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

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
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
