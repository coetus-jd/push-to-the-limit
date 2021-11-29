using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class PlayerControl : MonoBehaviour
{
    public float Life { get; private set; } = 100;

    [Header("Physics")]
    [SerializeField]
    private Collider Col;

    [SerializeField]
    private Rigidbody Rb;

    [Header("Velocity")]
    [SerializeField]
    private float Speed;

    private float Acceleration;

    [SerializeField]
    private float ReductionForce;

    [SerializeField]
    private float StopForce;

    [Space]
    [SerializeField]
    private float RotateSpeed;
    private float rotate;
    [SerializeField]
    private float parallax;

    private float Vertical;
    private float Horizontal;

    [Header("Animation")]
    [SerializeField]
    private Animator Animator;

    [SerializeField]
    private SpriteRenderer SpriteRenderer;

    [Header("Parallax")]
    [SerializeField]
    private MeshRenderer mr;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Col = GetComponent<Collider>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");

        Movement();
        Rotation();
    }

    public void TakeDamage(float damage)
    {
        Life -= damage;
    }

    private void Movement()
    {
        if (Vertical != 0)
        {
            if (Vertical > 0)
            {
                if (Acceleration < 0)
                    Acceleration += Speed * Time.deltaTime * ReductionForce;
                else
                    Acceleration += Speed * Time.deltaTime;
            }
            else
            {
                if (Acceleration > 0)
                    Acceleration -= Speed * Time.deltaTime * ReductionForce;
                else
                    Acceleration -= Speed * Time.deltaTime;
            }
            Rb.velocity = Acceleration * transform.forward;
        }
        else
        {
            if (Acceleration > 0)
                Acceleration -= Speed * Time.deltaTime * StopForce;
            else
                Acceleration = 0;
            
        }

        
        Animator.SetFloat("Acceleration", Acceleration);
    }

    private void Rotation()
    {

        if (Horizontal != 0)
        {
            
            transform.Rotate(0,RotateSpeed * Horizontal * Time.deltaTime,0);
            SpriteRenderer.flipX = Horizontal >= 0 ? false : true;
            
            rotate = transform.localEulerAngles.y / 360;

            mr.material.mainTextureOffset = new Vector2 (rotate,0);


            Animator.SetBool("Curving", true);
            return;
        }

        
        Animator.SetBool("Curving", false);
    }
}
