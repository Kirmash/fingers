using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchController : MonoBehaviour {

	[HideInInspector]public bool isDragging = false;
	[HideInInspector]public float distance;
	[HideInInspector]public bool isTouched;
	[HideInInspector]public bool isReturning;
	[HideInInspector]public bool distanceGet;

	public Animation anim;
    private OptionsScript optionsScript;


    public AudioClip endSpace;
	public AudioClip[] bubblePop;
	public AudioClip[] starFall;
	public AudioClip endChoir;
	public AudioClip[] appleOhh;

	private Vector3 startPosition;

	[HideInInspector]public GameObject tObject;

	private Ray ray;

	private TouchNumbers touchNumbers;
	private CloseScript closeScript;
	private NumChange numChange;

	private int counter = 0;
		
	float speedCake = 12f;
	float lerpMoving = 0;

	private Vector3 tempVectorY;
	
	Vector3 endPoint;
	Vector3 childStartPoint;
	//[HideInInspector]public bool cakeEndMove = false;
	private float[] speedExit = new float[8]; 
	[HideInInspector]public List<GameObject> usedMainObjects;
	[HideInInspector]public List<GameObject> usedTouchableObject;

	[HideInInspector]public bool objectMove;
    [HideInInspector] public bool closeProcessOnline;
	private RaycastHit2D hit;

	[HideInInspector]public GameObject activeMainObject;

	private int arrayCounter;
	private CircleCollider2D activePlateCollider;

	[HideInInspector]public bool overMainObject = false; 
	[HideInInspector]public Vector3 mainObjectCoordinates;

	//Scene cakes 1
	public AudioClip cakeCut;
	public AudioClip munchSingle;
	public AudioClip munchMany;
	private bool ifPlayedCutSound;

	//Scene rocket 2
	private bool rocketRotate;
	float speedRocket = 2f;
	float deltaSpeedRocket = 0.05f;
	float rotationSpeed = 300f;
	float rotationFlightSpeed = 0.2f;
	float normalizedDistance = 1.9f;
	Vector3 targetDirection;
	Vector3 rocketDirection;
	Vector3 cross;
	private byte isForwardRotate = 0;
	private float targetScale = 0.6f;
	private float shrinkSpeed = 10f;
	private bool thisTouched;
	private Quaternion rightAngle = Quaternion.Euler (0f,0f,180f);
	private Quaternion leftAngle = Quaternion.Euler (0f,0f,0f);
	float distanceBetweenObjects;
	float halfTheDistance;
	bool isDistanceGot;
	private Vector3 rocketEndPoint = new Vector3 (10f, 7f, 0f);
	private Vector3 rocketOffset = new Vector3 (0f, -0.3f, 0f);
	public AudioClip rocketLaunch;
	public AudioClip[] peopleLanding;

//Scene football 3
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
	[HideInInspector]public bool isFinishingFootball = false;
	public AudioClip[] ballFlick;
	public AudioClip[] endOfGame;

//Scene bubbles 4
	int randBubblePop;

//Scene carrots 5
	float distanceBetweenCarrotHippo;
	bool doneDraggingCarrot = false;
	public AudioClip[] hippoMunch;
	public AudioClip[] hippoOpenMouth;
	public AudioClip hippoFinalMunch;
	private AudioClip lastPlayedOpenMouth;


//Scene apples 6
	bool isForceNeedToBeAdded = false;
	private AnimationClip[] appleAnimation;
	
//Scene stars 7
//Scene rabbits 9
	private float butteflyScaleRandomizer;
	private Vector3 butterflyScale;

//Scene choir 10 
	[HideInInspector]public bool isChoirFinish;

    //Scene tea 11
    private Vector3 teaOffset = new Vector3 (-2.1f, -2.7f, 0);
	private float speedKettle = 1f;
	public AudioClip teaPouring;
    private Vector3 worldCenter;

	void Start () {
		//plates, planets
		usedMainObjects = new List<GameObject>();
		//cakes, balls
		usedTouchableObject = new List<GameObject>();
		touchNumbers = (TouchNumbers)GameObject.Find("shirmas").GetComponent(typeof(TouchNumbers));
		closeScript = (CloseScript)GameObject.Find("Redcross").GetComponent(typeof(CloseScript));
		numChange = GameObject.Find("numb_container").GetComponent<NumChange>();
        optionsScript = (OptionsScript)GameObject.Find("backOptions").GetComponent(typeof(OptionsScript));
        worldCenter = new Vector3(0f, 0f, 0f);
        usedBallsAnimation = new List<int>();
			}

    void Update() {
        int nbTouches = Input.touchCount;

        if (nbTouches > 0) {
            if (Input.GetTouch(0).phase == TouchPhase.Began && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_open_idle") && !touchNumbers.cakeEndMove && !objectMove) {
                //if (Input.GetMouseButtonDown (0) && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo (0).IsName ("curtains_open_idle") && !touchNumbers.cakeEndMove && !objectMove) {
                if (closeProcessOnline) {
                    closeProcessOnline = false;
                }
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
                //touch on space object / or teaParty object 
                if (hit.transform != null && hit.collider != null && hit.collider.tag == "spacestuff") {
                    if (!usedMainObjects.Contains(hit.transform.gameObject) && ((touchNumbers.currentSceneNum == 11) || (touchNumbers.currentSceneNum == 2))) {
                        thisTouched = true;
                        tObject = GameObject.Find(hit.transform.gameObject.name);
                        usedMainObjects.Add(tObject);
                        if (touchNumbers.currentSceneNum == 11) {
                            mainObjectCoordinates.x = hit.collider.gameObject.transform.position.x + hit.collider.gameObject.GetComponent<BoxCollider2D>().offset.x;
                            mainObjectCoordinates.y = hit.collider.gameObject.transform.position.y + hit.collider.gameObject.GetComponent<BoxCollider2D>().offset.y;
                            endPoint = mainObjectCoordinates - teaOffset;
                            activeMainObject = hit.collider.gameObject;
                            tObject = GameObject.Find("002. teapot(Clone)");
                            objectMove = true;
                        } else {
                            endPoint = tObject.transform.position + rocketOffset;
                            tObject.GetComponent<BoxCollider2D>().enabled = false;
                            tObject.GetComponent<Animator>().SetBool("isStill", true);
                            tObject = GameObject.Find("spaceObject11(Clone)");
                            rocketRotate = true;
                        }
                    }
                }
                if (hit.transform != null && hit.collider != null && hit.collider.tag == "cakerocket" && !thisTouched) {

                    //Debug.Log(hit.transform);	
                    //	Debug.Log(hit.transform.position);			
                    if (!usedTouchableObject.Contains(hit.transform.gameObject)) {
                        tObject = GameObject.Find(hit.transform.gameObject.name);

                        if (touchNumbers.currentSceneNum == 6 && tObject.transform.Find("apple_calm").gameObject.activeSelf) {
                            tObject.transform.Find("apple_calm").gameObject.SetActive(false);
                            tObject.transform.Find("apple_open").gameObject.SetActive(true);
                            if (optionsScript.colliderBlocker == 1)
                            {
                                randBubblePop = Random.Range(0, 4);
                                GetComponent<AudioSource>().PlayOneShot(appleOhh[randBubblePop]);
                            } else {
                                randBubblePop = Random.Range(0, 10);
                                GetComponent<AudioSource>().PlayOneShot(appleOhh[randBubblePop]);
                            }

                        }
                        //	Debug.Log(tObject);
                        //return to start position control
                        if (touchNumbers.currentSceneNum == 1) {

                            startPosition = tObject.transform.position;
                            childStartPoint = tObject.transform.Find("cake1").localPosition;
                        }
                        //drag control
                        if ((touchNumbers.currentSceneNum == 1) || (touchNumbers.currentSceneNum == 2) || (touchNumbers.currentSceneNum == 6)) {
                            if (!distanceGet) {
                                distance = Vector3.Distance(tObject.transform.position, Camera.main.transform.position);
                                if (touchNumbers.currentSceneNum == 1) {
                                    childStartPoint = tObject.transform.Find("cake1").localPosition;
                                }
                                distanceGet = true;
                            }
                        }
                        //flick control

                        if (touchNumbers.currentSceneNum == 3) {
                            startFlickPositionY = Input.GetTouch(0).position.y;
                            flickStartTime = Time.time;
                            flickStarted = true;
                        }
                        //end of Flick control 

                        //Bubble pop						
                        if (touchNumbers.currentSceneNum == 4) {
                            tObject.GetComponent<Animation>().Play();
                            closeScript.PlaySound();
                            numChange.BackChange();
                            randBubblePop = Random.Range(0, 4);
                            GetComponent<AudioSource>().PlayOneShot(bubblePop[randBubblePop]);
                            closeScript.touchCounter += 1;
                        }
                        //Star fall						
                        if (touchNumbers.currentSceneNum == 7) {
                            //Debug.Log("Playing sounds and counting");
                            closeScript.PlaySound();
                            numChange.BackChange();
                            randBubblePop = Random.Range(0, 4);
                            usedTouchableObject.Add(tObject);
                            GetComponent<AudioSource>().PlayOneShot(starFall[randBubblePop]);
                            closeScript.touchCounter += 1;
                            tObject.GetComponent<Animator>().SetFloat("fallTime", 3.0f);
                        }

                        //Clouds fly
                        if (touchNumbers.currentSceneNum == 8) {
                            //	Debug.Log("Playing sounds and counting");
                            closeScript.PlaySound();
                            //		Debug.Log(closeScript.touchCounter);
                            numChange.BackChange();
                            usedTouchableObject.Add(tObject);
                            //	Debug.Log(tObject);
                            tObject.GetComponent<Animator>().SetFloat("fallTime", 3.0f);
                            touchNumbers.InputShortLock();
                            closeScript.touchCounter += 1;
                        }

                        if (touchNumbers.currentSceneNum == 9) {
                            closeScript.PlaySound();
                            numChange.BackChange();
                            usedTouchableObject.Add(tObject);
                            randBubblePop = Random.Range(0, 4);
                            GetComponent<AudioSource>().PlayOneShot(starFall[randBubblePop]);
                            //	Debug.Log(tObject);
                            closeScript.touchCounter += 1;
                            tObject.GetComponentInChildren<Animator>().SetInteger("TransTime", 3);
                            butteflyScaleRandomizer = Random.Range(0.75f, 1f);
                            butterflyScale = new Vector3(butteflyScaleRandomizer, butteflyScaleRandomizer, butteflyScaleRandomizer);
                            tObject.transform.GetChild(5).transform.localScale = butterflyScale;
                            tObject.transform.GetChild(6).transform.localScale = butterflyScale;
                        }

                        if (touchNumbers.currentSceneNum == 10) {
                            closeScript.PlaySound();
                            numChange.BackChange();
                            usedTouchableObject.Add(tObject);
                            tObject.GetComponent<Animator>().SetInteger("isSinging", 3);
                            tObject.GetComponent<AudioSource>().Play();
                            closeScript.touchCounter += 1;
                        }
                        isTouched = true;
                    }
                }
            }

            if (isTouched) {

                if ((touchNumbers.currentSceneNum == 1) || (touchNumbers.currentSceneNum == 2) || (touchNumbers.currentSceneNum == 5) || (touchNumbers.currentSceneNum == 6)) {
                    if (counter < 10) {
                        counter += 1;
                    }

                    if (counter == 10) {
                        isDragging = true;

                    }
                }
            }

            //execute flick

            if (flickStarted && !(Input.GetTouch(0).phase == TouchPhase.Ended)) {
                //	if (flickStarted && !Input.GetMouseButtonUp (0)) {
                differenceFlickPositions = Input.GetTouch(0).position.y - startFlickPositionY;
                flickFinishTime = Mathf.Abs(flickStartTime - Time.time);
                if (differenceFlickPositions < 0 || flickFinishTime >= 1f) {
                    flickStarted = false;
                }
            }

            //check and execute touch 
            if (Input.GetTouch(0).phase == TouchPhase.Ended && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_open_idle") && isTouched && !objectMove) {
                //if (Input.GetMouseButtonUp (0) && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo (0).IsName ("curtains_open_idle") && isTouched && !objectMove) {
                isTouched = false;
                if (counter < 10 && !isDragging && (touchNumbers.currentSceneNum != 6)) {
                    if (touchNumbers.currentSceneNum == 1) {
                        usedTouchableObject.Add(tObject);
                        GetComponent<AudioSource>().PlayOneShot(cakeCut);
                    }

                    if ((touchNumbers.currentSceneNum == 1) || ((touchNumbers.currentSceneNum == 2) && !thisTouched)) {
                        arrayCounter = 1;
                        while (usedMainObjects.Contains(touchNumbers.sceneObjects[arrayCounter])) {
                            arrayCounter += 1;
                        }
                        usedMainObjects.Add(touchNumbers.sceneObjects[arrayCounter]);
                    }
                    if (touchNumbers.currentSceneNum == 1) {

                        endPoint = touchNumbers.sceneObjects[arrayCounter].transform.position - childStartPoint;
                        objectMove = true;
                    }

                    if (touchNumbers.currentSceneNum == 2 && !thisTouched) {
                        endPoint = touchNumbers.sceneObjects[arrayCounter].transform.position + rocketOffset;
                        //GetComponent<AudioSource> ().PlayOneShot (rocketLaunch);
                        //  Debug.Log("Playing sound");
                        touchNumbers.sceneObjects[arrayCounter].GetComponent<Animator>().SetBool("isStill", true);
                        rocketRotate = true;
                    }
                    thisTouched = false;
                }
                if (counter < 10 && !isDragging && (touchNumbers.currentSceneNum == 6) && (tObject.GetComponent<Rigidbody2D>().gravityScale != 1)) {
                    tObject.GetComponent<Rigidbody2D>().gravityScale = 9.81f;
                    tObject.GetComponent<Rigidbody2D>().angularDrag = 0.05f;
                    tObject.layer = 12;
                    tObject.GetComponent<Animation>().Stop();
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
                    usedTouchableObject.Add(tObject);
                    objectMove = true;
                    randBubblePop = Random.Range(0, 2);
                    GetComponent<AudioSource>().PlayOneShot(ballFlick[randBubblePop]);

                    tObject.transform.Find("football_ten").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);

                }


                // movement over Main objects
                if ((touchNumbers.currentSceneNum == 1) || (touchNumbers.currentSceneNum == 2)) {

                    if (overMainObject && !isReturning && isDragging) {
                        usedMainObjects.Add(activeMainObject);

                        if (touchNumbers.currentSceneNum == 1) {
                            usedTouchableObject.Add(tObject);
                            endPoint = mainObjectCoordinates - childStartPoint;
                        }

                        if (touchNumbers.currentSceneNum == 2) {
                            endPoint = mainObjectCoordinates + rocketOffset;
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
                    ifPlayedCutSound = false;
                }
            }
            //end check and execute touch


            //object follows after the mouse/touch
            if (isDragging) {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                //ray = Camera.main.ScreenPointToRay (Input.mousePosition);
                Vector3 rayPoint = ray.GetPoint(distance);
                if ((touchNumbers.currentSceneNum == 3) || (touchNumbers.currentSceneNum == 2) || (touchNumbers.currentSceneNum == 6) || (touchNumbers.currentSceneNum == 11)) {
                    if (tObject != null) {

                        tObject.GetComponent<Rigidbody2D>().transform.position = rayPoint;
                        if (touchNumbers.currentSceneNum == 6) {
                            distanceBetweenCarrotHippo = Vector3.Distance(tObject.transform.position, touchNumbers.basketPosition);
                            tObject.GetComponent<Animation>().Stop();

                        }
                    }
                }
                if (touchNumbers.currentSceneNum == 1) {
                    if (tObject != null) {
                        tObject.transform.Find("cake1").GetComponent<SpriteRenderer>().sortingOrder = 4;
                        if (!ifPlayedCutSound) {
                            GetComponent<AudioSource>().PlayOneShot(cakeCut);
                            ifPlayedCutSound = true;
                        }
                        tObject.GetComponent<Rigidbody2D>().transform.position = rayPoint - childStartPoint;
                    }
                }
                if (touchNumbers.currentSceneNum == 5) {
                    if (tObject != null) {
                        //Debug.Log ("Dragging carrots");
                        if (tObject.transform.Find("insideCarrot").gameObject.GetComponent<SpriteRenderer>().sortingLayerName != "octopus") {
                            tempVectorY = tObject.GetComponent<Rigidbody2D>().transform.position;
                            tempVectorY.y = rayPoint.y;
                            if ((tempVectorY.y - tObject.GetComponent<Rigidbody2D>().transform.position.y) > 0) {
                                tObject.GetComponent<Rigidbody2D>().transform.position = tempVectorY;
                            }
                            //Debug.Log(tObject.GetComponent<BoxCollider2D>().size.y/2);
                            if (tObject.GetComponent<Rigidbody2D>().transform.position.y > tObject.transform.Find("insideCarrot").gameObject.GetComponent<BoxCollider2D>().size.y) {
                                //tObject.GetComponent<Rigidbody2D>().mass = 1;

                                tObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                                tObject.GetComponent<Rigidbody2D>().isKinematic = false;
                                tObject.transform.Find("insideCarrot").gameObject.layer = 12;
                                tObject.transform.Find("insideCarrot").gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "octopus";
                                tObject.layer = 11;

                            }
                        }

                        else {
                            if (hit.transform != null && hit.collider != null && hit.collider.tag == "cakerocket") {
                                if (rayPoint.z != 0) {
                                    rayPoint.z = 0;
                                }

                                tObject.GetComponent<Rigidbody2D>().transform.position = rayPoint;
                                distanceBetweenCarrotHippo = Vector3.Distance(tObject.transform.position, touchNumbers.sceneObjects[1].transform.position);
                                // touchNumbers.sceneObjects[1].GetComponent<Animator>().Stop(); 
                                //distance-frameHippo relationship
                                if (distanceBetweenCarrotHippo > 6.5f) {
                                    touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoIdle");
                                }
                                else if ((distanceBetweenCarrotHippo <= 6.5f) && (distanceBetweenCarrotHippo > 6f))
                                {
                                    touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoOpenMouth", 0, (1f / 60f) * 7);
                                    if (lastPlayedOpenMouth != hippoOpenMouth[0]) {
                                        GetComponent<AudioSource>().PlayOneShot(hippoOpenMouth[0]);
                                        lastPlayedOpenMouth = hippoOpenMouth[0];
                                    }

                                    // touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoIdle");
                                }
                                else if ((distanceBetweenCarrotHippo <= 6f) && (distanceBetweenCarrotHippo > 5.5f))
                                {
                                    touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoOpenMouth", 0, (1f / 60f) * 15);
                                    if (lastPlayedOpenMouth != hippoOpenMouth[1]) {
                                        GetComponent<AudioSource>().PlayOneShot(hippoOpenMouth[1]);
                                        lastPlayedOpenMouth = hippoOpenMouth[1];
                                    }

                                    // touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoIdle");
                                }
                                else if ((distanceBetweenCarrotHippo <= 5.5f) && (distanceBetweenCarrotHippo > 5f))
                                {
                                    touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoOpenMouth", 0, (1f / 60f) * 23);
                                    if (lastPlayedOpenMouth != hippoOpenMouth[2]) {
                                        GetComponent<AudioSource>().PlayOneShot(hippoOpenMouth[2]);
                                        lastPlayedOpenMouth = hippoOpenMouth[2];
                                    }
                                    //touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoIdle");
                                }
                                else if ((distanceBetweenCarrotHippo <= 5f) && (distanceBetweenCarrotHippo > 4.5f))
                                {
                                    touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoOpenMouth", 0, (1f / 60f) * 31);
                                    if (lastPlayedOpenMouth != hippoOpenMouth[3]) {
                                        GetComponent<AudioSource>().PlayOneShot(hippoOpenMouth[3]);
                                        lastPlayedOpenMouth = hippoOpenMouth[3];
                                    }
                                    //touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoIdle");
                                }
                                else if ((distanceBetweenCarrotHippo <= 4.5f) && (distanceBetweenCarrotHippo > 4f))
                                {
                                    touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoOpenMouth", 0, (1f / 60f) * 39);
                                    if (lastPlayedOpenMouth != hippoOpenMouth[4]) {
                                        GetComponent<AudioSource>().PlayOneShot(hippoOpenMouth[4]);
                                        lastPlayedOpenMouth = hippoOpenMouth[4];
                                    }
                                    //touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoIdle");
                                }
                                else if ((distanceBetweenCarrotHippo <= 4f) && (distanceBetweenCarrotHippo > 3.5f))
                                {
                                    touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoOpenMouth", 0, (1f / 60f) * 45);
                                    if (lastPlayedOpenMouth != hippoOpenMouth[5]) {
                                        GetComponent<AudioSource>().PlayOneShot(hippoOpenMouth[5]);
                                        lastPlayedOpenMouth = hippoOpenMouth[5];
                                    }
                                    //   touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoIdle");
                                }
                                else if ((distanceBetweenCarrotHippo <= 3.5f) && (distanceBetweenCarrotHippo > 3f))
                                {
                                    touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoOpenMouth", 0, (1f / 60f) * 53);
                                    if (lastPlayedOpenMouth != hippoOpenMouth[6]) {
                                        GetComponent<AudioSource>().PlayOneShot(hippoOpenMouth[6]);
                                        lastPlayedOpenMouth = hippoOpenMouth[6];
                                    }
                                    // touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoIdle");
                                }
                                else if ((distanceBetweenCarrotHippo <= 3f) && (distanceBetweenCarrotHippo > 2.5f))
                                {
                                    touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoOpenMouth", 0, (1f / 60f) * 59);
                                    if (lastPlayedOpenMouth != hippoOpenMouth[7]) {
                                        GetComponent<AudioSource>().PlayOneShot(hippoOpenMouth[7]);
                                        lastPlayedOpenMouth = hippoOpenMouth[7];
                                    }
                                    //    touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoIdle");
                                }
                                else if (distanceBetweenCarrotHippo <= 2.5f)
                                {
                                    touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoOpenMouth", 0, (1f / 60f) * 59);
                                    //      touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoIdle");
                                }
                            }
                        }

                    }
                }

                if (tObject != null) {
                    tObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                }

            }
        }
        //end if_nbTouches>0
        //check if Drag is on for carrots/apples
        if (nbTouches == 0 && isDragging && (touchNumbers.currentSceneNum == 5 || touchNumbers.currentSceneNum == 6) && tObject != null) {
            isDragging = false;
            tObject.GetComponent<Rigidbody2D>().gravityScale = 5f;
            tObject.GetComponent<Rigidbody2D>().angularDrag = 0.05f;
            if (touchNumbers.currentSceneNum == 6) {
                tObject.layer = 12;
            }
            isForceNeedToBeAdded = true;
            doneDraggingCarrot = true;
            //	Debug.Log ("dragging off");
        }

        //return Hippo to idleANim
        if (nbTouches == 0 && !isDragging && touchNumbers.currentSceneNum == 5 && doneDraggingCarrot) {
            //	Debug.Log ("Here!");
            touchNumbers.sceneObjects[1].GetComponent<Animator>().Play("scene4_hippoIdle");

            doneDraggingCarrot = false;
            if (distanceBetweenCarrotHippo <= 3.5f) {
                tObject.transform.localScale -= new Vector3(1f, 1f, 1f);
                closeScript.PlaySound();
                numChange.BackChange();
                closeScript.touchCounter += 1;
                distanceBetweenCarrotHippo = 100f;
                randBubblePop = Random.Range(0, 2);
                GetComponent<AudioSource>().PlayOneShot(hippoMunch[randBubblePop]);
                counter = 0;

            }
        }


        //check if apple in the basket 
        if (nbTouches == 0 && !isDragging && touchNumbers.currentSceneNum == 6 && doneDraggingCarrot) {

            doneDraggingCarrot = false;
            if (distanceBetweenCarrotHippo <= 2.5f) {
                AppleDisappear(tObject);
            }
        }
        //end hippo/basket_Check_scene4-5-11

        // moving Objects control
        if (objectMove && !closeProcessOnline) {
            lerpMoving += Time.deltaTime;
            if (touchNumbers.currentSceneNum == 1) {
                tObject.transform.Find("cake1").GetComponent<SpriteRenderer>().sortingOrder = 3;
                Quaternion newRotation = Quaternion.AngleAxis(5, Vector3.forward);
                tObject.transform.position = Vector3.MoveTowards(tObject.transform.position, endPoint, speedCake * lerpMoving);
                tObject.transform.rotation = Quaternion.Slerp(tObject.transform.rotation, newRotation, .05f);
            }

            if (touchNumbers.currentSceneNum == 2) {
                distanceBetweenObjects = Vector3.Distance(tObject.transform.position, endPoint);
                if (!isDistanceGot) {
                    GetComponent<AudioSource>().PlayOneShot(rocketLaunch);
                    Debug.Log("Playing sound");
                    halfTheDistance = 3 * distanceBetweenObjects / 4;
                    rotationFlightSpeed = 0.2f;
                    //	Debug.Log(halfTheDistance);
                    rotationFlightSpeed = rotationFlightSpeed * ((2 * normalizedDistance) / halfTheDistance);
                    //	Debug.Log (rotationFlightSpeed);
                    isDistanceGot = true;
                }

                tObject.transform.position = Vector3.MoveTowards(tObject.transform.position, endPoint, lerpMoving * speedRocket);
                tObject.transform.localScale = Vector3.Lerp(tObject.transform.localScale, new Vector3(targetScale, targetScale, targetScale), Time.deltaTime * shrinkSpeed);
                if (distanceBetweenObjects <= halfTheDistance) {
                    //Debug.Log (speedRocket);
                    if (speedRocket > 0.3f) {
                        speedRocket -= deltaSpeedRocket;
                        deltaSpeedRocket += 0.05f;
                    }

                }
                if (distanceBetweenObjects <= (halfTheDistance / 2)) {
                    if ((tObject.transform.rotation.z < 0.5) && (tObject.transform.rotation.z > -0.5) && (tObject.transform.rotation.z != 0)) {
                        //						Debug.Log (tObject.transform.rotation.z);
                        //						Debug.Log("rotateRight");
                        tObject.transform.rotation = Quaternion.Slerp(tObject.transform.rotation, leftAngle, rotationFlightSpeed);
                    } else if ((tObject.transform.rotation.z != 1) && (tObject.transform.rotation.z != 0)) {
                        //					Debug.Log (tObject.transform.rotation.z);
                        //					Debug.Log("rotateLeft");
                        tObject.transform.rotation = Quaternion.Slerp(tObject.transform.rotation, rightAngle, rotationFlightSpeed);
                    }
                }
            }

            if (touchNumbers.currentSceneNum == 3) {

                tObject.transform.position = Vector3.MoveTowards(tObject.transform.position, endPoint, ballSpeed * lerpMoving);
            }

            if (touchNumbers.currentSceneNum == 11) {
                tObject.transform.position = Vector3.MoveTowards(tObject.transform.position, endPoint, speedKettle * lerpMoving);

                if (tObject.transform.position == endPoint) {
                    touchNumbers.InputLock();
                    tObject.GetComponent<Animator>().enabled = true;
                    tObject.GetComponent<Animator>().Play("TeaSceneTeapotIdle", -1, 1f);
                    tObject.GetComponent<Animator>().SetInteger("TeaFlows", 3);
                    tObject.GetComponent<Animator>().SetInteger("isWaiting", 1);
                    tObject.GetComponent<Animator>().Play("TeaSceneTeapotIdle", -1, 1f);
                    GetComponent<AudioSource>().PlayOneShot(teaPouring);
                    activeMainObject.GetComponent<Animator>().SetInteger("isPouring", 3);

                }
            }


            if (tObject.transform.position == endPoint && !(endPoint == rocketEndPoint)) {
                closeScript.PlaySound();
                objectMove = false;
                thisTouched = false;
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
                    speedRocket = 2f;
                    deltaSpeedRocket = 0.05f;
                    isDistanceGot = false;
                    randBubblePop = Random.Range(0, 2);
                    GetComponent<AudioSource>().PlayOneShot(peopleLanding[randBubblePop]);
                    usedMainObjects[closeScript.touchCounter - 1].transform.Find("flag_3").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                    if (usedMainObjects[closeScript.touchCounter - 1].transform.Find("fingers_space_hum2")) {
                        usedMainObjects[closeScript.touchCounter - 1].transform.Find("fingers_space_hum2").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                    }
                    if (usedMainObjects[closeScript.touchCounter - 1].transform.Find("fingers_space_hum1")) {
                        usedMainObjects[closeScript.touchCounter - 1].transform.Find("fingers_space_hum1").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                    }
                }

                lerpMoving = 0f;
                isDragging = false;
            }

        }
        //end if_objectMove

        // close after every plate has been touched
        if (closeScript.touchCounter == touchNumbers.numberFingers && !closeProcessOnline) {
            closeProcessOnline = true;
            isTouched = false;
            if (touchNumbers.currentSceneNum == 3) {
                isFinishingFootball = true;
            }

            if (touchNumbers.currentSceneNum == 1) {
                for (int i = 0; i < touchNumbers.sceneObjects.Length - 1; i++) {
                    speedExit[i] = Random.Range(5, 10);
                }
                if (touchNumbers.numberFingers <= 3) {
                    GetComponent<AudioSource>().PlayOneShot(munchSingle);
                } else {
                    GetComponent<AudioSource>().PlayOneShot(munchMany);
                }
            }

            if (touchNumbers.currentSceneNum == 2) {
                GetComponent<AudioSource>().PlayOneShot(endSpace);
                GetComponent<AudioSource>().PlayOneShot(rocketLaunch);
                Debug.Log("Playing sound");
                distanceBetweenObjects = Vector3.Distance(tObject.transform.position, rocketEndPoint);
                rocketRotate = true;
                if (!isDistanceGot) {
                    endPoint = rocketEndPoint;
                    halfTheDistance = 3 * distanceBetweenObjects / 4;
                    rotationFlightSpeed = 0.2f;
                    //	Debug.Log(halfTheDistance);
                    rotationFlightSpeed = rotationFlightSpeed * ((2 * normalizedDistance) / halfTheDistance);
                    //	Debug.Log (rotationFlightSpeed);
                    isDistanceGot = true;
                }

            }

            if (touchNumbers.currentSceneNum == 10) {
                Invoke("ChoirFinish", 2f);
            }
            if (touchNumbers.currentSceneNum == 6) {
                GetComponent<AudioSource>().PlayOneShot(endChoir);
                Invoke("AppleJumps", 0.5f);
                distanceGet = false;
            }
            if (touchNumbers.currentSceneNum == 5) {
                GetComponent<AudioSource>().PlayOneShot(hippoFinalMunch);
            }

            closeScript.startClosing();
            lerpMoving = 0f;
        }
        //end if_closeProcess

        //finishing move for rocket
        if (closeProcessOnline && isDistanceGot)
        {
            lerpMoving += Time.deltaTime;
            tObject.transform.position = Vector3.MoveTowards(tObject.transform.position, endPoint, lerpMoving * speedRocket * 0.5f);
            tObject.transform.localScale = Vector3.Lerp(tObject.transform.localScale, new Vector3(targetScale, targetScale, targetScale), Time.deltaTime * shrinkSpeed);
            if (tObject.transform.position == endPoint)
            {
                isDistanceGot = false;
                rocketRotate = false;
                lerpMoving = 0f;
            }

        }
        //finishing move for teapot
        if (tObject != null) { 
            if (!touchNumbers.isInputLocked && closeProcessOnline && touchNumbers.currentSceneNum == 11 && !tObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("TeaSceneTapotPouring"))
            {
                lerpMoving += Time.deltaTime;
                tObject.transform.position = Vector3.MoveTowards(tObject.transform.position, worldCenter, lerpMoving * speedKettle * 0.5f);
                if (tObject.transform.position == worldCenter)
                {
                    Debug.Log("Arrived");
                    lerpMoving = 0f;
                    tObject.GetComponent<Animator>().SetInteger("isLeaving", 3);
                }
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
			tObject.transform.Find("cake1").GetComponent<SpriteRenderer>().sortingOrder = 3;
			tObject.transform.position = Vector3.MoveTowards (tObject.transform.position, startPosition, speedCake * lerpMoving);
			if (tObject.transform.position == startPosition) {
				isReturning = false;
				lerpMoving = 0;
			}
		}

//rotation of rocket, scene 2
		if (rocketRotate) {
			Transform nose = tObject.transform.Find("nose");
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

	public void AppleDisappear(GameObject objectDisappear) {
		//objectDisappear.transform.localScale -= new Vector3 (1f,1f,1f);
		objectDisappear.transform.position = new Vector3 (2.91f, -5.48f, 0f);
		objectDisappear.GetComponent<Rigidbody2D>().gravityScale = 0f;
		objectDisappear.GetComponent<Rigidbody2D>().mass = 0f;
		objectDisappear.GetComponent<Rigidbody2D> ().simulated = false;
		objectDisappear.GetComponent<CircleCollider2D> ().enabled = false;
		usedMainObjects.Add (objectDisappear);
		isDragging = false;
		counter = 0;
		isTouched = false;
		closeScript.PlaySound();
		numChange.BackChange();
		closeScript.touchCounter +=1;
		distanceBetweenCarrotHippo = 100f;
		}

	private void AppleJumps () {
		for (int i = 0; i < usedMainObjects.Count; i++) {
			touchNumbers.sceneObjects [i + 3].GetComponent<CircleCollider2D> ().enabled = false;
			touchNumbers.sceneObjects[i+3].GetComponent<Animation> ().Play("appleAnimationJump" + (i+1).ToString());
			//Debug.Log (touchNumbers.sceneObjects[i+3].GetComponent<Animation> ().Play("appleAnimationJump" + (i+1).ToString()));
		}

	}

    private void ChoirFinish()
    {
        GetComponent<AudioSource>().PlayOneShot(endChoir);
        isChoirFinish = true;
    }

}

