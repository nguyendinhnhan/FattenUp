using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class SwipeTouchNew : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerUpHandler // required interface when using the OnPointerUp method.
{
	public AudioClip Sound;
	public GameObject animal;
	public GameObject animAnimal;

	Vector2 beginSwipe = Vector2.zero;
	Vector2 deltaSwipe = Vector2.zero;

	public Sprite pig;
	public Sprite dog;
	public Sprite monkey;
	private Image imageAnimal;

	public static SwipeTouchNew instance;
	private bool isDraging = false;
	private bool allowDrag = true;

	void Awake () {
		animal = gameObject.transform.GetChild (0).gameObject;
		imageAnimal = animal.GetComponent<Image>();
		animAnimal = gameObject.transform.GetChild (1).gameObject;
		getInstance ();
	}

	void getInstance () {
		if (instance == null) {
			instance = this;
		}
	}

	public void OnBeginDrag(PointerEventData data)
	{
		beginSwipe = data.position;
		isDraging = true;
		allowDrag = true;
	}

	public void OnDrag(PointerEventData data)
	{
		deltaSwipe = data.position - beginSwipe;
		if (deltaSwipe.magnitude > 100 && allowDrag) {
			ActiveAnimAnimal (animAnimal, true);
			allowDrag = false;
		}
	}

	public void OnEndDrag(PointerEventData data)
	{
		isDraging = false;
		beginSwipe = Vector2.zero;
		deltaSwipe = Vector2.zero;
	}

	public void ActiveAnimAnimal(GameObject anim, bool isPlay) {
		if (!isPlay) {
			Vector2 pos = anim.GetComponent<RectTransform> ().localPosition;
			pos.x = 0;
			pos.y = -25f;
			anim.GetComponent<RectTransform> ().localPosition = pos;
		}
		anim.GetComponent<Animator> ().enabled = isPlay;
		anim.SetActive (isPlay);
	}

	public void OnPointerUp(PointerEventData data)
	{
		if (!isDraging) {
			ChangeSprite (imageAnimal);
		}
	}

	public void ChangeSprite (Image image) {
		if (image.sprite.Equals (pig)) {
			image.sprite = dog;
			animAnimal.GetComponent<Image> ().sprite = dog;
		} else if (image.sprite.Equals (dog)) {
			image.sprite = monkey;
			animAnimal.GetComponent<Image> ().sprite = monkey;
		} else {
			image.sprite = pig;
			animAnimal.GetComponent<Image> ().sprite = pig;
		}
		PlayMusic();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if ((other.CompareTag ("sallad") && imageAnimal.sprite.Equals (pig))
			|| (other.CompareTag ("bone") && imageAnimal.sprite.Equals (dog))
			|| (other.CompareTag ("banana") && imageAnimal.sprite.Equals (monkey))) {

			GameManager.s_score += 1;
			GameManager.instance.UpdateGUIGame ();
			PlayMusic();

			allowDrag = false;
			ActiveAnimAnimal (animAnimal, false);
			if (gameObject.CompareTag ("Animal1")) {
				Debug.Log ("===Animal=====CreateFood=====1111=");
				Top.instance.CreateFood (1); // create food for col 1
			} else if (gameObject.CompareTag ("Animal2")) {
				Debug.Log ("====Animal====CreateFood=====2222=");
				Top.instance.CreateFood (2); // create food for col 2
			}

			Destroy(other.gameObject);
		} else if (other.CompareTag ("Animal1") || other.CompareTag ("Animal2") || other.CompareTag ("Top")) {
		} else {
			GameManager.instance.GameOver(); //Game Over
		}
	}

	public void PlayMusic () {
		if (!MainMenuController.s_isMuteSound)
			GetComponent<AudioSource> ().PlayOneShot (Sound);
	}
}