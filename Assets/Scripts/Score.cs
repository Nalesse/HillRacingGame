using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public TextMeshProUGUI scoreValue;
    private float scoreTimer;
    void Start()
    {
        score = 000000;
        scoreValue.text = "" + score;
        //first number is delay, second (f) is rate of points of given
        InvokeRepeating("scoreTimer", 0, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreTimer += Time.deltaTime;
    }
    public void UpdateScore(int points)
    {
        score += points;
        scoreValue.text = "" + score;
    }
    public void increasingScore()
    {
        {
            UpdateScore(1);
        }
    }
}
