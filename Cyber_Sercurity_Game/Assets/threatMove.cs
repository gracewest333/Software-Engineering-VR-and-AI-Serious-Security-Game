
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class threatMove : MonoBehaviour
{
    public float speed= 0.01f;

    // Update is called once per frame
    //update moves the threat forward every frame
    void Update()
    {
        transform.Translate(-Vector3.back * speed * Time.deltaTime);

        //transform.position= Vector3.MoveTowards(transform.position,target, speed * Time.deltaTime);
    }
}
