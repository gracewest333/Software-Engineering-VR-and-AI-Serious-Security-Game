//https://github.com/renaissanceCoder/Simple-Scripting-Series/blob/master/TimedSpawn.cs
//https://www.youtube.com/watch?v=1h2yStilBWU


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour {

    public GameObject spawnee;
    
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
	}
	
    public void SpawnObject() {
        Instantiate(spawnee, transform.position, transform.rotation);
        if(stopSpawning) {
            
            CancelInvoke("SpawnObject");
            
            
        }
    }
}