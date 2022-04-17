using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject controlScreen;
    public GameObject optionsScreen;
    public GameObject keyboardControls;
    public GameObject gamepadControls;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void OpenControls()
    {
        controlScreen.SetActive(true);
    }

    public void CloseControls()
    {
        controlScreen.SetActive(false);
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void ShowKeyboardControls()
    {
        keyboardControls.SetActive(true);
        gamepadControls.SetActive(false);
    }

    public void ShowGamepadControls()
    {
        keyboardControls.SetActive(false);
        gamepadControls.SetActive(true);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
