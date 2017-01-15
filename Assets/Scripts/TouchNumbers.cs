
using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;


public class TouchNumbers : MonoBehaviour
{

    //	public AudioClip number1;
    //	public AudioClip number2;
    //	public AudioClip number3;
    //	public AudioClip number4;
    //	public AudioClip number5;
    //	public AudioClip number6;
    //	public AudioClip number7;
    //	public AudioClip number8;
    //	public AudioClip number9;
    //	public AudioClip number10;

    int[] randomScene1 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9 };
    int[] randomScene2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    int[] randomScene3 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    int[] randomScene4 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    int[] randomScene5 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    int[] randomScene6 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    int[] randomScene7 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    int[] randomScene8 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    int[] randomScene9 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9 };
    int[] randomScene10 = new int[] { 2, 3, 4, 6, 7, 8, 9 };
	
	bool is1stSceneLoaded;
	bool is2ndSceneLoaded;

    private List<int> scenes1 = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
    private List<int> scenes2 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private List<int> scenes3 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private List<int> scenes4 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private List<int> scenes5 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private List<int> scenes6 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private List<int> scenes7 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private List<int> scenes8 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private List<int> scenes9 = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
    private List<int> scenes10 = new List<int> { 2, 3, 4, 6, 7, 8, 9 };

    private List<int> numScene;
    private int[] allScenes = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    [HideInInspector] public int currentSceneNum;

	//private CloseScript closeScript;
	private NumChange numChange;
	private BackChange backChange;
	private TouchController touchController;
	private OptionsScript optionsScript;
	private numberLeftChange numberLeftChange;
	private numberRightChange numberRightChange;

	[HideInInspector] public int numberFingers = 1;

	[HideInInspector] public bool isInputLocked = false;
	[HideInInspector] public float inputLockingTime = 0.5f;

	[HideInInspector]public Animator animator;

	private int toyIndex;
	
	private float randomX;
	private float randomY;

	private int index;

	private int currCoordinateIndex;


	[HideInInspector] public GameObject[] sceneObjects;

	//arrays and assets for PlatesScene 1
	[HideInInspector] public Object[] plates;
	private int plateRandCounter;
	[HideInInspector] public GameObject[] cake;
	[HideInInspector] public GameObject[] cakeScene;
	Vector3 centerPlatePosition;
	[HideInInspector]public bool cakeEndMove = false;

	//arrays and assets for SpaceScene (2)
	[HideInInspector] public Object[] spaceObjects;

    [HideInInspector] public Vector3[] spaceCoordinatesArray;
