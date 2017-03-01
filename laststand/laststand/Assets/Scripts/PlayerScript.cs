using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour { //is this the script for just the enemy-attackable player, or for the whole UI?
	private int health = 100;
    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            //TODO: end the game
        }
    }
}
