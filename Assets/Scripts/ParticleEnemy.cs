using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEnemy : MonoBehaviour
{
    private bool isAlreadyPlayed;
    void Update()
    {
        
        if(transform.root.childCount == 1 && !isAlreadyPlayed )
        {
            GetComponent<ParticleSystem>().Play();
            isAlreadyPlayed = true;
           
        }
    }
}
