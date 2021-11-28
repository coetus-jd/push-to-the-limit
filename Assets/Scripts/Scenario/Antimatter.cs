using System.Collections;
using System.Collections.Generic;
using TimeRace.Scripts.Managers;
using UnityEngine;

namespace TimeRace.Scripts.Scenario
{
    public class Antimatter : MonoBehaviour
    {
        [SerializeField]
        private AntimatterManager AntimatterManager;

        private GameObject Player;

        void Start()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            AntimatterManager = GameObject
                .FindGameObjectWithTag("AntimatterManager")
                .GetComponent<AntimatterManager>();
        }

        void Update()
        {
            transform.LookAt(Player.transform);
        }

        void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player"))
                return;
            
            AntimatterManager.Add(1);
            Destroy(gameObject);
        }
    }
}
