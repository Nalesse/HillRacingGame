using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShityCar : MonoBehaviour, ICollidable
{
    private Rigidbody carRB;

    [SerializeField] private float speed;
    [SerializeField] private float minDistance;
    [SerializeField] private float minDestroyDistance;
    [SerializeField] private float nearMissSpeed;
    
    [Header("Crash Settings")]
    [SerializeField] private float crashLeftSideX;
    [SerializeField] private float crashRightSideX;
    [SerializeField] private float crashSpeed;
    private string crashDirection;
    private Animator Animator;
    
    private bool stopMoving;
    private Transform _transform;
    private bool doCrash;
    private static readonly int CrashLeft = Animator.StringToHash("CrashLeft");
    private static readonly int CrashRight = Animator.StringToHash("CrashRight");
    private AudioSource audioSource;


    private void Awake()
    {
        _transform = GetComponent<Transform>();
        carRB = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
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
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
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
            CollisionAction();
        }
    }

    private void LerpPosition(float target)
    {
        var position = _transform.position;
        position.x = Mathf.MoveTowards(position.x, target, crashSpeed * Time.deltaTime);
        _transform.position = position;
    }

    public void CollisionAction()
    {
        doCrash = true;
        float xDistance = Player.Instance.transform.position.x - _transform.position.x;
        crashDirection = xDistance < 0 ? "Left" : "Right";
        stopMoving = true;

        switch (crashDirection)
        {
            case "Left":
                LerpPosition(crashLeftSideX);
                Animator.SetTrigger(CrashLeft);
                break;
            case "Right":
                LerpPosition(crashRightSideX);
                Animator.SetTrigger(CrashRight);
                break;
        }
        
        carRB.velocity = Vector3.zero;
        carRB.angularVelocity = Vector3.zero;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (Player.Instance.isDamage == false && !Player.Instance.gameOver)
        {
            Debug.Log("Near Miss");
            Player.Instance.speed = nearMissSpeed;
        }
    }
}


