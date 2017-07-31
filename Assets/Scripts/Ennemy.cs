using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour {

    public AudioClip[] audioClips;

    private AudioSource audioSource;
    private float moanTime;
    private float timeSinceLastMoan = 0;


	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource> ();
        moanTime = Random.Range (5, 20);
	}
	
	// Update is called once per frame
	void Update () {

        if (timeSinceLastMoan >= moanTime) {
            Moan ();
            timeSinceLastMoan = 0;
            moanTime = Random.Range (5, 20);
        }

        timeSinceLastMoan += Time.deltaTime;
	}

    void Moan () {
        int soundClip = (int)Random.Range (0, 10);
        soundClip = soundClip < 5 ? 0 : 1;
        print (soundClip); 
        audioSource.clip = audioClips [soundClip];
        audioSource.Play ();
    }
}
