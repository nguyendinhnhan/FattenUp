using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{

	public GameObject banana;
	public GameObject bone;
	public GameObject sallad;

	public int[] foodArr1 = new int[5];
	public int[] foodArr2 = new int[5];

	public static Top instance;

	void Awake ()
	{
		getInstance ();
	}

	void getInstance ()
	{
		if (instance == null) {
			instance = this;
		}
	}

	void Start ()
	{
		InitFoodArr ();
	}

	void InitFoodArr ()
	{
		int type = 0;
		for (int i = 0; i < 5; i++) {
			// Random Array Food 1 with not same value every third
			type = Random.Range (0, 3);
			if (i >= 2) {
				if (type == foodArr1 [i - 2]) {
					type = Mathf.Abs (type - 1);
				}
			}
			foodArr1 [i] = type;

			// Random Array Food 2 with not same value every third
			type = Random.Range (0, 3);
			if (i >= 2) {
				if (type == foodArr2 [i - 2]) {
					type = Mathf.Abs (type - 1);
				}
			}
			foodArr2 [i] = type;
		}
	}

	public void CreateFood (int animal)
	{
		Vector2 position = transform.position;
		int type = 0;
		if (animal == 1) {
			if (GameManager.s_numCol == 2) {
				position.x = position.x - IDefine.POS_X_COL2;
			}
			//type = foodArr1 [0];
		} else if (animal == 2) {
			position.x = position.x + IDefine.POS_X_COL2;
			//type = foodArr2 [0];
		}

		type = Random.Range (0, 3);

		switch (type) {
		case IDefine.BANANA:		// 0
			Instantiate (banana, position, Quaternion.identity);
			break;
		case IDefine.SALLAD:		// 1
			Instantiate (sallad, position, Quaternion.identity);
			break;
		case IDefine.BONE:			// 2
			Instantiate (bone, position, Quaternion.identity);
			break;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Animal1") || other.CompareTag ("Animal2")) {
			Debug.Log ("=========Trigger Anim Animal===========");
			SwipeTouchNew.instance.ActiveAnimAnimal (other.gameObject, false);
		}
	}

	void debugArr (int[] arr)
	{
		for (int i = 0; i < 5; i++) {
			Debug.Log ("Arr[" + i + "]: " + arr [i]);
		}
	}

	//	public void createFood_old () {
	//		Debug.Log ("Create FOdd!");
	//		StartCoroutine(SpawnerFood());
	//	}
	//
	//	IEnumerator SpawnerFood()
	//	{
	//		if (GameManager.s_numCol == 1) {
	//			FoodFor_1COL ();
	//		} else if (GameManager.s_numCol == 2) {
	//			FoodFor_2COL ();
	//		}
	//		yield return new WaitForSeconds(4f);
	//		if (!GameManager.s_isGameOver) {
	//			StartCoroutine (SpawnerFood ());
	//		} else {
	//			Debug.Log ("Stop Create FOdd!");
	//		}
	//	}
	//
	//	public void FoodFor_1COL () {
	//		Vector2 position = transform.position;
	//		int m_type = Random.Range (0, 3);
	//
	//		switch (m_type) {
	//		case IDefine.BANANA:		// 0
	//			Instantiate (banana, position, Quaternion.identity);
	//			break;
	//		case IDefine.SALLAD:		// 1
	//			Instantiate (bone, position, Quaternion.identity);
	//			break;
	//		case IDefine.BONE:			// 2
	//			Instantiate (sallad, position, Quaternion.identity);
	//			break;
	//		}
	//	}
	//
	//	public void FoodFor_2COL () {
	//		Vector2 position1 = transform.position;
	//		Vector2 position2 = transform.position;
	//
	//		position1.x = position1.x - IDefine.POS_X_COL2;
	//		position2.x = position2.x + IDefine.POS_X_COL2;
	//
	//		int m_type = Random.Range (0, 3);
	//
	//		switch (m_type) {
	//		case IDefine.BANANA:
	//			Instantiate (banana, position1, Quaternion.identity);
	//			break;
	//		case IDefine.SALLAD:
	//			Instantiate (bone, position1, Quaternion.identity);
	//			break;
	//		case IDefine.BONE:
	//			Instantiate (sallad, position1, Quaternion.identity);
	//			break;
	//		}
	//
	//		m_type = Random.Range (0, 3);
	//
	//		switch (m_type) {
	//		case IDefine.BANANA:
	//			Instantiate (banana, position2, Quaternion.identity);
	//			break;
	//		case IDefine.SALLAD:
	//			Instantiate (bone, position2, Quaternion.identity);
	//			break;
	//		case IDefine.BONE:
	//			Instantiate (sallad, position2, Quaternion.identity);
	//			break;
	//		}
	//	}
}
