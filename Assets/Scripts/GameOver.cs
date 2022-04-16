using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverScreen;
    private void OnEnable()
    {
        GameEvents.GameOver.AddListener(enableGameOverScreen);
    }

    private void enableGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }
}
