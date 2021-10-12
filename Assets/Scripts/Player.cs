using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float Velocity;

    [SerializeField]
    private float StopForce = 20f;

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            var verticalMovement = Input.GetAxis("Vertical");
            Velocity += verticalMovement * Time.deltaTime;
        }
        else
        {
            if (Velocity > 0)
                Velocity -= StopForce * Time.deltaTime;
            else
                Velocity = 0f;
        }

        transform.position += (Velocity * Time.deltaTime) * transform.forward;
    }
}
