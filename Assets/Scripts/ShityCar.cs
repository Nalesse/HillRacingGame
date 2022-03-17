using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShityCar : MonoBehaviour
{
    Rigidbody carRB;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        carRB = GetComponent<Rigidbody>();
        transform.parent = null;
        speed = Player.Instance.speed;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = (Player.Instance.transform.position - transform.position).z;
        

        Debug.Log(distance);
        if(distance >= -100)
        {
            var currentVelocity = carRB.velocity.y;
            carRB.velocity = new Vector3(0, currentVelocity, 1 * speed * Time.deltaTime);
        }
    }
}
