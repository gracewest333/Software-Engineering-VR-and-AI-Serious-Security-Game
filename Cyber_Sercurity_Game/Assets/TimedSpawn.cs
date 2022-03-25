//https://github.com/renaissanceCoder/Simple-Scripting-Series/blob/master/TimedSpawn.cs
//https://www.youtube.com/watch?v=1h2yStilBWU



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class TimedSpawn : MonoBehaviour {

    // each threat prefab
    public int wave_lenghth = 5;

    public GameObject hacker;
    public GameObject sql;
    public GameObject man_middle;
    public GameObject malware;
    public GameObject denial_of_service;
    public GameObject phishing;
    

    public GameObject new_threat_hacker;
    public GameObject new_threat_sql;
    public GameObject new_threat_man_middle;
    public GameObject new_threat_malware;
    public GameObject new_threat_denial_of_service;
    public GameObject new_threat_phishing;

    public GameObject cryptographer;
    int crypto_spawn=1;

    int wave=0;
    int number_so_far=0;
    int random_threat=1;


    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;


	void Start () {
		InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
	}
	
    // genporates a random threat 
    public void SpawnObject() {
        System.Random random = new System.Random();

        if (number_so_far % wave_lenghth ==0){
            switch (wave){
                case 0:
                    new_threat_malware.SetActive(true);
                    wave = wave +1;
                    break;
                case 1:
                    wave = wave +1;
                    new_threat_sql.SetActive(true);
                    break;
                case 2:
                    wave = wave +1;
                    new_threat_man_middle.SetActive(true);
                    break;
                case 3:
                    wave = wave +1;
                    new_threat_hacker.SetActive(true);
                    break;
                case 4:
                    wave = wave +1;
                    new_threat_denial_of_service.SetActive(true);
                    break;
                case 5:
                    wave = wave +1;
                     new_threat_phishing.SetActive(true);
                    break;
                case 6:
                    wave = wave +1;
                    break;
            }
        } 


        switch (wave){
            case 1:
                break;
            case 2:
                random_threat = random.Next(1, 3);
                break;
            case 3:
                random_threat = random.Next(1, 4);
                break;
            case 4:
                random_threat = random.Next(1, 5);
                break;
            case 5:
                random_threat = random.Next(1, 6);
                break;
            case 6:
                random_threat = random.Next(1, 7);
                break;

        }

        
        crypto_spawn=random.Next(1,11);
        if (cryptographer.activeInHierarchy == true && crypto_spawn % 3 == 0){
            transform.rotation = new Quaternion (0,90,0,0);
        }
        else{
            transform.rotation = new Quaternion (0, 45, 0, 45);
        }
        switch (random_threat){
            case 1:
                Instantiate(malware, transform.position, transform.rotation);
                //crypto_spawn=random.Next(1,11);
                number_so_far=number_so_far+1;
                break;
            case 2:
                Instantiate(sql, transform.position, transform.rotation);
                //crypto_spawn=random.Next(1,11);
                number_so_far=number_so_far+1;
                break;
            case 3:
                Instantiate(man_middle, transform.position, transform.rotation);
                //crypto_spawn=random.Next(1,11);
                number_so_far=number_so_far+1;
                break;
            case 4:
                Instantiate(hacker, transform.position, transform.rotation);
                //crypto_spawn=random.Next(1,11);
                number_so_far=number_so_far+1;
                break;
            case 5:
                Instantiate(denial_of_service, transform.position, transform.rotation);
                //crypto_spawn=random.Next(1,11);
                number_so_far=number_so_far+1;
                break;
            case 6:
                Instantiate(phishing, transform.position, transform.rotation);
                //crypto_spawn=random.Next(1,11);
                number_so_far=number_so_far+1;
                break; 
        }
        if (wave>6){
            SceneManager.LoadScene("WinEndPage");
        }        
        
        if(stopSpawning) {
            
            CancelInvoke("SpawnObject");
            
            
        }
    }
}