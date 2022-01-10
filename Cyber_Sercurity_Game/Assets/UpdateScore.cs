using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public Text scoreText;

    int score=0;


    void Start()
    {
        scoreText.text=score.ToString();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)){
            IncreaseScore(10);
        }
        if (Input.GetKeyDown(KeyCode.W)){
            DecreaseScore(10);
        }
    }

    void IncreaseScore(int change){
        score += change;
        scoreText.text=score.ToString();
    }

    void DecreaseScore(int change){
        score -= change;
        scoreText.text=score.ToString();
    }
}

