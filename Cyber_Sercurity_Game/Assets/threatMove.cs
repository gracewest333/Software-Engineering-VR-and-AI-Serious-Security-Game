
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class threatMove : MonoBehaviour
{
    public float speed= 0.01f;
    //private Vector3 target_position=transform.position.target;
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.back * speed * Time.deltaTime);

        //transform.position= Vector3.MoveTowards(transform.position,target, speed * Time.deltaTime);
    }
}
