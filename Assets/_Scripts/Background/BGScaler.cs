using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

	private MeshRenderer meshRenderer;
	public Material material_BG_2Col;
	public Material material_BG_3Col;

	public static BGScaler instance;

	void Awake() {
		getInstance ();
		meshRenderer = GetComponent<MeshRenderer> ();
	}

	void getInstance () {
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		
		float worldHeight = Camera.main.orthographicSize * 2f;
		float worldWidth = worldHeight * Screen.width / Screen.height;
		//float worldHeight = Camera.main.pixelHeight / 160f;
		//float worldWidth = Camera.main.pixelWidth / 160f;
		transform.localScale = new Vector3(worldWidth, worldHeight, 0f);

	}

	public void ChangeBG (int numCols) {
		if (numCols == 2) {
			Debug.Log ("Change BG 2");
			meshRenderer.materials[0].CopyPropertiesFromMaterial( material_BG_2Col);
		} else if (numCols == 3) {
			Debug.Log ("Change BG 3");
			meshRenderer.materials[0].CopyPropertiesFromMaterial( material_BG_3Col);
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		
		if (GameManager.s_score == IDefine.SCORE_TO_BG2COL) {
			
		} else if (GameManager.s_score == IDefine.SCORE_TO_BG3COL) {
			
		}

	}
}
