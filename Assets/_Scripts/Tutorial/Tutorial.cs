using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	public GameObject AnimPoint;
	public GameObject AnimDialog;
	public GameObject Bone;
	public GameObject Sallad;
	public GameObject Banana;

	public bool isDog = false;
	public bool isPig = false;
	public bool isMonkey = false;

	public static bool s_allowClickAnimal = false;
	public static bool s_isFoodForPet = false;
	public static Tutorial instance;

	void Awake () {
		getInstance ();
	}

	void getInstance () {
		if (instance == null) {
			instance = this;
		}
	}

	void Start () {
		if (StorageManager.s_doneTutorial == 0) {
			ActiveFood (IFattenUpDefines.BONE);
		} else if (StorageManager.s_doneTutorial == 1) {
			destroyTutorial ();
		}
	}

	public void destroyTutorial () {
		Destroy (gameObject);
		Destroy (AnimDialog);
		AutoDestroyAnim.instance.BeginAnimNumber ();
		GameManager.instance.ActiveAnimal1 ();
	}

	public void ActiveAnimPoint(bool isPlay){
		AnimPoint.GetComponent<Animator> ().enabled = isPlay;
		AnimDialog.GetComponent<Animator> ().enabled = isPlay;

		string txt = "";
		if (isDog) {
			txt = "Tap to choose Pet \n Dog eat Bone!!!";
		} else if (isPig) {
			txt = "Tap to choose Pet \n Pig eat Sallad!!!";
		} else if (isMonkey) {
			txt = "Tap to choose Pet \n Monkey eat Banana!!!";
		}

		GameObject txtDialog = AnimDialog.transform.GetChild (1).gameObject;
		txtDialog.GetComponent<Text> ().text = txt;

		Vector2 pos = AnimPoint.transform.position;
		pos.y = -5.5f;
		AnimPoint.transform.position = pos;

		Vector2 posDialog = AnimDialog.transform.position;
		posDialog.y = -455f;
		AnimDialog.transform.position = posDialog;
	}

	public void ActiveFood(int indexFood) {
		switch (indexFood) {
		case IFattenUpDefines.BONE:
			Bone.GetComponent<Tutorial_Food> ().m_speed = 3;
			isDog = true;
			isPig = false;
			isMonkey = false;
			break;
		case IFattenUpDefines.SALLAD:
			Sallad.GetComponent<Tutorial_Food> ().m_speed = 3;
			isPig = true;
			isDog = false;
			isMonkey = false;
			break;
		case IFattenUpDefines.BANANA:
			Banana.GetComponent<Tutorial_Food> ().m_speed = 3;
			isMonkey = true;
			isDog = false;
			isPig = false;
			break;
		}
	}

}
