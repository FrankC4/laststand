using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Status { none, frozen, shock }

struct Point { int x; int y; }

public class EnemyScript : MonoBehaviour {
    List<Point> path;
    public int damage; //how much damage the enemy deals to the player['s tower]
	public float walkspeed; // this is affected by freezeTower
	public Status status; // this is affected by emp and freezeTower
    public float statusDuration; //when is this used?
	public float health; // all enemies should start with full health
	float timeLeft = 20.0f; // ten seconds frozen
    public bool immune;
	void Start ()
    {
        status = none;
	}
	void Update ()
    {

	}
	public void ApplyStatus(Status s, float f) {
        if (immune) return;
		// this takes in whether the characters are shocked or frozen
		switch(s)
        {
		case frozen:
			Debug.Log ("Enemy status: frozen");
			walkspeed = 0.0f;
            statusDuration = f;
			break;
		case shock:
			Debug.Log ("Enemy status: shocked");
			walkspeed = 0.0f;
			break;
		}
	}
	private string GetStatus(){ //Why is this called 'getStatus'? it's not fetching the status, it's modifying it...
		//the return type here is listed as 'string', but no 'return' is even called?

		// we should also do like animation or something
		// just saying but not necessary
		if (status == frozen) {
			timeLeft -= Time.deltaTime;
			for (int i = 0; i <= 100; i++){
				walkspeed += (i * 0.25f);
				// this is used to unfreeze enemy back to normal speed
				status = none;
			}
		}
		else if (status == shock) {
			timeLeft -= Time.deltaTime;
			if (timeLeft == 0) {
				walkspeed = 10.0f;
				status = none;
			}
		}
	}
    //TODO: function that moves enemy along the path
    //      this function should also rotate the enemy so it's facing the right way
}
