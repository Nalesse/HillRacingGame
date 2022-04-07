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
    public float score;
    public TextMeshProUGUI scoreValue;
    public float pointsIncreasing;
    private TrickSystem TrickSystem;

    [Header("Score Requirement Settings")]
    [SerializeField] private float scoreRequirement;
    [SerializeField] private float requirementIncreaseAmount;

    // for debug only
    [Header("Debug")]
    [SerializeField] private bool enableGameOver;

    private void OnEnable() => GameEvents.TimerCompleted.AddListener(ScoreRequirement);

    private void OnDisable() => GameEvents.TimerCompleted.RemoveListener(ScoreRequirement);

    void Start()
    {
        score = 0f;
        pointsIncreasing = 1f;

        TrickSystem = FindObjectOfType<TrickSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue.text = "" + $"{(int)score:00000}";
        

        if (TrickSystem.isDoingTrick)
        {
            score += pointsIncreasing = 100 * Time.deltaTime;
        }
    }

    private void ScoreRequirement()
    {
        if (score < scoreRequirement)
        {
            if (enableGameOver)
            {
                GameEvents.GameOver?.Invoke();
            }
            
            Debug.Log("Game Over");
        }
        else
        {
            scoreRequirement += requirementIncreaseAmount;
            Debug.Log("Score Requirement: " + scoreRequirement);
        }
    }
}
