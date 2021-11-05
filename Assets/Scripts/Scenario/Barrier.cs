using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeRace.Scripts.Scenario
{
    public class Barrier : MonoBehaviour
    {
        void OnCollisionStay(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Player"))
                return;

            var player = collision.gameObject.GetComponent<Player>();

            player?.TakeDamage(1f);
        }
    }
}
