using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShityCar : MonoBehaviour
{
    Rigidbody carRB;
    // Start is called before the first frame update
    void Start()
    {
        carRB = GetComponent<Rigidbody>();
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = (Player.Instance.transform.position - transform.position).z;
        var speed = Player.Instance.speed;

        if(distance >= 20)
        {
            Debug.Log(distance);
            var currentVelocity = carRB.velocity.y;
            carRB.velocity = new Vector3(0, currentVelocity, 1 * speed * Time.deltaTime);
        }
        else if(distance >= 300)
        {
            Destroy(gameObject, 2);
            Debug.Log("Car destroyed");
        }
    }
}
