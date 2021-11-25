using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float Life { get; private set; } = 100;

    [Header("Physics")]
    [SerializeField]
    private Collider Col;
    [SerializeField]
    private Rigidbody rb;

    [Header("Velocity")]
    [SerializeField]
    private float speed;
    private float acceleration;
    [SerializeField]
    private float ReductionForce;
    [SerializeField]
    private float StopForce;
    [Space]
    [SerializeField]
    private float rotateSpeed;

    private float Vertical;
    private float Horizontal;

    [Header("Animation")]
    [SerializeField]
    private Animator Animator;
    [SerializeField]
    private SpriteRenderer SpriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Col = GetComponent<Collider>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
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

        if(Vertical != 0)
        {

            if(Vertical > 0)
            {
                if (acceleration < 0)
                    acceleration += speed * Time.deltaTime * ReductionForce;
                else
                    acceleration += speed * Time.deltaTime;
            }
            else
            {
                if (acceleration > 0)
                    acceleration -= speed * Time.deltaTime * ReductionForce;
                else
                    acceleration -= speed * Time.deltaTime;

            }
            
            rb.velocity = acceleration * transform.forward;

        }
        else

        
        {
            if(acceleration >0)
            {
                acceleration -= speed*Time.deltaTime*StopForce;
            }
            else if(acceleration<0)
            {
                acceleration += speed*Time.deltaTime*StopForce;
            }

            rb.velocity = acceleration * transform.forward;

        }

        Animator.SetFloat("Acceleration", acceleration);

    }

    void Rotation()
    {

        if (Horizontal != 0)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0,rotateSpeed * Horizontal* Time.deltaTime,0) );
            SpriteRenderer.flipX = Horizontal >= 0 ? false : true;

            Animator.SetBool("Curving", true);
        }

        else
        {
            Animator.SetBool("Curving", false);
        }

    }

}
