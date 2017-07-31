using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour {

    public GameObject eyes;

    private Camera camera;

	// Use this for initialization
	void Start () {
        camera = eyes.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis ("Zoom") > 0) {
            Zoom (Input.GetAxis ("Zoom"));
        } else if (Input.GetAxis ("Zoom") < 0) {
            Zoom (Input.GetAxis ("Zoom"));
        }
	}

    void Zoom (float zoomValue) {
        camera.fieldOfView = Mathf.Clamp (camera.fieldOfView - (zoomValue * 10), 60, 80);
    }
}
