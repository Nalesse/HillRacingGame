using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShityCar : MonoBehaviour
{
    private Rigidbody carRB;

    [SerializeField] private float speed;
    [SerializeField] private float minDistance;
    [SerializeField] private float minDestroyDistance;
    // [SerializeField] private float distanceBetweenCars;
    
    // Start is called before the first frame update
    void Start()
    {
        carRB = GetComponent<Rigidbody>();
        transform.parent = null;
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawWireSphere(transform.position, distanceBetweenCars);
    //
    // }

    // Update is called once per frame
    void FixedUpdate()
    {
        var distance = (Player.Instance.transform.position - transform.position).z;
        
        if(distance >= minDistance)
        {
            var currentVelocity = carRB.velocity.y;
            carRB.velocity = new Vector3(0, currentVelocity, 1 * speed * Time.deltaTime);
        }

        if (distance >= minDestroyDistance)
        {
            Destroy(gameObject);
        }

        
    }
}
