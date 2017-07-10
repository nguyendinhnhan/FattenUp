using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Animal : MonoBehaviour {

	public AudioClip Sound;

	public Sprite pig;
	public Sprite dog;
	public Sprite monkey;

	public static int s_indexAnimal;

	private SpriteRenderer m_spriteRenderer;


	// Use when get a component object physic
	void Awake() {
		m_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void OnMouseDown () {
		if (Tutorial.s_allowClickAnimal){
			if (m_spriteRenderer.sprite.Equals (pig)) {
				m_spriteRenderer.sprite = dog;
				if (Tutorial.instance.isDog) {
					Tutorial.s_allowClickAnimal = false;
					Tutorial.instance.ActiveFood(IFattenUpDefines.BONE);
					Tutorial.instance.ActiveAnimPoint (false);
				}
			} else if (m_spriteRenderer.sprite.Equals (dog)) {
				m_spriteRenderer.sprite = monkey;
				if (Tutorial.instance.isMonkey) {
					Tutorial.s_allowClickAnimal = false;
					Tutorial.instance.ActiveFood(IFattenUpDefines.BANANA);
					Tutorial.instance.ActiveAnimPoint (false);
				}
			} else {
				m_spriteRenderer.sprite = pig;
				if (Tutorial.instance.isPig) {
					Tutorial.s_allowClickAnimal = false;
					Tutorial.instance.ActiveFood(IFattenUpDefines.SALLAD);
					Tutorial.instance.ActiveAnimPoint (false);
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!MainMenuController.s_isMuteSound) {
			GetComponent<AudioSource> ().PlayOneShot (Sound);
		}

		// dog	->  pig		-> 	monkey
		// bone	-> 	sallad	-> 	banana
		if (other.CompareTag ("bone") && m_spriteRenderer.sprite.Equals (dog)) {
			Tutorial.instance.ActiveFood(IFattenUpDefines.SALLAD);
		}

		if (other.CompareTag ("sallad") && m_spriteRenderer.sprite.Equals (pig)) {
			Tutorial.instance.ActiveFood(IFattenUpDefines.BANANA);
		}

		if (other.CompareTag ("banana") && m_spriteRenderer.sprite.Equals (monkey)) {
			StorageManager.s_doneTutorial = 1;
			StorageManager.instance.SaveTutorialData (1);
			Tutorial.instance.destroyTutorial ();
		}
			
		Destroy(other.gameObject);
	}
		
}
