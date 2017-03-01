using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaScript : MonoBehaviour {
    public int damage;
    public float reloadTime;
    public float range;
    public float effectDuration;
    bool[] reloaded = { true, true, true };
    List<EnemyScript> targetEnemies = new List<EnemyScript>();

    void Start()
    {
        gameObject.GetComponent<SphereCollider>().radius = range;
    }
    void Update()
    {
        for (int i = 0; i < targetEnemies.Count && i < 3; ++i)
            if (reloaded[i])
            {
                targetEnemies[i].TakeDamage(damage, 1, effectDuration);
                reloaded[i] = false;
                StartCoroutine(Reload(i));
            }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            targetEnemies.Add(other.GetComponent<EnemyScript>());
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
            targetEnemies.Remove(other.GetComponent<EnemyScript>());
    }
    IEnumerator Reload(int i)
    {
        yield return new WaitForSeconds(reloadTime);
        reloaded[i] = true;
    }
}
