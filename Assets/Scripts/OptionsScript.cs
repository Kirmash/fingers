using UnityEngine;
using System.Collections;
using SmartLocalization;


public class OptionsScript : MonoBehaviour {
	[HideInInspector] public bool isOpenedSettings;
	private bool blockedOptions;
	private RaycastHit2D hit;
	Vector3 positionStart = new Vector3 (-14f, 0f, 0f);
	Vector3 crossStartPosition = new Vector3 (6.25f, 4.6f, 0f);

	Transform shirmasTransform;
	Transform crossTransform;
	[HideInInspector] public LanguageManager languageManager;


	// Use this for initialization
	void Start () {
		languageManager = LanguageManager.Instance;	
		shirmasTransform = (Transform)GameObject.Find("shirmas").GetComponent(typeof(Transform));
		crossTransform = (Transform)GameObject.Find("Redcross").GetComponent(typeof(Transform));
		languageManager.ChangeLanguage ("en");
	}
	
	// Update is called once per frame
	void Update () {
		int nbTouches = Input.touchCount;
		if (isOpenedSettings && !blockedOptions) {
						transform.position = Vector3.zero;
			crossTransform.position = positionStart;
			blockedOptions = true;
				}
		if (nbTouches > 0 && isOpenedSettings && blockedOptions) {

			hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position), Vector2.zero);
			if (hit.collider != null && hit.transform != null && hit.collider.tag == "korean") {
				Debug.Log ("Korean!");
				languageManager.ChangeLanguage ("ko");
			}
			if (hit.collider != null && hit.transform != null && hit.collider.tag == "russian") {
				Debug.Log ("Russian!");
				languageManager.ChangeLanguage ("ru");
			}
			if (hit.collider != null && hit.transform != null && hit.collider.tag == "english") {
				Debug.Log ("English!");
				languageManager.ChangeLanguage ("en");
			}
			Debug.Log ("hit collider: " + hit.collider.tag);
			if (hit.collider != null && hit.transform != null && hit.collider.tag == "optionsCross") {
				shirmasTransform.position = Vector3.zero;
				crossTransform.position = crossStartPosition;
				transform.position = positionStart;
				blockedOptions = false;
				isOpenedSettings = false;
				shirmasTransform.position = Vector3.zero;
			}
				}
	}
}
