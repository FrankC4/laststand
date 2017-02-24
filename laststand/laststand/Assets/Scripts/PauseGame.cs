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

	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyUp(KeyCode.Escape))
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
				AudioListener.volume = 0;
                Cursor.lockState = CursorLockMode.None;
        		}
        		else
        		{
           	 	canvas.gameObject.SetActive(false);
            	Time.timeScale = 1f;
				AudioListener.volume = 1;
                Cursor.lockState = CursorLockMode.Locked;
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