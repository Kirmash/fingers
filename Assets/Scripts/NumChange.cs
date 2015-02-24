using UnityEngine;
using System.Collections;

public class NumChange : MonoBehaviour {
	public Sprite[] numbers;
	private SpriteRenderer spriteRenderer;
	private TouchNumbers touchNumbers;
	private CloseScript closeScript;
	public bool changeBack = false;
	// Use this for initialization
	void Start () {
		spriteRenderer = renderer as SpriteRenderer;
		touchNumbers = GameObject.Find("shirmas").GetComponent<TouchNumbers>();
		closeScript = GameObject.Find ("Redcross").GetComponent<CloseScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		//int nbTouches = Input.touchCount;

		//if (Input.touchCount > 0) {

		if (changeBack) {
						spriteRenderer.sprite = numbers [touchNumbers.numberFingers - 1];
			changeBack = false;

				}

		if (Input.GetMouseButton (0) && !touchNumbers.isInputLocked && touchNumbers.isDoorOpen && !closeScript.inputLocked) {
			//RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position), Vector2.zero);
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if  (hit.collider != null && hit.transform != null && (hit.collider.tag == "toy" || hit.collider.tag == "plate")) {
			//Debug.Log("Back_num: " + touchNumbers.currentSceneNum);
			spriteRenderer.sprite = numbers [closeScript.touchCounter];
		}
		}
	}
}
