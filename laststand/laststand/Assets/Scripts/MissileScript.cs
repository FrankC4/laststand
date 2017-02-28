using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour {
    public int damage;
    void Start()
    {
        StartCoroutine(KillSelf());
    }
    IEnumerator KillSelf()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            other.GetComponent<EnemyScript>().TakeDamage(damage);
    }
}
