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

    public float Acceleration;

    [SerializeField]
    private float ReductionForce;

    [SerializeField]
    private float StopForce;

    [Space]
    [SerializeField]
    private float RotateSpeed;
    private float rotate;

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
    [Header("Check")]
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float groundDistance = 0.1f; 
    [SerializeField]
    private Transform Feet;
    private bool ground;

    [Header("Damage")]
    [SerializeField]
    public Transform HealthBar;         //Barra verde
    [SerializeField]
    public GameObject HealthBarObject;  // Objeto pai das barras
    private Vector3 HealthBarScale;     //Tamanho da barra
    private float HealthPercent;        //Pencentual de vida para o calculo do tamanho da barra


    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Col = GetComponent<Collider>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
        HealthBarScale = HealthBar.localScale;
        HealthPercent = HealthBarScale.x / Life;
    }

    void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        ground = !Physics.CheckSphere(Feet.position, groundDistance, groundLayer,QueryTriggerInteraction.Ignore);
        Movement();
        Rotation();
    }

    public void TakeDamage(float damage)
    {
        Life -= damage;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        HealthBarScale.x = HealthPercent * Life;
        HealthBar.localScale = HealthBarScale;
    }

    private void Movement()
    {
        if (Vertical != 0 && ground == false)
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
        else if (Vertical == 0 && ground == false)
        {
            if (Acceleration > 0)
                Acceleration -= Speed * Time.deltaTime * StopForce;
            else
                Acceleration = 0;

            Rb.velocity = Acceleration * transform.forward;
            
        }
        else
        {
            Rb.velocity -=transform.up;
        }

        
        Animator.SetFloat("Acceleration", Acceleration);
    }

    private void Rotation()
    {

        if (Horizontal != 0)
        {
            
            Rb.MoveRotation(Rb.rotation * Quaternion.Euler(0,RotateSpeed * Horizontal * Time.deltaTime,0));
            SpriteRenderer.flipX = Horizontal >= 0 ? false : true;
            
            rotate = transform.localEulerAngles.y / 360;

            mr.material.mainTextureOffset = new Vector2 (rotate,0);


            Animator.SetBool("Curving", true);
            return;
        }

        
        Animator.SetBool("Curving", false);
    }
}
