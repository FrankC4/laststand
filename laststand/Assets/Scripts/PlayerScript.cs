using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	private float playerHealth = 100.0f;
    //do you guys want to make it an integer?
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// check if playerHealth = 0
		if (playerHealth == 0) {
			// gameover
			// probably a GUI skin stating that the game is over and an options menu just to be safe
		} else {
			// do something
		}
	}
}
