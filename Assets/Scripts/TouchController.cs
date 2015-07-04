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
	public AudioClip endSpace;
	public AudioClip[] bubblePop;

	private Vector3 startPosition;

	[HideInInspector]public GameObject tObject;

	private Ray ray;

	private TouchNumbers touchNumbers;
	private CloseScript closeScript;
	private NumChange numChange;

	private int counter = 0;
		
	float speedCake = 12f;
	float lerpMoving = 0;
	
	Vector3 endPoint;
	Vector3 childStartPoint;
	//[HideInInspector]public bool cakeEndMove = false;
	private float[] speedExit = new float[8]; 
	[HideInInspector]public List<GameObject> usedMainObjects;
	[HideInInspector]public List<GameObject> usedTouchableObject;

	[HideInInspector]public bool objectMove;
	private bool closeProcessOnline;
	private RaycastHit2D hit;

	[HideInInspector]public GameObject activeMainObject;

	private int arrayCounter;
	private CircleCollider2D activePlateCollider;

	[HideInInspector]public bool overMainObject = false; 
	[HideInInspector]public Vector3 mainObjectCoordinates;

//Scene 2
	float speedRocket = 3f;
	float rotationSpeed = 300;
	Vector3 targetDirection;
	Vector3 rocketDirection;
	Vector3 cross;
	private byte isForwardRotate = 0;

//Scene 3
	private bool rocketRotate;
	float startFlickPositionY;
	float differenceFlickPositions;
	//	float errorMarginFlick = 0.01f;
	float flickStartTime;
	float flickFinishTime;
	bool flickStarted;
	[HideInInspector]public List<int> usedBallsAnimation;
	private Vector3 leftBallEndPoint = new Vector3 (-2,2,0);
	private Vector3 rightBallEndPoint = new Vector3 (2,2,0);
	float ballSpeed = 8f;
	[HideInInspector]public bool isStriked = false;
	[HideInInspector]public byte ballAnimationIndex = 0;
	[HideInInspector]public byte animationIndex = 0;

//Scene 4
	int randBubblePop;


	void Start () {
		//plates, planets
		usedMainObjects = new List<GameObject>();
		//cakes, balls
		usedTouchableObject = new List<GameObject>();
		touchNumbers = (TouchNumbers)GameObject.Find("shirmas").GetComponent(typeof(TouchNumbers));
		closeScript = (CloseScript)GameObject.Find("Redcross").GetComponent(typeof(CloseScript));
		numChange = GameObject.Find("numb_container").GetComponent<NumChange>();

		usedBallsAnimation = new List<int>();
	}

	void Update() {
						int nbTouches = Input.touchCount;
		
							if (nbTouches > 0) {
						if (Input.GetTouch (0).phase == TouchPhase.Began && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo (0).IsName ("curtains_open_idle") && !touchNumbers.cakeEndMove && !objectMove) {
								//if (Input.GetMouseButtonDown (0) && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo (0).IsName ("curtains_open_idle") && !touchNumbers.cakeEndMove && !objectMove) {
								if (closeProcessOnline) {
										closeProcessOnline = false;
								}
								//	hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
								hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position), Vector2.zero);
					if (hit.transform != null && hit.collider != null && hit.collider.tag == "cakerocket") {
										if (!usedTouchableObject.Contains (hit.transform.gameObject)) {
												tObject = GameObject.Find (hit.transform.gameObject.name);

//return to start position control
												if (touchNumbers.currentSceneNum == 1) {

														startPosition = tObject.transform.position;
												}
//drag control
												if ((touchNumbers.currentSceneNum == 1) || (touchNumbers.currentSceneNum == 2)) {
														if (!distanceGet) {
																distance = Vector3.Distance (tObject.transform.position, Camera.main.transform.position);
								
																if (touchNumbers.currentSceneNum == 1) {
																		childStartPoint = tObject.transform.Find ("cake1").localPosition;
																}
																distanceGet = true;
															}
//flick control
														}
						if (touchNumbers.currentSceneNum == 3) {
							startFlickPositionY = Input.GetTouch (0).position.y;
							flickStartTime = Time.time;
							flickStarted = true;
						}
						if (touchNumbers.currentSceneNum == 4) {
							tObject.animation.Play();
							closeScript.PlaySound();
							numChange.BackChange();
							randBubblePop = Random.Range (0, 4);
							audio.PlayOneShot (bubblePop[randBubblePop]);
							closeScript.touchCounter += 1;
						}
						isTouched = true;
										}
								}
				
						}

					

						if (isTouched) {
				if ((touchNumbers.currentSceneNum == 1) || (touchNumbers.currentSceneNum == 2)) {
								if (counter < 10) {
										counter += 1;
								}
				
								if (counter == 10) {
										isDragging = true;
					
								}
				}
						}

