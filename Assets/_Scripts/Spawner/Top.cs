using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour {

	public GameObject banana;
	public GameObject bone;
	public GameObject sallad;

	private bool initFood = true;

	void Update () {
			if (initFood
			#if !DEBUG
				&& StorageManager.s_doneTutorial == 1
			#endif
			) {
				StartCoroutine(SpawnerFood());
				initFood = false;
			}

	}

	IEnumerator SpawnerFood()
	{
		yield return new WaitForSeconds(4f);

		if (GameManager.s_numCols_Current == 1) {
			FoodFor_1COL ();
		} else if (GameManager.s_numCols_Current == 2) {
			FoodFor_2COL ();
		} else if (GameManager.s_numCols_Current == 3) {
			FoodFor_3COL ();
		}

		StartCoroutine(SpawnerFood());
	}

	public void FoodFor_1COL () {
		Vector2 position = transform.position;
		int m_type = Random.Range (0, 3);

		switch (m_type) {
		case IDefine.BANANA:		// 0
			Instantiate (banana, position, Quaternion.identity);
			break;
		case IDefine.SALLAD:		// 1
			Instantiate (bone, position, Quaternion.identity);
			break;
		case IDefine.BONE:			// 2
			Instantiate (sallad, position, Quaternion.identity);
			break;
		}
	}

	public void FoodFor_2COL () {
		Vector2 position1 = transform.position;
		Vector2 position2 = transform.position;

		position1.x = position1.x - IDefine.POS_X_COL2;
		position2.x = position2.x + IDefine.POS_X_COL2;

		int m_type = Random.Range (0, 3);

		switch (m_type) {
		case IDefine.BANANA:
			Instantiate (banana, position1, Quaternion.identity);
			break;
		case IDefine.SALLAD:
			Instantiate (bone, position1, Quaternion.identity);
			break;
		case IDefine.BONE:
			Instantiate (sallad, position1, Quaternion.identity);
			break;
		}

		m_type = Random.Range (0, 3);

		switch (m_type) {
		case IDefine.BANANA:
			Instantiate (banana, position2, Quaternion.identity);
			break;
		case IDefine.SALLAD:
			Instantiate (bone, position2, Quaternion.identity);
			break;
		case IDefine.BONE:
			Instantiate (sallad, position2, Quaternion.identity);
			break;
		}
	}

	public void FoodFor_3COL () {
		Vector2 position1 = transform.position;
		Vector2 position2 = transform.position;
		Vector2 position3 = transform.position;

		position1.x = position1.x - IDefine.POS_X_COL3;
		position2.x = 0;
		position3.x = position3.x + IDefine.POS_X_COL3;

		int m_type = Random.Range (0, 3);

		switch (m_type) {
		case IDefine.BANANA:
			Instantiate (banana, position1, Quaternion.identity);
			break;
		case IDefine.SALLAD:
			Instantiate (bone, position1, Quaternion.identity);
			break;
		case IDefine.BONE:
			Instantiate (sallad, position1, Quaternion.identity);
			break;
		}

		m_type = Random.Range (0, 3);

		switch (m_type) {
		case IDefine.BANANA:
			Instantiate (banana, position2, Quaternion.identity);
			break;
		case IDefine.SALLAD:
			Instantiate (bone, position2, Quaternion.identity);
			break;
		case IDefine.BONE:
			Instantiate (sallad, position2, Quaternion.identity);
			break;
		}

		m_type = Random.Range (0, 3);

		switch (m_type) {
		case IDefine.BANANA:
			Instantiate (banana, position3, Quaternion.identity);
			break;
		case IDefine.SALLAD:
			Instantiate (bone, position3, Quaternion.identity);
			break;
		case IDefine.BONE:
			Instantiate (sallad, position3, Quaternion.identity);
			break;
		}
	}
}
