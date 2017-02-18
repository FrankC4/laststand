using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseGame : MonoBehaviour 
{
    public Transform canvas;
	public Animator pausemenu;
	public Animator menu;
	public Animator settingsmenu;
	public Slider volumeSlider;
	public AudioSource volumeAudio;
    public static bool paused;

	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}

    public void Pause()
    {
			if (canvas.gameObject.activeInHierarchy == false) // checks to see if canvas us active or not
        	    {
            	canvas.gameObject.SetActive(true);
            	Time.timeScale = 0f;
                paused = true;
				AudioListener.volume = 0;
        		}
        		else
        		{
           	 	canvas.gameObject.SetActive(false);
            	Time.timeScale = 1f;
                paused = false;
				AudioListener.volume = 1;
        		}
    }

	public void Mainmenu() 
	{	
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
	}

	public void	PauseOpenSettings()
	{
		pausemenu.SetBool ("isHidden",false);
		settingsmenu.SetBool ("isHidden", true);
	
	}

	public void PauseClosingSettings()
	{
		pausemenu.SetBool ("isHidden",true);
		settingsmenu.SetBool ("isHidden", false);
	}

	public void	MenuOpenSettings()
	{
		settingsmenu.SetBool ("isHidden", true);
		menu.SetBool ("isHidden",false);

	}

	public void MenuClosingSetings()
	{
		settingsmenu.SetBool ("isHidden", false);
		menu.SetBool ("isHidden",true);
	}
		
	public void StartGame() 
	{
		SceneManager.LoadScene("Level1");
	}
		
	public void Credits()
	{
		SceneManager.LoadScene ("Credits");
	}
		
	public void VolumeController()
	{
		volumeAudio.volume = volumeSlider.value;
	}
}