//execute flick
			
			if (flickStarted && !(Input.GetTouch (0).phase == TouchPhase.Ended)) {
				//	if (flickStarted && !Input.GetMouseButtonUp (0)) {
				differenceFlickPositions = Input.GetTouch (0).position.y - startFlickPositionY;
				flickFinishTime = Mathf.Abs(flickStartTime - Time.time);
				if (differenceFlickPositions < 0 || flickFinishTime >= 1f) {
					flickStarted = false;
				}
			}

//check and execute touch 
	if (Input.GetTouch (0).phase == TouchPhase.Ended && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo (0).IsName ("curtains_open_idle") && isTouched && !objectMove) {
								//if (Input.GetMouseButtonUp (0) && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo (0).IsName ("curtains_open_idle") && isTouched && !objectMove) {
								isTouched = false;
								if (counter < 10 && !isDragging) {
										if (touchNumbers.currentSceneNum == 1) {
												usedTouchableObject.Add (tObject);
										}

if ((touchNumbers.currentSceneNum == 1) || (touchNumbers.currentSceneNum == 2)) {
												arrayCounter = 1;
						while (usedMainObjects.Contains(touchNumbers.sceneObjects[arrayCounter])) {
							arrayCounter += 1;
						}
						Debug.Log("ArrayCount " + arrayCounter);
						Debug.Log("sceneObj " + touchNumbers.sceneObjects[arrayCounter]);
						usedMainObjects.Add (touchNumbers.sceneObjects [arrayCounter]);
					}
					if (touchNumbers.currentSceneNum == 1) {
												endPoint = touchNumbers.sceneObjects [arrayCounter].transform.position - childStartPoint;
												objectMove = true;

										}

										if (touchNumbers.currentSceneNum == 2) {
												endPoint = touchNumbers.sceneObjects [arrayCounter].transform.position;
												rocketRotate = true;
										}
								}

//ball flick Scene 3 

if (flickStarted) {
										isTouched = false;
										flickStarted = false;
										arrayCounter = 0;
										if (tObject.transform.position.x <= 0) {
												animationIndex = 1;
												endPoint = leftBallEndPoint;
						
										} else {
												animationIndex = 2;
												endPoint = rightBallEndPoint;
										}
					usedTouchableObject.Add (tObject);
										objectMove = true;
										tObject.transform.FindChild ("football_ten").GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
					
								}


// movement over Main objects
								if ((touchNumbers.currentSceneNum == 1) || (touchNumbers.currentSceneNum == 2)) {
										if (overMainObject && !isReturning && isDragging) {
												
												usedMainObjects.Add (activeMainObject);

												if (touchNumbers.currentSceneNum == 1) {
							                            usedTouchableObject.Add (tObject);
							

														endPoint = mainObjectCoordinates - childStartPoint; 
												}

												if (touchNumbers.currentSceneNum == 2) {
														endPoint = mainObjectCoordinates;
												}

												objectMove = true;
										} else {
												if (touchNumbers.currentSceneNum == 1) {
														isReturning = true;
												}
											
										}

		
					                    distanceGet = false;
										counter = 0;
										isDragging = false;
										overMainObject = false;
								}
						}

		

