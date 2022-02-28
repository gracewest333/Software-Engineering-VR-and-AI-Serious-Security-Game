using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selected : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 pos;
    public string name = "AccessManagement";


    void Update(){
        if (Input.GetKeyDown(KeyCode.Z)){name = "AccessManagement";}
        if (Input.GetKeyDown(KeyCode.X)){name = "AntiMalware";}
        if (Input.GetKeyDown(KeyCode.C)){name = "encrypter";}
        if (Input.GetKeyDown(KeyCode.V)){name = "firewall";}
        if (Input.GetKeyDown(KeyCode.B)){name = "WebFiltering";}


        pos= GameObject.FindGameObjectWithTag(name).transform.position;
        transform.position = pos;
    }

}
