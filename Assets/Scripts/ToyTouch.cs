using UnityEngine;
using System.Collections;

public class ToyTouch : MonoBehaviour {



	private TouchNumbers touchNumbers;
	private CloseScript closeScript;
	private bool isTouched = false;
	// Use this for initialization
	void Start () {
		touchNumbers = (TouchNumbers)GameObject.Find("shirmas").GetComponent(typeof(TouchNumbers));
		closeScript = (CloseScript)GameObject.Find("Redcross").GetComponent(typeof(CloseScript));

	}

	void InputUnlock()
	{
		touchNumbers.isInputLocked = false;
	}
	
	void InputLock()
	{
		touchNumbers.isInputLocked = true;
		Invoke("InputUnlock",touchNumbers.inputLockingTime);
	}
		

	void Update () {

				//int nbTouches = Input.touchCount;
		
			//	if (nbTouches > 0) {
			//	if (Input.GetTouch (0).phase == TouchPhase.Began & !touchNumbers.isInputLocked && touchNumbers.isDoorOpen && !isTouched) {
	if (Input.GetMouseButton(0) && !touchNumbers.isInputLocked && touchNumbers.isDoorOpen) {

		//RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position), Vector2.zero);
	RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
							
				if ( hit.collider != null && hit.transform != null && hit.collider.tag == "toy")
				{						
				isTouched = true;
				InputLock();
				closeScript.touchCounter += 1;
				print (closeScript.touchCounter);
				hit.transform.gameObject.transform.position = new Vector3(3000,3000,0);

												switch (closeScript.touchCounter) {
							
												case 10: 
														audio.PlayOneShot (touchNumbers.number10);
				                                   
														break;
							
												case 1: 
														audio.PlayOneShot (touchNumbers.number1);
													 
														break;
							
												case 2: 
														audio.PlayOneShot (touchNumbers.number2);
													
														break;
							
												case 3:
														audio.PlayOneShot (touchNumbers.number3);
													
														break;
							
												case 4:
														audio.PlayOneShot (touchNumbers.number4);
														
														break;
							
												case 5:
														audio.PlayOneShot (touchNumbers.number5);
													
														break;
							
												case 6:
														audio.PlayOneShot (touchNumbers.number6);
														
														break;
							
												case 7: 
														audio.PlayOneShot (touchNumbers.number7);
												
														break;
							
												case 8: 
														audio.PlayOneShot (touchNumbers.number8);
													
														break;
							
												case 9: 
														audio.PlayOneShot (touchNumbers.number9);
													
														break;
												}
							//	}
							}
		
						}

						if (closeScript.touchCounter == touchNumbers.numberFingers) {
								closeScript.startClosing ();
						}

				}
		}
