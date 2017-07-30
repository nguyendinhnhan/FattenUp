using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Animal : MonoBehaviour {

	public AudioClip Sound;
	public Sprite pig;
	public Sprite dog;
	public Sprite monkey;

	private Image m_image;

	// Use when get a component object physic
	void Awake() {
		m_image = GetComponent<Image> ();
	}

	public void ChangeSprite () {
		if (m_image.sprite.Equals (pig)) {
			m_image.sprite = dog;
		} else if (m_image.sprite.Equals (dog)) {
			m_image.sprite = monkey;
		} else {
			m_image.sprite = pig;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if ((other.CompareTag ("sallad") && m_image.sprite.Equals (pig))
			|| (other.CompareTag ("bone") && m_image.sprite.Equals (dog))
			|| (other.CompareTag ("banana") && m_image.sprite.Equals (monkey))) {
			if (!MainMenuController.s_isMuteSound) {
				GetComponent<AudioSource> ().PlayOneShot (Sound);
			}

			GameManager.s_score += 1;
			GameManager.instance.UpdateGUIGame ();
		} else {
			//Game Over
			GameManager.instance.GameOver();
		}
			
		Destroy(other.gameObject);

	}
		
}
