using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlareSticks : MonoBehaviour {

    [Tooltip("Max amount of FlareSticks.")]
    public int flareStickAvailable = 10;
    [Tooltip("Duration in seconds.")]
    public float flareStickMaxDuration = 30;
    public GameObject FlareStickPrefab;

    private GameObject UserFlareStick;
    private GameObject Ground;
    private bool haveFlare = false;
    private Text Count;
    private float flareLightDuration = 0;  // TODO : Move Flare timer on flare prefab

	// Use this for initialization
	void Start () {
        Count = GetComponent<Text> ();
        Count.text = flareStickAvailable.ToString ();
        Ground = GameObject.Find ("Terrain");
	}
	
	// Update is called once per frame
	void Update () {
        flareLightDuration += Time.deltaTime;

        if (!haveFlare && Input.GetKeyDown (KeyCode.F) && flareStickAvailable > 0) {
            LightFlare ();
        } else if (Input.GetKeyDown (KeyCode.F) && flareStickAvailable > 0 
            || flareLightDuration >= flareStickMaxDuration && haveFlare) {
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
        UserFlareStick = Instantiate (FlareStickPrefab, transform.position, Quaternion.identity, transform);
        UpdateFlareCount ();
        haveFlare = true;
    }

    void DropLightFlare () {
        if (flareLightDuration >= flareStickMaxDuration) {
            Destroy (UserFlareStick.gameObject);
        }
        UserFlareStick.transform.parent = Ground.transform;
        UserFlareStick.GetComponent<Rigidbody> ().isKinematic = false;
        haveFlare = false;
    }
}
