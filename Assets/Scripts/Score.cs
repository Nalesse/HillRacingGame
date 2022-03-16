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
    void Start()
    {
        score = 000000f;
        pointsIncreasing = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue.text = "" + (int)score;
        if (Input.GetKey(KeyCode.RightBracket))
            score += pointsIncreasing = 100 * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftBracket))
            score += pointsIncreasing = -100 * Time.deltaTime;
    }
}
