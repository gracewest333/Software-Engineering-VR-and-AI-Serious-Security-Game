using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startbutton : MonoBehaviour
{
    //calls the main game scene when the button is pressed
    public void PlayGame ()
    {
        SceneManager.LoadScene("SpaceShipScene");
    }
    
}
