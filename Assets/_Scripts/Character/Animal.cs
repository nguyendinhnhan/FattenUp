using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Animal : MonoBehaviour {

	public Sprite pig;
	public Sprite dog;
	public Sprite monkey;

	private Image m_image;

	void Awake () {
		m_image = GetComponent<Image> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if ((other.CompareTag ("sallad") && m_image.sprite.Equals (pig))
			|| (other.CompareTag ("bone") && m_image.sprite.Equals (dog))
			|| (other.CompareTag ("banana") && m_image.sprite.Equals (monkey))) {
			SwipeTouchNew.instance.PlayMusic();

			GameManager.s_score += 1;
			GameManager.instance.UpdateGUIGame ();

			SwipeTouchNew.instance.ActiveAnimAnimal(gameObject, false);
			if (gameObject.CompareTag ("Animal1")) {
				Debug.Log ("===Animal=====CreateFood=====1111=");
				Top.instance.CreateFood (1); // create food for col 1
			} else if (gameObject.CompareTag ("Animal2")) {
				Debug.Log ("====Animal====CreateFood=====2222=");
				Top.instance.CreateFood (2); // create food for col 2
			}

			Destroy(other.gameObject);
		} else if (other.CompareTag ("Animal1") || other.CompareTag ("Animal2") || other.CompareTag ("Top")) {
		} else {
			GameManager.instance.GameOver(); //Game Over
		}
	}

}
