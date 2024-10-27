using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float jumpHeight;

    [SerializeField, Range(1, 20)] private float mouseSensX;
    [SerializeField, Range(1, 20)] private float mouseSensY;
    [SerializeField, Range(-90, 0)] private float minViewAngle;
    [SerializeField, Range(0, 90)] private float maxViewAngle;

    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform lookAtPoint;

    [SerializeField] private LayerMask groundLayer;

    private Rigidbody rb;
    private Vector3 movementVector;
    private Vector3 targetVelocity;
    private Vector2 currentRotation;

    private float xVelocity; 
    private float yVelocity; 
    private float zVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce (movementVector); 

        Vector3 forwardDirection = transform.forward.normalized;
        Vector3 rightDirection = transform.right.normalized;

        Vector3 relativeMovement = (forwardDirection * movementVector.z + rightDirection * movementVector.x).normalized;

        targetVelocity = relativeMovement * maxSpeed;
        xVelocity = Mathf.Lerp(rb.velocity.x, targetVelocity.x, acceleration * Time.deltaTime);
        zVelocity = Mathf.Lerp(rb.velocity.z, targetVelocity.z, acceleration * Time.deltaTime);
        rb.velocity =  new Vector3(xVelocity, rb.velocity.y, zVelocity);
    } 

    void OnMove(InputValue movementValue)
    {
        movementVector = movementValue.Get<Vector3>();
    }

    void OnJump ()
    {
        if (IsGrounded())
        {
            rb.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
        }
    }

    void OnLook(InputValue lookValue)
    {
        //controls rotation angles
        currentRotation.x += lookValue.Get<Vector2>().x * Time.deltaTime * mouseSensX;
        currentRotation.y += lookValue.Get<Vector2>().y * Time.deltaTime * -mouseSensY;

        //rotates left & right 
        transform.rotation = Quaternion.AngleAxis(currentRotation.x, Vector3.up);

        //clamp rotation angles 
        currentRotation.y = Mathf.Clamp(currentRotation.y, minViewAngle, maxViewAngle);

        //rotate up and down
        lookAtPoint.localRotation = Quaternion.AngleAxis(currentRotation.y, Vector3.right);
    }


    private bool IsGrounded()
    {
        

        if (Physics.Raycast(transform.position, Vector3.down, 10.5f, groundLayer))
        {
           
            return true;
        } 
        else
        {
            
            return false;
        }
    }
}
