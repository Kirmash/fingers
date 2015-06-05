using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RocketScript : MonoBehaviour {

	public AudioClip endSpace;

	private TouchNumbers touchNumbers;
	private CloseScript closeScript;
	private NumChange numChange;
	private Quaternion rotationWhileMoving;
	private GameObject tObject;
	private Ray ray;

	private RaycastHit2D hit;
	private int counter;
	private int arrayCounter;
	Vector3 endPoint;

	[HideInInspector]public float distance;

	private bool isTouched;
	private bool distanceGet;
	private bool closeProcessOnline = false;
	[HideInInspector]public bool isDragging;
	[HideInInspector]public bool rocketMove;
	private bool rocketRotate;

	[HideInInspector]public bool overSpaceObject = false; 
	[HideInInspector]public List<GameObject> usedSpaceObjects;
	[HideInInspector]public GameObject hoveredOverSpaceObject;
	[HideInInspector]public Vector3 hoveredOverSpaceObjectCoordinates;
	[HideInInspector]public bool finishedMoving;

	float speed = 3f;
	float lerpMoving = 0;
	float rotationSpeed = 100;
	float rotationErrorFraction = 0.02f;
	
	Vector3 targetDirection;
	Vector3 rocketDirection;
	Vector3 cross;
	private byte isForwardRotate = 0;

	// Use this for initialization
	void Start () {
		usedSpaceObjects = new List<GameObject>();
		touchNumbers = (TouchNumbers)GameObject.Find("shirmas").GetComponent(typeof(TouchNumbers));
		closeScript = (CloseScript)GameObject.Find("Redcross").GetComponent(typeof(CloseScript));
		numChange = GameObject.Find("numb_container").GetComponent<NumChange>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (touchNumbers.currentSceneNum == 2) {
									int nbTouches = Input.touchCount;
								if (nbTouches > 0) {
											if (Input.GetTouch (0).phase == TouchPhase.Began && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_open_idle") && !touchNumbers.cakeEndMove && !rocketMove) {
			//if (Input.GetMouseButtonDown (0) && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_open_idle") && !rocketMove && !rocketRotate) {
				//Debug.Log("Trying to hit");
			//	hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
					if (closeProcessOnline) 
					{
						closeProcessOnline = false;
					}
					hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position), Vector2.zero);
				if (hit.transform != null && hit.collider != null && hit.collider.tag == "rocket") {
						
					tObject = GameObject.Find (hit.transform.gameObject.name);
					//Debug.Log ("I am a TObject: " + tObject);
						isTouched = true;
					//	Debug.Log ("Touched first!");
						if (!distanceGet) {
						distance = Vector3.Distance (tObject.transform.position, Camera.main.transform.position);
							distanceGet = true;
						}
				
				}
				
			}
			
			if (isTouched) {
				if (counter < 10) {
						//Debug.Log ("Counting is on!");
					counter += 1;
					//Debug.Log("Counting: " + counter);
				}
				
				if (counter == 10) {
					// Debug.Log ("Dragging is on!");
					isDragging = true;
					
				}
			}

			//if (Input.GetMouseButtonUp (0) && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_open_idle") && isTouched && !rocketMove && !rocketRotate) {
			if (Input.GetTouch (0).phase == TouchPhase.Ended  && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_open_idle") && isTouched && !rocketMove) {
		
				isTouched = false;
				
				if (counter < 10 && !isDragging) {
				//	Debug.Log ("Executed let go");
					arrayCounter = 1;
					while (usedSpaceObjects.Contains(touchNumbers.activeSpaceObjects[arrayCounter])) {
						arrayCounter += 1;
					}
					usedSpaceObjects.Add (touchNumbers.activeSpaceObjects[arrayCounter]);
					endPoint = touchNumbers.activeSpaceObjects [arrayCounter].transform.position;
					rocketRotate = true;
					closeScript.PlaySound ();

				}

			

				if (overSpaceObject && isDragging) {
					usedSpaceObjects.Add (hoveredOverSpaceObject);
					endPoint = hoveredOverSpaceObjectCoordinates;
					rocketMove = true;
					closeScript.PlaySound ();
				} else {
					distanceGet = false;
				}
				
				counter = 0;
				isDragging = false;
				overSpaceObject = false;
				
				
			}
			
			if (isDragging) {
				//Debug.Log ("Over plate: " + overSpaceObject);
				ray = Camera.main.ScreenPointToRay(Input.GetTouch (0).position);
				//ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				Vector3 rayPoint = ray.GetPoint (distance);
				tObject.rigidbody2D.transform.position = rayPoint;
				tObject.transform.rotation = new Quaternion(0, 0, 0, 0);
				
			}
			}

			if (closeScript.touchCounter == touchNumbers.numberFingers && !closeProcessOnline) {
				closeProcessOnline = true;	
				closeScript.startClosing ();
				audio.PlayOneShot (endSpace);
				lerpMoving = 0f;

			}

		}

		if (rocketRotate) {
			Transform nose = tObject.transform.FindChild("nose");
			targetDirection = (endPoint - nose.position);
		//	Debug.Log ("Target dir " + targetDirection);
			targetDirection.z = 0;
			rocketDirection = (nose.position - tObject.transform.position);
			targetDirection.Normalize();
			rocketDirection.Normalize ();
			cross = Vector3.Cross(rocketDirection, targetDirection);
			Debug.Log (cross.z);
			if((cross.z < 0 && isForwardRotate == 1) || (cross.z > 0 && isForwardRotate == 2))
			{
				rocketRotate = false;
				rocketMove = true;
				isForwardRotate = 0;
			}
			else
			{
				if(cross.z > 0) {
					tObject.transform.Rotate(Vector3.forward, Time.deltaTime*rotationSpeed);
					isForwardRotate = 1; }
				else {
					tObject.transform.Rotate(Vector3.back, Time.deltaTime*rotationSpeed);
					isForwardRotate = 2; }
			}

				}
		if (rocketMove) {

		lerpMoving += Time.deltaTime;
			tObject.transform.position = Vector3.MoveTowards (tObject.transform.position, endPoint, speed*lerpMoving);
			
			if (tObject.transform.position == endPoint) {
				rocketMove = false;
				numChange.BackChange();
				closeScript.touchCounter += 1;
				usedSpaceObjects[closeScript.touchCounter-1].transform.FindChild("flag_3").GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
				lerpMoving = 0f;
			}
			
			
		}

	}
}
