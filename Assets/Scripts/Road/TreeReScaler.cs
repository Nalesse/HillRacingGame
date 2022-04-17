using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeReScaler : MonoBehaviour
{
    public bool isPalm;
    // Start is called before the first frame update
    void Start()
    {
        if (!isPalm)
        {
            gameObject.transform.localScale = new Vector3(1, Random.Range(0.9f, 1.3f), 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(2f, Random.Range(1.9f, 2.1f), 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
