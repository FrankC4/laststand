using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour 
{
    public void StartGame() 
    {
        SceneManager.LoadScene("Level1");
    }
	public void Settings()
	{
		SceneManager.LoadScene ("Settings");
	}
	public void Credits()
	{
		SceneManager.LoadScene ("Credits");
	}
}
