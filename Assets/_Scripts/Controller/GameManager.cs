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

public class GameManager : MonoBehaviour {

	// Sound to be played when enter game
	//public GameObject mainMenuSounds;

//	private GameState currentState = GameState.NotStarted;
	public static bool s_isGameOver = false;
	public Text textScore;
	public static int s_score;
	public static int s_speed;
	public static int s_numCols_Current;
	public static int s_countAds;

	public GameObject animal_1;
	public GameObject animal_2;
	public GameObject animal_3;

	public static GameManager instance;

	void Awake () {
		getInstance ();
	}

	void getInstance () {
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		s_countAds = 0;
		s_isGameOver = false;
		s_score = IDefine.SCORE_START;			// 0
		s_speed = IDefine.SPEED_START;			// 3
		s_numCols_Current = IDefine.COL_START;	// 1
	}

	// Update is called once per frame
	void Update () {

	}

	public void UpdateGUIGame () {
		// Update Text Score
		textScore.text = "Score: " + s_score;

		// Update BG if true
		if (s_score == IDefine.SCORE_TO_BG2COL && s_numCols_Current == 1) {
			Debug.Log ("Change_2COLS 2");
			Change_2COLS ();
		} else if(s_score == IDefine.SCORE_TO_BG3COL && s_numCols_Current == 2) {
			Debug.Log ("Change_3COLS 3");
			Change_3COLS ();
		}

		// Raise speed Random
		if ((s_numCols_Current == 1 && s_score % 6 == 0)
			|| (s_numCols_Current == 2 && s_score % 6 == 0)
			|| (s_numCols_Current == 3 && s_score % 12 == 0)) {
			s_speed++;
		}
	}

	public void ActiveAnimal1(){
		animal_1.SetActive (true);
	}

	public void Change_2COLS () {
		
		s_numCols_Current = 2;
		BGScaler.instance.ChangeBG (2);

		s_speed--;
		Vector3 posAnimal_1 = animal_1.transform.position;
		posAnimal_1.x = -IDefine.POS_X_COL2;
		animal_1.transform.position = posAnimal_1;

		animal_2.SetActive (true);
		Vector3 posAnimal_2 = animal_2.transform.position;
		posAnimal_2.x = IDefine.POS_X_COL2;
		animal_2.transform.position = posAnimal_2;
	}

	public void Change_3COLS () {
		
		s_numCols_Current = 3;
		//Food.instance.Destroy_Food ();
		BGScaler.instance.ChangeBG (3);

		s_speed--;
		Vector3 posAnimal_1 = animal_1.transform.position;
		posAnimal_1.x = -IDefine.POS_X_COL3;
		animal_1.transform.position = posAnimal_1;

		Vector3 posAnimal_2 = animal_2.transform.position;
		posAnimal_2.x = 0;
		animal_2.transform.position = posAnimal_2;

		animal_3.SetActive (true);
		Vector3 posAnimal_3 = animal_3.transform.position;
		posAnimal_3.x = IDefine.POS_X_COL3;
		animal_3.transform.position = posAnimal_3;
	}

	public void GameOver () {
		if (!s_isGameOver) {
			Debug.Log ("Game Over!!!!");
			s_isGameOver = true;
			if (s_countAds < 1) {
				s_countAds++;
				GameController.instance.ShowAdsPanel (true);
			} else {
				ShowPlayAgain ();
			}
		}
	}

	public void ShowPlayAgain () {
		s_countAds = 0;
	#if DEBUG
		GameController.instance.GameOver ();
	#else
		int position = StorageManager.instance.checkScoreOnLeaderBoard (s_score);
		if (position > -1) {
			GameController.instance.InputName ();
		} else {
			GameController.instance.GameOver ();
		}
	#endif
	}

}
