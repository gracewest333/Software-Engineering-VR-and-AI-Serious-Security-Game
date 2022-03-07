using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamMemberManager : MonoBehaviour
{
    #region Singelton

    public static TeamMemberManager instance;
    void Awake(){
        instance=this;
    }
    #endregion

    public GameObject player;
}
