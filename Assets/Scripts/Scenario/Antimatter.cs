using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeRace.Scripts.Scenario
{
    public class Antimatter : MonoBehaviour
    {
        private GameObject Player;

        void Start()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        void Update()
        {
            transform.LookAt(Player.transform);
        }

        void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player"))
                return;
            
            Destroy(gameObject);
        }
    }
}