[HideInInspector] public Vector3 rocketCoordinates = new Vector3 (3.635082f,0.4855805f,0f);
	//[HideInInspector] public GameObject[] activeSpaceObjects;
	[HideInInspector] public GameObject rocket;
	private List<int> usedCoordinates;

	//arrays and assets for FootballScene (3)
	Vector3[] ballPositionArray = new [] { new Vector3(1.1939f,-1.940f,0), new Vector3(-0.845f,-2.014f,0), new Vector3(-1.122f,-3.797f,0), new Vector3(1.2436f,-3.805f,0), new Vector3(-2.785f,-1.915f,0), new Vector3(3.1588f,-1.989f,0), new Vector3(-3.531f,-3.830f,0), new Vector3(3.6314f,-3.805f,0), new Vector3(-4.825f,-1.915f,0),new Vector3(5.1735f,-1.915f,0)};
	[HideInInspector] public GameObject[] soccerObjects;
	//[HideInInspector] public GameObject[] activeBalls;
	private GameObject tablo;
	private GameObject vratar;
	[HideInInspector] public GameObject vorota;

	//arrays and assets for BubbleScene (4)
	[HideInInspector] public GameObject[] bubbleObjects;
	Vector3[] balloonPositionArray = new [] { new Vector3(0f,0f,0),new Vector3(2f,2f,0),new Vector3(0f,-3.5f,0),new Vector3(-2f,3f,0),new Vector3(5f,0f,0),new Vector3(-5f,0f,0), new Vector3(-4.5f,-3.0f,0),new Vector3(4f,3f,0),new Vector3(-4f,-3f,0),new Vector3(5.2f,-4f,0)};

	//arrays and assets for CarrotScene (5)
	[HideInInspector] public GameObject[] carrotObjects;
	Vector3 groundPosition = new Vector3(0f, -2.98f, 0f);
	Vector3 hippoPosition = new Vector3(4f,-3.7f,0f);
	Vector3 snailPosition = new Vector3(-3.348f,-3.957f,0f);
	Vector3 butterfly1Postition = new Vector3(-5.65f,3.49f,0f);
	Vector3 butterfly2Postition = new Vector3(4.14f,3.28f,0f);
	Vector3[] carrotPositionArray = new [] {new Vector3(0.14f,0f,0),new Vector3(1.12f,0f,0),new Vector3(-1.8f,0f,0),new Vector3(2.87f,0f,0),new Vector3(-3.47f,0f,0),new Vector3(4.98f,0f,0),new Vector3(-4.51f,0f,0),new Vector3(5.8f,0,0),new Vector3(-5.5f,0,0)} ;

	//arrays and assetd for AppleScene (6)
	[HideInInspector] public GameObject[] appleObjects;
	[HideInInspector] public Vector3 basketPosition = new Vector3 (3.07f, -3.52f, 0f);
	Vector3 wormPosition = new Vector3 (-3.13f, 3.01f, 0f);
	Vector3[] applePositionsArray = new[] {new Vector3(-0.94f,2.98f,0f), new Vector3(1.63f,1.83f,0f),new Vector3(0.86f,3.29f,0f), new Vector3(0.59f,-0.61f,0f),new Vector3(-1.98f,4.55f,0f),new Vector3(-2.23f,-0.98f,0f),new Vector3(4.91f,4.05f,0f),new Vector3(-5.69f,3.16f,0f),new Vector3(5.25f,0.35f,0f), new Vector3(-4.87f,0.56f,0f)};

    //arrays and assetd for StarScene (7)
	[HideInInspector] public GameObject[] starObjects;
	Vector3[] starPositionsArray = new [] { new Vector3(-5.38f,3.83f,0),new Vector3(-4.15f,1.53f,0),new Vector3(-4.022f,-2.96f,0),new Vector3(-0.76f,2.34f,0),new Vector3(2.6f,3.93f,0),new Vector3(5.35f,2.6f,0), new Vector3(3.02f,0.73f,0),new Vector3(3.2f,-2.37f,0),new Vector3(0.63f,-4.22f,0),new Vector3(-0.34f,-1.05f,0)};
    private List<int> starUsedCoordinates;
	
	//arrays and assets for CloudScene (8)
	[HideInInspector] public GameObject[] cloudObjects;
	
	//arrays and assets for RabbitsScene (9)
	[HideInInspector] public GameObject[] rabbitsObjects;
	private float rabbitSizeRandomizer;
	private Vector3 rabbitSize = new Vector3 (0.9f, 0.9f, 0.9f);

	[HideInInspector] public int touchKey = 0;
	private int numTouch = 0;
	[HideInInspector] public int nbTouches = 0;

	
	private GameObject backScene;


	void Start () 
	{
		animator = GetComponent<Animator>();
		usedCoordinates = new List<int>();
       	//closeScript = (CloseScript)GameObject.Find("Redcross").GetComponent(typeof(CloseScript));
		numChange = (NumChange)GameObject.Find("numb_container").GetComponent(typeof(NumChange));
		backChange = (BackChange)GameObject.Find("background").GetComponent(typeof(BackChange));
		touchController = (TouchController)GameObject.Find("Main Camera").GetComponent(typeof(TouchController));
		optionsScript = (OptionsScript)GameObject.Find("backOptions").GetComponent(typeof(OptionsScript));
		numberLeftChange = (numberLeftChange)GameObject.Find("numberLeft").GetComponent(typeof(numberLeftChange));
		numberRightChange = (numberRightChange)GameObject.Find("numberRight").GetComponent(typeof(numberRightChange));
	}

	void Update () 
	{
	nbTouches = Input.touchCount;
		
		if (nbTouches > 0 && !optionsScript.isOpenedSettings) {
						RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position), Vector2.zero);
						if (hit.collider != null && hit.transform != null && hit.collider.tag == "shirma") {	
				if (numTouch == nbTouches && !isInputLocked && this.animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_idle")) {
					animator.SetBool("isShirmasOpen",true);	
					numberRightChange.spriteNumberRight.sprite = numberRightChange.numRight [nbTouches - 1];
					numberRightChange.ChangeNumber ();
					numberLeftChange.spriteNumberLeft.sprite = numberLeftChange.numLeft [nbTouches - 1];
					numberLeftChange.ChangeNumber ();
					touchKey += 1;

								}
						}	
			if (hit.collider != null && hit.transform != null && hit.collider.tag == "settings") {
				Debug.Log ("Touching options");
				optionsScript.isOpenedSettings = true;
				transform.position = new Vector3 (-12f, 0f, 0f);
				}

				}
		numTouch = nbTouches;
		if (touchKey == 25) {
			InputLock ();
			numberFingers = nbTouches;
			openSesame ();
			touchKey = 0;
		}

		if (nbTouches == 0) {
			StopTheOpening();
			touchKey = 0;
		}
	
	}

	void openSesame ()
	{
		//numberFingers = Random.Range(1, 11);
		numChange.changeBack = true;
		setNumber (numberFingers);
		animator.SetFloat ("isOpen", 2);
		animator.SetFloat ("isClosed", 0);

		}


 public	void InputUnlock()
	{
		isInputLocked = false;
		numberRightChange.numOpacity = false;
		numberLeftChange.numOpacity = false;
	}

