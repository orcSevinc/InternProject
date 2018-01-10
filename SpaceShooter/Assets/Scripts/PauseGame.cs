using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

	public Transform canvas;
	
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (canvas.gameObject.activeInHierarchy == false) 
			{
				canvas.gameObject.SetActive(true);
				Time.timeScale = 0;
			} else 
				{
					canvas.gameObject.SetActive(false);
					Time.timeScale = 1;
				}
		}
	}
	
	public void doExitGame() 
	{
		Application.Quit();
	}
	
	public void doResumeGame() 
	{
		canvas.gameObject.SetActive(false);
		Time.timeScale = 1;
	}

}
