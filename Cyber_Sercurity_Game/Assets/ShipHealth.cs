using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        
        //at the start of the game the health is at maximum so it is set to maximum
        //uses .setmaxhealth from healthbar.cs script to show it on the bar 
        currentHealth=maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {   
        //if the ship engineer has been made active then the ship health is set back to max 
        //.setHealth is used from the healthbar.cs script
        if (TeamMate.activeSelf && RepairedShip == false){
            currentHealth=maxHealth;
            healthBar.setHealth(currentHealth);
            RepairedShip=true;
        }


        //if no health left then you lose the game and it goes to the lose screen
        if (currentHealth <= 0){
            SceneManager.LoadScene("LooseEndPage");
        }

    }

    public void TakeDamage(int damage){

        //when the ship takes damage the damage value is taken away from the current health and the health
        //bar is updated.
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }
}

//credit to https://youtu.be/BLfNP4Sc_iA