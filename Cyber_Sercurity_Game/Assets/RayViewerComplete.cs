using UnityEngine;
using System.Collections;

public class RayViewerComplete : MonoBehaviour {

    public float weaponRange = 50f;                       // Distance in Unity units over which the Debug.DrawRay will be drawn
    public Camera fpsCam;                                // Holds a reference to the first person camera
    public GameObject gunEnd;	

    Vector3 pos;



    void Start ()

    {
        pos= new Vector3 (-16f,-9f,12f);

    }

	
	void Update () 
    {
        // Create a vector at the center of our camera's viewport
        Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        // Draw a line in the Scene View  from the point lineOrigin in the direction of fpsCam.transform.forward * weaponRange, using the color green
        
        Debug.DrawRay(lineOrigin, fpsCam.transform.forward * weaponRange, Color.green);
        Debug.DrawRay(pos, fpsCam.transform.forward * weaponRange, Color.green);
	}
}
