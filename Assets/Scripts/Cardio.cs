using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardio : MonoBehaviour {
//
//    Le cœur bat dans les conditions basales à une fréquence moyenne de 65 battements par minute. 
//
//    La durée d’un cycle complet dure 0.92 seconde, 0.27 seconde pour la systole ventriculaire et 0.65 seconde pour la diastole ventriculaire.


    public float bpm = 65;

    private float pulse; // pulsation
    private float frequency1; // fréquence1
    private float frequency2;
    private float Um = 2f; // amplitude
    private float temps = 0; // temps
    private float Tense;
    private float newX, newY = 0;
    private float second;
    private float repeatGraph; // each x seconds
    private float repeatTime = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update () {
        repeatGraph = 60f / bpm;
        frequency2 = 0.175f; // start timer

        frequency1 = repeatGraph * 0.3f / 2; // curve

        repeatTime += Time.deltaTime;

        second += Time.deltaTime;        
        temps = second;
        if (second >= frequency2 && second <= frequency1 + frequency2) {
            pulse = (2 * Mathf.PI / frequency1) * temps;
            Tense = Um * Mathf.Sin (pulse);
        } else {
            pulse = 16 * 0.1f;
            Tense = 0;
        }

        newX = Mathf.Clamp (pulse * Time.deltaTime + transform.localPosition.x, 0, 8f);

        if (second >= repeatGraph) {
            newX = 0;
            second = 0;
            repeatTime = 0;
        } else {
            repeatTime = repeatGraph;
        }
        newY = Tense;
        transform.localPosition = new Vector3 (newX, newY, transform.localPosition.z);
    }
}
