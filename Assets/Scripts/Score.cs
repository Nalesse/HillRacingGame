using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float score;
    private float highScore;
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private TextMeshProUGUI highScoreValue;
    private float pointsIncreasing;
    private TrickSystem TrickSystem;

    [Header("Score Requirement Settings")]
    [SerializeField] private float scoreRequirement;
    [SerializeField] private float requirementMultiplier;
    [SerializeField] private TextMeshProUGUI goalValue;

    // for debug only
    [Header("Debug")]
    [SerializeField] private bool enableGameOver;

    private void OnEnable()
    {
        GameEvents.TimerCompleted.AddListener(ScoreRequirement);
        GameEvents.GameOver.AddListener(GameOver);
    }

    private void OnDisable() => GameEvents.TimerCompleted.RemoveListener(ScoreRequirement);

    private void Start()
    {
        score = 0f;
        pointsIncreasing = 1f;
        TrickSystem = FindObjectOfType<TrickSystem>();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetFloat("HighScore");
            highScoreValue.text = $"{(int)highScore:00000}";
        }
        
    }

    // Update is called once per frame
    private void Update()
    {
        scoreValue.text = $"{(int)score:00000}";
        

        if (TrickSystem.isDoingTrick)
        {
            score += pointsIncreasing = 100 * Time.deltaTime;
        }
    }

    private void ScoreRequirement()
    {
        goalValue.text = $"{(int)scoreRequirement * requirementMultiplier}";

        if (score < (int)scoreRequirement)
        {
            if (enableGameOver)
            {
                GameEvents.GameOver?.Invoke();
            }
            
            Debug.Log("Game Over");
        }
        else
        {
            scoreRequirement *= requirementMultiplier;
            Debug.Log("Score Requirement: " + (int)scoreRequirement);
        }
    }

    private void GameOver()
    {
        if (!(score > highScore)) return;
        
        highScore = (int)score;
        PlayerPrefs.SetFloat("HighScore", highScore);
        highScoreValue.text = $"{(int)highScore:00000}";
    }
}
