using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TimeRace.Scripts
{
    public class Ramp : MonoBehaviour
    {
        [SerializeField]
        private float Force = 2f;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player"))
                return;

            var playerRb = other.gameObject.GetComponent<Rigidbody>();
            
            playerRb?.AddForce(
                new Vector3(0, Force, 0),
                ForceMode.Impulse
            );
        }
    }
}