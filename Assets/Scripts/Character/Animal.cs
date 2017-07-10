using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour {

	public AudioClip Sound;
	public static bool s_isGameOver = false;
	public Sprite pig;
	public Sprite dog;
	public Sprite monkey;

	private SpriteRenderer m_spriteRenderer;
//	private Rigidbody2D m_rigidbody2D;

	// Use when get a component object physic
	void Awake() {
		m_spriteRenderer = GetComponent<SpriteRenderer>();
//		m_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		s_isGameOver = false;
	}

	// Update is called once per frame
	void Update () {
//		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
//			if (m_spriteRenderer.sprite.Equals (pig))
//				m_spriteRenderer.sprite = dog;
//			else if (m_spriteRenderer.sprite.Equals (dog))
//				m_spriteRenderer.sprite = monkey;
//			else
//				m_spriteRenderer.sprite = pig;
//		}
	}
		
	// Use when update one component object physic
	void FixedUpdate(){
	}

	void OnMouseDown() {
		if (m_spriteRenderer.sprite.Equals (pig))
			m_spriteRenderer.sprite = dog;
		else if (m_spriteRenderer.sprite.Equals (dog))
			m_spriteRenderer.sprite = monkey;
		else
			m_spriteRenderer.sprite = pig;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if ((other.CompareTag ("sallad") && m_spriteRenderer.sprite.Equals (pig))
		    || (other.CompareTag ("bone") && m_spriteRenderer.sprite.Equals (dog))
		    || (other.CompareTag ("banana") && m_spriteRenderer.sprite.Equals (monkey))) {
			if (!MainMenuController.s_isMuteSound) {
				GetComponent<AudioSource> ().PlayOneShot (Sound);
			}

			GameManager.s_score += 1;
			GameManager.instance.UpdateGUIGame ();
		} else {
			//Game Over
			s_isGameOver = true;
			int position = StorageManager.instance.checkScoreOnLeaderBoard (GameManager.s_score);
			if (position > -1) {
				GameController.instance.InputName ();
			} else {
				GameController.instance.GameOver ();
			}
		}
			
		Destroy(other.gameObject);

	}
		
}
