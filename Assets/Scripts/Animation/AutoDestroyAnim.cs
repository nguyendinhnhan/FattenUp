﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyAnim : MonoBehaviour {
	
	float delay = 0.5f;
	public static AutoDestroyAnim instance;

	void Awake () {
		getInstance ();
	}

	void getInstance () {
		if (instance == null) {
			instance = this;
		}
	}

	public void BeginAnimNumber () {
		Debug.Log("begin anim number");
		gameObject.GetComponent<Animator> ().enabled = true;
		Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
	}
}