public void InputLock()
	{
		isInputLocked = true;
		Invoke ("InputUnlock", 2f);
	}
	
	public void InputShortLock()
	{
		isInputLocked = true;
		Invoke ("InputUnlock", 0.5f);
	}


	public void StopTheOpening() 
	{
		animator.SetBool ("isShirmasOpen", false);
		numberRightChange.numOpacity = false;
		numberLeftChange.numOpacity = false;
		}


	public void setNumber (int number)
	{
		switch (number)
		{
		case 10: 
			//audio.PlayOneShot(number10);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("ten"));
//            currentSceneNum = randomScene10[Random.Range(0, randomScene10.Length)];
//               while (!scenes10.Contains(currentSceneNum)) { 
//                   currentSceneNum = randomScene10[Random.Range(0, randomScene10.Length)];
//                }
//                SceneDelete();
             currentSceneNum = 9;
                GetTheToys();
		    break;
			
		case 1: 
			//audio.PlayOneShot(number1);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("one"));
	  	currentSceneNum = randomScene1[Random.Range(0, randomScene1.Length)];
            while (!scenes1.Contains(currentSceneNum))
               {
                   currentSceneNum = randomScene1[Random.Range(0, randomScene1.Length)];
            }
                SceneDelete();
             //   currentSceneNum = 5;
                GetTheToys();
			break;
			
		case 2: 
			//audio.PlayOneShot(number2);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("two"));
			currentSceneNum = randomScene2[Random.Range(0, randomScene2.Length)];
                while (!scenes2.Contains(currentSceneNum))
                {
                    currentSceneNum = randomScene2[Random.Range(0, randomScene2.Length)];
                }
                scenes2.Remove(currentSceneNum);
                SceneDelete();
          //      currentSceneNum = 2;
                GetTheToys();
			break;
			
		case 3: 
			//audio.PlayOneShot(number3);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("three"));
		    currentSceneNum = randomScene3[Random.Range(0, randomScene3.Length)];
                while (!scenes3.Contains(currentSceneNum))
                {
                    currentSceneNum = randomScene3[Random.Range(0, randomScene3.Length)];
                }
               SceneDelete();
              //  currentSceneNum = 7;
                GetTheToys();
			break;
			
		case 4: 
			//audio.PlayOneShot(number4);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("four"));
		    currentSceneNum = randomScene4[Random.Range(0, randomScene4.Length)];
                while (!scenes4.Contains(currentSceneNum))
                {
                    currentSceneNum = randomScene4[Random.Range(0, randomScene4.Length)];
                }
                SceneDelete();
                //currentSceneNum = 4;
                GetTheToys();
			break;
			
		case 5: 
			//audio.PlayOneShot(number5);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("five"));
         currentSceneNum = randomScene5[Random.Range(0, randomScene5.Length)];
                while (!scenes5.Contains(currentSceneNum))
                {
                    currentSceneNum = randomScene5[Random.Range(0, randomScene5.Length)];
                }
                SceneDelete();
                //   currentSceneNum = 5;
                GetTheToys();
			break;
			
		case 6: 
			//audio.PlayOneShot(number6);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("six"));
		    currentSceneNum = randomScene6[Random.Range(0, randomScene6.Length)];
                while (!scenes6.Contains(currentSceneNum))
                {
                    currentSceneNum = randomScene6[Random.Range(0, randomScene6.Length)];
                }
                SceneDelete();
                //currentSceneNum = 3;
                GetTheToys();
			break;
			
		case 7: 
			//audio.PlayOneShot(number7);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("seven"));
		   currentSceneNum = randomScene7[Random.Range(0, randomScene7.Length)];
                while (!scenes7.Contains(currentSceneNum))
                {
                    currentSceneNum = randomScene7[Random.Range(0, randomScene7.Length)];
                }
                SceneDelete();
              //  currentSceneNum = 7;
                GetTheToys();
			break;
			
		case 8: 
			//audio.PlayOneShot(number8);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("eight"));
		    currentSceneNum = randomScene8[Random.Range(0, randomScene8.Length)];
                while (!scenes8.Contains(currentSceneNum))
                {
                    currentSceneNum = randomScene8[Random.Range(0, randomScene8.Length)];
                }
                SceneDelete();
                //currentSceneNum = 3;
                GetTheToys();
			break;
			
		case 9: 
			//audio.PlayOneShot(number9);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("nine"));
		    currentSceneNum = randomScene9[Random.Range(0, randomScene9.Length)];
                while (!scenes9.Contains(currentSceneNum))
                {
                    currentSceneNum = randomScene9[Random.Range(0, randomScene9.Length)];
                }
                SceneDelete();
                //currentSceneNum = 5;
                GetTheToys ();
			break;
		}
		
	}


	//Choosing the scene for particular numbers
	void GetTheToys () {
				switch (currentSceneNum) {
		case 1:
			plates = Resources.LoadAll("plates", typeof(GameObject)).Cast<GameObject> ().ToArray ();
			cake = Resources.LoadAll("cakes", typeof(GameObject)).Cast<GameObject> ().ToArray ();
			backChange.isBackChanging = true;
			LoadScene1(numberFingers);
			break;

		case 2:
			spaceObjects = Resources.LoadAll("spaceObjects", typeof(GameObject)).Cast<GameObject> ().ToArray ();
			backChange.isBackChanging = true;
			LoadScene2 (numberFingers);
			break;

		case 3: 
			soccerObjects = Resources.LoadAll("footballBalls", typeof(GameObject)).Cast<GameObject> ().ToArray (); 
			backChange.isBackChanging = true;
			LoadScene3 (numberFingers);
			break;

		case 4:
				bubbleObjects = Resources.LoadAll("bubbles", typeof(GameObject)).Cast<GameObject> ().ToArray ();
				backChange.isBackChanging = true;
			LoadScene4 (numberFingers);	 
			break;

		case 5:
			carrotObjects = Resources.LoadAll ("carrots", typeof(GameObject)).Cast<GameObject> ().ToArray ();
			backChange.isBackChanging = true;
			LoadScene5 (numberFingers);
			break;

		case 6:
		appleObjects = Resources.LoadAll ("apples", typeof(GameObject)).Cast<GameObject> ().ToArray ();
		backChange.isBackChanging = true;
		LoadScene6 (numberFingers);
		break;
		
		case 7: 
			starObjects = Resources.LoadAll ("stars", typeof(GameObject)).Cast<GameObject> ().ToArray ();
			backChange.isBackChanging = true;
		LoadScene7 (numberFingers);
				break;
		
		case 8: 
		cloudObjects = Resources.LoadAll ("Clouds", typeof(GameObject)).Cast<GameObject> ().ToArray ();
		backChange.isBackChanging = true;
		LoadScene8 (numberFingers);
	// rabbitsObjects = Resources.LoadAll ("Rabbits", typeof(GameObject)).Cast<GameObject> ().ToArray ();
	//	LoadScene9 (numberFingers);
					break;
					
		case 9: 
		rabbitsObjects = Resources.LoadAll ("Rabbits", typeof(GameObject)).Cast<GameObject> ().ToArray ();
		backChange.isBackChanging = true;
		LoadScene9 (numberFingers);
		break;
		
		}
		}


