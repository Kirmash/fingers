using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallTouchScript : MonoBehaviour {

	private TouchNumbers touchNumbers;
	private CloseScript closeScript;
	private NumChange numChange;

	public GameObject vorotaAnim;

	private bool isTouched = false;
	private bool ballMove = false;
	private bool closeProcessOnline = false;

	private GameObject tObject;
	private Ray ray;
	
	private RaycastHit2D hit;
	private int arrayCounter;
	private Vector3 endPoint;

	private Vector3 leftBallEndPoint = new Vector3 (-2,2,0);
	private Vector3 rightBallEndPoint = new Vector3 (2,2,0);

	[HideInInspector]public List<GameObject> usedBallObjects;

	private Animator animator;

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


			//if (Input.GetMouseButtonDown (0) && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_open_idle") && !ballMove) {
				//Debug.Log("Trying to hit");
				//hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
					if (closeProcessOnline) 
					{
						closeProcessOnline = false;
					}
					hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position), Vector2.zero);
				if (hit.transform != null && hit.collider != null && hit.collider.tag == "ball") {
					
					tObject = GameObject.Find (hit.transform.gameObject.name);
					//Debug.Log ("I am a TObject: " + tObject);
					isTouched = true;
					//	Debug.Log ("Touched first!");
									
				}
				
			}
			}
			//if (Input.GetMouseButtonUp (0) && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_open_idle") && isTouched && !ballMove) {
			if (Input.GetTouch (0).phase == TouchPhase.Ended  && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_open_idle") && isTouched && !ballMove) {
				isTouched = false;
			
					//	Debug.Log ("Executed let go");
					arrayCounter = 0;
					while (usedBallObjects.Contains(touchNumbers.activeBalls[arrayCounter])) {
						arrayCounter += 1;
					}
					//Debug.Log("ArrayCounter: " + arrayCounter);
					usedBallObjects.Add (touchNumbers.activeBalls[arrayCounter]);
				if (tObject.transform.position.x <= 0) 
				{
					endPoint = leftBallEndPoint;

				}

				else {

					endPoint = rightBallEndPoint;
				}

					ballMove = true;
				tObject.transform.FindChild("football_ten").GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
					closeScript.PlaySound ();

			}

		

			if (closeScript.touchCounter == touchNumbers.numberFingers && !closeScript.closeProcessOnline) {
			//	Debug.Log ("Close process");
				//			Debug.Log ("if ToyTouch " + touchNumbers.isInputLocked);
				////			touchNumbers.isInputLocked = true;
				////			Invoke("InputUnlock",touchLockTime);
				//			Debug.Log ("InputUnlock " + touchNumbers.isInputLocked);
				closeProcessOnline = true;
				closeScript.startClosing ();
				lerpMoving = 0f;
			}

				}
		if (ballMove) {
			lerpMoving += Time.deltaTime;
			//Debug.Log ("LerpMoving: " + lerpMoving); 
			//Debug.Log(endPoint);
			tObject.transform.position = Vector3.MoveTowards (tObject.transform.position, endPoint, speed*lerpMoving);
			
			if (tObject.transform.position == endPoint) {
				vorotaAnim.animation.Stop();
				ballMove = false;
				Debug.Log(vorotaAnim.animation.isPlaying);
				if (!vorotaAnim.animation.isPlaying) {
					vorotaAnim.animation.Play();
				}
				
				numChange.BackChange();
				//finishedMoving = true;
				closeScript.touchCounter += 1;
				lerpMoving = 0f;
			}
			
			
		}

			}
}
