using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareStick : MonoBehaviour {
    
    [Tooltip("Duration in seconds.")]
    public float flareStickMaxDuration = 30;
    public GameObject Player;

    private GameObject Ground;
    private float flareLightDuration = 0;
    private Player playerScript;

	// Use this for initialization
    void Start () {
        playerScript = Player.GetComponent<Player> ();
        Ground = GameObject.Find ("Terrain");
	}

    void Update () {
        flareLightDuration += Time.deltaTime;

        if (flareLightDuration >= flareStickMaxDuration) {
            if (playerScript.haveFlare) {
                playerScript.DropFlare ();
            }
        }
    }
}
