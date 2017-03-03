using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {
    public TowerBuildScript towerBuildScript;
    public TowerChooseScript towerChooseScript;
    public GameObject victoryMenuCanvas;
    public float startTime;
    public int count;
    public float interval;
    public Transform enemy;
    public UnityEngine.UI.Text timerName;
    public UnityEngine.UI.Text minutes;
    public UnityEngine.UI.Text seconds;
    public UnityEngine.UI.Text waveNumberTxt;
    public UnityEngine.UI.Text enemyNumber;
    private int waveNumber = 0;
    private int remainingSeconds;
    private int remainingMinutes;
    int upgrade = -1;

    IEnumerator Wave()
    {
        timerName.text = "Wave Start";
        yield return new WaitForSeconds(startTime);
        timerName.text = "Last Enemy";
        ++waveNumber;
        waveNumberTxt.text = waveNumber.ToString();
        for(int i = 0; i < count; ++i)
        {
            Instantiate(enemy, transform.position, transform.rotation, transform);
            yield return new WaitForSeconds(interval);
        }
        while (gameObject.transform.childCount > 0)
            yield return new WaitForSeconds(Time.deltaTime);
        DetermineUpgrade();
        if (waveNumber < 4)
        {
            count += 2;
            interval -= .1f;
            StartCoroutine(Wave());
            StartCoroutine(CountDown());
        }
        else
            StartCoroutine(FinalWave());
    }


    IEnumerator FinalWave()
    {
        timerName.text = "Wave Start";
        count = 12;
        interval = .5f;
        StartCoroutine(CountDown());
        yield return new WaitForSeconds(startTime);
        timerName.text = "Last Enemy";
        waveNumberTxt.text = "Final";
        for (int i = 0; i < count; ++i)
        {
            Instantiate(enemy, transform.position, transform.rotation, transform);
            yield return new WaitForSeconds(interval);
        }
        while (gameObject.transform.childCount > 0)
            yield return new WaitForSeconds(Time.deltaTime);
        yield return new WaitForSeconds(.5f);
        Victory();
    }

    IEnumerator CountDown()
    {
        remainingMinutes = (int)(startTime / 60);
        remainingSeconds = (int)(startTime - (remainingMinutes * 60));
        if (remainingSeconds > 9)
            seconds.text = remainingSeconds.ToString();
        else
            seconds.text = "0" + remainingSeconds.ToString();
        if (remainingMinutes > 9)
            minutes.text = remainingMinutes.ToString();
        else
            minutes.text = "0" + remainingMinutes.ToString();
        for (int i = 0; i < (int)startTime; ++i)
        {
            yield return new WaitForSeconds(1);
            if (remainingSeconds > 0)
            {
                --remainingSeconds;
                if (remainingSeconds > 9)
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
        float time = (interval * count);
        remainingMinutes = (int)(time / 60);
        remainingSeconds = (int)(time - (remainingMinutes * 60));
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
        StartCoroutine(CountDown());
        DetermineUpgrade();
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

    void Victory()
    {
        victoryMenuCanvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.volume = 0;
        Cursor.lockState = CursorLockMode.None;
    }
}
