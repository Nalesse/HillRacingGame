using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60.0f;
    public TextMeshProUGUI timeValue; // used for showing countdown from 3, 2, 1 
    public static bool gamePaused;
    public GameObject pauseMenu;
    void Start()
    {

    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeValue.text = (timeLeft).ToString("0");
        if (timeLeft < 0)
        {

            timeLeft = 60f;

            //pauses game
            //Time.timeScale = 0f;
        }

       // if (Input.GetKeyDown(KeyCode.P)) <-Pause function; work in progress.
        //{
           // gamePaused = !gamePaused;
           // PauseGame();
        //}
    }

}
