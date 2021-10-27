using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeRace.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private float Acceleration;

        [SerializeField]
        private float VerticalVelocity;

        [SerializeField]
        private float HorizontalVelocity;

        [SerializeField]
        private float StopForce = 0.01f;

        [SerializeField]
        private float MaxRotationAngle = 25f;

        [SerializeField]
        private float MaxSpeed = 40f;

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

                if (VerticalVelocity < MaxSpeed)
                    VerticalVelocity += verticalMovement * Acceleration * Time.deltaTime;
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

                // var yRotation = 1;

                Debug.Log(horizontalMovement);
                // Debug.Log($"É menor que o máximo: {transform.eulerAngles.y < MaxRotationAngle}");
                // Debug.Log($"É maior que o mínimo: {transform.eulerAngles.y > (MaxRotationAngle * -1)}");

                if (transform.eulerAngles.y < MaxRotationAngle && transform.eulerAngles.y > (MaxRotationAngle * -1))
                    transform.Rotate(0, 1 * horizontalMovement, 0, Space.Self);
                else
                    transform.Rotate(0, 1 * (horizontalMovement * -1), 0, Space.Self);
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
}
