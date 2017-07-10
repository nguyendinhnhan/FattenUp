using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Food : MonoBehaviour {

	public int m_speed;
	private Rigidbody2D m_rigidbody2D;

	void Awake() {
		m_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		m_rigidbody2D.velocity = new Vector2(0, -m_speed);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("triggerFoodTutorial")) {
			Debug.Log ("test trigger");
			m_speed = 0;
			Tutorial.instance.ActiveAnimPoint (true);
			Tutorial.s_allowClickAnimal = true;
		}
	}

}
