using UnityEngine;
using System.Collections;

public class WaypointScript : MonoBehaviour {
    public GameObject nextWaypoint;
    public float distance = -1f; //distance starts as -1.
    public float Distance()
    {
        return (distance != -1f) ? distance : //if distance has already been calculated, returns distance.
            distance = (gameObject.transform.position - nextWaypoint.transform.position).magnitude + (nextWaypoint.GetComponent<WaypointScript>().Distance());
        //      otherwise, adds (the distance from this waypoint to the next) to (the distance that the next waypoint gives for itself).
    }
}
