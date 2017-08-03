using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public bool respawn;

    private GameObject[] SpawnPoints;

	// Use this for initialization
	void Start () {
        SpawnPoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");
        //Respawn ();
	}
	
	// Update is called once per frame
	void Update () {
        if (respawn) {
            Respawn ();
        }
	}

    void Respawn () {
        int spawnNumber = Mathf.Abs (Random.Range (0, 3));
        transform.position = SpawnPoints [spawnNumber].transform.position;
        respawn = false;
    }
}
