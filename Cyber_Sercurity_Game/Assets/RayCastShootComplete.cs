// credits to https://www.youtube.com/watch?v=u0yksFw9PSs&t=402s

using UnityEngine;
using System.Collections;

public class RayCastShootComplete : MonoBehaviour {

	public AudioClip zap;
	public int gunDamage = 1;											// Set the number of hitpoints that this gun will take away from shot objects with a health script
	public float fireRate = 0.25f;										// Number in seconds which controls how often the player can fire
	public float weaponRange = 50f;										// Distance in Unity units over which the player can fire
	public float hitForce = 100f;										// Amount of force which will be added to objects with a rigidbody shot by the player
	public Transform gunEnd;											// Holds a reference to the gun end object, marking the muzzle location of the gun
	public Camera fpsCam;												// Holds a reference to the first person camera

	
	public bool hit_threat=false;
	public Vector3 hit_point;

	private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);	// WaitForSeconds object used by our ShotEffect coroutine, determines time laser line will remain visible
	private LineRenderer laserLine;										// Reference to the LineRenderer component which will display our laserline
	private float nextFire;												// Float to store the time the player will be allowed to fire again, after firing
	public Vector3 pos;

	void Start () 
	{
		// Get and store a reference to our LineRenderer component
		laserLine = GetComponent<LineRenderer>();
		

	}
	

	void Update () 
	{
		// Check if the player has pressed the fire button and if enough time has elapsed since they last fired
		if (Input.GetButtonDown("Fire1") && Time.time > nextFire) 
		{
			// Update the time when our player can fire next
			nextFire = Time.time + fireRate;

			// Start our ShotEffect coroutine to turn our laser line on and off
            StartCoroutine (ShotEffect());

            // Create a vector at the center of our camera's viewport
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));

            // Declare a raycast hit to store information about what our raycast has hit
            RaycastHit hit;

			// Set the start position for our visual effect for our laser to the position of gunEnd
			laserLine.SetPosition (0, pos);

			// Check if our raycast has hit anything
			if (Physics.Raycast (pos, fpsCam.transform.forward, out hit, weaponRange))
			{
				hit_threat=true;
				hit_point=hit.point;

				// Set the end position for our laser line 
				laserLine.SetPosition (1, hit.point);

				// Get a reference to a health script attached to the collider we hit
				ShootableBox health = hit.collider.GetComponent<ShootableBox>();
				// If there was a health script attached
				if (health != null)
				{
					// Call the damage function of that script, passing in our gunDamage variable
					health.Damage (gunDamage);
				}

				
			}
			else
			{
				hit_threat=false;
				// If we did not hit anything, set the end of the line to a position directly in front of the camera at the distance of weaponRange
                laserLine.SetPosition (1, pos + (fpsCam.transform.forward * weaponRange));
			}
		}
	}


	private IEnumerator ShotEffect()
	{

		// Turn on our line renderer
		laserLine.enabled = true;
		AudioSource audio = GetComponent<AudioSource>();
		audio.clip=zap;
		audio.Play();
		//Wait for .07 seconds
		yield return shotDuration;

		// Deactivate our line renderer after waiting
		laserLine.enabled = false;
	}
}