using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Physics")]
    [SerializeField]
    private Collider Col;
    [SerializeField]
    private Rigidbody rb;

    [Header("Speed")]
    [SerializeField]
    private int speed;
    [SerializeField]
    private int ReductionForce;
    [SerializeField]
    private int burstForce;
    [SerializeField]
    private float acceleration;

    [Header("Rotation")]
    [SerializeField]
    private float rotateTime;
    [SerializeField]
    private float rotateSpeed;
    private float rotateElapsedTime = 0;
    private float rotate;

    private float LateralMove;
    
    private float Vertical;
    private float Horizontal;
    private Vector3 horizontalDirection;
    private Vector3 verticalDirection;
    private bool boost;



    [SerializeField]
    private float maxVel;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        boost = Input.GetKey(KeyCode.LeftShift);
    }

    void FixedUpdate()
    {
        Movement();
       //Rotation();
    }

    void Movement()
    {
    /*
    if ( Vertical == 0)
        {

            if (boost)
            {
                acceleration += speed * Time.deltaTime * burstForce;
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, acceleration);
            }

            return;
        }
        */
        if (Vertical < 0)
        {
            if (boost)
                acceleration += speed * Time.deltaTime * burstForce;
            /*else
            {
                if (rb.velocity.z > 0)
                    acceleration -= speed * Time.deltaTime * ReductionForce;
                else
                    acceleration -= speed * Time.deltaTime;
            }*/
            verticalDirection = acceleration * transform.forward;
            transform.position += (verticalDirection * Time.deltaTime);

        }
        /*
        else if(Vertical > 0)
        {
            if (boost)
            acceleration += speed * Time.deltaTime * burstForce;
        else
        {
            if (rb.velocity.z < 0)
                acceleration += speed * Time.deltaTime * ReductionForce;
            else
                acceleration += speed * Time.deltaTime;
        }

        rb.MovePosition(transform.position + (verticalDirection * acceleration));
        }
        */

    }
/*
    void Rotation()
    {
        if (Horizontal != 0)
        {

            LateralMove += Horizontal*rotateSpeed*Time.deltaTime;
            rotate = rb.rotation.y;

            if (rotateElapsedTime < (rotateTime / 3))
            {
                rotateElapsedTime += Time.fixedDeltaTime;
                rb.velocity = new Vector3( LateralMove,rb.velocity.y , rb.velocity.z);
                return;
            }

            else if (rotateElapsedTime < rotateTime * 100)
            {
                rotate += Horizontal*rotateSpeed*Time.deltaTime;
                rotateElapsedTime += Time.fixedDeltaTime;
                rb.transform.Rotate(Vector3.up, rotate);
                Debug.Log(rotate);
                return;

            }
                

        }
        else
        {

            LateralMove = 0;
            rotateElapsedTime = 0;

        }

    }
    */
}
