using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Facebook.Unity;

public class GameController : MonoBehaviour
{
	public GameObject pausePanel;
	public GameObject gameOverPanel;
	public GameObject adsPanel;
	public GameObject inputNamePanel;
	public InputField NamePlayerInputField;
	public GameObject buttonPause;
	public GameObject buttonResume;
	public GameObject buttonSound;
	public Button videoButton;

	AudioSource audioSource;
	public static GameController instance;

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

	void Start ()
	{
		InitSound ();
		videoButton.onClick.AddListener(AdManager.instance.ShowRewardedFuelVideoAd);
	}

	public void InitSound ()
	{
		GameObject gameObject = buttonSound.transform.GetChild (0).gameObject;
		if (MainMenuController.s_isMuteSound) {
			audioSource.mute = true;
			gameObject.GetComponent<Text> ().text = "Sound: Off";
		} else {
			audioSource.mute = false;
			gameObject.GetComponent<Text> ().text = "Sound: On";
		}
	}
		
	public void GameOver ()
	{
		gameOverPanel.SetActive (true);
		Time.timeScale = 0f;
	}

/**
 * Button in Game Play
 *
 **/
	public void PauseButton ()
	{
		pausePanel.SetActive (true);
		buttonResume.SetActive (true);
		buttonPause.SetActive (false);
		Time.timeScale = 0f;
	}
/*****End Button in Game Play****/

/**
 * Button in Game Pause
 *
 **/
	public void ResumeButton ()
	{
		pausePanel.SetActive (false);
		buttonResume.SetActive (false);
		buttonPause.SetActive (true);
		Time.timeScale = 1f;
	}

	public void ButtonSound ()
	{
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

	public void MainMenuButton ()
	{
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
		Time.timeScale = 1f;
	}
/*****End Button in Game Pause****/

/**
* Button in Game Over
*
**/
	public void InputName ()
	{
		inputNamePanel.SetActive (true);
		Time.timeScale = 0f;
	}

	public void InputNameButton ()
	{
		string name = (NamePlayerInputField.text != "") ? NamePlayerInputField.text : IFattenUpDefines.NAME_DEFAULT;
		StorageManager.instance.addPlayerIntoLeaderBoard (name, GameManager.s_score);
		RestartButton ();
	}

	public void RestartButton ()
	{
		SceneManager.LoadScene ("GamePlay", LoadSceneMode.Single);
		Time.timeScale = 1f;
	}

	public void Share ()
	{
		FB.ShareLink (
			new System.Uri ("http://neonindo.com"),
			"This game is awesome!",
			"A description of the game",
			new System.Uri ("http://neonindo.com/wp-content/themes/sauron/images/logo.png"),
			callback: ShareCallback
		);
	}

	private void ShareCallback (IShareResult result)
	{
		if (result.Cancelled || !System.String.IsNullOrEmpty (result.Error)) {
			Debug.Log ("ShareLink Error: " + result.Error);
		} else if (!System.String.IsNullOrEmpty (result.PostId)) {
			// Print post identifier of the shared content
			Debug.Log (result.PostId);
		} else {
			// Share succeeded without postID
			Debug.Log ("ShareLink success!");
		}
	}
/*****End Button in Game Over****/

/**
 * Button in Ads Panel
 *
 **/
	public void ShowAdsPanel (bool show) {
		adsPanel.SetActive (show);
		if (show) {
			Time.timeScale = 0f;
		} else {
			//Time.timeScale = 1f;
		}
	}

	public void ButtonCloseAds () {
		adsPanel.SetActive (false);
		Time.timeScale = 1f;
		GameManager.instance.ShowPlayAgain ();
	}
/*****End Button in Ads Panel****/
}