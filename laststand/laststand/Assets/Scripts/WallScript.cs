using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : TowerScript {
    int health;
    void Start()
    {
        health = damage;
    }
    void Update()
    {

    }
    IEnumerator Regenerate()
    {
        transform.GetChild(0).transform.position = new Vector3(0, -50, 0);
        yield return new WaitForSeconds(reloadTime);
        health = damage;
        transform.GetChild(0).transform.position = transform.position;
    }
    public virtual int WallDamage(int d)
    {
        if ((health -= d) <= 0)
            StartCoroutine(Regenerate());
        return 0;
    }
}
