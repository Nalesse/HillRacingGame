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
    
    [Header("Crash Settings")]
    [SerializeField] private float crashLeftSideX;
    [SerializeField] private float crashRightSideX;
    [SerializeField] private float crashSpeed;
    private string crashDirection;
    
    private bool stopMoving = false;
    private Transform _transform;
    private bool doCrash = false;
    
    

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    
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
        if(distance >= minDistance && stopMoving == false)
        {
            var currentVelocity = carRB.velocity.y;
            carRB.velocity = new Vector3(0, currentVelocity, 1 * speed * Time.deltaTime);
        }

        if (distance >= minDestroyDistance)
        {
            Destroy(gameObject);
        }

        
    }

    private void Update()
    {
        if (doCrash)
        {
            Crash(crashDirection);
        }
    }

    public void Crash(string _crashDirection)
    {
        crashDirection = _crashDirection;
        doCrash = true;
        stopMoving = true;

        switch (crashDirection)
        {
            case "Left":
                LerpPosition(crashLeftSideX);
                break;
            case "Right":
                LerpPosition(crashRightSideX);
                break;
        }
        
        carRB.velocity = Vector3.zero;
        carRB.angularVelocity = Vector3.zero;
        
    }

    private void LerpPosition(float target)
    {
        var position = _transform.position;
        position.x = Mathf.MoveTowards(position.x, target, crashSpeed * Time.deltaTime);
        _transform.position = position;
    }
}
