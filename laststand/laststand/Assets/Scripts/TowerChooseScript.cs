using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerChooseScript : MonoBehaviour {
    public GameObject firstPersonHUD;
    public Transform buildModeHUD;
    public GameObject gatlingPanel;
    public GameObject teslaPanel;
    public GameObject wallPanel;
    public TowerBuildScript towerBuildScript;
    int upgrade;


    public void Activate()
    {
        gameObject.GetComponent<Camera>().enabled = true;
        firstPersonHUD.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        gatlingPanel.SetActive(true);
        teslaPanel.SetActive(true);
        wallPanel.SetActive(true);
    }

    void Deactivate()
    {
        gatlingPanel.SetActive(false);
        teslaPanel.SetActive(false);
        wallPanel.SetActive(false);
        towerBuildScript.enabled = true;
        towerBuildScript.Activate(upgrade);
    }

    public void gatlingClick()
    {
        upgrade = 0;
        Deactivate();
    }

    public void teslaClick()
    {
        upgrade = 1;
        Deactivate();
    }

    public void wallClick()
    {
        upgrade = 2;
        Deactivate();
    }
}
