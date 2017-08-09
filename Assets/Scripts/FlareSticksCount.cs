using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlareSticksCount : MonoBehaviour {
    
    public GameObject Player;

    private Text Count;
    private Player player;

	// Use this for initialization
	void Start () {
        player = Player.GetComponent<Player> ();
        Count = GetComponent<Text> ();
        Count.text = player.flareStickAvailable.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void UpdateFlareCount () {
        player.flareStickAvailable--;
        Count.text = player.flareStickAvailable.ToString ();
    }
}
