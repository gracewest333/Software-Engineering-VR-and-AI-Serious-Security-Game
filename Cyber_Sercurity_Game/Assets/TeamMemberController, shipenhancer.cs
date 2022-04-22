//ship enhancer

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TeamMemberController : MonoBehaviour
{
  public float lookRadius=10f;
  Transform target;
  NavMeshAgent agent;

  //set the target to the player and make the players mesh agent a variable
  //use player from TeamMemberManager.cs
  void Start(){
    target=TeamMemberManager.instance.player.transform;
    agent=GetComponent<NavMeshAgent>();  
  }


  void Update(){

    //if (Input.GetKeyDown(KeyCode.L)){
      


    //get the distance from team member to player as float
    float distance = Vector3.Distance(target.position, transform.position);

    //if the distance is within the radius of the team member set the destination of the team member to the players coordinates
    if(distance <= lookRadius){
      agent.SetDestination(target.position);

      //if the distance gets close to the mesh agent of the player then turn to face the player too
      if (distance <= agent.stoppingDistance){
        FaceTarget();
      }
          
    }
  }


  void FaceTarget(){
    //gets the direction of the player from the team member
    //makes the team member face the player.
    Vector3 direction=(target.position-transform.position).normalized;
    Quaternion lookRotation= Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
    transform.rotation= Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime * 5f);
  }

}

//credit to https://youtu.be/xppompv1DBg