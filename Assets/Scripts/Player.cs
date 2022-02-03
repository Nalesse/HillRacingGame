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

    private void Awake()
    {
        controls = new Controls();

        controls.Racing.Move.performed += ctx => controllerInput = ctx.ReadValue<Vector2>();
        controls.Racing.Move.canceled += ctx => controllerInput = Vector2.zero;

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
        //Lerp speed test
        if (Input.GetKeyDown(KeyCode.L))
        {
            doLerp = true;
        }

        if (doLerp)
        {
            speed = LerpSpeed(speed, 15);
        }
    }

    private float LerpSpeed(float currentSpeed,float desiredSpeed)
    {
        float newSpeed;
        float t = 0f;
        float duration = 2f;

        t += Time.deltaTime / duration;

        newSpeed = Mathf.Lerp(currentSpeed, desiredSpeed, t);

        return newSpeed;

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
