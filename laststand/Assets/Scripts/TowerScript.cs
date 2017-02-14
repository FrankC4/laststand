using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : EnemyScript {

	bool cooldown = true; // need to check whether cooldown exists or not for the towers default is true

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Attack ();
	}

	void Attack (){
		if (cooldown) {
			// based on the cooldown length we should delay the next attack X seconds

		} else {
			
		}
	}
}

public class GatTowerScript : TowerScript {
	private bool cooldown = false;
	private int damage;

	void GatTower(){
		// initialize machine gun tower
	}

	int setDamage(){
		// The amount of damage machine gun tower can deal out
	}

	void GatAttack (){
		
	}
}

public class EMPTowerScript : TowerScript {
	private bool cooldown = true;


	void EMPTower(){
	
	}

	void EMPAttack(){
		EnemyScript.setStatus ("shock");
	}
}

public class FreezeTowerScript : TowerScript {
	private bool cooldown = true;

	void FreezeTower (){
	
	}

	void FreezeAttack(){
		EnemyScript.setStatus ("frozen");
	}
}

