using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
    public GameObject waypoint;
    public int damage;
    public float maxWalkSpeed;
    public int health;
    float currentWalkSpeed;
    bool shocked = false;
    bool onFire = false;
    Transform killLocation;

    void Start()
    {
        currentWalkSpeed = maxWalkSpeed;
        killLocation = GameObject.FindGameObjectWithTag("Kill").GetComponent<Transform>();
    }
    void Update()
    {
        Walk();
    }
    void Walk()
    {
        //TODO: move enemy
        //TODO: rotate enemy to face the way it's walking
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
        if (!shocked)
            if (effect == 1)
                StartCoroutine(Shock(effectDuration));
        if (!onFire)
            if (effect == 2)
                StartCoroutine(Burn(effectDuration));
    }
    IEnumerator KillSelf()
    {
        gameObject.transform.position = killLocation.position;
        gameObject.transform.rotation = killLocation.rotation;
        yield return null;
        Destroy(gameObject);
    }
    IEnumerator Shock(float duration)
    {
        shocked = true;
        float runningTime = 0.0f;
        while(runningTime < duration)
        {
            currentWalkSpeed = (runningTime / duration) * maxWalkSpeed;
            yield return null;
            runningTime += Time.deltaTime;
        }
        shocked = false;
        currentWalkSpeed = maxWalkSpeed;
    }
    IEnumerator Burn(float duration)
    {
        onFire = true;
        float burnTime = Time.time;
        float runningTime = 0.0f;
        while(runningTime < duration)
        {
            --health;
            yield return null;
            runningTime += Time.deltaTime;
        }
        onFire = false;
    }
}
