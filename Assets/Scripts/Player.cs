using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float Accelartion;
    
    [SerializeField]
    private float VerticalVelocity;

    [SerializeField]
    private float HorizontalVelocity;

    [SerializeField]
    private float StopForce = 0.01f;

    [SerializeField]
    private float MaxRotationAngle = 30f;

    void Update()
    {
        HandleHorizontalMovement();
        HandleVerticalMovement();
    }

    private void HandleHorizontalMovement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            var verticalMovement = Input.GetAxis("Vertical");
            VerticalVelocity += verticalMovement * Accelartion * Time.deltaTime;
        }
        else
        {
            if (VerticalVelocity > 0)
                VerticalVelocity -= StopForce * Time.deltaTime;
            else
                VerticalVelocity = 0f;
        }

        transform.position += (VerticalVelocity * Time.deltaTime) * transform.forward;
    }

    private void HandleVerticalMovement()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            var horizontalMovement = Input.GetAxis("Horizontal");
            HorizontalVelocity += horizontalMovement * Time.deltaTime;

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.identity,
                ((transform.rotation.y >= MaxRotationAngle || transform.rotation.y <= -MaxRotationAngle) ? 0f : (horizontalMovement * 1))
            );
        }
        else
        {
            if (HorizontalVelocity > 0)
                HorizontalVelocity -= StopForce * Time.deltaTime;
            else
                HorizontalVelocity = 0f;
        }

        transform.position += (HorizontalVelocity * Time.deltaTime) * transform.right;
    }
}