//Handler for loading the scenes

//tort
	void LoadScene1 (int numberF)
	{ 
		numChange.spriteRenderer.color = new Color(1f,1f,1f,1f);
		sceneObjects = new GameObject[numberF+1];
		cakeScene = new GameObject[8];
		centerPlatePosition = new Vector3 (0.27f, 0f, 0);
		sceneObjects[0] = GameObject.Instantiate (plates[0], centerPlatePosition, Quaternion.identity) as GameObject;
		for (int j = 0; j<8; j++) {
			cakeScene[j] = GameObject.Instantiate (cake[j], Vector3.zero, Quaternion.identity) as GameObject;
									}
	switch (numberF) 
		{
		case 2:
			Vector3[] platePositionArray2 = new [] { new Vector3(6.3f,0f,0), new Vector3(-5.95f,0f,0) };
			for (int i = 1; i < numberF+1; i++) {
				plateRandCounter = Random.Range(1,7);
				sceneObjects [i] = GameObject.Instantiate (plates[plateRandCounter], platePositionArray2[i-1], Quaternion.identity) as GameObject;
			}
			break;

		case 3:
			Vector3[] platePositionArray3 = new [] { new Vector3(-3.52f,4.55f,0), new Vector3(5.85f,-1.65f,0), new Vector3(-3.74f,-4.33f,0) };
			for (int i = 1; i < numberF+1; i++) {
				plateRandCounter = Random.Range(1,7);
				sceneObjects [i] = GameObject.Instantiate (plates[plateRandCounter], platePositionArray3[i-1], Quaternion.identity) as GameObject;
			}
			break;

		case 4:
			Vector3[] platePositionArray4 = new [] { new Vector3(3.55f,4.76f,0), new Vector3(5.79f,-1.37f,0), new Vector3(-3.29f,-4.64f,0), new Vector3(-5.57f,1.07f,0) };
				for (int i = 1; i < numberF+1; i++) {
				plateRandCounter = Random.Range(1,7);
				sceneObjects [i] = GameObject.Instantiate (plates[plateRandCounter], platePositionArray4[i-1], Quaternion.identity) as GameObject;
			}
				break;

		case 5:
			Vector3[] platePositionArray5 = new [] { new Vector3(0.16f,5.48f,0), new Vector3(6.3f,-0.03f,0), new Vector3(3.58f,-4.91f,0), new Vector3(-3.31f,-4.92f,0), new Vector3(-5.9f,-0.05f,0) };
					for (int i = 1; i < numberF+1; i++) {
				plateRandCounter = Random.Range(1,7);
				sceneObjects [i] = GameObject.Instantiate (plates[plateRandCounter], platePositionArray5[i-1], Quaternion.identity) as GameObject;
			}
				break;

		case 6:
			Vector3[] platePositionArray6 = new [] {  new Vector3(3.63f,4.9f,0), new Vector3(6.35f,0f,0), new Vector3(3.62f,-4.71f,0), new Vector3(-3.26f,-4.77f,0), new Vector3(-5.88f,0.02f,0), new Vector3(-3.27f,4.89f,0) };
						for (int i = 1; i < numberF+1; i++) {
				plateRandCounter = Random.Range(1,7);
				sceneObjects [i] = GameObject.Instantiate (plates[plateRandCounter], platePositionArray6[i-1], Quaternion.identity) as GameObject;
				}
					break;

		case 7:
			Vector3[] platePositionArray7 = new [] { new Vector3(3.56f,4.89f,0), new Vector3(6.32f,0f,0), new Vector3(6.12f,-4.75f,0), new Vector3(0.15f,-5.55f,0), new Vector3(-5.77f,-4.81f,0), new Vector3(-5.92f,0f,0), new Vector3(-3.29f,4.89f,0) };
							for (int i = 1; i < numberF+1; i++) {
				plateRandCounter = Random.Range(1,7);
				sceneObjects [i] = GameObject.Instantiate (plates[plateRandCounter], platePositionArray7[i-1], Quaternion.identity) as GameObject;
				}
					break;

		case 8:
			Vector3[] platePositionArray8 = new [] {new Vector3(6.12f,4.89f,0), new Vector3(6.32f,0f,0), new Vector3(6.12f,-4.75f,0), new Vector3(0.15f,-5.55f,0), new Vector3(-5.77f,-4.81f,0), new Vector3(-5.92f,0f,0), new Vector3(-5.75f,4.86f,0), new Vector3(0.14f,5.57f,0) };
								for (int i = 1; i < numberF+1; i++) {
				plateRandCounter = Random.Range(1,7);
				sceneObjects [i] = GameObject.Instantiate (plates[plateRandCounter], platePositionArray8[i-1], Quaternion.identity) as GameObject;
				}
					break;
		}
		}

