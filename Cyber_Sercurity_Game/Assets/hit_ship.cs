
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_ship : MonoBehaviour
{
    //saves the script of shiphealth as h (h for health)
    ShipHealth h;

    //finds the health bar object, then find the component ShipHealth
	void Start(){
		h= GameObject.FindGameObjectWithTag("health_bar").GetComponent<ShipHealth>();
	}


    //Start is called before the first frame update
    //Detects if the threat collides with a ship prefab tag
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ship")
        {
            //removes the threat
            gameObject.SetActive (false);

            //reduces ship health
            h.TakeDamage(15);
        }
    }

}
