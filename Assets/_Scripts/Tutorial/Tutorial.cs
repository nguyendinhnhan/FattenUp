﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	public GameObject AnimPoint;
	public GameObject AnimSwipe;
	public GameObject AnimDialog;
	public GameObject Bone;
	public GameObject Sallad;
	public GameObject Banana;
	public GameObject SwipeTouch;

	public bool isDog = false;
	public bool isPig = false;
	public bool isMonkey = false;

	public static bool s_allowClickAnimal = false;
	public static bool s_allowSwipeAnimal = false;
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
		Debug.Log ("Tutorial!!!!" + StorageManager.s_doneTutorial);
		if (StorageManager.s_doneTutorial == 0) {
			ActiveFood (IDefine.BONE);
		} else if (StorageManager.s_doneTutorial == 1) {
			destroyTutorial ();
		}
	}

	public void destroyTutorial () {
		Debug.Log ("=====nhan=======destroy tur==========");
		Destroy (SwipeTouch);
		Destroy (gameObject);
		Destroy (AnimDialog);
		AutoDestroyAnim.instance.BeginAnimNumber ();
		GameManager.instance.ActiveCharacter1 ();
	}

	public void ActiveAnimPoint(bool isPlay){
		AnimPoint.GetComponent<Animator> ().enabled = isPlay;
		AnimDialog.GetComponent<Animator> ().enabled = isPlay;

		string txt = "";
		if (isDog) {
			txt = "Tap to choose Pet \nDog eat Bone !";
		} else if (isPig) {
			txt = "Tap to choose Pet \nPig eat Salad !";
		} else if (isMonkey) {
			txt = "Tap to choose Pet \nMonkey eat Banana !";
		}

		GameObject txtDialog = AnimDialog.transform.GetChild (1).gameObject;
		txtDialog.GetComponent<Text> ().text = txt;

		if (!isPlay) {
			Vector2 pos = AnimPoint.transform.position;
			pos.y = -5.5f;
			AnimPoint.transform.position = pos;

			Vector2 posDialog = AnimDialog.transform.position;
			posDialog.y = -6f;
			AnimDialog.transform.position = posDialog;
		}
	}

	public void ActiveAnimSwipe(bool isPlay) {
		AnimSwipe.GetComponent<Animator> ().enabled = isPlay;
		AnimDialog.GetComponent<Animator> ().enabled = isPlay;

		string txt = "Swipe your Pet \nto eat food faster !";
		GameObject txtDialog = AnimDialog.transform.GetChild (1).gameObject;
		txtDialog.GetComponent<Text> ().text = txt;

		if (!isPlay) {
			Vector2 pos = AnimSwipe.transform.position;
			pos.x = 2f;
			pos.y = -5.5f;
			AnimSwipe.transform.position = pos;
		}
	}

	public void ActiveFood(int indexFood) {
		switch (indexFood) {
		case IDefine.BONE:
			Bone.GetComponent<Tutorial_Food> ().m_speed = 3;
			isDog = true;
			isPig = false;
			isMonkey = false;
			break;
		case IDefine.SALLAD:
			Sallad.GetComponent<Tutorial_Food> ().m_speed = 3;
			isPig = true;
			isDog = false;
			isMonkey = false;
			break;
		case IDefine.BANANA:
			Banana.GetComponent<Tutorial_Food> ().m_speed = 3;
			isMonkey = true;
			isDog = false;
			isPig = false;
			break;
		}
	}

}
