using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MainMenuController : MonoBehaviour {

	public GameObject AboutScreen;
	public GameObject HelpScreen;
	public GameObject PopUpReplayTutorial;
	public GameObject PopUpExitGame;
	public GameObject PanelLeaderBoard;
	public GameObject ButtonSound;

	AudioSource audioSource;
	public static bool s_isMuteSound = false;

	public static MainMenuController instance;

	void Awake ()
	{
		getInstance ();
		audioSource = GetComponent<AudioSource> ();
	}

	void getInstance ()
	{
		if (instance == null) {
			instance = this;
		}
	}

	void Start() {
//		InitSound ();
	}

	public void PlayGameButton () {
		SceneManager.LoadScene ("GamePlay", LoadSceneMode.Single);
		Time.timeScale = 1f;
	}
		
	public void ShowLeaderBoard (bool show) {
		PanelLeaderBoard.SetActive(show);
	}

	public void ShowAboutScreen (bool show) {
		AboutScreen.SetActive(show);
	}

	public void ShowHelpScreen (bool show) {
		HelpScreen.SetActive(show);
	}

	public void ShowConfirmReplayTutorial (bool show) {
		PopUpReplayTutorial.SetActive(show);
	}

	public void ShowConfirmExitGame (bool show) {
		PopUpExitGame.SetActive(show);
	}

	public void ReplayTutorial () {
		StorageManager.s_doneTutorial = 0;
		StorageManager.instance.SaveTutorialData (0);
		ShowConfirmReplayTutorial (false);
	}

	public void SoundButton () {
		if (s_isMuteSound) {
			s_isMuteSound = false;
			audioSource.mute = false;
			ChangeSoundImage (false);
			StorageManager.instance.SaveSoundData (1);
		} else {
			s_isMuteSound = true;
			audioSource.mute = true;
			ChangeSoundImage (true);
			StorageManager.instance.SaveSoundData (0);
		}
	}

	void ChangeSoundImage (bool isSoundOn) {
		ButtonSound.transform.GetChild (0).gameObject.SetActive(isSoundOn);
		ButtonSound.transform.GetChild (1).gameObject.SetActive(!isSoundOn);
	}

	public void InitSound() {
		if (StorageManager.s_isSound == 1) {
			s_isMuteSound = false;
		} else if (StorageManager.s_isSound == 0){
			s_isMuteSound = true;
		}
		if (s_isMuteSound) {
			audioSource.mute = true;
			ChangeSoundImage (true);
		} else {
			audioSource.mute = false;
			ChangeSoundImage (false);
		}
	}

	public void QuitGame() {
		Application.Quit ();
	}
}
