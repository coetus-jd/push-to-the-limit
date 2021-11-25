using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeRace.Scripts.Scenario
{
    public class FinishLine : MonoBehaviour
    {
        [SerializeField]
        private GameObject TurnWithoutHitDialog;

        private int Rounds;

        void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player"))
                return;

            var pPlayer = other.gameObject.GetComponent<PlayerControl>();

            Rounds++;

            if (Rounds == 1 && pPlayer.Life == 100)
                TurnWithoutHitDialog.SetActive(true);
        }
    }
}
