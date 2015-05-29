using UnityEngine;
using System.Collections;

public class NumChange : MonoBehaviour {
	public Sprite[] numbers;
	[HideInInspector] public SpriteRenderer spriteRenderer;
	private TouchNumbers touchNumbers;
	private TouchController touchController;
	private CloseScript closeScript;
	[HideInInspector] public bool changeBack = false;
	//private BallTouchScript ballTouchScript;
	// Use this for initialization
	void Start () {
		spriteRenderer = renderer as SpriteRenderer;
		touchNumbers = GameObject.Find("shirmas").GetComponent<TouchNumbers>();
		touchController = GameObject.Find ("Main Camera").GetComponent<TouchController> ();
		closeScript = GameObject.Find ("Redcross").GetComponent<CloseScript> ();
	//	ballTouchScript = (BallTouchScript)GameObject.Find("Main Camera").GetComponent(typeof(BallTouchScript));


	}
	
	// Update is called once per frame
	void Update () {


		if (changeBack) {
		//	Debug.Log("ChangeBack " + touchNumbers.numberFingers);
						spriteRenderer.sprite = numbers [touchNumbers.numberFingers - 1];
			changeBack = false;

				}

		switch (touchNumbers.currentSceneNum) {
		case 0:
			spriteRenderer.color = new Color(1f,1f,1f,1f);
			
			if (Input.touchCount > 0) {
			//if (Input.GetMouseButton (0) && !touchNumbers.isInputLocked && touchNumbers.isDoorOpen && !closeScript.inputLocked) {
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position), Vector2.zero);
				//RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
				if  (hit.collider != null && hit.transform != null && hit.collider.tag == "toy") {
					BackChange();
				}
			}
				break;

		case 1:

			if (touchController.cakeMove) {
				BackChange();
			}
			break;

		case 2:

			break;

		case 3:

			break;
		}
				}
		
	public void BackChange () {
	//	Debug.Log (closeScript.touchCounter);
		spriteRenderer.sprite = numbers [closeScript.touchCounter];

	}
}
