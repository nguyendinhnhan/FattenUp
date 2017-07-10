using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MainMenuController : MonoBehaviour {

	public GameObject AboutScreen;
	public GameObject HelpScreen;
	public GameObject confirmReplayTutorial;
	public GameObject confirmExitGame;
	public GameObject leaderBoardPanel;
	public GameObject buttonSoundOn;
	public GameObject buttonSoundOff;

	AudioSource audioSource;
	public static bool s_isMuteSound = false;

	void Awake () {
		audioSource = GetComponent<AudioSource> ();
	}

	void Start(){
		InitSound ();
	}

	public void PlayGameButton () {
		SceneManager.LoadScene ("GamePlay", LoadSceneMode.Single);
		Time.timeScale = 1f;
	}
		
	public void ShowLeaderBoard (bool show) {
		leaderBoardPanel.SetActive(show);
	}

	public void ShowAboutScreen (bool show) {
		AboutScreen.SetActive(show);
	}

	public void ShowHelpScreen (bool show) {
		HelpScreen.SetActive(show);
	}

	public void ShowConfirmReplayTutorial (bool show) {
		confirmReplayTutorial.SetActive(show);
	}

	public void ShowConfirmExitGame (bool show) {
		confirmExitGame.SetActive(show);
	}

	public void ReplayTutorial () {
		StorageManager.s_doneTutorial = 0;
		StorageManager.instance.SaveTutorialData (0);
		ShowConfirmReplayTutorial (false);
	}

	public void SoundOffButton () {
		s_isMuteSound = true;
		audioSource.mute = s_isMuteSound;
		buttonSoundOn.SetActive (!s_isMuteSound);
		buttonSoundOff.SetActive (s_isMuteSound);
	}

	public void SoundButton () {
		if (s_isMuteSound) {
			s_isMuteSound = false;
			audioSource.mute = false;
		} else {
			s_isMuteSound = true;
			audioSource.mute = true;
		}
		buttonSoundOn.SetActive (!s_isMuteSound);
		buttonSoundOff.SetActive (s_isMuteSound);
	}

	public void InitSound() {
		if (s_isMuteSound) {
			audioSource.mute = true;
		} else {
			audioSource.mute = false;
		}
		buttonSoundOn.SetActive (!s_isMuteSound);
		buttonSoundOff.SetActive (s_isMuteSound);
	}

	public void QuitGame() {
		Application.Quit ();
	}
}
