using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControls : MonoBehaviour
{

    public float horizontalSpeed = 105;
    float horizontalInput;
    float jumpForce = 100f;

    public LayerMask groundMask;

    private float timeElapsed = 0f;
    private bool started = false; 
    private Vector2 startPosition;

    Rigidbody body; 
    Transform t;

    float gravity = 9.8f;


    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private float jumpSpeed = 1;
    [SerializeField]
    private float maxSpeedVertical = 3;

    Vector3 movementVector = Vector3.zero;
    bool isGrounded = false;
    bool isGroundedCheckStop = false;

    void Start () 
    {
        body = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
    }

    void GetMovement() 
    {
        if( Input.GetKey(KeyCode.LeftArrow) ) {
            GetComponent<Rigidbody>()
                .MovePosition(
                    GetComponent<Rigidbody>().position - transform.right * horizontalSpeed * Time.fixedDeltaTime
                );
        }
        if( Input.GetKey(KeyCode.RightArrow) ) {
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.right * horizontalSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.Space)) {
            GetComponent<Rigidbody>()
                .MovePosition(
                    GetComponent<Rigidbody>().position + transform.up * jumpForce * Time.deltaTime
                );
        }
    }

    void ApplyGravity()
    {
        if (t.position.y >= 0) {
            GetComponent<Rigidbody>()
                .MovePosition(
                    GetComponent<Rigidbody>().position - transform.up * gravity * Time.deltaTime
                );
        }
    }

    private bool IsGrounded()
    {
        if (isGroundedCheckStop)
            return false;
        return body.position.y >= 0;
    }    

    void Update()
    {
        isGrounded = IsGrounded();

        if (isGrounded)
        {
            movementVector.y = 0;
        }

        if (t.position.y >= 0)
        {
            movementVector.y += gravity * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            isGroundedCheckStop = true;
            movementVector.y = -jumpSpeed;
            StartCoroutine(ResetGroundedCheckStop());
        }

        movementVector.z = Input.GetAxis("Horizontal") * this.speed;
        body.MovePosition(body.position + movementVector * Time.deltaTime);
        // ApplyGravity();
        // GetMovement();
    }

    private IEnumerator ResetGroundedCheckStop()
    {
        yield return new WaitForSeconds(0.5f);
        isGroundedCheckStop = false;
    }    

    void FixedUpdate()
    {
        
    }

}
