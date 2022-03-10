using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class warnings : MonoBehaviour
{
    //calls the welcome scene to the game scene when the button is pressed
    public void PlayGame ()
    {
        SceneManager.LoadScene("welcomescence");
    }
    
}
