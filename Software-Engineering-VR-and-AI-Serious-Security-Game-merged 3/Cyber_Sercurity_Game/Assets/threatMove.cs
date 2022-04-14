
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IBM.Watson.SpeechToText.V1;
using IBM.Cloud.SDK;
using IBM.Cloud.SDK.Authentication;
using IBM.Cloud.SDK.Authentication.Iam;
using IBM.Cloud.SDK.Utilities;
using IBM.Cloud.SDK.Datatypes;

public class threatMove : MonoBehaviour
{
    public float speed= 0.01f;
    public int pause = 0;

    // Update is called once per frame
    //update moves the threat forward every frame
    void Update()
    {
        if (pause == 0)
        {
            transform.Translate(-Vector3.back * speed * Time.deltaTime);
        }
        else
        {
            speed = 0;
        }

        //transform.position= Vector3.MoveTowards(transform.position,target, speed * Time.deltaTime);
    }
}
