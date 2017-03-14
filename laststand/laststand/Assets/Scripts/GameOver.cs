using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public UnityEngine.UI.Button retryButton;
    public UnityEngine.UI.Button exitButton;

    private void OnEnable()
    {
        StartCoroutine("delayInteraction");
    }

    IEnumerator delayInteraction()
    {
        retryButton.interactable = false;
        exitButton.interactable = false;
        yield return new WaitForSecondsRealtime(.5f);
        retryButton.interactable = true;
        exitButton.interactable = true;
    }

}
