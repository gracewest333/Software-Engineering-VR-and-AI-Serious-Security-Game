using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class explosion_on_collision : MonoBehaviour
{
    public GameObject explosion; // the explosion prefab
    // when the threat reaches 0 health, this function is called, the user has destroyed the threat!
    void OnCollisionEnter(){
        GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject; // starts the exposion at the position of the threat that is about to be destroyed 
        Destroy(gameObject); // destroys the threat
    }
}


