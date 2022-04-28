using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMoving : MonoBehaviour
{
    public float speed = 60.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (transform.position.z < -50)
        {
            Destroy(gameObject);
        }
    }
}

