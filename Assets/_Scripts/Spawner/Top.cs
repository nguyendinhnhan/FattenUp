using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour {

	[SerializeField]
	private GameObject banana;
	[SerializeField]
	private GameObject bone;
	[SerializeField]
	private GameObject sallad;

	private bool initFood = true;
	//private BoxCollider2D m_boxCollider2D;

	void Awake() {
		//m_boxCollider2D = GetComponent<BoxCollider2D>();
	}

	// Use this for initialization
	void Start () {
		
	}

	void Update () {
		if (initFood && StorageManager.s_doneTutorial == 1) {
			StartCoroutine(SpawnerFood());
			initFood = false;
		}
	}

	IEnumerator SpawnerFood()
	{
		yield return new WaitForSeconds(3f);

		if (GameManager.s_numCols_Current == 1) {
			FoodFor_1COL ();
		} else if (GameManager.s_numCols_Current == 2) {
			FoodFor_2COL ();
		} else {
			FoodFor_3COL ();
		}

		StartCoroutine(SpawnerFood());
	}

	public void FoodFor_1COL () {
		Vector2 position = transform.position;
		int m_type = Random.Range (0, 3);

		switch (m_type) {
		case IFattenUpDefines.BANANA:		// 0
			Instantiate (banana, position, Quaternion.identity);
			break;
		case IFattenUpDefines.SALLAD:		// 1
			Instantiate (bone, position, Quaternion.identity);
			break;
		case IFattenUpDefines.BONE:			// 2
			Instantiate (sallad, position, Quaternion.identity);
			break;
		}
	}

	public void FoodFor_2COL () {
		Vector2 position1 = transform.position;
		Vector2 position2 = transform.position;

		position1.x = position1.x - IFattenUpDefines.POS_X_COL2;
		position2.x = position2.x + IFattenUpDefines.POS_X_COL2;

		int m_type = Random.Range (0, 3);

		switch (m_type) {
		case IFattenUpDefines.BANANA:
			Instantiate (banana, position1, Quaternion.identity);
			break;
		case IFattenUpDefines.SALLAD:
			Instantiate (bone, position1, Quaternion.identity);
			break;
		case IFattenUpDefines.BONE:
			Instantiate (sallad, position1, Quaternion.identity);
			break;
		}

		m_type = Random.Range (0, 3);

		switch (m_type) {
		case IFattenUpDefines.BANANA:
			Instantiate (banana, position2, Quaternion.identity);
			break;
		case IFattenUpDefines.SALLAD:
			Instantiate (bone, position2, Quaternion.identity);
			break;
		case IFattenUpDefines.BONE:
			Instantiate (sallad, position2, Quaternion.identity);
			break;
		}
	}

	public void FoodFor_3COL () {
		Vector2 position1 = transform.position;
		Vector2 position2 = transform.position;
		Vector2 position3 = transform.position;

		position1.x = position1.x - IFattenUpDefines.POS_X_COL3;
		position2.x = 0;
		position3.x = position3.x + IFattenUpDefines.POS_X_COL3;

		int m_type = Random.Range (0, 3);

		switch (m_type) {
		case IFattenUpDefines.BANANA:
			Instantiate (banana, position1, Quaternion.identity);
			break;
		case IFattenUpDefines.SALLAD:
			Instantiate (bone, position1, Quaternion.identity);
			break;
		case IFattenUpDefines.BONE:
			Instantiate (sallad, position1, Quaternion.identity);
			break;
		}

		m_type = Random.Range (0, 3);

		switch (m_type) {
		case IFattenUpDefines.BANANA:
			Instantiate (banana, position2, Quaternion.identity);
			break;
		case IFattenUpDefines.SALLAD:
			Instantiate (bone, position2, Quaternion.identity);
			break;
		case IFattenUpDefines.BONE:
			Instantiate (sallad, position2, Quaternion.identity);
			break;
		}

		m_type = Random.Range (0, 3);

		switch (m_type) {
		case IFattenUpDefines.BANANA:
			Instantiate (banana, position3, Quaternion.identity);
			break;
		case IFattenUpDefines.SALLAD:
			Instantiate (bone, position3, Quaternion.identity);
			break;
		case IFattenUpDefines.BONE:
			Instantiate (sallad, position3, Quaternion.identity);
			break;
		}
	}
}
