using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {
    public TowerBuildScript towerBuildScript;
    public TowerChooseScript towerChooseScript;
    public float startTime;
    public int count;
    public float interval;
    public Transform enemy;
    public UnityEngine.UI.Text minutes;
    public UnityEngine.UI.Text seconds;
    private int remainingSeconds;
    private int remainingMinutes;
    int upgrade = -1;

    IEnumerator Wave()
    {
        yield return new WaitForSeconds(startTime);
        for(int i = 0; i < count; ++i)
        {
            Instantiate(enemy);
            yield return new WaitForSeconds(interval);
        }
        DetermineUpgrade();
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

    void DetermineUpgrade()
    {
        if (upgrade == -1)
        {
            towerChooseScript.enabled = true;
            towerChooseScript.Activate();
        }
        else
        {
            float RNGesus = Random.value;
            if (RNGesus > .2 && RNGesus <= .6)
            {
                ++upgrade;
                if (upgrade == 3)
                {
                    upgrade = 0;
                }
            }
            else if (RNGesus > .6)
            {
                --upgrade;
                if (upgrade == -1)
                {
                    upgrade = 2;
                }
            }
            towerBuildScript.enabled = true;
            towerBuildScript.Activate(upgrade);
        }
    }

    public void SetUPgrade(int u)
    {
        upgrade = u;
    }

}
