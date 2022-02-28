using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class explosion_on_collision : MonoBehaviour
{
    public GameObject explosion; // drag your explosion prefab here


    void OnCollisionEnter(){
        GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject); // destroy the grenade
        //Destroy(expl, 3); // delete the explosion after 3 seconds
    }
}

