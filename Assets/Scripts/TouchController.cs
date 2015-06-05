using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchController : MonoBehaviour {

	[HideInInspector]public bool isDragging = false;
	[HideInInspector]public float distance;
	[HideInInspector]public bool isTouched;
	[HideInInspector]public bool isReturning;
	[HideInInspector]public bool distanceGet;

	
	public AudioClip munch;

	private Vector3 startPosition;

	private GameObject tObject;

	private Ray ray;


	private TouchNumbers touchNumbers;
	private CloseScript closeScript;

	private int counter = 0;
		
	float speed = 12f;
	float lerpMoving = 0;
	
	Vector3 endPoint;
	Vector3 childStartPoint;
	//[HideInInspector]public bool cakeEndMove = false;
	private float[] speedExit = new float[8]; 
	[HideInInspector]public List<GameObject> usedPlates;
	[HideInInspector]public List<GameObject> usedCakes;

	[HideInInspector]public bool cakeMove;
	private bool closeProcessOnline;
	private RaycastHit2D hit;

	[HideInInspector]public GameObject activePlate;

	private int arrayCounter;
	private CircleCollider2D activePlateCollider;

	[HideInInspector]public bool overPlate = false; 
	[HideInInspector]public Vector3 plateCoordinates;


	void Start () {
		usedPlates = new List<GameObject>();
		usedCakes = new List<GameObject>();
		touchNumbers = (TouchNumbers)GameObject.Find("shirmas").GetComponent(typeof(TouchNumbers));
		closeScript = (CloseScript)GameObject.Find("Redcross").GetComponent(typeof(CloseScript));
	}

	void Update() {

		if (touchNumbers.currentSceneNum == 1) {
						int nbTouches = Input.touchCount;
		
							if (nbTouches > 0) {
											if (Input.GetTouch (0).phase == TouchPhase.Began && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_open_idle") && !touchNumbers.cakeEndMove && !cakeMove) {
			//if (Input.GetMouseButtonDown (0) && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo (0).IsName ("curtains_open_idle") && !touchNumbers.cakeEndMove && !cakeMove) {
				if (closeProcessOnline) 
					{
						closeProcessOnline = false;
					}
			//	hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
					hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position), Vector2.zero);
				if (hit.transform != null && hit.collider != null && hit.collider.tag == "cake") {
					if (!usedCakes.Contains (hit.transform.gameObject)) {
						tObject = GameObject.Find (hit.transform.gameObject.name);
						//Debug.Log ("I am a TObject: " + tObject);	
						startPosition = tObject.transform.position;
						isTouched = true;
						//	Debug.Log ("Touched first!");
						if (!distanceGet) {
							distance = Vector3.Distance (tObject.transform.position, Camera.main.transform.position);
								childStartPoint = tObject.transform.Find ("cake1").localPosition;
							distanceGet = true;
						}
					}
				}
				
			}


			//check and execute touch 
			if (Input.GetTouch (0).phase == TouchPhase.Ended && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_open_idle") && isTouched && !cakeMove) {
			//if (Input.GetMouseButtonUp (0) && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo (0).IsName ("curtains_open_idle") && isTouched && !cakeMove) {
				isTouched = false;
				
				if (counter < 10 && !isDragging) {
					//	Debug.Log ("Executed let go");
					usedCakes.Add (tObject);
					arrayCounter = 1;
					while (usedPlates.Contains(touchNumbers.scenePlates[arrayCounter])) {
						arrayCounter += 1;
					}
					//Debug.Log("ArrayCounter: " + arrayCounter);
					usedPlates.Add (touchNumbers.scenePlates [arrayCounter]);
					endPoint = touchNumbers.scenePlates [arrayCounter].transform.position - childStartPoint;
					cakeMove = true;
					closeScript.PlaySound ();
				}
				
				if (overPlate && !isReturning && isDragging) {
					//Debug.Log("Moving to plate, baby");
					usedCakes.Add (tObject);
					usedPlates.Add (activePlate);
					endPoint = plateCoordinates - childStartPoint; 
						//Debug.Log ("EndPoint: " + endPoint);
					cakeMove = true;
					closeScript.PlaySound ();
				} else {
					isReturning = true;
					distanceGet = false;
				}
				
				counter = 0;
				isDragging = false;
				overPlate = false;
				
				
			}

			if (isTouched) {
				if (counter < 6) {
					//	Debug.Log ("Counting is on!");
					counter += 1;
					//		Debug.Log("Counting: " + counter);
				}
				
				if (counter == 6) {
					// Debug.Log ("Dragging is on!");
					isDragging = true;
					
				}
			}
			}
			//cake follows after the mouse/touch
			if (isDragging) {
				//Debug.Log ("Over plate: " + overPlate);
			ray = Camera.main.ScreenPointToRay(Input.GetTouch (0).position);
			//ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				Vector3 rayPoint = ray.GetPoint (distance);
				tObject.rigidbody2D.transform.position = rayPoint;
				
			}
			
			//return cake to the start point after drag
			if (isReturning) {
				//	Debug.Log("here!");
				lerpMoving += Time.deltaTime;
				tObject.transform.position = Vector3.MoveTowards (tObject.transform.position, startPosition, speed * lerpMoving);
				if (tObject.transform.position == startPosition) {
					isReturning = false;
					lerpMoving = 0;
				}
			}
			
			
			
			//move cake if touched
						
			// close after every plate has been touched
			if (closeScript.touchCounter == touchNumbers.numberFingers && !closeProcessOnline) {
				closeProcessOnline = true;
				closeScript.startClosing ();
				lerpMoving = 0f;
				
				for (int i=0; i<touchNumbers.scenePlates.Length-1; i++) {
					speedExit [i] = Random.Range (1, 10);
				}
				audio.PlayOneShot (munch);

			}
			
			//finishing move for cakes
			if (touchNumbers.cakeEndMove) {
				for (int i=0; i<usedPlates.Count; i++) {
					usedCakes [i].transform.position = Vector3.MoveTowards (usedCakes [i].transform.position, 2 * usedCakes [i].transform.position, speedExit [i] / 25);
					usedPlates [i].transform.position = Vector3.MoveTowards (usedPlates [i].transform.position, 2 * usedPlates [i].transform.position, speedExit [i] / 25);
				}
			}


		}

		if (cakeMove) {
			lerpMoving += Time.deltaTime;
			Quaternion newRotation = Quaternion.AngleAxis (5, Vector3.forward);
			tObject.transform.position = Vector3.MoveTowards (tObject.transform.position, endPoint, speed*lerpMoving);
			tObject.transform.rotation = Quaternion.Slerp (tObject.transform.rotation, newRotation, .05f); 
			if (tObject.transform.position == endPoint) {
				cakeMove = false;
				distanceGet = false;
				closeScript.touchCounter += 1;
				lerpMoving = 0f;
			}
			
			
		}

	}
	}


