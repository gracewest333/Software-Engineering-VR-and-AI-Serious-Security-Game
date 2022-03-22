using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public Text scoreText;
    public int score;


    void Start()
    {
        //change the integer score to a string
        scoreText.text=score.ToString();

    }

    public void IncreaseScore(int change){

        //increase the score by a certain change and update its string version
        score += change;
        scoreText.text=score.ToString();
    }

    public void DecreaseScore(int change){

        //decrease the score by a certain change and update its string version 
        score -= change;
        scoreText.text=score.ToString();
    }
}

//credit to https://youtu.be/TAGZxRMloyU