//space 
	void LoadScene2 (int numberF)
	{
        spaceCoordinatesArray = new Vector3[]  { new Vector3(-3.852236f, 3.1f, 0f), new Vector3(-2.534921f, -1.356382f, 0f), new Vector3(-5.007737f, 0.8001435f, 0f), new Vector3(-3.846421f, -3.674136f, 0f), new Vector3(0.2980204f, 2.75679f, 0f), new Vector3(4.4626f, 3.274817f, 0f), new Vector3(1.330779f, -2.177835f, 0f), new Vector3(5.25f, -1.369833f, 0f), new Vector3(0.373147f, -3.8f, 0f), new Vector3(4.802197f, -3.464654f, 0f) };
        backScene = GameObject.Instantiate (spaceObjects[11], Vector3.zero, Quaternion.identity) as GameObject;
		sceneObjects = new GameObject[numberF+1];
		sceneObjects[0] = GameObject.Instantiate (spaceObjects[0], rocketCoordinates, Quaternion.identity) as GameObject;
		currCoordinateIndex = Random.Range (0, 4);
		numChange.spriteRenderer.color = new Color(1f,1f,1f,0.3f);
		for (int i = 1; i <= numberF; i++) {
			while (usedCoordinates.Contains(currCoordinateIndex))
			{
				currCoordinateIndex = Random.Range (0, 10);
			}
            sceneObjects[i] = GameObject.Instantiate(spaceObjects[i], spaceCoordinatesArray[currCoordinateIndex],Quaternion.identity) as GameObject;

			usedCoordinates.Add (currCoordinateIndex);
		}
		usedCoordinates.Clear ();
		
	}

