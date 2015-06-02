using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallTouchScript : MonoBehaviour {

	private TouchNumbers touchNumbers;
	private CloseScript closeScript;
	private NumChange numChange;


	private bool isTouched = false;
	private bool ballMove = false;
	private bool closeProcessOnline = false;
	[HideInInspector]public bool isStriked = false;
	[HideInInspector]public byte animationIndex = 0;
	[HideInInspector]public byte ballAnimationIndex = 0;

	[HideInInspector]public GameObject tObject;
	private Ray ray;
	float startFlickPositionY;
	float differenceFlickPositions;
	float errorMarginFlick = 0.01f;
	float flickStartTime;
	float flickFinishTime;
	bool flickStarted;

	private RaycastHit2D hit;
	private int arrayCounter;
	private Vector3 endPoint;

	private Vector3 leftBallEndPoint = new Vector3 (-2,2,0);
	private Vector3 rightBallEndPoint = new Vector3 (2,2,0);

	[HideInInspector]public List<GameObject> usedBallObjects;

	float speed = 8f;
	float lerpMoving = 0;

	// Use this for initialization
	void Start () {
	
		touchNumbers = (TouchNumbers)GameObject.Find("shirmas").GetComponent(typeof(TouchNumbers));
		closeScript = (CloseScript)GameObject.Find("Redcross").GetComponent(typeof(CloseScript));
		numChange = GameObject.Find("numb_container").GetComponent<NumChange>();
		usedBallObjects = new List<GameObject>();

	}
	
	// Update is called once per frame
	void Update () {
	
		if (touchNumbers.currentSceneNum == 3) {
												int nbTouches = Input.touchCount;
								
												if (nbTouches > 0) {
														if (Input.GetTouch (0).phase == TouchPhase.Began && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_open_idle") && !touchNumbers.cakeEndMove && !ballMove) {
		//		if (Input.GetMouseButtonDown (0) && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_open_idle") && !ballMove) {
				//Debug.Log("Trying to hit");
				//hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
					hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position), Vector2.zero);
					if (closeProcessOnline) 
					{
						closeProcessOnline = false;
					}
				if (hit.transform != null && hit.collider != null && hit.collider.tag == "ball") {
					tObject = GameObject.Find (hit.transform.gameObject.name);
					//startFlickPositionY = Input.mousePosition.y;
					startFlickPositionY = Input.GetTouch (0).position.y;
					flickStartTime = Time.time;
					flickStarted = true;
					isTouched = true;
				}	
				}
			}
		if (flickStarted && !(Input.GetTouch (0).phase == TouchPhase.Ended)) {
		//	if (flickStarted && !Input.GetMouseButtonUp (0)) {
				Debug.Log ("Flick started: " + flickStarted);
				differenceFlickPositions = Input.mousePosition.y - startFlickPositionY;
				flickFinishTime = Mathf.Abs(flickStartTime - Time.time);
				Debug.Log ("Difference pos: " + differenceFlickPositions);
				Debug.Log ("Time: " + flickFinishTime);
				if (differenceFlickPositions < 0 || flickFinishTime >= 1f) {
					flickStarted = false;
					}
				}

			//if (Input.GetMouseButtonUp (0) && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_open_idle") && isTouched && !ballMove) {
			if (Input.GetTouch (0).phase == TouchPhase.Ended  && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_open_idle") && isTouched && !ballMove) {
			if (flickStarted) {
				isTouched = false;
					flickStarted = false;
					arrayCounter = 0;
					while (usedBallObjects.Contains(touchNumbers.activeBalls[arrayCounter])) {
						arrayCounter += 1;
					}
					usedBallObjects.Add (touchNumbers.activeBalls[arrayCounter]);
				if (tObject.transform.position.x <= 0) 
				{
					animationIndex = 1;
					endPoint = leftBallEndPoint;

				}

				else {
					animationIndex = 2;
					endPoint = rightBallEndPoint;
				}

					ballMove = true;
				tObject.transform.FindChild("football_ten").GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
					
				}
			}

		
			if (closeScript.touchCounter == touchNumbers.numberFingers && !closeScript.closeProcessOnline) {
				closeProcessOnline = true;
				closeScript.startClosing ();
				lerpMoving = 0f;
			}

				}
		if (ballMove) {
			lerpMoving += Time.deltaTime;
			tObject.transform.position = Vector3.MoveTowards (tObject.transform.position, endPoint, speed*lerpMoving);
			if (tObject.transform.position == endPoint) {
				closeScript.PlaySound ();
				ballMove = false;
				isStriked = true;
				if (endPoint == leftBallEndPoint) {
					ballAnimationIndex = 1;
				}
				else { ballAnimationIndex = 2; }
				numChange.BackChange();
				closeScript.touchCounter += 1;
				lerpMoving = 0f;
			}

		}

			}
}
