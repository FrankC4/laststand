using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerScript : MonoBehaviour {
    public int damage;
    public float reloadTime;
    public float range;
    public int effect; //0 => none, 1 => shock, 2 => fire
    public float effectDuration;
    public float rotationSpeed;
    bool reloaded = false;
    List<EnemyScript> targetEnemies;
    EnemyScript target;
	void Update () {
        if (targetEnemies.Count > 0)
        {
            if (target == null)
                FindTarget();
            gameObject.transform.rotation.SetLookRotation(Vector3.RotateTowards(gameObject.transform.forward, target.gameObject.transform.forward, rotationSpeed * Time.deltaTime, 0f));
            if (reloaded)
            {
                target.TakeDamage(damage, effect, effectDuration);
                reloaded = false;
                StartCoroutine(Reload());
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
        targetEnemies.Add(other.GetComponent<EnemyScript>());
    }
    void OnTriggerExit(Collider other)
    {
        //for (int i = 0; i < targetEnemies.Count; ++i)
        //    if (targetEnemies[i] == other.gameObject.GetComponent<EnemyScript>())
        targetEnemies.Remove(other.GetComponent<EnemyScript>());
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        reloaded = true;
    }
}
