using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonScript : MonoBehaviour { //this script should be attached to the perspective camera
    public float reloadTime = 1f;
    public bool reloaded = true;
    public UnityEngine.UI.Text AmmoVal;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && reloaded && Time.timeScale > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            AmmoVal.text = "0"; //Since our gun only shoots once we can just directly set it to 0 when fired. We can easily modify this later if we want for bigger clips.
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
        AmmoVal.text = "1";
        reloaded = true;
    }
}
