using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {
    public float startTime;
    public int count;
    public float interval;
    public Transform enemy;
    IEnumerator Wave() {
        yield return new WaitForSeconds(startTime);
        for(int i = 0; i < count; ++i) {
            Instantiate(enemy);
            yield return new WaitForSeconds(interval);
        }
    }
    void Start() { StartCoroutine(Wave()); }
}
