using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialObjectMove : MonoBehaviour
{
    public float speed = 40.0f;
    public float minDistance;
    public float minDestroyDistance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        var distance = (Player.Instance.transform.position - transform.position).z;

        // Starts moving the car when the player is within the min distance
        if (distance >= minDistance)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (distance >= minDestroyDistance)
        {
            Destroy(gameObject);
        }


    }
}
