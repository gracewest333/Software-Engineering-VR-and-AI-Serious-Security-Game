
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_ship : MonoBehaviour
{
    ShipHealth h;

    	
	void Start(){
		h= GameObject.FindGameObjectWithTag("health_bar").GetComponent<ShipHealth>();
	}


    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ship")
        {
            gameObject.SetActive (false);

            h.TakeDamage(15);
        }
    }

}
