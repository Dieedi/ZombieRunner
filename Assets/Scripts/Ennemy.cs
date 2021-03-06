using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemy : MonoBehaviour {

    public AudioClip[] moanSounds;
    /* Copy from First Person Controller */
    [SerializeField] private float m_StepInterval;
    [SerializeField] private AudioClip[] m_FootstepSounds;    // an array of footstep sounds that will be randomly selected from.
    [SerializeField] private AudioClip m_LandSound;           // the sound played when character touches back on ground.
    private float m_StepCycle;
    private float m_NextStep;
    private float speed;
    /* ================================= */

    private AudioSource audioSource;
    private float moanTime;
    private float timeSinceLastMoan = 0;


	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource> ();
        moanTime = Random.Range (5, 20);
        speed = GetComponent<NavMeshAgent> ().speed;

        m_StepCycle = 0f;
        m_NextStep = m_StepCycle/2f;
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

    void FixedUpdate () {
        ProgressStepCycle (speed); // consider fixed speed in navmeshAgent ?
    }

    void Moan () {
        int soundClip = (int)Random.Range (0, 10);
        soundClip = soundClip < 5 ? 0 : 1;

        audioSource.clip = moanSounds [soundClip];
        audioSource.Play ();
    }

    private void ProgressStepCycle(float speed)
    {
        m_StepCycle += (4 + speed) * Time.fixedDeltaTime;
        
        if (!(m_StepCycle > m_NextStep))
        {
            return;
        }

        m_NextStep = m_StepCycle + m_StepInterval;

        PlayFootStepAudio();
    }

    // from fpcontroller
    private void PlayFootStepAudio()
    {
        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        int n = Random.Range(1, m_FootstepSounds.Length);
        audioSource.clip = m_FootstepSounds[n];
        audioSource.PlayOneShot(audioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = audioSource.clip;
    }
}
