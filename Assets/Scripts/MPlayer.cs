using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlayer : MonoBehaviour
{

    [Header("Physics")]
    [SerializeField]
    private Collider Col;
    [SerializeField]
    private Rigidbody rb;

    [Header("Speed")]
    [SerializeField]
    float acceleration;
    [SerializeField]
    float maxSpeed;

    Vector3 velocity;
    Vector3 direction = Vector3.zero;
    Vector3 currentVelocity;

    void Start()
    {
        
    }

    void Update()
    {
        playerMoviment();
    }

    void playerMoviment()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

        velocity = Vector3.SmoothDamp(velocity, direction * maxSpeed, ref currentVelocity, maxSpeed / acceleration);

        transform.position += velocity * Time.deltaTime;
        
    }
}
