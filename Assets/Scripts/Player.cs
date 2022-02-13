using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Controls controls;

    public float speed;
    public float turnSpeed;

    public Vector2 controllerInput;

    public Rigidbody playerRB;

    public float currentVelocity;

    private bool doLerp;

    public bool isGrounded;

    //Tricks
    public bool isTrick;
    public bool northTrick;
    
    [Header("Lerp Debug")]
    // Lerp variables
    [SerializeField] private float speedToLerpTo;
    [SerializeField] private float lerpSpeed;

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
        currentVelocity = playerRB.velocity.y; //makes the player fall normally
        //Moves player forward

        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        playerRB.velocity = new Vector3(0, currentVelocity, 1 * speed * Time.deltaTime);

        //right
        if (controllerInput.x >= 0.2f)
        {
            //transform.Translate(Vector2.right * Time.deltaTime * turnSpeed);
            playerRB.velocity = new Vector3(controllerInput.x * turnSpeed * Time.deltaTime, currentVelocity, 1 * speed * Time.deltaTime);
        }

        //left
        if (controllerInput.x <= -0.2f)
        {
            //transform.Translate(Vector2.left * Time.deltaTime * turnSpeed);
            playerRB.velocity = new Vector3(controllerInput.x * turnSpeed * Time.deltaTime, currentVelocity, 1 * speed * Time.deltaTime);
        }
    }

    private void Update()
    {
        // This is just code to test that the lerp works, feel free to replace this with the new input system. or implement the LerpSpeed() function
        // in anyway you see fit.
        if (Input.GetKeyDown(KeyCode.L))
        {
            doLerp = true;
        }

        if (doLerp)
        {
            speed = LerpSpeed(speed, speedToLerpTo, lerpSpeed);
        }
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
    /// <param name="lerpSpeed">
    /// The rate at which currentSpeed will approach desiredSpeed
    /// </param>
    /// <returns></returns>
    private float LerpSpeed(float currentSpeed,float desiredSpeed, float lerpSpeed)
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, desiredSpeed, lerpSpeed * Time.deltaTime);

        return currentSpeed;
    }

    void NorthTrick()
    {
        isTrick = true;
        northTrick = true;
    }

    void NorthTrickCancelled()
    {
        StartCoroutine(NorthTrickCooldown());
    }

    IEnumerator NorthTrickCooldown()
    {
        northTrick = false;
        Debug.Log("start cooldown");

        yield return new WaitForSeconds(1.5f);

        Debug.Log("Trickcooled");
        isTrick = true;

        yield return null;

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
