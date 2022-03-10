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
        
        currentHealth=maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {   

        if (TeamMate.activeSelf && RepairedShip == false){
            currentHealth=maxHealth;
            healthBar.setHealth(currentHealth);
            RepairedShip=true;
        }

        if (currentHealth <= 0){
            SceneManager.LoadScene("LooseEndPage");
        }

    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }
}
