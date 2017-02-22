using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildScript : MonoBehaviour { //this script should be attached to the orthographic camera
    public GameObject[] baseTowers;
    public GameObject[] gatlings;
    public GameObject[] teslas;
    public GameObject[] walls;
    public GameObject towerDescription;
    public GameObject firstPersonHUD;
    public UnityEngine.UI.Text descriptionText;
    string[,] towerDescriptions =
    {
        {
            "base gatling",//
            "beam",//
            "incendiary",//
            "missile"//
        },
        {
            "base tesla",//
            "fast tesla",//
            "shock tesla",//
            "emp"//
        },
        {
            "base wall",//
            "quick wall",//
            "return damage wall",//
            "thick wall"//
        }
    };
    int upgrade;
    void Update()
    {
        if (gameObject.GetComponent<Camera>().enabled)
        {
            Ray ray = gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
                if (Input.GetMouseButtonDown(0))
                {
                    switch (hitInfo.transform.tag)
                    {
                        case "Node":
                            Vector3 buildPosition = hitInfo.transform.position;
                            Destroy(hitInfo.transform.gameObject);
                            Instantiate(baseTowers[upgrade], buildPosition, Quaternion.identity); //this might be more complicated for walls
                            Deactivate();
                            break;
                        case "Gatling":
                            Vector3 gatlingPosition = hitInfo.transform.position;
                            Destroy(hitInfo.transform.gameObject);
                            Instantiate(gatlings[upgrade], gatlingPosition, Quaternion.identity);
                            Deactivate();
                            break;
                        case "Tesla":
                            Vector3 teslaPosition = hitInfo.transform.position;
                            Destroy(hitInfo.transform.gameObject);
                            Instantiate(teslas[upgrade], teslaPosition, Quaternion.identity);
                            Deactivate();
                            break;
                        case "Wall":
                            Vector3 wallPosition = hitInfo.transform.position;
                            Destroy(hitInfo.transform.gameObject);
                            Instantiate(walls[upgrade], wallPosition, Quaternion.identity); //this might be more complicated
                            Deactivate();
                            break;
                    }
                }
                else
                {
                    switch (hitInfo.transform.tag)
                    {
                        case "Node":
                            if (upgrade < 2)
                            {
                                descriptionText.text = towerDescriptions[upgrade,0];
                                towerDescription.SetActive(true);
                                //move 'image' to this location (if it's not already there)
                                //make a ui element showing tower based on upgrade type
                            }
                            break;
                        case "WallNode":
                            descriptionText.text = towerDescriptions[upgrade,0];
                            towerDescription.SetActive(true);
                            //for building a new wall
                            break;
                        case "Gatling":
                            descriptionText.text = towerDescriptions[0, upgrade + 1];
                            towerDescription.SetActive(true);
                            //move 'image' to this location (if it's not already there)
                            //make a ui element showing upgraded gatling
                            break;
                        case "Tesla":
                            descriptionText.text = towerDescriptions[1, upgrade + 1];
                            towerDescription.SetActive(true);

                            break;
                        case "Wall":
                            descriptionText.text = towerDescriptions[2, upgrade + 1];
                            towerDescription.SetActive(true);

                            break;
                        default:
                            towerDescription.SetActive(false);
                            break;
                    }
                }
        }
    }
    public void Activate(int u)
    {
        gameObject.GetComponent<Camera>().enabled = true;
        firstPersonHUD.SetActive(false);
        Time.timeScale = 0;
        upgrade = u;
    }
    void Deactivate()
    {
        gameObject.GetComponent<Camera>().enabled = false;
        firstPersonHUD.SetActive(true);
        Time.timeScale = 1;
        towerDescription.SetActive(false);
    }
}
