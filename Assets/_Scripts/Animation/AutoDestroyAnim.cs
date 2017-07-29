using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyAnim : MonoBehaviour {
	
	//float delay = 0.5f;
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
		gameObject.GetComponent<Animator> ().enabled = true;
		//Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
		StartCoroutine (EndAnimNumber());
	}

	public IEnumerator EndAnimNumber () {
		yield return new WaitForSeconds (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
		gameObject.GetComponent<Animator> ().enabled = false;

		Vector2 pos = this.transform.position;
		pos.y = 7f;
		this.transform.position = pos;
	}
}