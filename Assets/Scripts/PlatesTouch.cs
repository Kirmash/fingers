using UnityEngine;
using System.Collections;

public class PlatesTouch : MonoBehaviour {

	private TouchNumbers touchNumbers;
	private CloseScript closeScript;

	public AudioClip munch;

	private bool isInvoking = false;
	Vector3 startPoint;
	Vector3 endPoint;
	Vector3 childStartPoint;
	float speed = 16f;
	float innerSpeed = 4f;
	float rotateSpeed = 40f;
	float lerpMoving;
	bool cakeMove = false;
	[HideInInspector]public bool cakeEndMove = false;
	private bool noTouching = false;
	private float[] speedExit = new float[8]; 

	// Use this for initialization
	void Start () {
		touchNumbers = (TouchNumbers)GameObject.Find("shirmas").GetComponent(typeof(TouchNumbers));
		closeScript = (CloseScript)GameObject.Find("Redcross").GetComponent(typeof(CloseScript));
	}
	
	// Update is called once per frame
	void Update () {
		if (cakeMove) {
			lerpMoving += Time.deltaTime;
			Quaternion newRotation = Quaternion.AngleAxis(5, Vector3.forward);
			//			Debug.Log(newRotation);
			touchNumbers.cakeScene[closeScript.touchCounter].transform.position = Vector3.MoveTowards(startPoint, endPoint, speed*lerpMoving);
			touchNumbers.cakeScene[closeScript.touchCounter].transform.Find("cake1").localPosition = Vector3.MoveTowards(childStartPoint, Vector3.zero, innerSpeed*lerpMoving);
			touchNumbers.cakeScene[closeScript.touchCounter].transform.rotation = Quaternion.Slerp(touchNumbers.cakeScene[closeScript.touchCounter].transform.rotation, newRotation, .05f); 
			//Debug.Log ("We are here! " + speed*lerpMoving + startPoint + endPoint);
			if (touchNumbers.cakeScene[closeScript.touchCounter].transform.position == endPoint) 
			{
				//	Debug.Log ("Now we ended!");
				cakeMove = false;
				closeScript.touchCounter += 1;
				lerpMoving = 0f;
			}
			if (closeScript.touchCounter == touchNumbers.scenePlates.Length-1)
			{
				noTouching = true;
				lerpMoving = 0f;
			}
			
		}
		
		if (closeScript.cakeEndMove) {
			//lerpMoving += Time.deltaTime;
			for (int i=1; i<touchNumbers.scenePlates.Length; i++)
			{
				Debug.Log(speedExit[i-1]);

			//	speedExit = Random.Range(1,5);
				touchNumbers.cakeScene[i-1].transform.position = Vector3.MoveTowards(touchNumbers.cakeScene[i-1].transform.position, 2*touchNumbers.cakeScene[i-1].transform.position, speedExit[i-1]/25);
				touchNumbers.scenePlates[i].transform.position = Vector3.MoveTowards(touchNumbers.scenePlates[i].transform.position, 2*touchNumbers.scenePlates[i].transform.position, speedExit[i-1]/25);
			}
		}

		//int nbTouches = Input.touchCount;
		
		//	if (nbTouches > 0) {
		//	if (Input.GetTouch (0).phase == TouchPhase.Began & !touchNumbers.isInputLocked && touchNumbers.isDoorOpen && !isTouched) {
		if (Input.GetMouseButton (0) && !touchNumbers.isInputLocked && !closeScript.inputLocked && touchNumbers.isDoorOpen) {
						//RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position), Vector2.zero);
			
						RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

			if ( hit.collider != null && hit.transform != null && hit.collider.tag == "plate"  && !cakeMove && !noTouching)
			{
				
				//print (closeScript.touchCounter+1);
				startPoint = touchNumbers.cakeScene[closeScript.touchCounter].transform.position;
				endPoint = touchNumbers.scenePlates[closeScript.touchCounter+1].transform.position; 
				childStartPoint = touchNumbers.cakeScene[closeScript.touchCounter].transform.Find("cake1").localPosition;
				cakeMove = true;
				closeScript.PlaySound();
			}

				}

		if (closeScript.touchCounter == touchNumbers.numberFingers && !isInvoking) {
			//			Debug.Log ("if ToyTouch " + touchNumbers.isInputLocked);
			////			touchNumbers.isInputLocked = true;
			////			Invoke("InputUnlock",touchLockTime);
			//			Debug.Log ("InputUnlock " + touchNumbers.isInputLocked);
			closeScript.startClosing ();

			for (int i=0; i<touchNumbers.scenePlates.Length-1; i++)
			{
				speedExit[i] = Random.Range(1,10);
			}
			Debug.Log("Playing!");
			audio.PlayOneShot(munch);
			isInvoking = true;
		}

	}



}
