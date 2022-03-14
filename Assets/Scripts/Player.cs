using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cinemachine;

public class Player : MonoBehaviour
{
    Controls controls;
    
    [Header("Movement")]
    public float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float lerpSpeed;
    public float turnSpeed = 420f;
    public Vector2 controllerInput;
    public Rigidbody playerRB;
    public float currentVelocity;


    [Header("Ground collision")]
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask ground;

    //Tricks
    [Header("Tricks")]
    public bool isTrick;
    public bool northTrick;
    
    //Player Boundaries
    [Header("Player Bounds")]
    [SerializeField] private float xLimit;
    // Slow down Vars
    [Header("Slowdown Vars")]
    [SerializeField] private float xSlowDownRange;
    [SerializeField] private float slowDownSpeed;
    [SerializeField] private float slowDownLerpSpeed;
    private bool slowDownIsActive;

    //Animation stuff
    public Animator animator;

    
    private void Awake()
    {
        controls = new Controls();

        controls.Racing.Move.performed += ctx => controllerInput = ctx.ReadValue<Vector2>();
        controls.Racing.Move.canceled += ctx => controllerInput = Vector2.zero;

        controls.Racing.NorthTrick.performed += ctx => NorthTrick();
        controls.Racing.NorthTrick.canceled += ctx => NorthTrickCancelled();

    }
    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
        
        KeepInBounds();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,.15f, ground);
        if (!isGrounded)
        {
            animator.SetBool("isGrounded",false);
        }
        else
        {
            animator.SetBool("isGrounded", true);
        }

        if (!slowDownIsActive)
        {
            speed = LerpSpeed(speed, maxSpeed, lerpSpeed);
        }

        if (isTrick)
        {
            turnSpeed = 210f;
        }
        else
        {
            turnSpeed = 420;
        }

        //checks to see if player Wipesout, and resets trick bools
        if (isTrick && isGrounded)
        {
            Debug.Log("Wipeout");
            isTrick = false;
            northTrick = false;
            

            //Decrease hp by one here:
        }

        PlayerSlowDown();
    }

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


    //All code Refering to north button trick
    void NorthTrick()
    {
        if (!isGrounded)
        {
            isTrick = true;
            northTrick = true;
            animator.SetBool("Ntrick", true);
            

        }
       
    }

    void NorthTrickCancelled()
    {
        StartCoroutine(NorthTrickCooldown());
    }

    IEnumerator NorthTrickCooldown()
    {
        if (!isGrounded)
        {
            northTrick = false;
            animator.SetBool("Ntrick", false);
            Debug.Log("start cooldown");
            

            //this is cooldown time for trick
            yield return new WaitForSeconds(.7f);

            Debug.Log("Trickcooled");
            
            isTrick = false;
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
        
    private void OnEnable()
    {
        controls.Racing.Enable();
    }

    private void OnDisable()
    {
        controls.Racing.Disable();
    }
}
