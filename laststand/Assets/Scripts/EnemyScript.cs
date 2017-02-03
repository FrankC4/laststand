using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public float walkspeed; // this is effected by freezeTower
	public string status; // this is effected by emp and freezeTower
	public float health; // all enemies should start with full health
	float timeLeft = 20.0f; // ten seconds frozen

	// Use this for initialization
	void Start () {
		getStatus ();
	}
	
	// Update is called once per frame
	void Update () {
		getStatus (); // to be honest 
	}


	public string setStatus(string status){
		// this takes in whether the characters are shocked or frozen

		switch(status){

		case "frozen":
			Debug.Log ("Enemy status: %s", status);
			walkspeed = 0.0f;
			break;

		case "shock":
			Debug.Log ("Enemy status: %s", status);
			walkspeed = 0.0f;
			break;
		}

	}

	private string getStatus(){
		
		// we should also do like animation or something
		// just saying but not necessary
		if (status == "frozen") {
			timeLeft -= Time.deltaTime;
			for (int i = 0; i <= 100; i++){
				walkspeed += (i * 0.25f);
				// this is used to unfreeze enemy back to normal speed
				status = "none";
			}
		}
		else if (status == "shock") {
			timeLeft -= Time.deltaTime;
			if (timeLeft == 0) {
				walkspeed = 10.0f;
				status = "none";
			}
		}
	}


}
