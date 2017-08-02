using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public bool respawn;
    public GameObject FlareStick;

    private GameObject[] SpawnPoints;
    private GameObject UserFlareStick;
    private GameObject Ground;
    private bool haveFlare = false;
    private int flareStickAvailable = 10;

	// Use this for initialization
	void Start () {
        SpawnPoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");
        Respawn ();

        Ground = GameObject.Find ("Terrain");
	}
	
	// Update is called once per frame
	void Update () {
        if (respawn) {
            Respawn ();
        }

        if (!haveFlare && Input.GetKeyDown (KeyCode.F) && flareStickAvailable > 0) {
            LightFlare ();
        } else if (Input.GetKeyDown (KeyCode.F) && flareStickAvailable > 0) {
            DropLightFlare ();
        } else if (flareStickAvailable == 0) {
            Debug.LogWarning ("TODO : no-flare sound");
        }
	}

    void Respawn () {
        int spawnNumber = Mathf.Abs (Random.Range (0, 3));
        transform.position = SpawnPoints [spawnNumber].transform.position;
        respawn = false;
    }

    void LightFlare () {
        UserFlareStick = Instantiate (FlareStick, transform.position, Quaternion.identity, transform);
        haveFlare = true;
    }

    void DropLightFlare () {
        UserFlareStick.transform.parent = Ground.transform;
        UserFlareStick.GetComponent<Rigidbody> ().isKinematic = false;
        haveFlare = false;
    }
}
