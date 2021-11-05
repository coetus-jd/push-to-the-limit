using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeRace.Scripts
{
    public class Player : MonoBehaviour
    {
        [Header ("Physics")]
        [SerializeField]
        private Collider CarCollider;

        [SerializeField]
        private Rigidbody rb;

        [Header ("Velocity")]
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

        [SerializeField]
        private float Life = 100f;
        
        void Start() {

        rb = GetComponent<Rigidbody>();
        

        }


        void FixedUpdate() 
        {
            Accelerator();
        }

        void Accelerator ()
        {
            

        }

        void Update()
        {
            HandleHorizontalMovement();
            HandleVerticalMovement();
        }

        private void HandleVerticalMovement()
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

        private void HandleHorizontalMovement()
        {
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                return;

            var horizontalMovement = Input.GetAxis("Horizontal");
            transform.Rotate(0, 1 * horizontalMovement, 0, Space.Self);
        }


        public void TakeDamage(float damage)
        {
            Life -= damage;
        }
    }
}
