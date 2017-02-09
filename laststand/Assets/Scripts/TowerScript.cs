using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Status { none, frozen, shock }

public class TowerScript : MonoBehaviour {
    public int damage;
	public float reloadTime;
    public float range;
    Status status;
    public EnemyScript target = null;
    Update()
    {
        if (target)
            StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        target.TakeDamage(damage, status);
        //TODO: instantiate the 'bullet' (it could be a laser beam or some other attack)
        //      perhaps all towers shoot a beam instead of projectiles?
        //      this would make it much simpler to code
        yield return new WaitForSeconds(reloadTime);
    }
    //TODO: a function that changes the target to an enemy within the range
    //TODO: a function that rotates the tower to point towards the targeted enemy
}
