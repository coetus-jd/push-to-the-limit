using System.Collections.Generic;
using UnityEngine;

namespace TimeRace.Scripts.Utilities
{
    public class Activator : MonoBehaviour
    {
        /// <summary>
        /// Objects to activate when another object enter the area
        /// </summary>
        [SerializeField]
        private List<GameObject> objectsToActivate;

        /// <summary>
        /// Tag that will be used to compare on the collision
        /// </summary>
        [SerializeField]
        private string tagToCompare = "Player";

        void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag(tagToCompare))
                return;

            if (objectsToActivate == null || objectsToActivate.Count == 0)
                return;

            objectsToActivate.ForEach(gameObject => gameObject.SetActive(true));
        }
    }
}