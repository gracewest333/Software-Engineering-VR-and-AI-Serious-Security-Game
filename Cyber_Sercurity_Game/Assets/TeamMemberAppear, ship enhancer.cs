
//ship enhancer 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamMemberAppear : MonoBehaviour
{
    public GameObject TeamMember;
    public bool appeared=false;
    
   //MEENAL WILL CHANGE 
    public void Spawn()
    {
        //to be activated in the editor 
        if (appeared == false) {
            TeamMember.SetActive(true);
            appeared=true;
        }
    }


}

//credit to https://youtu.be/xppompv1DBg