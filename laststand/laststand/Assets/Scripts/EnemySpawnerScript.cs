using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {
    public TowerBuildScript towerBuildScript;
    public float startTime;
    public int count;
    public float interval;
    public Transform enemy;
    public UnityEngine.UI.Text minutes;
    public UnityEngine.UI.Text seconds;
    public int upgrade;
    private int remainingSeconds;
    private int remainingMinutes;

    IEnumerator Wave()
    {
        yield return new WaitForSeconds(startTime);
        for(int i = 0; i < count; ++i)
        {
            Instantiate(enemy);
            yield return new WaitForSeconds(interval);
        }
        towerBuildScript.Activate(upgrade);
    }

    IEnumerator CountDown(float time)
    {
        if (remainingSeconds > 9)
            seconds.text = remainingSeconds.ToString();
        else
            seconds.text = "0" + remainingSeconds.ToString();
        if (remainingMinutes > 9)
            minutes.text = remainingMinutes.ToString();
        else
            minutes.text = "0" + remainingMinutes.ToString();
        yield return new WaitForSeconds(time - (int)time);
        for (int i = 0; i < (int)time; ++i)
        {
            yield return new WaitForSeconds(1);
            if (remainingSeconds > 0)
            {
                --remainingSeconds;
                if (remainingSeconds >9)
                    seconds.text = remainingSeconds.ToString();
                else
                    seconds.text = "0" + remainingSeconds.ToString();
            }
            else
            {
                --remainingMinutes;
                remainingSeconds = 59;
                if (remainingMinutes > 9)
                    minutes.text = remainingMinutes.ToString();
                else
                    minutes.text = "0" + remainingMinutes.ToString();
                seconds.text = "59";
            }
        }
    }
    void Start()
    {
        StartCoroutine(Wave());
        float time = (interval * count) + startTime;
        remainingMinutes = (int)time / 60;
        remainingSeconds = (int)(time - (remainingMinutes * 60));
        StartCoroutine(CountDown(time));
    }
}
