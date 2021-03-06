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

    [Header("FireBurst")]
    [SerializeField]
    private Transform fire;
    [SerializeField]
    private GameObject burst;

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
  
    // [Header("Audio")]
    // [SerializeField]
    // private AudioSource EngineSound;

    // [SerializeField]
    // private AudioSource EngineJumpSound;
    [Header("Damage")]
    [SerializeField]
    public Transform HealthBar;         //Barra verde
    [SerializeField]
    public GameObject HealthBarObject;  // Objeto pai das barras
    private Vector3 HealthBarScale;     //Tamanho da barra
    private float HealthPercent;       //Pencentual de vida para o calculo do tamanho da barra
    [SerializeField]
    private Transform Dam;
    [SerializeField]
    private GameObject Dano;
    private bool lastDamage;


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
        fire.transform.rotation = transform.localRotation;
        burst.GetComponent<Animator>().SetFloat("Accel2", Acceleration);
       
        if(lastDamage == false){
        Movement();
        Rotation();
        }

    }

    public void TakeDamage(float damage)
    {
        Dam.transform.rotation = transform.localRotation;
        
        if( Life >0)
        {
        Life -= damage;
        Dano.GetComponent<Animator>().SetBool("Damaging", true);
 
        if(Acceleration > 0)
        {
            Acceleration -= 4;
        }
        }
        else if(lastDamage == false)
        {
            Dano.GetComponent<Animator>().SetBool("Destruction", true);
            Acceleration = 0;
            lastDamage = true;
        }
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
            if (Vertical > 0 && Acceleration <= 30)
            {
                if (Acceleration < 0)
                    Acceleration += Speed * Time.deltaTime * ReductionForce;
                else
                    Acceleration += Speed * Time.deltaTime;
                    burst.GetComponent<Animator>().SetBool("Accel1", true);
                    
            }
            else if(Acceleration >=-30)
            {
                if (Acceleration > 0)
                    Acceleration -= Speed * Time.deltaTime * ReductionForce;
                else
                    Acceleration -= Speed * Time.deltaTime;

                    burst.GetComponent<Animator>().SetBool("Accel1",false);
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
            burst.GetComponent<Animator>().SetBool("Accel1",false);
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
