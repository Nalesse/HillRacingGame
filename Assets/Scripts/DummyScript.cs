using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DummyScript : MonoBehaviour
{
    public TextMeshProUGUI textThing;
    public int numbers;
    private TrickSystem trickSys;
    // Start is called before the first frame update
    void Start()
    {
        trickSys = GameObject.Find("Player").GetComponent<TrickSystem>();
        textThing = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textThing.text = "" + numbers;
        if (trickSys.isDoingTrick)
        {
            numbers += 1;
        }
        
    }
}
