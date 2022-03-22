using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity=100f;
    public Transform playerBody;
    float xRotation=0f;

    // Start is called before the first frame update
    void Start()
    {
        //hardware poiter is locked to the centre of the game view
        Cursor.lockState=CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //get the x and y value of the mouse and multiplies it by sensitivity and time value
        float mouseX= Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY=Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        //Rotates the players body to follow the direction of the pointer
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f );
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f );
        playerBody.Rotate(Vector3.up * mouseX );

    }
}
//credit to https://youtu.be/_QajrabyTJc and https://youtu.be/HIyxpl-Yahs