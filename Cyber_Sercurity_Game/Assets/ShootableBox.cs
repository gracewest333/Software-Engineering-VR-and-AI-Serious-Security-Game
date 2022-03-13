using UnityEngine;
using System.Collections;

public class ShootableBox : MonoBehaviour {


	public string current_gun = "AccessManagement";
	public string defeated_by_gun = "firewall";



	public int currentHealth = 1;
	public GameObject explosion;
	private Vector3 vec;
	
	UpdateScore update;
	
	void Start(){
		update= GameObject.FindGameObjectWithTag("score").GetComponent<UpdateScore>();
	}


	public void Damage(int damageAmount)
	{
		current_gun = GameObject.FindGameObjectWithTag("selected_gun").GetComponent<Change_gun>().selected_gun;

		if (defeated_by_gun == current_gun){
			currentHealth -= damageAmount;
		}
		

		if (currentHealth <= 0) 
		{
			vec= gameObject.transform.position;
			Instantiate( explosion, vec, transform.rotation);
			gameObject.SetActive (false);

			update.IncreaseScore(10);


		}
	}
}
