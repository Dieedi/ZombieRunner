using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnnemySpawner : MonoBehaviour {

    public GameObject ZombiePrefab;
    public GameObject Player;

    private GameObject Ennemies;
    private GameObject Ennemy;

	// Use this for initialization
	void Start () {
        Ennemies = GameObject.Find ("Ennemies");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit (Collider collider) {
        print ("collision Exit");
        Ennemy = Instantiate (ZombiePrefab, transform.position, Quaternion.identity, Ennemies.transform) as GameObject;
        Ennemy.GetComponent<AICharacterControl> ().target = Player.transform;
        StartCoroutine ("ActivateMeshAgent");
    }

    IEnumerator ActivateMeshAgent () {

        yield return new WaitForSeconds(2);

        Ennemy.GetComponent<NavMeshAgent> ().enabled = true;
    }
}
