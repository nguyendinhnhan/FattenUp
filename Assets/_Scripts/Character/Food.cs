using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

	private int m_speed;
	private Rigidbody2D m_rigidbody2D;
	public static Food instance;

	void Awake() {
		getInstance ();
		m_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void getInstance () {
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		m_speed = GameManager.s_speed;	
	}
		
	void FixedUpdate() {
		if (GameManager.s_isGameOver) {
			Debug.Log ("Destroy Food!!!");
			Destroy (gameObject);
		}
		
		m_rigidbody2D.velocity = new Vector2(0, -m_speed);
	}

	public void Destroy_Food () {
		Debug.Log ("Destroy Food 111111 !!!");
		Destroy (gameObject);
	}
}
