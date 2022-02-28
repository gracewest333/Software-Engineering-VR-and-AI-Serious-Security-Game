using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_gun : MonoBehaviour
{

    private enum Gun_Name {
        Access_Management,
        Anti_Malware,
        Encrypter,
        Firewall,
        Web_Filtering
    }

    public LineRenderer Object;

    public Material pink;
    public Material green;
    public Material blue;
    public Material orange;
    public Material purple;
 
    void Update(){
        if (Input.GetKeyDown(KeyCode.Z)){
            Object.GetComponent<LineRenderer> ().material = pink;
            }

        if (Input.GetKeyDown(KeyCode.X)){
            Object.GetComponent<LineRenderer> ().material = green;
            }

        if (Input.GetKeyDown(KeyCode.C)){
            Object.GetComponent<LineRenderer> ().material = blue;
            }

        if (Input.GetKeyDown(KeyCode.V)){
            Object.GetComponent<LineRenderer> ().material = orange;
            }

        if (Input.GetKeyDown(KeyCode.B)){
            Object.GetComponent<LineRenderer> ().material = purple;
            }

 
    }


}