//football
	void LoadScene3 (int numberF) {

		sceneObjects = new GameObject[numberF];
		vorota =  GameObject.Instantiate (soccerObjects[0], Vector3.zero, Quaternion.identity) as GameObject;
		vratar =  GameObject.Instantiate (soccerObjects[1], Vector3.zero, Quaternion.identity) as GameObject;
		numChange.spriteRenderer.color = new Color(1f,1f,1f,1f);
		tablo =  GameObject.Instantiate (soccerObjects[2], soccerObjects[2].transform.position, Quaternion.identity) as GameObject;
		currCoordinateIndex = Random.Range (0, 10);
	for (int i = 0; i < numberF; i++) {
			sceneObjects[i] = GameObject.Instantiate(soccerObjects[i+3], ballPositionArray[i],Quaternion.identity) as GameObject;		
	}
	}

//bubbles
	void LoadScene4 (int numberF) {
		sceneObjects = new GameObject[numberF];
        numChange.spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        backScene = GameObject.Instantiate (bubbleObjects[10], Vector3.zero, Quaternion.identity) as GameObject;
		for (int i = 0; i < numberF; i++) {
			sceneObjects[i] = GameObject.Instantiate(bubbleObjects[i], balloonPositionArray[i], Quaternion.identity) as GameObject;
		}
	}
		

