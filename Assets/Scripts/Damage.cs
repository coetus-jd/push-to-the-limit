using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject lost;
    [SerializeField]
    private GameObject Die;

    void Danification()
    {
        GetComponent<Animator>().SetBool("Damaging", false);
    }
    
    void Destroy(){
        player.GetComponent<SpriteRenderer>().enabled = false;

    }

    void Fim(){
        GetComponent<Animator>().SetBool("Destruction", false);
        Die.SetActive(true);
        
        lost.SetActive(true);
    }

}
