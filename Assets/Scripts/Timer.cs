using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60.0f;
    public TextMeshProUGUI timeValue; // used for showing countdown from 3, 2, 1 

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeValue.text = (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            //Do something useful or Load a new game scene depending on your use-case
        }
    }
}
