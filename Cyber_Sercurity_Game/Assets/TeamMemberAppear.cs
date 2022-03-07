using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamMemberAppear : MonoBehaviour
{
    public GameObject TeamMember;
    public bool appeared=false;
   

    void Update()
    {
        if (Input.GetKeyDown (KeyCode.L) && appeared == false) {
            TeamMember.SetActive(true);
            appeared=true;
        }
    }

}
