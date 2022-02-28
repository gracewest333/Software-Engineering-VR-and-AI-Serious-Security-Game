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
        scoreText.text=score.ToString();

    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q)){
    //        IncreaseScore(10);
    //    }
    //    if (Input.GetKeyDown(KeyCode.W)){
    //        DecreaseScore(10);
    //    }
    //}

    public void IncreaseScore(int change){
        score += change;
        scoreText.text=score.ToString();
    }

    public void DecreaseScore(int change){
        score -= change;
        scoreText.text=score.ToString();
    }
}

