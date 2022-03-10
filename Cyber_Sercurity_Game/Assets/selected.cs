using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selected : MonoBehaviour
{
    // sets the start gun as AccessManagement
    public Vector3 pos;
    public string name = "AccessManagement";

    //updates the posiotion of the green box depending on which gun (or pause) has been selected by the user
    void Update(){
        name = GameObject.FindGameObjectWithTag("selected_gun").GetComponent<Change_gun>().selected_gun;
        pos= GameObject.FindGameObjectWithTag(name).transform.position;
        transform.position = pos;
    }

}
