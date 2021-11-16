using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [Header("Physics")]
    [SerializeField]
    private Collider Col;
    [SerializeField]
    private Rigidbody rb;

    [Header("Speed")]
    [SerializeField]
    private int speed;
    private float acceleration;
    [SerializeField]
    private int ReductionForce;
    [SerializeField]
    private int StopForce;

    [Header("Rotation")]
    [SerializeField]
    private float rotateSpeed;
    private Vector3 rotate;
    Vector3 currentVelocity;




    private float LateralMove;
    private Vector3 horizontalDirection;
    private Vector3 verticalDirection;



    private float Vertical;
    private float Horizontal;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Col = GetComponent<Collider>();
    }

    void Update() 
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        Movement();
        Rotation();
    }

    void Movement()
    {

        if(Vertical > 0)
        {
            if(acceleration < 0)
            {
                acceleration += speed * Time.deltaTime * ReductionForce * StopForce;
            }            
            else
            {
                acceleration += speed * Time.deltaTime;
            }
            
            verticalDirection = acceleration * transform.forward;
            transform.position += (verticalDirection * Time.deltaTime);

        }
        else if(Vertical < 0)
        {
            if(acceleration > 0)
            {
                acceleration -= speed * Time.deltaTime * ReductionForce * StopForce;
            }            
            else
            {
                
                acceleration -= speed * Time.deltaTime;
            }
            
            verticalDirection = acceleration * transform.forward;
            transform.position += (verticalDirection * Time.deltaTime);

        }
        else
        {
            if(acceleration > 0)
            {
                acceleration -= speed * Time.deltaTime * StopForce;
            }   
            else if(acceleration < 0)
            {
                acceleration += speed * Time.deltaTime * StopForce;
            } 


            verticalDirection = acceleration * transform.forward;
            transform.position += (verticalDirection * Time.deltaTime);
            Debug.Log(acceleration);

        }
        

    }

    void Rotation()
    {
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            return;
        
        Vector3 direction = new Vector3(Horizontal, 0, 0).normalized;

        rotate = Vector3.SmoothDamp(rotate, direction * rotateSpeed, ref currentVelocity,acceleration );

        transform.Rotate(0, rotateSpeed * Horizontal, 0, Space.Self);

    }
}
