using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShityCar : MonoBehaviour
{
    private Rigidbody carRB;

    [SerializeField] private float speed;
    [SerializeField] private float minDistance;
    [SerializeField] private float minDestroyDistance;
    [SerializeField] private GameObject[] shittyCarModels;
    
    // Start is called before the first frame update
    void Start()
    {
        // Picks a random car model and makes it a child object
        var spawnIndex = Random.Range(0, shittyCarModels.Length);
        Instantiate(shittyCarModels[spawnIndex], transform);
        
        carRB = GetComponent<Rigidbody>();
        // Unparents the game object from the road tile
        // so it doesn't get destroyed when the tile does 
        transform.parent = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var distance = (Player.Instance.transform.position - transform.position).z;
        
        // Starts moving the car when the player is within the min distance
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
