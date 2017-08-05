using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;

public class FBScript : MonoBehaviour
{

	public GameObject ButtonFB;

	void Awake ()
	{
		if (!FB.IsInitialized) {
			FB.Init (InitCallback, OnHideUnity);
		} else {
			FB.ActivateApp ();
		}
		ShowUI ();
	}

	private void InitCallback ()
	{
		if (FB.IsInitialized) {
			FB.ActivateApp ();
		} else {
			Debug.Log ("Failed to Initialize the Facebook");
		}
	}

	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	public void FBLogin ()
	{
		if (!FB.IsLoggedIn) {
			FB.LogInWithReadPermissions (new List<string> (){ "public_profile", "email", "user_friends" }, AuthCallback);
		} else {
			Logout ();
		}
	}

	private void Logout ()
	{
		FB.LogOut ();
		ShowUI ();
	}

	private void AuthCallback (ILoginResult result)
	{
		/*
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
		*/
		if (result.Error == null) {
			Debug.Log ("==Nhan dep trai======User is logged in=============");
		} else {
			Debug.Log ("==Nhan dep trai======User cancelled login=======" + result.Error);
		}
		ShowUI ();
	}

	void ChangText (string txt) {
		ButtonFB.transform.GetChild (0).GetComponent<Text>().text = txt;
	}

	void ShowUI ()
	{
		if (FB.IsLoggedIn) {
			ChangText ("Log out");
		} else {
			ChangText ("Log in ");
		}
	}

//	public void ShareWithFriends()
//    {
//        if (FB.IsLoggedIn)
//        {
//            FB.Feed(
//                linkCaption: "I'm playing this awesome game",
//                picture: "https://media.licdn.com/mpr/mpr/p/2/005/096/045/19d71d5.jpg",
//                linkName: "Checkout this game",
//				link: "http://app.facebook.com/" + FB.AppId + "/?challenge_brag=" + (FB.IsLoggedIn ? Facebook.Unity.AccessToken.CurrentAccessToken.UserId : "guest")
//                );
//            Debug.Log("Fb logged in");
//        }
//        else
//        {
//            FBLogin();
//        }
//    }

    public void InviteFriends()
    {
        FB.AppRequest(
            message: "This game is awesome,join me. now",
            title: "Invite your friends to join you"
            );
    }
}
