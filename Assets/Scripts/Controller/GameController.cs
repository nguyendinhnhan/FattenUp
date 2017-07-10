using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	[SerializeField]
	private GameObject pausePanel;
	[SerializeField]
	private GameObject gameOverPanel;
	[SerializeField]
	private GameObject inputNamePanel;

	[SerializeField]
	private GameObject buttonPause;
	[SerializeField]
	private GameObject buttonResume;

	[SerializeField]
	private InputField NamePlayerInputField;

	[SerializeField]
	private GameObject buttonSound;

	AudioSource audioSource;
	public static GameController instance;

	void Awake () {
		getInstance ();
		audioSource = GetComponent<AudioSource> ();
	}

	void getInstance () {
		if (instance == null) {
			instance = this;
		}
	}

	void Start(){
		InitSound ();
	}

	public void InputNameButton(){
		StorageManager.instance.addPlayerIntoLeaderBoard (NamePlayerInputField.text, GameManager.s_score);
		//Debug.Log("nhan: " + NamePlayerInputField.text);
		//MainMenuButton ();
		RestartButton();
	}

	public void PauseButton () {
		pausePanel.SetActive (true);
		buttonResume.SetActive (true);
		buttonPause.SetActive (false);
		Time.timeScale = 0f;
	}

	public void ResumeButton () {
		pausePanel.SetActive (false);
		buttonResume.SetActive (false);
		buttonPause.SetActive (true);
		Time.timeScale = 1f;
	}

	public void InputName () {
		inputNamePanel.SetActive (true);
		Time.timeScale = 0f;
	}

	public void GameOver () {
		gameOverPanel.SetActive (true);
		Time.timeScale = 0f;
	}

	public void MainMenuButton () {
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
		Time.timeScale = 1f;
	}

	public void RestartButton () {
		SceneManager.LoadScene ("GamePlay", LoadSceneMode.Single);
		Time.timeScale = 1f;
	}

	public void InitSound(){
		GameObject gameObject = buttonSound.transform.GetChild (0).gameObject;
		if (MainMenuController.s_isMuteSound) {
			audioSource.mute = true;
			gameObject.GetComponent<Text> ().text = "Sound: Off";
		} else {
			audioSource.mute = false;
			gameObject.GetComponent<Text> ().text = "Sound: On";
		}
	}

	public void ButtonSound(){
		Debug.Log ("test: " + MainMenuController.s_isMuteSound);
		GameObject gameObject = buttonSound.transform.GetChild (0).gameObject;
		if (MainMenuController.s_isMuteSound) {
			MainMenuController.s_isMuteSound = false;
			audioSource.mute = false;
			gameObject.GetComponent<Text> ().text = "Sound: On";
		} else {
			MainMenuController.s_isMuteSound = true;
			audioSource.mute = true;
			gameObject.GetComponent<Text> ().text = "Sound: Off";
		}
	}
}