//carrots
	void LoadScene5 (int numberF) {
		sceneObjects = new GameObject[numberF+5];
        numChange.spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        //load ground
        //Debug.Log ("Loading scene");
        sceneObjects[0] = GameObject.Instantiate(carrotObjects[19], groundPosition, Quaternion.identity) as GameObject;
		sceneObjects[1] = GameObject.Instantiate(carrotObjects[15], hippoPosition, Quaternion.identity) as GameObject;
		sceneObjects[2] = GameObject.Instantiate(carrotObjects[16], butterfly1Postition, Quaternion.identity) as GameObject;
		sceneObjects[3] = GameObject.Instantiate(carrotObjects[17], butterfly2Postition, Quaternion.identity) as GameObject;
		sceneObjects[4] = GameObject.Instantiate(carrotObjects[18], snailPosition, Quaternion.identity) as GameObject; 	
		currCoordinateIndex = Random.Range (0, 15);
		//Debug.Log (currCoordinateIndex);
		for (int i = 0; i < numberF; i++) {
			while (usedCoordinates.Contains(currCoordinateIndex))
			{
				currCoordinateIndex = Random.Range (0, 15);
			}
			sceneObjects[i+5] = GameObject.Instantiate(carrotObjects[currCoordinateIndex], carrotPositionArray[i],Quaternion.identity) as GameObject;
			//Debug.Log (sceneObjects[i+5]);
			usedCoordinates.Add (currCoordinateIndex);
		}
		usedCoordinates.Clear ();
	}

