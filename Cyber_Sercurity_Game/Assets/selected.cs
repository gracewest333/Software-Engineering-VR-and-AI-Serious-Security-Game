using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selected : MonoBehaviour
{
    public Vector3 pos;
    public string name = "AccessManagement";

    void Update(){
        name = GameObject.FindGameObjectWithTag("selected_gun").GetComponent<Change_gun>().selected_gun;
        pos= GameObject.FindGameObjectWithTag(name).transform.position;
        transform.position = pos;
    }

}
