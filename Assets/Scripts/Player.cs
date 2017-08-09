using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject FlareStickPrefab;
    public GameObject FlareCounter;
    public int recoDone = 0;
    [Tooltip("Max amount of FlareSticks.")]
    public int flareStickAvailable = 10;
    public bool haveFlare = false;

    private GameObject UserFlareStick;
    private GameObject Ground;
    private FlareSticksCount flareCounter;

	// Use this for initialization
	void Start () {
        flareCounter = FlareCounter.GetComponent<FlareSticksCount> ();
        Ground = GameObject.Find ("Terrain");
    }

    // Update is called once per frame
    void Update () {
        if (!haveFlare && Input.GetKeyDown (KeyCode.F) && flareStickAvailable > 0) {
            LightFlare ();
        } else if (Input.GetKeyDown (KeyCode.F) && flareStickAvailable > 0) {
            DropFlare ();
        } else if (flareStickAvailable == 0) {
            Debug.LogWarning ("TODO : no-flare sound");
        }
    }

    void LightFlare () {
        UserFlareStick = Instantiate (FlareStickPrefab, transform.position, Quaternion.identity, transform);
        Destroy (UserFlareStick, UserFlareStick.GetComponent<FlareStick> ().flareStickMaxDuration);
        flareCounter.UpdateFlareCount ();
        haveFlare = true;
    }

    public void DropFlare () {
        UserFlareStick.transform.parent = Ground.transform;
        UserFlareStick.GetComponent<Rigidbody> ().isKinematic = false;
        haveFlare = false;
    }
}
