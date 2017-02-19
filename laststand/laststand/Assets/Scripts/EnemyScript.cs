using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
    public int damage;
    public float maxWalkSpeed;
    public int health;
    public float currentWalkSpeed; //Temporarily public for testing
    float fireDuration = 0; //External from fire so that the coroutine can be extended if the enemy is lit on fite again.
    float shockDuration = 0;
    bool onFire = false;
    Transform killLocation;
    private GameObject waypoint;

    void Start()
    {
        currentWalkSpeed = maxWalkSpeed;
        killLocation = GameObject.FindGameObjectWithTag("Kill").GetComponent<Transform>();
        waypoint = GameObject.FindGameObjectWithTag("FirstWaypoint");
    }
    void Update()
    {
        Walk();
    }
    void Walk()
    {
        if ((gameObject.transform.position - waypoint.transform.position).magnitude == 0f)
            if (waypoint.GetComponent<WaypointScript>().Distance() != 0)
                waypoint = waypoint.GetComponent<WaypointScript>().nextWaypoint;
            else
            {
                //start attacking player
            }
        else
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, waypoint.transform.position, Time.deltaTime * currentWalkSpeed);

    }
    public float ETA()
    {
        return (gameObject.transform.position - waypoint.transform.position).magnitude + waypoint.GetComponent<WaypointScript>().Distance();
        // returns (the distance from this enemy to the next waypoint) added to (the Distance the next waypoint gives for itself).
    }
    public void TakeDamage(int damage, int effect, float effectDuration)
    {
        if ((health -= damage) <= 0)
            StartCoroutine(KillSelf());
        if (effect == 1)
        { 
            StopCoroutine("Shock"); //Stop the shop if there's already one occurring.
            if (effectDuration > shockDuration)
                shockDuration = effectDuration;
            StartCoroutine("Shock"); //Start the shock.
        }
        if (effect == 2)
        {
            if(effectDuration > fireDuration)
                fireDuration = effectDuration; //Setting this extends the duration of fire if the enemy is burned again.
            if (!onFire)
                StartCoroutine(Burn());
        }
    }
    IEnumerator KillSelf()
    {
        if (gameObject)
        {
            gameObject.transform.position = killLocation.position;
            gameObject.transform.rotation = killLocation.rotation;
            yield return null;
            Destroy(gameObject);
        }
    }
    IEnumerator Shock()
    {
        float runningTime = 0.0f;
        while(runningTime < shockDuration)
        {
            currentWalkSpeed = (runningTime / shockDuration) * maxWalkSpeed;
            yield return new WaitForSeconds(.02f);
            runningTime += .02f;
        }
        currentWalkSpeed = maxWalkSpeed;
    }
    IEnumerator Burn()
    {
        onFire = true;
        //float burnTime = Time.time;
        //float runningTime = 0.0f;
        while (fireDuration > 0)
        {
            if (--health <= 0)
                StartCoroutine(KillSelf());
            yield return new WaitForSeconds(1.0f);
            --fireDuration;
        }
        /*
        while(runningTime < duration)
        {
            --health;
            yield return null;
            runningTime += Time.deltaTime;
        }*/
        onFire = false;
        
    }
}
