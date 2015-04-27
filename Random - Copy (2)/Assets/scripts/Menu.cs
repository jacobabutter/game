using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public AudioSource music;
	
	void Start(){
		if (Application.loadedLevelName != "DeadMenu") {
			PlayerPrefs.SetInt ("lastlevel", Application.loadedLevel);
			// and you can call this info by using:
		}
		if (PlayerPrefs.GetInt ("lastlevelAccess") == 0) {
			PlayerPrefs.SetInt ("lastlevelAccess", 1);
		}
		if (Application.loadedLevelName == "VictoryMenu") {
			PlayerPrefs.SetInt ("lastlevelAccess", Application.loadedLevel + 1);
			// and you can call this info by using:
		}
	}

	public void QuitGame(){
		Debug.Log("game is exiting...");
		Application.Quit();
	}
	public void LoadLevelSelect (string level){
		Application.LoadLevel (level);
	}
	public void StartGame (int level){
		int levelAccess = PlayerPrefs.GetInt ("lastlevelAccess");
		int levelLoad = level + 3;
		Debug.Log (levelAccess);
		if ( levelLoad >= levelAccess) {
			Application.LoadLevel (levelLoad);
		}
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
	public void LevelAccess (int levelAccess){
		int lastLevelAccess = PlayerPrefs.GetInt ("lastlevelAccess");
		if (lastLevelAccess >= levelAccess) {
			Application.LoadLevel (levelAccess);
		}
	}
}






















