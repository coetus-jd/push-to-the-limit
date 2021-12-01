using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeRace.Scripts.Scenario
{
    public class Barrier : MonoBehaviour
    {   


        [SerializeField]
        private float Damage = 1f;
        [SerializeField]
        private float pushForce;


        void OnCollisionEnter(Collision other) {

            var player = other.gameObject.GetComponent<PlayerControl>();
            var playerRb = other.gameObject.GetComponent<Rigidbody>();

        if (other.gameObject.CompareTag("Player"))
        {

            player?.TakeDamage(Damage);
            Debug.Log(player.transform.position);

            if (player.Acceleration >0 && playerRb != null)
            {

                    playerRb.AddForce(transform.position * pushForce, ForceMode.Impulse);

            }

            
        }

        }


    }
}
