//ship enhancer
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamMemberManager : MonoBehaviour
{
   
   //create globally acessible singelton
    #region Singelton

    public static TeamMemberManager instance;

    //attach this script to the instance object so that it can be accessed globally
    void Awake(){
        instance=this;
    }
    #endregion

    public GameObject player;
}

//credit to https://youtu.be/xppompv1DBg