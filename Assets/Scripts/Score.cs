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
    [SerializeField] private float tempScore;
    private float highScore;
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private TextMeshProUGUI tempScoreValue;
    [SerializeField] private TextMeshProUGUI highScoreValue;
    [SerializeField] private TextMeshProUGUI pointMultValue;
    private float pointsIncreasing;
    private int pointMultiplier;
    private TrickSystem TrickSystem;
    
    private bool isScoreMultiplying = true;

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
        tempScoreValue.text = $"{(int)tempScore:00000}";
        

        if (TrickSystem.isDoingTrick)
        {
            tempScore += pointsIncreasing = 100 * Time.deltaTime;
        }
        if (TrickSystem.isDoingTrickSmaller)
        {
            pointMultValue.text = "x" + $"{(int)pointMultiplier + 1}";
        }

        if (Player.Instance.isDamage)
        {
            //Debug.Log("TempScoreToZero");
            tempScore = 0;
        }

        if (Player.Instance.isGrounded)
        {

            score += tempScore * pointMultiplier;
            tempScore = 0;
            pointMultiplier = 0;
            pointMultValue.text = "x" + $"{(int)pointMultiplier + 1}";
        }

        

        if (!TrickSystem.isDoingTrickSmaller && tempScore > 0)
        {
            
            if (isScoreMultiplying == true)
            {
                //Debug.Log(pointMultiplier + " point multiplier");
                pointMultiplier += 1;
                isScoreMultiplying = false;
            }
        }
        else
        {
            isScoreMultiplying = true;
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
