using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;


    public void SetMaxHealth(int health){
        // sets the health bar sliders maximum value to the inputted value
        slider.maxValue = health;

        //at the start of the game the health is the same as the max health
        slider.value = health;

        //colour is set to the start colour of the gradient which is green
        fill.color = gradient.Evaluate(1f);
        
    }

    public void setHealth(int health){
        // updates slider value to new health value
        slider.value = health;

        //updates the colour of the slider from the gradient
        fill.color = gradient.Evaluate(slider.normalizedValue);
        
    }
        
}

//credit to https://youtu.be/BLfNP4Sc_iA