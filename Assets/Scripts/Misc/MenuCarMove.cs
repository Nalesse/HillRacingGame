using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCarMove : MonoBehaviour
{
    private int bound = 90;
    public float speed = 40.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.position.x > bound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -bound)
        {
            Destroy(gameObject);
        }
    }
}
