using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageManager : MonoBehaviour {

	public GameObject playerPanel;
	[SerializeField]
	private GameObject popUpPanel;

	// Class Varibles
	public static ListPlayer s_listPlayer;
	public static int s_doneTutorial;

	public const string PlayerPreferencesKey = "player";
	public const string TutorialPreferencesKey = "tutorial";

	public const int numPlayer = 5;
	public int StorageManagerInited;

	public static StorageManager instance;

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
		
	}
	
	// Update is called once per frame
	void Update () {
		if (StorageManagerInited < 1) {
			StorageManagerInited++;
			InitPlayer ();
		}
	}

	public void InitPlayer () {
		
		s_doneTutorial = ReadTutorialData();
		Debug.Log ("s_doneTutorial: " + s_doneTutorial);

		//s_listPlayer = ReadPlayerData ();
		ApplyDataToGame ();
		//initPlayerPanelUI ();
	}

/// <summary>
/// Reads the tutorial data.
/// Save the tutorial data.
/// </summary>
	public int ReadTutorialData () {
		int doneTut = 0;
		if (PlayerPrefs.HasKey (TutorialPreferencesKey)) {
			doneTut = PlayerPrefs.GetInt (TutorialPreferencesKey);
		} else {
			SaveTutorialData (doneTut);
		}
		return doneTut;
	}
		
	public void SaveTutorialData(int doneTut){
		PlayerPrefs.SetInt (TutorialPreferencesKey, doneTut);
	}

/// <summary>
/// Reads the player data.
/// Get default the player data.
/// Save the player data.
/// </summary>
	public ListPlayer ReadPlayerData () {
		ListPlayer listPlayer = null;
		if (PlayerPrefs.HasKey (PlayerPreferencesKey)) {
			string json = PlayerPrefs.GetString (PlayerPreferencesKey);
			listPlayer = JsonUtility.FromJson<ListPlayer> (json);
		} else {
			listPlayer = new ListPlayer ();
			listPlayer.players = GetDefaultDataForPlayers ();
			SavePlayerData (listPlayer);
		}

		return listPlayer;
	}

	public List<Player> GetDefaultDataForPlayers() {
		List<Player> listPlayer = new List<Player> ();
		Player player;
		for (int i = 0; i < numPlayer; i++) {
			player = new Player();
			player.id = i + 1;
			player.name = "Fatten Up";
			player.score = 0;
			listPlayer.Add (player);
		}
			
		return listPlayer;
	}

	public static void SavePlayerData(ListPlayer listPlayer){
		string json = JsonUtility.ToJson (listPlayer);
		PlayerPrefs.SetString (PlayerPreferencesKey, json);
	}

	public int checkScoreOnLeaderBoard(int score) {
		for (int i = 0; i < s_listPlayer.players.Count; i++) {
			if (score > s_listPlayer.players [i].score) {
				return (i + 1);
			}
		}
		return -1;
	}

	public void addPlayerIntoLeaderBoard(string name, int score) {
		ListPlayer listPlayer = StorageManager.s_listPlayer;
		int position = checkScoreOnLeaderBoard (GameManager.s_score);

		for (int i = numPlayer-1; i >= position; i--) {
			listPlayer.players [i].name = listPlayer.players [i - 1].name;
			listPlayer.players [i].score = listPlayer.players [i - 1].score;
		}

		listPlayer.players [position - 1].name = name;
		listPlayer.players [position - 1].score = score;

		SavePlayerData (listPlayer);
	}

	public void ApplyDataToGame(){
		s_listPlayer = ReadPlayerData ();

		float posY_Anchor = 0.75f;
		float high_Anchor = 0.14f;

		for (int i = 0; i < s_listPlayer.players.Count; i++) {
			// Create object player and set position, set parrent Object
			GameObject gameObject = Instantiate (playerPanel);
			gameObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (1, (posY_Anchor - i * high_Anchor));
			gameObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, (posY_Anchor - (i + 1) * high_Anchor));
			gameObject.transform.SetParent (popUpPanel.transform, false);

			if (s_listPlayer.players [i].score > 0) {
				gameObject.SetActive (true);

				// Get Object nameText and set text
				GameObject nameText = gameObject.transform.GetChild (0).gameObject;
				Text txtName = nameText.GetComponent<Text> ();
				txtName.text = s_listPlayer.players [i].name;

				// Get Object scoreText and set text
				GameObject scoreText = gameObject.transform.GetChild (1).gameObject;
				Text txtScore = scoreText.GetComponent<Text> ();
				txtScore.text = "" + s_listPlayer.players [i].score;
			} else {
				gameObject.SetActive (false);
			}
		}

	}

	// Save Data Into Storage
	// Read Data From Storage
	// Get Default Data
	// Initialize Levels
	// ApplyDataSgle Level

	public void debugListPlayer(){
		for (int i = 0; i < s_listPlayer.players.Count; i++) {
			Debug.Log ("i: " + s_listPlayer.players[i].score);
		}
	}

}
