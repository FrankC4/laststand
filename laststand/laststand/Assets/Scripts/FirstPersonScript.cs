using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonScript : MonoBehaviour { //this script should be attached to the perspective camera
    public float reloadTime = 1f;
    public bool reloaded = true;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && reloaded && Time.timeScale > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            StartCoroutine(Reload());
            if (Physics.Raycast(ray, out hitInfo))
                if (hitInfo.transform.CompareTag("Enemy"))
                    hitInfo.transform.GetComponent<EnemyScript>().TakeDamage(5);
        }
    }
    IEnumerator Reload()
    {
        reloaded = false;
        yield return new WaitForSeconds(reloadTime);
        reloaded = true;
    }
}
