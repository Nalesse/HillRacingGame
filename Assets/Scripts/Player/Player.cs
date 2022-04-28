using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Cinemachine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Controls controls;
    //TrickSystem trickSystem;

    AudioManager audioSongs;

    [Header("Movement")]
    public float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float lerpSpeed;
    public float turnSpeed = 420f;
    public Vector2 controllerInput;
    public Rigidbody playerRB;
    public float currentVelocity;
    public AudioSource lofi;

    //Timers
    public bool northTrickTimer;
    public bool eastTrickTimer;
    public bool southTrickTimer;
    public bool westTrickTimer;

    public float maxInputBuffer = 0.3f;

    [Header("Ground collision")]
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask ground;

    
    [Header("Tricks")]
    public bool isDamage;
    private TrickSystem TrickSystem;

    //Player Boundaries
    [Header("Player Bounds")]
    [SerializeField] private float xLimit;
    // Slow down Vars
    [Header("Slowdown Vars")]
    [SerializeField] private float xSlowDownRange;
    [SerializeField] private float slowDownSpeed;
    [SerializeField] private float slowDownLerpSpeed;
    private bool slowDownIsActive;

    public bool gameOver { get; private set; }

    //Animation stuff
    public Animator animator;

    //Debug Tools
    public float jumpForce;

    //singleton
    public static Player Instance { get; private set; }
    
    //Audio
    [Header("Audio")]
    [SerializeField] private AudioClip damageSFX;
    [SerializeField] private AudioClip landingSFX;
    private AudioSource audioSource;
    private AudioSource sfxAudioSource;


    


    #region Unity Functions(Awake,Update, Start, etc)
    private void OnEnable()
    {
        controls.Racing.Enable();
        GameEvents.GameOver.AddListener(GameOver);
    }

    private void OnDisable()
    {
        controls.Racing.Disable();
        GameEvents.GameOver.RemoveListener(GameOver);
    }
    
    private void Awake()
    {
        controls = new Controls();

        audioSongs = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        TrickSystem = GetComponent<TrickSystem>();
        audioSource = GetComponent<AudioSource>();

        controls.Racing.Move.performed += ctx => controllerInput = ctx.ReadValue<Vector2>();
        controls.Racing.Move.canceled += ctx => controllerInput = Vector2.zero;

        // controls.Racing.DebugJump.performed += ctx => Jump();

        
        //stuff
        controls.Racing.NorthTrick.performed += ctx => northTrickTimer = true;
        controls.Racing.NorthTrick.canceled += ctx => northTrickTimer = false;

        controls.Racing.EastTrick.performed += ctx => eastTrickTimer = true;
        controls.Racing.EastTrick.canceled += ctx => eastTrickTimer = false;

        controls.Racing.SouthTrick.performed += ctx => southTrickTimer = true;
        controls.Racing.SouthTrick.canceled += ctx => southTrickTimer = false;

        controls.Racing.WestTrick.performed += ctx => westTrickTimer = true;
        controls.Racing.WestTrick.canceled += ctx => westTrickTimer = false;



        /*
        controls.Racing.NorthTrick.performed += ctx => TrickSystem.DoTrick("Ntrick");
        controls.Racing.NorthTrick.canceled += ctx => StartCoroutine(TrickSystem.CooldownTrick("Ntrick"));
        
        controls.Racing.EastTrick.performed += ctx => TrickSystem.DoTrick("Etrick");
        controls.Racing.EastTrick.canceled += ctx => StartCoroutine(TrickSystem.CooldownTrick("Etrick"));
        
        controls.Racing.SouthTrick.performed += ctx => TrickSystem.DoTrick("Strick");
        controls.Racing.SouthTrick.canceled += ctx => StartCoroutine(TrickSystem.CooldownTrick("Strick"));
        */


        // Singleton setup
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this;
        }

    }


   

    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
        sfxAudioSource = gameObject.AddComponent<AudioSource>();
        sfxAudioSource.volume = 0.5f;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {

        #region Input

        if (!gameOver)
        {
            //checks to see if turning
            int turning = 0;

            currentVelocity = playerRB.velocity.y; //makes the player fall normally
            //Moves player forward

            //transform.Translate(Vector3.forward * Time.deltaTime * speed);
            playerRB.velocity = new Vector3(0, currentVelocity, 1 * speed * Time.deltaTime);

            //right
            if (controllerInput.x >= 0.2f)
            {
                //transform.Translate(Vector2.right * Time.deltaTime * turnSpeed);
                playerRB.velocity = new Vector3(controllerInput.x * turnSpeed * Time.deltaTime, currentVelocity, 1 * speed * Time.deltaTime);
                turning = 1;
            }

            //left
            if (controllerInput.x <= -0.2f)
            {
                //transform.Translate(Vector2.left * Time.deltaTime * turnSpeed);
                playerRB.velocity = new Vector3(controllerInput.x * turnSpeed * Time.deltaTime, currentVelocity, 1 * speed * Time.deltaTime);
                turning = -1;
            }

            animator.SetInteger("Turn", turning);
        }
        

        #endregion
        
        KeepInBounds();
    }
    
    private void Update()
    {
        IsGroundedCheck();
        LerpControl();
        CheckForWipeout();
        PlayerSlowDown();

        if (TrickSystem.isDoingTrick)
        {
            turnSpeed = 210f;
        }
        else
        {
            turnSpeed = 420;
        }

        if (isGrounded)
        {
            if (!audioSource.isPlaying && isGrounded)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }

        TryTrick();

        
        
    }
    #endregion

    #region TrickTimers
    void TryTrick() 
    {
        if (TrickSystem.isDoingTrick)
        {
            CheckTrickCooldownTimers();
        }
        else
        {
            CheckTrickTimers();
        }

    }

    private void CheckTrickTimers()
    {
        if (northTrickTimer)
        {
            TrickSystem.DoTrick("Ntrick");
        }
        else if (eastTrickTimer)
        {
            TrickSystem.DoTrick("Etrick");
        }
        else if (southTrickTimer)
        {
            TrickSystem.DoTrick("Strick");
        }
        else if (westTrickTimer)
        {
            TrickSystem.DoTrick("Wtrick");
        }
    }

    private void CheckTrickCooldownTimers()
    {
        if (TrickSystem.stopCooldown)
        {
            return;
        }
        
        if (!northTrickTimer)
        {
            StartCoroutine(TrickSystem.CooldownTrick("Ntrick"));
        }

        if (!eastTrickTimer)
        {
            StartCoroutine(TrickSystem.CooldownTrick("Etrick"));
        }

        if (!southTrickTimer)
        {
            StartCoroutine(TrickSystem.CooldownTrick("Strick"));
        }

        if (!westTrickTimer)
        {
            StartCoroutine(TrickSystem.CooldownTrick("Wtrick"));
        }
    }

    #endregion
    


    #region UpdateHelperFunctions
    private void IsGroundedCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,.15f, ground);
        animator.SetBool("isGrounded", isGrounded);
    }

    private void LerpControl()
    {
        if (!slowDownIsActive && !isDamage)
        {
            speed = LerpSpeed(speed, maxSpeed, lerpSpeed);
        }
        
        if (isDamage)
        {
            speed = LerpSpeed(speed, speed/2, 500);
        }
    }

    private void CheckForWipeout()
    {
        // //checks to see if player Wipes-out
        if (TrickSystem.isDoingTrick && isGrounded)
        {
            TrickSystem.isDoingTrick = false;
            StartCoroutine(Damage());

        }
    }
    
    /// <summary>
    /// Keeps the player in the play area by limiting how far thy can move on the x
    /// </summary>
    private void KeepInBounds()
    {
        // Calculates what the position will be at the end of the current FixedUpdate frame based on the current
        // position and velocity of the rigid body. 
        var positionAtEndOfFrame = playerRB.position + playerRB.velocity * Time.deltaTime;
        
        // Adjusts the calculated position to be within the allowed x range.
        positionAtEndOfFrame.x = Mathf.Clamp(positionAtEndOfFrame.x, -xLimit, xLimit);
        // Calculates a new velocity that will take the player to the adjusted position which is inside the x range.
        var clampedVelocity = (positionAtEndOfFrame - playerRB.position) / Time.deltaTime;
        // Sets the velocity to the new velocity
        playerRB.velocity = clampedVelocity;
        
    }

    /// <summary>
    /// Reduces the players speed when they enter the slowdown range
    /// </summary>
    private void PlayerSlowDown()
    {
        // does not run the rest of the code if the player is in the air
        if (!isGrounded) {return;}
        
        var player = transform.position;
        
        if (player.x <= -xSlowDownRange || player.x >= xSlowDownRange)
        {
            slowDownIsActive = true;
            speed = LerpSpeed(speed, slowDownSpeed, slowDownLerpSpeed);
        }
        else
        {
            slowDownIsActive = false;
        }

    }

    #endregion

    

    /// <summary>
    /// Lerps between the current speed to the desired speed.
    /// the speed will slowly get closer to the desired speed each time this function is called 
    /// </summary>
    /// <param name="currentSpeed">
    /// The starting value for the lerp
    /// </param>
    /// <param name="desiredSpeed">
    /// The ending value for the lerp
    /// </param>
    /// <param name="_lerpSpeed">
    /// The rate at which currentSpeed will approach desiredSpeed
    /// </param>
    /// <returns></returns>
    private float LerpSpeed(float currentSpeed,float desiredSpeed, float _lerpSpeed)
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, desiredSpeed, _lerpSpeed * Time.deltaTime);

        return currentSpeed;
    }
    
    //Trick Debug 
    
    // void Jump()
    // {
    //     transform.Translate(Vector3.up * jumpForce * Time.deltaTime, Space.World);
    // }

     IEnumerator Damage()
     {

         if (TrickSystem.animatorBool != string.Empty)
         {
             animator.SetBool(TrickSystem.animatorBool, false);
         }
         
         animator.SetTrigger("isDamage");
         isDamage = true;
         yield return new WaitForSeconds(4);
         isDamage = false;

        

     }
     

    private void OnCollisionEnter(Collision collision)
    {
        var collisionObject = collision.gameObject.GetComponent<ICollidable>();
        if (collisionObject != null)
        {
            StartCoroutine(Damage());
            sfxAudioSource.PlayOneShot(damageSFX);
            collision.collider.enabled = false;
            //if the object the player collided with has a script attached which implements CollisionAction();
            //from ICollidable then that objects specific action will be run. e.g cars will spin out and billboards will play a particle effect    
            collisionObject.CollisionAction();
        }
        else
        {
            if (!audioSource.isPlaying)
            {
                sfxAudioSource.PlayOneShot(landingSFX);
            }
            
        }
    }

    private void GameOver()
    {
        playerRB.velocity /= 2;
        audioSongs.musicSource.Stop();
        sfxAudioSource.Stop();
        lofi.Play();
        gameOver = true;


    }
}
