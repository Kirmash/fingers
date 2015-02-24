using UnityEngine;
using System.Collections;

public class ToyTouch : MonoBehaviour {


	private TouchNumbers touchNumbers;
	private CloseScript closeScript;
	private bool inputLocked = false;
	private bool isInvoking = false;


	// Use this for initialization
	void Start () {
		touchNumbers = (TouchNumbers)GameObject.Find("shirmas").GetComponent(typeof(TouchNumbers));
		closeScript = (CloseScript)GameObject.Find("Redcross").GetComponent(typeof(CloseScript));

			}

		void Update () {

		//int nbTouches = Input.touchCount;
		
			//	if (nbTouches > 0) {
			//	if (Input.GetTouch (0).phase == TouchPhase.Began & !touchNumbers.isInputLocked && touchNumbers.isDoorOpen && !isTouched) {
		if (Input.GetMouseButton(0) && !touchNumbers.isInputLocked && !closeScript.inputLocked && touchNumbers.isDoorOpen) {
		//RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position), Vector2.zero);
	
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
				
			if ( hit.collider != null && hit.transform != null && hit.collider.tag == "toy")
				{		
				hit.transform.gameObject.transform.position = new Vector3(3000,3000,0);
					closeScript.PlaySound();
					closeScript.touchCounter += 1;

							}
							}
				
		if (closeScript.touchCounter == touchNumbers.numberFingers && !isInvoking) {
			closeScript.startClosing ();
			isInvoking = true;
						}

				}

		}
