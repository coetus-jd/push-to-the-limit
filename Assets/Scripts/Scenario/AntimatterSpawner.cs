using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeRace.Scenario
{
    public class AntimatterSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject AntimatterPrefab;

        [SerializeField]
        private int Quanitity = 10;

        [SerializeField]
        private float AxisY = 0.3f;

        void Start()
        {
            for (int index = 0; index < Quanitity; index++)
            {
                Vector3 origin = transform.position;
                Vector3 range = transform.localScale / 2.0f;
                
                Vector3 randomRange = new Vector3(
                    UnityEngine.Random.Range(-range.x, range.x),
                    AxisY,
                    UnityEngine.Random.Range(-range.z, range.z)
                );
                Vector3 randomCoordinate = origin + randomRange;

                var instatiatedAntimatter = Instantiate(
                    AntimatterPrefab,
                    randomCoordinate,
                    Quaternion.identity
                );
            }
        }
    }
}
