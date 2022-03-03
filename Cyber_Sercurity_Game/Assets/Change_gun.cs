using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_gun : MonoBehaviour
{
    public string selected_gun= "AccessManagement";


    public LineRenderer Object;

    public Material pink;
    public Material green;
    public Material blue;
    public Material orange;
    public Material purple;
 
    void Update(){
        if (Input.GetKeyDown(KeyCode.Z)){
            Object.GetComponent<LineRenderer> ().material = pink;
            selected_gun= "AccessManagement";
            }

        if (Input.GetKeyDown(KeyCode.X)){
            Object.GetComponent<LineRenderer> ().material = green;
            selected_gun= "AntiMalware";            
            }

        if (Input.GetKeyDown(KeyCode.C)){
            Object.GetComponent<LineRenderer> ().material = blue;
            selected_gun= "encrypter";            
            }

        if (Input.GetKeyDown(KeyCode.V)){
            Object.GetComponent<LineRenderer> ().material = orange;
            selected_gun= "firewall";            
            }

        if (Input.GetKeyDown(KeyCode.B)){
            Object.GetComponent<LineRenderer> ().material = purple;
            selected_gun= "WebFiltering";            
            }

 
    }


}
