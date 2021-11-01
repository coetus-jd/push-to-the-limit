using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [Header("Physics")]
    [SerializeField] private Collider Col;
    [SerializeField] private Rigidbody rb;

    [Header("Speed")]
    [SerializeField] private int speed;
    [SerializeField] private int ReductionForce;

    [SerializeField] private float maxVel;

    private float acceleration;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Moviment();
    }

    void Moviment()
    {
         if (Input.GetAxis("Vertical") != 0 )

        {      

            if (Input.GetAxis("Vertical") > 0)
            {  
                if(rb.velocity.z < 0)
                {
                acceleration += speed * Time.deltaTime * ReductionForce; 
                }
                else
                {
                acceleration += speed * Time.deltaTime;  
                }
                rb.velocity = new Vector3(0f,rb.velocity.y,acceleration);
                
            }
            else
            {    
                if(rb.velocity.z > 0)
                {
                acceleration -= speed * Time.deltaTime * ReductionForce;  
                }
                else
                {
                acceleration -= speed * Time.deltaTime;  
                }
                rb.velocity = new Vector3(0f,rb.velocity.y,acceleration);

            }

        }

        else
        {
            acceleration = rb.velocity.z;
        }

    }

    void Rotation()
    {


    }






}
