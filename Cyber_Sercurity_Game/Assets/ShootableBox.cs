using UnityEngine;
using System.Collections;

public class ShootableBox : MonoBehaviour {
	public int currentHealth = 3;
	public GameObject explosion;
	private Vector3 vec;
	
	UpdateScore update;
	
	void Start(){
		update= GameObject.FindGameObjectWithTag("score").GetComponent<UpdateScore>();
	}


	public void Damage(int damageAmount)
	{
		currentHealth -= damageAmount;

		if (currentHealth <= 0) 
		{
			vec= gameObject.transform.position;
			Instantiate( explosion, vec, transform.rotation);
			gameObject.SetActive (false);

			update.IncreaseScore(10);


		}
	}
}
