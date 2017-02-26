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
    public GameObject nodes;
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
    int upgrade = 0;
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
                            if (upgrade < 2)
                            {
                                Vector3 buildPosition = hitInfo.transform.position;
                                if (hitInfo.transform.GetComponent<NodeScript>().wallNode1)
                                    Destroy(hitInfo.transform.GetComponent<NodeScript>().wallNode1);
                                if (hitInfo.transform.GetComponent<NodeScript>().wallNode2)
                                    Destroy(hitInfo.transform.GetComponent<NodeScript>().wallNode2);
                                if (hitInfo.transform.GetComponent<NodeScript>().wallNode3)
                                    Destroy(hitInfo.transform.GetComponent<NodeScript>().wallNode3);
                                if (hitInfo.transform.GetComponent<NodeScript>().wallNode4)
                                    Destroy(hitInfo.transform.GetComponent<NodeScript>().wallNode4);
                                Destroy(hitInfo.transform.gameObject);
                                Instantiate(baseTowers[upgrade], buildPosition, Quaternion.identity);
                                Deactivate();
                            }
                            break;
                        case "WallNode":
                            if (upgrade == 2)
                            {
                                Vector3 buildPosition = hitInfo.transform.position;
                                if (hitInfo.transform.GetComponent<wallnodescript>().Node1)
                                    Destroy(hitInfo.transform.GetComponent<wallnodescript>().Node1);
                                if (hitInfo.transform.GetComponent<wallnodescript>().Node2)
                                    Destroy(hitInfo.transform.GetComponent<wallnodescript>().Node2);
                                Destroy(hitInfo.transform.gameObject);
                                if (hitInfo.transform.GetComponent<wallnodescript>().isSideways)
                                    Instantiate(baseTowers[upgrade], buildPosition, Quaternion.Euler(0f,-90f,0f));
                                else
                                    Instantiate(baseTowers[upgrade], buildPosition, Quaternion.identity);
                                Deactivate();
                            }
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
                                descriptionText.text = towerDescriptions[upgrade, 0];
                                towerDescription.SetActive(true);
                                //move 'image' to this location (if it's not already there)
                                //make a ui element showing tower based on upgrade type
                            }
                            else
                                towerDescription.SetActive(false);
                            break;
                        case "WallNode":
                            if (upgrade == 2)
                            {
                                descriptionText.text = towerDescriptions[upgrade, 0];
                                towerDescription.SetActive(true);
                            }
                            else
                                towerDescription.SetActive(false);
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
        nodes.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        upgrade = u;

    }
    void Deactivate()
    {
        gameObject.GetComponent<Camera>().enabled = false;
        firstPersonHUD.SetActive(true);
        nodes.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        towerDescription.SetActive(false);
        enabled = false;
    }

    
}
