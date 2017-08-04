using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoPoint : MonoBehaviour {

    public float recoTime = 5;

    private float recoTimeCount;
    private int recoDone = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay (Collider collider) {
        if (collider.name == "Player") {
            recoTimeCount += Time.deltaTime;

            if (recoTimeCount >= recoTime) {
                // TODO add text on UI
                Debug.Log ("Point Done");
                recoDone++;
            }

            if (recoDone >= 3) {
                // TODO Play heli voice
                Debug.Log ("All reco done !");
            }
        }
    }
}
