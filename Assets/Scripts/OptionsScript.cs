using UnityEngine;
using System.Collections;
using SmartLocalization;


public class OptionsScript : MonoBehaviour {
	[HideInInspector] public bool isOpenedSettings;
	public AudioClip[] touchLanguage;
	private int randLanguageSelectSound;
	private bool blockedOptions;
	private int cooldownCounter = 0;
	private RaycastHit2D hit;
	Vector3 positionStart = new Vector3 (-14f, 0f, 0f);
	Vector3 crossStartPosition = new Vector3 (6.25f, 4.6f, 0f);
	// ru, ko, en
	Vector3[] selectorPositionArray = new [] { new Vector3(-3.29f, 2.89f, -1f), new Vector3(0.14f, 2.89f, -1f), new Vector3(3.57f, 2.89f, -1f)};
	//blocker for disabling colliders (0 - ru, 1 - ko, 2 - en)
	[HideInInspector] public int colliderBlocker;
	private int russianChoice;
	Transform shirmasTransform;
	Transform crossTransform;
	Transform selectorTransform;
	[HideInInspector] public LanguageManager languageManager;


	// Use this for initialization
	void Start () {
		languageManager = LanguageManager.Instance;	
		shirmasTransform = (Transform)GameObject.Find("shirmas").GetComponent(typeof(Transform));
		crossTransform = (Transform)GameObject.Find("Redcross").GetComponent(typeof(Transform));
		selectorTransform = (Transform)GameObject.Find("Selector").GetComponent(typeof(Transform));
		languageManager.ChangeLanguage ("ru");
	}
	
	// Update is called once per frame
	void Update () {
		int nbTouches = Input.touchCount;
		if (isOpenedSettings && !blockedOptions) {
			//			transform.position = Vector3.zero;
			crossTransform.position = positionStart;
			blockedOptions = true;
				}
		if (nbTouches > 0 && isOpenedSettings && blockedOptions) {

			hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position), Vector2.zero);
			if (hit.collider != null && hit.transform != null && hit.collider.tag == "korean" && colliderBlocker != 1) {
				languageManager.ChangeLanguage ("ko");
				selectorTransform.position = selectorPositionArray [1];
				LanguageSelectSound ();
				colliderBlocker = 1;
			}
			if (hit.collider != null && hit.transform != null && hit.collider.tag == "russian" && colliderBlocker != 0) {
				russianChoice = Random.Range(0,2);
				if (russianChoice == 0) {
					//Debug.Log ("First ru select");
					languageManager.ChangeLanguage ("ru"); 
				} else {
				//	Debug.Log ("Ssecond ru select");
					languageManager.ChangeLanguage ("ru-RU"); 
				}
				selectorTransform.position = selectorPositionArray [0];
				LanguageSelectSound ();
				colliderBlocker = 0;
			}
			if (hit.collider != null && hit.transform != null && hit.collider.tag == "english" && colliderBlocker != 2) {
				languageManager.ChangeLanguage ("en");
				selectorTransform.position = selectorPositionArray [2];
				LanguageSelectSound ();
				colliderBlocker = 2;
			}
			if (hit.collider != null && hit.transform != null && hit.collider.tag == "Skazki" && cooldownCounter == 0) {
				Application.OpenURL ("https://itunes.apple.com/ru/app/%D1%81%D0%BA%D0%B0%D0%B7%D0%BA%D0%B8-%D0%B2%D0%BD%D1%83%D1%82%D1%80%D0%B8/id989725221");
				LanguageSelectSound ();
				cooldownCounter = 30;
			}

			if (hit.collider != null && hit.transform != null && hit.collider.tag == "Dubdom" && cooldownCounter == 0) {
				Application.OpenURL ("https://itunes.apple.com/ru/app/дубдом/id944961430");
				LanguageSelectSound ();
				cooldownCounter = 30;
			}

			if (hit.collider != null && hit.transform != null && hit.collider.tag == "Kharms" && cooldownCounter == 0) {
				Application.OpenURL ("https://itunes.apple.com/ru/app/charms-of-kharms/id968020984");
				LanguageSelectSound ();
				cooldownCounter = 30;
			}

			if (hit.collider != null && hit.transform != null && hit.collider.tag == "optionsCross") {
				shirmasTransform.position = Vector3.zero;
				crossTransform.position = crossStartPosition;
				transform.position = positionStart;
				blockedOptions = false;
				isOpenedSettings = false;
				shirmasTransform.position = Vector3.zero;
			}
				}
		if (cooldownCounter != 0) {
			cooldownCounter -= 1;
		}
	}

	void LanguageSelectSound () {
		GetComponent<Animation> ().Play ("OptionsStars");
		randLanguageSelectSound = Random.Range (0, 3);
		GetComponent<AudioSource>().PlayOneShot (touchLanguage[randLanguageSelectSound]);
	}

}
