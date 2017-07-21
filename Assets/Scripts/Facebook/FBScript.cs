using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;

public class FBScript : MonoBehaviour {

	public GameObject ButtonLoginFB;
	public GameObject ButtonLogoutFB;

	void Awake () {
		if (!FB.IsInitialized) {
			FB.Init (InitCallback, OnHideUnity);
		} else {
			FB.ActivateApp ();
		}
		ShowUI ();
	}

	private void InitCallback(){
		if (FB.IsInitialized) {
			FB.ActivateApp ();
		} else {
			Debug.Log ("Failed to Initialize the Facebook");
		}
	}

	private void OnHideUnity(bool isGameShown){
		if (!isGameShown) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	public void FBLogin(){
		var perms = new List<string>(){"public_profile", "email", "user_friends"};
		FB.LogInWithReadPermissions(perms, AuthCallback);
	}

	private void AuthCallback(ILoginResult result){
		if (FB.IsLoggedIn) {
			// AccessToken class will have session details
			var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
			// Print current access token's User ID
			Debug.Log("User is logged in");
			Debug.Log(aToken.UserId);
			// Print current access token's granted permissions
			foreach (string perm in aToken.Permissions) {
				Debug.Log(perm);
			}
		} else {
			Debug.Log("User cancelled login");
		}

		ShowUI ();
	}

	void ShowUI () {
		if (FB.IsLoggedIn) {
			ButtonLoginFB.SetActive (false);
			ButtonLogoutFB.SetActive (true);
		} else {
			ButtonLoginFB.SetActive (true);
			ButtonLogoutFB.SetActive (false);
		}
	}

}
