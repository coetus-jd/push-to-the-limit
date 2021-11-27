using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeRace.Scripts.Scenario
{
    public class Barrier : MonoBehaviour
    {
        [SerializeField]
        private float Damage = 1f;

        void OnCollisionStay(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Player"))
                return;

            var player = collision.gameObject.GetComponent<PlayerControl>();

            player?.TakeDamage(Damage);

            var playerRb = player.GetComponent<Rigidbody>();
            
            if (playerRb == null || playerRb.velocity.z <= 0)
                return;
            
            playerRb.AddForce(
                new Vector3(0, 0, Time.deltaTime * -1),
                ForceMode.Acceleration
            );
        }
    }
}
