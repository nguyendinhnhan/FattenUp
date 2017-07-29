using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

	private MeshRenderer meshRenderer;
	public Material material_BG_2Col;
	public Material material_BG_3Col;

	void Awake() {
		meshRenderer = GetComponent<MeshRenderer> ();
	}
	// Use this for initialization
	void Start () {
		
		float worldHeight = Camera.main.orthographicSize * 2f;
		float worldWidth = worldHeight * Screen.width / Screen.height;
		//float worldHeight = Camera.main.pixelHeight / 160f;
		//float worldWidth = Camera.main.pixelWidth / 160f;
		transform.localScale = new Vector3(worldWidth, worldHeight, 0f);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (GameManager.s_score == IFattenUpDefines.SCORE_TO_BG2COL) {
			meshRenderer.materials[0].CopyPropertiesFromMaterial( material_BG_2Col);
		} else if (GameManager.s_score == IFattenUpDefines.SCORE_TO_BG3COL) {
			meshRenderer.materials[0].CopyPropertiesFromMaterial( material_BG_3Col);
		}

	}
}
