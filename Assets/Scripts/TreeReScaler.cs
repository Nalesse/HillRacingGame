using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeReScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(1, Random.Range(0.9f,1.3f), 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
