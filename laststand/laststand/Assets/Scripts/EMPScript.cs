using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMPScript : MonoBehaviour {
    public int damage;
    public float effectDuration;
    public float range;
    public float reloadTime;
    float startTime;
    void Start()
    {
        startTime = Time.time;
    }
	void Update () {
        if (Time.timeScale != 0)
            if ((gameObject.GetComponent<SphereCollider>().radius = (((Time.time - startTime) / reloadTime) * range)) >= range)
                    startTime = Time.time;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            other.GetComponent<EnemyScript>().TakeDamage(damage, 1, effectDuration);
    }
}
