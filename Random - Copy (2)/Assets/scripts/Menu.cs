﻿using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public AudioSource music;

	void Start(){
		if (Application.loadedLevelName != "DeadMenu") {
			PlayerPrefs.SetInt ("lastlevel", Application.loadedLevel);
			// and you can call this info by using:
		}
	}

	public void QuitGame(){
		Debug.Log("game is exiting...");
		Application.Quit();
	}
	public void StartGame (string level){
		Application.LoadLevel (level);
	}
	public void SetGameVolume (float vol){
		music.volume = vol;
	}
	public void LoadMainMenu (string mainmenu){
		Application.LoadLevel (mainmenu);
	}
	public void LoadLastLevel (string lastlevelload){
		int lastLevel = PlayerPrefs.GetInt ("lastlevel");
		Application.LoadLevel (lastLevel);
		Debug.Log (lastLevel);
	}
	public void LoadNextLevel (string nextlevelload){
		int lastLevel = PlayerPrefs.GetInt ("lastlevel");
		Application.LoadLevel (lastLevel + 1);
		Debug.Log (lastLevel + 1);
	}
}





















