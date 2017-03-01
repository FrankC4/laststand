using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerScript : MonoBehaviour {
    public int damage;
    public float reloadTime;
    public float range;
    public int effect; //0 => none, 1 => shock, 2 => fire, 3 => missile
    public float effectDuration;
    bool reloaded = true;
    List<EnemyScript> targetEnemies = new List<EnemyScript>(); //Needed to initialize it to solve a null reference error in update.
    EnemyScript target;
    public GameObject projectile;

    private void Start()
    {
        gameObject.GetComponent<SphereCollider>().radius = range; //Sets the radius of the collider to the range. (This is tested and works)
    }

    void Update ()
    {
        if (targetEnemies.Count > 0)
        {
            if (target == null)
                FindTarget();
            if (target)
            {
                transform.LookAt(target.transform);
                if (reloaded)
                {
                    target.TakeDamage(damage, (effect < 3) ? effect : 0, effectDuration);
                    if (effect > 2)
                        Instantiate(projectile, target.transform.position, Quaternion.identity);
                    reloaded = false;
                    StartCoroutine(Reload());
                }
            }
        }
	}

    void FindTarget()
    {
        float leastValue = float.MaxValue;
        int leastIndex = -1;
        float thisValue;
        for (int i = 0; i < targetEnemies.Count; ++i)
            if(targetEnemies[i])
                if ((thisValue = targetEnemies[i].ETA()) < leastValue)
                {
                    leastValue = thisValue;
                    leastIndex = i;
                }
        if (leastIndex != -1)
            target = targetEnemies[leastIndex];
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            targetEnemies.Add(other.GetComponent<EnemyScript>());
    }

    void OnTriggerExit(Collider other)
    {
        //for (int i = 0; i < targetEnemies.Count; ++i)
        //    if (targetEnemies[i] == other.gameObject.GetComponent<EnemyScript>())
        if (other.CompareTag("Enemy"))
            targetEnemies.Remove(other.GetComponent<EnemyScript>());
        if (other.GetComponent<EnemyScript>() == target)
            target = null;
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        reloaded = true;
    }
}