//object follows after the mouse/touch
						if (isDragging) {
								ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
								//ray = Camera.main.ScreenPointToRay (Input.mousePosition);
								Vector3 rayPoint = ray.GetPoint (distance);
				if ((touchNumbers.currentSceneNum == 3) || (touchNumbers.currentSceneNum == 2)) {
					if (tObject != null) {
					tObject.rigidbody2D.transform.position = rayPoint;
					}
				}
				if (touchNumbers.currentSceneNum == 1) {
					if (tObject != null) {
					tObject.rigidbody2D.transform.position = rayPoint - childStartPoint;
					}
				}
				if (tObject != null) {
								tObject.transform.rotation = new Quaternion (0, 0, 0, 0);
				}
				
						}
		}


		if (objectMove) {
			lerpMoving += Time.deltaTime;
			if (touchNumbers.currentSceneNum == 1) {
				Quaternion newRotation = Quaternion.AngleAxis (5, Vector3.forward);
				tObject.transform.position = Vector3.MoveTowards (tObject.transform.position, endPoint, speedCake*lerpMoving);
				tObject.transform.rotation = Quaternion.Slerp (tObject.transform.rotation, newRotation, .05f); 
			}
			
			if (touchNumbers.currentSceneNum == 2) {
				tObject.transform.position = Vector3.MoveTowards (tObject.transform.position, endPoint, speedRocket*lerpMoving);
			}
			
			if (touchNumbers.currentSceneNum == 3) {
				
				tObject.transform.position = Vector3.MoveTowards (tObject.transform.position, endPoint, ballSpeed*lerpMoving);
			}
			
			if (tObject.transform.position == endPoint) {
				closeScript.PlaySound ();
				objectMove = false;
				if (touchNumbers.currentSceneNum == 3) {
					isStriked = true;
					if (endPoint == leftBallEndPoint) {
						ballAnimationIndex = 1;
					}
					else { ballAnimationIndex = 2; }
					
				}
				
				numChange.BackChange();
				closeScript.touchCounter += 1;
				
				if (touchNumbers.currentSceneNum == 2) {
					usedMainObjects[closeScript.touchCounter-1].transform.FindChild("flag_3").GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
				}
				
				lerpMoving = 0f;
				isDragging = false;
			}
			
		}
// close after every plate has been touched
		if (closeScript.touchCounter == touchNumbers.numberFingers && !closeProcessOnline) {
			closeProcessOnline = true;
			closeScript.startClosing ();
			lerpMoving = 0f;
			
			if (touchNumbers.currentSceneNum == 1) {	
				
				for (int i=0; i<touchNumbers.sceneObjects.Length-1; i++) {
					speedExit [i] = Random.Range (1, 10);
				}
				audio.PlayOneShot (munch);
			}
			
			if (touchNumbers.currentSceneNum == 2) {
				audio.PlayOneShot (endSpace);
				
			}
			
		}

		//finishing move for cakes
		if (touchNumbers.currentSceneNum == 1) {
			if (touchNumbers.cakeEndMove) {
				for (int i=0; i<usedMainObjects.Count; i++) {
					usedTouchableObject [i].transform.position = Vector3.MoveTowards (usedTouchableObject [i].transform.position, 2 * usedTouchableObject [i].transform.position, speedExit [i] / 25);
					usedMainObjects [i].transform.position = Vector3.MoveTowards (usedMainObjects [i].transform.position, 2 * usedMainObjects [i].transform.position, speedExit [i] / 25);
				}
			}
		}
		//return object to the start point after drag
		if (isReturning) {
			lerpMoving += Time.deltaTime;
			tObject.transform.position = Vector3.MoveTowards (tObject.transform.position, startPosition, speedCake * lerpMoving);
			if (tObject.transform.position == startPosition) {
				isReturning = false;
				lerpMoving = 0;
			}
		}

		//rotation of rocket, scene 2
		if (rocketRotate) {
			Transform nose = tObject.transform.FindChild("nose");
			targetDirection = (endPoint - nose.position);
			targetDirection.z = 0;
			rocketDirection = (nose.position - tObject.transform.position);
			targetDirection.Normalize();
			rocketDirection.Normalize ();
			cross = Vector3.Cross(rocketDirection, targetDirection);
			if((cross.z < 0 && isForwardRotate == 1) || (cross.z > 0 && isForwardRotate == 2))
			{
				rocketRotate = false;
				objectMove = true;
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
		


}
}

