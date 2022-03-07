//https://github.com/renaissanceCoder/Simple-Scripting-Series/blob/master/TimedSpawn.cs
//https://www.youtube.com/watch?v=1h2yStilBWU


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimedSpawn : MonoBehaviour {

    public GameObject hacker;
    public GameObject sql;
    public GameObject man_middle;
    public GameObject malware;
    public GameObject denial_of_service;
    public GameObject phishing;

    int number=1 ;
    

    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
	}
	
    public void SpawnObject() {
        //using Random = System.Random;
        System.Random random = new System.Random();
        int number = random.Next(1, 7);
        switch (number){
            case 1:
                Instantiate(hacker, transform.position, transform.rotation);
                break;

            case 2:
                Instantiate(sql, transform.position, transform.rotation);
                break;

            case 3:
                Instantiate(man_middle, transform.position, transform.rotation);
                break;

            case 4:
                Instantiate(malware, transform.position, transform.rotation);
                break;

            case 5:
                Instantiate(denial_of_service, transform.position, transform.rotation);
                break;
            
            case 6:
                Instantiate(phishing, transform.position, transform.rotation);
                break;

        } 
        
        
        if(stopSpawning) {
            
            CancelInvoke("SpawnObject");
            
            
        }
    }
}