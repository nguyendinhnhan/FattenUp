using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

	private int m_speed;
	private Rigidbody2D m_rigidbody2D;

	void Awake() {
		m_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		m_speed = GameManager.s_speed;	
	}
	
	// Update is called once per frame
	void Update () {

	}
		
	void FixedUpdate() {
		if (GameManager.s_isGameOver) {
			Debug.Log ("Destroy Food!!!");
			Destroy (gameObject);
		}
		
		m_rigidbody2D.velocity = new Vector2(0, -m_speed);
	}
}
