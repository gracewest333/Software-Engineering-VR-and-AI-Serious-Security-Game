using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamMemberAppear : MonoBehaviour
{
    public GameObject TeamMember;

    public void Update()
    {
        if (Input.GetKeyDown (KeyCode.L)){
            TeamMember.SetActive(true);
        }
    }


    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    //Update is called once per frame
    //void Update()
    //{
        //if (Input.GetKeyDown (KeyCode.L)) {
            //Instantiate(TeamMember, new Vector3(-4.722f ,-8.774f ,9.642f ), Quaternion.identity);
        ///}
    //}
}
