using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamMemberAppear : MonoBehaviour
{
    public GameObject TeamMember;
    public bool appeared=false;
    
   //MEENAL WILL CHANGE 
    void Update()
    {
        //when the button L is pressed and the ship engineer isnt already active set him to active
        if (Input.GetKeyDown (KeyCode.L) && appeared == false) {
            TeamMember.SetActive(true);
            appeared=true;
        }
    }


}

//credit to https://youtu.be/xppompv1DBg