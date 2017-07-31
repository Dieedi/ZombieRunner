using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

    [Tooltip ("Default 1 gives 1 degree rotation per second")]
    [Range(0.0f, 2.0f)]
    public float angleRatio = 1;

    private Quaternion startRotation;

	// Use this for initialization
	void Start () {
        startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        float angleThisFrame = Time.deltaTime * angleRatio; // Time.deltaTime gives above 1° / s 
        transform.RotateAround (transform.position, Vector3.forward, angleThisFrame);
	}
}