//starsScene loading
 private void LoadScene7 (int numberF) {
 sceneObjects = new GameObject [numberF + 1];
  numChange.spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
 sceneObjects[0] = GameObject.Instantiate(starObjects[10], transform.position, Quaternion.identity) as GameObject;
 currCoordinateIndex = Random.Range (0, 4);
numChange.spriteRenderer.color = new Color(1f,1f,1f,0.3f);
 for (int i = 1; i <= numberF; i++) {
			while (usedCoordinates.Contains(currCoordinateIndex))
			{
				currCoordinateIndex = Random.Range (0, 10);
			}
            sceneObjects[i] = GameObject.Instantiate(starObjects[currCoordinateIndex], starPositionsArray[currCoordinateIndex],Quaternion.identity) as GameObject;
			usedCoordinates.Add (currCoordinateIndex);
		}
		usedCoordinates.Clear ();

 }

	//appleScene loading
	private void LoadScene6(int numberF) {
		sceneObjects = new GameObject[numberF+3];
        numChange.spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        sceneObjects[0] = GameObject.Instantiate(appleObjects[10], transform.position, Quaternion.identity) as GameObject;
		sceneObjects[1] = GameObject.Instantiate(appleObjects[11], wormPosition, Quaternion.identity) as GameObject;
		sceneObjects[2] = GameObject.Instantiate(appleObjects[12], basketPosition, Quaternion.identity) as GameObject;
		for (int i = 0; i<numberF; i++) {
			sceneObjects[i+3] = GameObject.Instantiate(appleObjects[i], applePositionsArray[i],Quaternion.identity) as GameObject;
		}
	}
	
	//cloudScene loading
	private void LoadScene8(int numberF) {
		sceneObjects = new GameObject[numberF+1];
        numChange.spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
		for (int i = 0; i<numberF+1; i++) {
			sceneObjects[i] = GameObject.Instantiate(cloudObjects[i], cloudObjects[i].transform.position,Quaternion.identity) as GameObject;
		}
	}
		
	//rabbitScene loading
	private void LoadScene9(int numberF) {
		sceneObjects = new GameObject[numberF];
        numChange.spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
		for (int i = 0; i<numberF; i++) {
			rabbitSizeRandomizer = Random.Range (0.75f, 0.9f);
			rabbitSize = new Vector3 (rabbitSizeRandomizer, rabbitSizeRandomizer, rabbitSizeRandomizer);
			sceneObjects[i] = GameObject.Instantiate(rabbitsObjects[i], rabbitsObjects[i].transform.position,Quaternion.identity) as GameObject;
			sceneObjects [i].transform.localScale = rabbitSize;
		}
	}

	
  ///<summary>
  /// Delete scene && reload if needed
  /// </summary>
 private void SceneDelete()
    {
        if (scenes1.Contains(currentSceneNum))
            scenes1.Remove(currentSceneNum);
        if (scenes2.Contains(currentSceneNum))
            scenes2.Remove(currentSceneNum);
        if (scenes3.Contains(currentSceneNum))
            scenes3.Remove(currentSceneNum);
        if (scenes4.Contains(currentSceneNum))
            scenes4.Remove(currentSceneNum);
        if (scenes5.Contains(currentSceneNum))
            scenes5.Remove(currentSceneNum);
        if (scenes6.Contains(currentSceneNum))
            scenes6.Remove(currentSceneNum);
        if (scenes7.Contains(currentSceneNum))
            scenes7.Remove(currentSceneNum);
        if (scenes8.Contains(currentSceneNum))
            scenes8.Remove(currentSceneNum);
        if (scenes9.Contains(currentSceneNum))
            scenes9.Remove(currentSceneNum);
        if (scenes10.Contains(currentSceneNum))
            scenes10.Remove(currentSceneNum);

        if (scenes1.Count == 0)
            scenes1.AddRange(randomScene1);
        if (scenes2.Count == 0)
            scenes2.AddRange(randomScene2);
        if (scenes3.Count == 0)
            scenes3.AddRange(randomScene3);
        if (scenes4.Count == 0)
            scenes4.AddRange(randomScene4);
        if (scenes5.Count == 0)
            scenes5.AddRange(randomScene5);
        if (scenes6.Count == 0)
            scenes6.AddRange(randomScene6);
        if (scenes7.Count == 0)
            scenes7.AddRange(randomScene7);
        if (scenes8.Count == 0)
            scenes8.AddRange(randomScene8);
        if (scenes9.Count == 0)
            scenes9.AddRange(randomScene9);
        if (scenes10.Count == 0)
            scenes10.AddRange(randomScene10);
    }

    /// <summary>
    /// End of the scenes: destroying objects
    /// </summary>

    public void DestroySomeToys()
	{
		cakeEndMove = false;
		touchController.isDragging = false;
		switch (currentSceneNum) {
			
		case 1: 
				touchController.usedMainObjects.Clear ();
			touchController.usedTouchableObject.Clear();
			for (int i = 0; i<9; i++) {
				if (i <sceneObjects.Length)
				{
					Destroy (sceneObjects[i]);
				}
				if (i < cakeScene.Length)
				{
					Destroy (cakeScene[i]);
				}				
			}
		
			
			Resources.UnloadUnusedAssets();
			
			break;

		case 2:
			Destroy (backScene);
			if (touchController.objectMove) {
				touchController.objectMove = false;
			}
			touchController.usedTouchableObject.Clear();
			touchController.usedMainObjects.Clear ();

			for (int i = 0; i<sceneObjects.Length; i++)
			{
				Destroy(sceneObjects[i]);
			}

              Resources.UnloadUnusedAssets();
			break;

		case 3:

			Destroy(vorota);
			Destroy(vratar);
			Destroy(tablo);

			DestroyTouchableObjects();
			Resources.UnloadUnusedAssets();
			break;

		case 4:
			Destroy(backScene);
		 DestroyTouchableObjects();
            Resources.UnloadUnusedAssets();
			break;
		
		case 5:
			 DestroyTouchableObjects();
			 Resources.UnloadUnusedAssets();
			break;

		case 6:
		 DestroyTouchableObjects();
			Resources.UnloadUnusedAssets();
			break;

case 7: 
	        DestroyTouchableObjects();
			Resources.UnloadUnusedAssets();
			break;
		
		case 8: 
           DestroyTouchableObjects();
			Resources.UnloadUnusedAssets();
			break;
			
			case 9: 
            DestroyTouchableObjects();
			Resources.UnloadUnusedAssets();
			break;
		}

	}
	
		private void DestroyTouchableObjects () {
		touchController.usedTouchableObject.Clear();
for (int i = 0; i<sceneObjects.Length; i++)
			{			
				Destroy (sceneObjects[i]);
			}
	}
	}
	

