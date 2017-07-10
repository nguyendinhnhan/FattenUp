using UnityEngine;
using UnityEditor;
using System.Collections;

public class PlayerPreferencesCleaner  {

	[MenuItem("Tools/PlayerPreferences/Delete All")]
	public static void Clean(){

		PlayerPrefs.DeleteAll ();
		Debug.Log ("Player Preferences Cleared");
	}

}
