using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeRace.Scripts.Scenario
{
    public class Barrier : MonoBehaviour
    {   
        [SerializeField]
        private ParticleSystem Particle;

        [SerializeField]
        private float Damage = 1f;
        [SerializeField]
        public float pushForce;

        void OnCollisionStay(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Player"))
                return;

            var player = collision.gameObject.GetComponent<PlayerControl>();

            player?.TakeDamage(Damage);
            Particle.Play();

            var playerRb = player.GetComponent<Rigidbody>();
            var playerCont = player.GetComponent<PlayerControl>();
            
            if (playerRb == null || playerRb.velocity.z <= 0)
                return;
            
            playerCont.Acceleration -= 2 * Time.deltaTime;
            playerRb.AddForce(
                new Vector3(0, 0, pushForce),
                ForceMode.Impulse
            );
        }
    }
}
