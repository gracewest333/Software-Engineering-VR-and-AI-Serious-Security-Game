using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    public int maxHealth=100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject TeamMate;
    public bool RepairedShip=false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth=maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)){
            //TakeDamage(5);
        //}

        if (TeamMate.activeSelf && RepairedShip == false){
            //RepairShip(10);
            currentHealth=maxHealth;
            healthBar.setHealth(currentHealth);
            RepairedShip=true;
        }

    }


    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }
    // void RepairShip(int RepairVal){
    //     currentHealth += RepairVal;
    //     healthBar.setHealth(currentHealth);
    // }    
}
