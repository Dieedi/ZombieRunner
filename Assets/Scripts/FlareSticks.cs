using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlareSticks : MonoBehaviour {

    public int flareStickAvailable = 10;
    public GameObject FlareStick;

    private GameObject UserFlareStick;
    private GameObject Ground;
    private bool haveFlare = false;
    private Text Count;

	// Use this for initialization
	void Start () {
        Count = GetComponent<Text> ();
        Count.text = flareStickAvailable.ToString ();
        Ground = GameObject.Find ("Terrain");
	}
	
	// Update is called once per frame
	void Update () {
        if (!haveFlare && Input.GetKeyDown (KeyCode.F) && flareStickAvailable > 0) {
            LightFlare ();
        } else if (Input.GetKeyDown (KeyCode.F) && flareStickAvailable > 0) {
            DropLightFlare ();
        } else if (flareStickAvailable == 0) {
            Debug.LogWarning ("TODO : no-flare sound");
        }
	}

    void UpdateFlareCount () {
        flareStickAvailable--;
        Count.text = flareStickAvailable.ToString ();
    }

    void LightFlare () {
        UserFlareStick = Instantiate (FlareStick, transform.position, Quaternion.identity, transform);
        UpdateFlareCount ();
        haveFlare = true;
    }

    void DropLightFlare () {
        UserFlareStick.transform.parent = Ground.transform;
        UserFlareStick.GetComponent<Rigidbody> ().isKinematic = false;
        haveFlare = false;
    }
}
