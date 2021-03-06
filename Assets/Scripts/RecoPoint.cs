﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum OPTIONS {
    heli = 0,
    pyramid = 1,
    oasis = 2
}

public class RecoPoint : MonoBehaviour {

    public OPTIONS op;
    public float recoTime = 5;

    private float recoTimeCount;
    private bool oasisDone = false;
    private bool pyramidDone = false;
    private bool heliDone = false;
    private Player player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay (Collider collider) {
        if (collider.name == "Player") {
            if (player.recoDone >= 3) {
                // TODO Play heli voice
                Debug.Log ("All reco done !");
            }

            recoTimeCount += Time.deltaTime;

            if (recoTimeCount >= recoTime) {
                // TODO add text on UI

                switch(op) {
                case OPTIONS.heli:
                    if (heliDone == false) {
                        heliDone = true;
                        player.recoDone++;
                    }
                    break;
                case OPTIONS.oasis:
                    if (oasisDone == false) {
                        oasisDone = true;
                        player.recoDone++;
                    }
                    break;
                case OPTIONS.pyramid:
                    if (pyramidDone == false) {
                        pyramidDone = true;
                        player.recoDone++;
                    }
                    break;
                }

                recoTimeCount = 0;
            }
        }
    }
}
