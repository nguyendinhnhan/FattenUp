using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class Tutorial_SwipeTouch : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerUpHandler // required interface when using the OnPointerUp method.
{
	public AudioClip Sound;
	public GameObject animal;
	public GameObject animMonkey;

	Vector2 beginSwipe = Vector2.zero;
	Vector2 deltaSwipe = Vector2.zero;

	public Sprite pig;
	public Sprite dog;
	public Sprite monkey;
	private Image imageAnimal;

	private bool isDraging = false;

	void Awake () {
		imageAnimal = animal.GetComponent<Image> ();
	}

	public void OnBeginDrag(PointerEventData data)
	{
		beginSwipe = data.position;
		isDraging = true;
	}

	public void OnDrag(PointerEventData data)
	{
		deltaSwipe = data.position - beginSwipe;
		if (deltaSwipe.magnitude > 80 && Tutorial.s_allowSwipeAnimal) {
			animMonkey.SetActive (true);
			animMonkey.GetComponent<Animator> ().enabled = true;
		}
	}

	public void OnEndDrag(PointerEventData data)
	{
		isDraging = false;
		beginSwipe = Vector2.zero;
		deltaSwipe = Vector2.zero;
	}

	public void OnPointerUp(PointerEventData data)
	{
		if (!isDraging) {
			ChangeSprite ();
		}
	}

	public void ChangeSprite () {
		if (Tutorial.s_allowClickAnimal) {
			if (imageAnimal.sprite.Equals (pig)) {
				imageAnimal.sprite = dog;
				if (Tutorial.instance.isDog) {
					Tutorial.s_allowClickAnimal = false;
					Tutorial.instance.ActiveFood (IDefine.BONE);
					Tutorial.instance.ActiveAnimPoint (false);
				}
			} else if (imageAnimal.sprite.Equals (dog)) {
				imageAnimal.sprite = monkey;
				if (Tutorial.instance.isMonkey) {
					Tutorial.s_allowClickAnimal = false;
					Tutorial.s_allowSwipeAnimal = true;

//					Tutorial.instance.ActiveFood (IDefine.BANANA);
					Tutorial.instance.ActiveAnimPoint (false);
					Tutorial.instance.ActiveAnimSwipe (true);
				}
			} else {
				imageAnimal.sprite = pig;
				if (Tutorial.instance.isPig) {
					Tutorial.s_allowClickAnimal = false;
					Tutorial.instance.ActiveFood (IDefine.SALLAD);
					Tutorial.instance.ActiveAnimPoint (false);
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!MainMenuController.s_isMuteSound)
			GetComponent<AudioSource> ().PlayOneShot (Sound);

		// dog	->  pig		-> 	monkey
		// bone	-> 	sallad	-> 	banana
		if (other.CompareTag ("bone") && imageAnimal.sprite.Equals (dog)) {
			Tutorial.instance.ActiveFood(IDefine.SALLAD);
		}

		if (other.CompareTag ("sallad") && imageAnimal.sprite.Equals (pig)) {
			Tutorial.instance.ActiveFood(IDefine.BANANA);
		}

//		if (other.CompareTag ("banana") && imageAnimal.sprite.Equals (monkey)) {
//			Debug.Log ("==========nhan========end tuts========");
//			StorageManager.s_doneTutorial = 1;
//			StorageManager.instance.SaveTutorialData (1); // 1 : done tutorial
//			Tutorial.instance.destroyTutorial ();
//		}

		Destroy(other.gameObject);
	}
}