using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//List all the possible gamestates
public enum GameState
{
	NotStarted,
	Playing,
	Completed,
	Failed
}

//Require an audio source for the object
//[RequireComponent(typeof(AudioSource))]

public class GameManager : MonoBehaviour
{

	// Sound to be played when enter game
	//public GameObject mainMenuSounds;

	//	private GameState currentState = GameState.NotStarted;
	public static bool s_isGameOver = false;
	public Text textScore;
	public static int s_score;
	public static int s_speed;
	public static int s_numCol;
	public static int s_countAds;

	public static bool s_allowFood;

	public GameObject character1;
	public GameObject character2;

	public static GameManager instance;
	public static GameObject[] FoodArr = new GameObject[2];

	void Awake ()
	{
		getInstance ();
	}

	void getInstance ()
	{
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start ()
	{
		s_countAds = 0;
		s_isGameOver = false;
		s_score = IDefine.SCORE_START;			// 0
		s_speed = IDefine.SPEED_START;			// 15
		s_numCol = IDefine.COL_START;			// 1
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void UpdateGUIGame ()
	{
		// Update Text Score
		textScore.text = "Score: " + s_score;

		// Update BG if true
		if (s_score == IDefine.SCORE_TO_BG2COL && s_numCol == 1) {
			Debug.Log ("=======Change_2COLS 2=======");
			Change_2COLS ();
		}

		// Raise speed Random
		if (s_numCol == 1 && s_score % 2 == 0) {
			s_speed += 3;
		} else if (s_numCol == 2 && s_score % 4 == 0) {
			if (s_speed < 33) {
				s_speed += 2;
			}
//			else if (s_speed < 35) {
//				s_speed++;
//			}
		}
	}

	public void ActiveCharacter1 ()
	{
		character1.SetActive (true);
	}

	public void Change_2COLS ()
	{
		s_numCol = 2;
		BGScaler.instance.ChangeBG (2);
		Debug.Log ("===Change_2COLS=====CreateFood=====2222=");
		Top.instance.CreateFood (2);
		s_speed = 25;

		Vector3 posCharacter1 = character1.transform.position;
		posCharacter1.x = -IDefine.POS_X_COL2;
		character1.transform.position = posCharacter1;

		character2.SetActive (true);
		Vector3 posCharacter2 = character2.transform.position;
		posCharacter2.x = IDefine.POS_X_COL2;
		character2.transform.position = posCharacter2;
	}

	public void GameOver ()
	{
		if (!s_isGameOver) {
			DestroyAllFoods ();
			s_isGameOver = true;
			if (s_countAds < 1) {
				s_countAds++;
				GameController.instance.ShowAdsPanel (true);
			} else {
				ShowPlayAgain ();
			}
		}
	}

	public void ShowPlayAgain ()
	{
		Debug.Log ("Show play again");
		s_countAds = 0;
		int position = StorageManager.instance.checkScoreOnLeaderBoard (s_score);
		if (position > -1) {
			GameController.instance.InputName ();
		} else {
			GameController.instance.GameOver ();
		}
	}

	public void DestroyAllFoods ()
	{
		Debug.Log ("DestroyAllFoods!!!!!");
		DestroyAllFoodWithTag ("banana");
		DestroyAllFoodWithTag ("bone");
		DestroyAllFoodWithTag ("sallad");
	}

	public void DestroyAllFoodWithTag (string tag)
	{
		GameObject[] foods = GameObject.FindGameObjectsWithTag (tag);
		foreach (GameObject food in foods) {
			Destroy (food);
		}
	}

}
