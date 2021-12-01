using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    void Danification()
    {
        GetComponent<Animator>().SetBool("Damaging", false);
    }
    

    void Fim(){
        GetComponent<Animator>().SetBool("Destruction", false);
    }

}
