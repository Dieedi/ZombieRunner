using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

    public AudioClip callHeli;

    private AudioSource audioSource;
    private bool callDone = false;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown ("CallHelicopter") && !callDone) {
            CallHeli ();
            callDone = true;
        }
	}

    void CallHeli () {
        audioSource.clip = callHeli;
        audioSource.Play ();
    }
}
