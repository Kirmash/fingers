using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;


public class TouchNumbers : MonoBehaviour 
{
	//private ToyTouch toyTouch;

	public AudioClip number1;
	public AudioClip number2;
	public AudioClip number3;
	public AudioClip number4;
	public AudioClip number5;
	public AudioClip number6;
	public AudioClip number7;
	public AudioClip number8;
	public AudioClip number9;
	public AudioClip number10;

	int[] randomScene1 = new int[] {2,3};
	int[] randomScene2 = new int[] {1,2,3};
	int[] randomScene3 = new int[] {1,2,3};
	int[] randomScene4 = new int[] {1,2,3};
	int[] randomScene5 = new int[] {1,2,3};
	int[] randomScene6 = new int[] {1,2,3};
	int[] randomScene7 = new int[] {1,2,3};
	int[] randomScene8 = new int[] {1,2,3};
	int[] randomScene9 = new int[] {2,3};
	int[] randomScene10 = new int[] {2,3};

	[HideInInspector] public int currentSceneNum;

	//private CloseScript closeScript;
	private NumChange numChange;
	private TouchController touchController;
	private RocketScript rocketScript;

	[HideInInspector] public int numberFingers = 1;

	[HideInInspector] public bool isInputLocked = false;
	[HideInInspector] public float inputLockingTime = 0.5f;

	//private float openingTime = 1f;

	[HideInInspector]public Animator animator;

	private int toyIndex;
	
	private float randomX;
	private float randomY;

	private int index;

	private int currCoordinateIndex;


	//arrays for testScene 0
	[HideInInspector] public Object[] toys;
	[HideInInspector] public GameObject[] activeToys;

	//arrays and assets for PlatesScene 1
	[HideInInspector] public Object[] plates;
	[HideInInspector] public GameObject[] scenePlates;
	[HideInInspector] public GameObject[] cake;
	[HideInInspector] public GameObject[] cakeScene;
	Vector3 centerPlatePosition;
	[HideInInspector]public bool cakeEndMove = false;

	//arrays and assets for SpaceScene (2)
	[HideInInspector] public Object[] spaceObjects;

	[HideInInspector] public Vector3[] spaceCoordinatesArray;
	[HideInInspector] public Vector3 rocketCoordinates = new Vector3 (3.635082f,0.4855805f,0f);
	[HideInInspector] public GameObject[] activeSpaceObjects;
	private GameObject backSpace;
	[HideInInspector] public GameObject rocket;
	private List<int> usedCoordinates;

	//arrays and assets for FootballScene (3)
	Vector3[] ballPositionArray = new [] { new Vector3(-4.825f,-1.915f,0),new Vector3(-2.785f,-1.915f,0),new Vector3(-0.845f,-2.014f,0),new Vector3(1.1939f,-1.940f,0),new Vector3(3.1588f,-1.989f,0),new Vector3(5.1735f,-1.915f,0),new Vector3(-3.531f,-3.830f,0),new Vector3(-1.122f,-3.797f,0),new Vector3(1.2436f,-3.805f,0),new Vector3(3.6314f,-3.805f,0)};
	[HideInInspector] public GameObject[] soccerObjects;
	[HideInInspector] public GameObject[] activeBalls;
	private GameObject tablo;
	private GameObject vratar;
	[HideInInspector] public GameObject vorota;


	[HideInInspector] public int touchKey = 0;
	private int numTouch = 0;
	private int nbTouches = 0;


	void Start () 
	{
		animator = GetComponent<Animator>();

		toys = Resources.LoadAll ("toys", typeof(GameObject)).Cast<GameObject> ().ToArray ();

		plates = Resources.LoadAll("plates", typeof(GameObject)).Cast<GameObject> ().ToArray ();
		cake = Resources.LoadAll("cakes", typeof(GameObject)).Cast<GameObject> ().ToArray ();

		spaceObjects = Resources.LoadAll("spaceObjects", typeof(GameObject)).Cast<GameObject> ().ToArray ();
		usedCoordinates = new List<int>();
		rocketScript = (RocketScript)GameObject.Find("Main Camera").GetComponent(typeof(RocketScript));

		soccerObjects = Resources.LoadAll("footballBalls", typeof(GameObject)).Cast<GameObject> ().ToArray (); 

		//closeScript = (CloseScript)GameObject.Find("Redcross").GetComponent(typeof(CloseScript));
		numChange = (NumChange)GameObject.Find("numb_container").GetComponent(typeof(NumChange));
		touchController = (TouchController)GameObject.Find("Main Camera").GetComponent(typeof(TouchController));
	}

	void Update () 
	{
	nbTouches = Input.touchCount;
		
		if (nbTouches > 0) {
						RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position), Vector2.zero);
						if (hit.collider != null && hit.transform != null && hit.collider.tag == "shirma") {	
				if (numTouch == nbTouches && !isInputLocked && this.animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_idle")) {
					animator.SetBool("isShirmasOpen",true);				
					touchKey += 1;

								}
						}	
				}
		numTouch = nbTouches;
//		if (Input.GetMouseButton (0) && !isInputLocked && this.animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_idle")) {
//		//Debug.Log ("Button hit!");
//			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
//			if (hit.collider != null && hit.transform != null && hit.collider.tag == "shirma") {
//
//				animator.SetBool("isShirmasOpen",true);
//				touchKey += 1;
//			}
//		}
		if (touchKey == 30) {
			InputLock ();
			numberFingers = nbTouches;
			openSesame ();
			touchKey = 0;
		}

		if (nbTouches == 0) {
		//if (Input.GetMouseButtonUp (0) && !isInputLocked) {
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
	}

public void InputLock()
	{
		isInputLocked = true;
		Invoke ("InputUnlock", 1f);
	}

	public void StopTheOpening() 
	{
		animator.SetBool ("isShirmasOpen", false);

		}


	public void setNumber (int number)
	{
		
		switch (number)
		{
		case 10: 
			print(10);
			audio.PlayOneShot(number10);
			currentSceneNum = randomScene10[Random.Range(0, randomScene10.Length)];
			//currentSceneNum = 3;
			GetTheToys10();
		    break;
			
		case 1: 
			print(1);
			
			audio.PlayOneShot(number1);
			currentSceneNum = randomScene1[Random.Range(0, randomScene1.Length)];
			//currentSceneNum = 3;
			GetTheToys1();
			break;
			
		case 2: 
			print(2);
			audio.PlayOneShot(number2);
			currentSceneNum = randomScene2[Random.Range(0, randomScene2.Length)];
			//currentSceneNum = 3;
			GetTheToys2();
			break;
			
		case 3: 
			print(3);
			audio.PlayOneShot(number3);
		    currentSceneNum = randomScene3[Random.Range(0, randomScene3.Length)];
		    //currentSceneNum = 3;
			GetTheToys3();
			break;
			
		case 4: 
			print(4);
			audio.PlayOneShot(number4);
		    currentSceneNum = randomScene4[Random.Range(0, randomScene4.Length)];
		//	currentSceneNum = 3;
			GetTheToys4();
			break;
			
		case 5: 
			print(5);
			audio.PlayOneShot(number5);
		    currentSceneNum = randomScene5[Random.Range(0, randomScene5.Length)];
			//currentSceneNum = 3;
			GetTheToys5();
			break;
			
		case 6: 
			print(6);
			audio.PlayOneShot(number6);
		    currentSceneNum = randomScene6[Random.Range(0, randomScene6.Length)];
			//currentSceneNum = 3;
			GetTheToys6();
			break;
			
		case 7: 
			print(7);
			audio.PlayOneShot(number7);
		    currentSceneNum = randomScene7[Random.Range(0, randomScene7.Length)];
			//currentSceneNum = 3;
			GetTheToys7();
			break;
			
		case 8: 
			print(8);
			audio.PlayOneShot(number8);
		    currentSceneNum = randomScene8[Random.Range(0, randomScene8.Length)];
			//currentSceneNum = 3;
			GetTheToys8();
			break;
			
		case 9: 
			print(9);
			audio.PlayOneShot(number9);
		    currentSceneNum = randomScene9[Random.Range(0, randomScene9.Length)];
			//currentSceneNum = 3;
			GetTheToys9 ();
			break;
		}
		
	}


	//Choosing the scene for particular numbers
	void GetTheToys1 () {
				switch (currentSceneNum) {
		case 2:
			LoadScene2 (numberFingers);
			break;

		case 3: 
			LoadScene3 (numberFingers);
			break;
				}


		}
	void GetTheToys2 () {
			switch (currentSceneNum)
			{
		case 1:
			LoadScene1(numberFingers);
			break;

		case 2:
			LoadScene2 (numberFingers);
			break;
		
		case 3: 
			LoadScene3 (numberFingers);
		
			break;
		}
	}
	void GetTheToys3 () {
			switch (currentSceneNum)
			{
			case 1:
			LoadScene1(numberFingers);
				break;

		case 2:
			LoadScene2 (numberFingers);
			break;

		case 3: 
			LoadScene3 (numberFingers);
			break;
		}
	}
	void GetTheToys4 () {
			switch (currentSceneNum)
			{
			case 1:
			LoadScene1(numberFingers);
				break;

		    case 2:
			LoadScene2 (numberFingers);
			break;

		case 3: 
			LoadScene3 (numberFingers);
			break;
		}
	}
	void GetTheToys5 () {
			switch (currentSceneNum)
			{
			case 1:
			LoadScene1(numberFingers);
				break;

		case 2:
			LoadScene2 (numberFingers);
			break;

		case 3: 
			LoadScene3 (numberFingers);
			break;
		}
	}
	void GetTheToys6 () {
			switch (currentSceneNum)
			{
			case 1:
			LoadScene1(numberFingers);
				break;
		case 2:
			LoadScene2 (numberFingers);
			break;

		case 3: 
			LoadScene3 (numberFingers);
			break;
			}
	}
	void GetTheToys7 () {
			switch (currentSceneNum)
			{
			case 1:
			LoadScene1(numberFingers);
				break;

		case 2:
			LoadScene2 (numberFingers);
			break;
		case 3: 
			LoadScene3 (numberFingers);
			break;
		}
	}
	void GetTheToys8 () {
			switch (currentSceneNum)
			{
			case 1:
			LoadScene1(numberFingers);
				break;
		case 2:
			LoadScene2 (numberFingers);
			break;

		case 3: 
			LoadScene3 (numberFingers);
			break;
		}
	}
	void GetTheToys9 () {
			switch (currentSceneNum)
			{
			case 1:
			LoadScene1(numberFingers);
				break;

		case 2:
			LoadScene2 (numberFingers);
			break;
		
		case 3: 
			LoadScene3 (numberFingers);
			break;
		}
	}
	void GetTheToys10 () {
			switch (currentSceneNum)
			{
			case 1:
			LoadScene1(numberFingers);
				break;

		    case 2:
			LoadScene2 (numberFingers);
			break;

		case 3:
			LoadScene3(numberFingers);
			break;
		}


	}


	//Handler for loading the scenes

//tort
	void LoadScene1 (int numberF)
	{
		numChange.spriteRenderer.color = new Color(1f,1f,1f,1f);
		scenePlates = new GameObject[numberF+1];
		cakeScene = new GameObject[8];
		centerPlatePosition = new Vector3 (0.27f, 0f, 0);
		scenePlates[0] = GameObject.Instantiate (plates[0], centerPlatePosition, Quaternion.identity) as GameObject;
		for (int j = 0; j<8; j++) {
			cakeScene[j] = GameObject.Instantiate (cake[j], Vector3.zero, Quaternion.identity) as GameObject;
		}


	switch (numberF) 
		{

		case 2:
			Vector3[] platePositionArray2 = new [] { new Vector3(6.3f,0f,0), new Vector3(-5.95f,0f,0) };
			for (int i = 1; i < numberF+1; i++) {
						scenePlates [i] = GameObject.Instantiate (plates[1], platePositionArray2[i-1], Quaternion.identity) as GameObject;
			}
			break;

		case 3:
			Vector3[] platePositionArray3 = new [] { new Vector3(-3.52f,4.55f,0), new Vector3(5.85f,-1.65f,0), new Vector3(-3.74f,-4.33f,0) };
			for (int i = 1; i < numberF+1; i++) {
				scenePlates [i] = GameObject.Instantiate (plates[1], platePositionArray3[i-1], Quaternion.identity) as GameObject;
			}
			break;

		case 4:
			Vector3[] platePositionArray4 = new [] { new Vector3(3.55f,4.76f,0), new Vector3(5.79f,-1.37f,0), new Vector3(-3.29f,-4.64f,0), new Vector3(-5.57f,1.07f,0) };
				for (int i = 1; i < numberF+1; i++) {
				scenePlates [i] = GameObject.Instantiate (plates[1], platePositionArray4[i-1], Quaternion.identity) as GameObject;
			}
				break;

		case 5:
			Vector3[] platePositionArray5 = new [] { new Vector3(0.16f,5.48f,0), new Vector3(6.3f,-0.03f,0), new Vector3(3.58f,-4.91f,0), new Vector3(-3.31f,-4.92f,0), new Vector3(-5.9f,-0.05f,0) };
					for (int i = 1; i < numberF+1; i++) {
				scenePlates [i] = GameObject.Instantiate (plates[1], platePositionArray5[i-1], Quaternion.identity) as GameObject;
			}
				break;

		case 6:
			Vector3[] platePositionArray6 = new [] {  new Vector3(3.63f,4.9f,0), new Vector3(6.35f,0f,0), new Vector3(3.62f,-4.71f,0), new Vector3(-3.26f,-4.77f,0), new Vector3(-5.88f,0.02f,0), new Vector3(-3.27f,4.89f,0) };
						for (int i = 1; i < numberF+1; i++) {
				
				scenePlates [i] = GameObject.Instantiate (plates[1], platePositionArray6[i-1], Quaternion.identity) as GameObject;
				}
					break;

		case 7:
			Vector3[] platePositionArray7 = new [] { new Vector3(3.56f,4.89f,0), new Vector3(6.32f,0f,0), new Vector3(6.12f,-4.75f,0), new Vector3(0.15f,-5.55f,0), new Vector3(-5.77f,-4.81f,0), new Vector3(-5.92f,0f,0), new Vector3(-3.29f,4.89f,0) };
							for (int i = 1; i < numberF+1; i++) {
				scenePlates [i] = GameObject.Instantiate (plates[1], platePositionArray7[i-1], Quaternion.identity) as GameObject;
				}
					break;

		case 8:
			Vector3[] platePositionArray8 = new [] {new Vector3(6.12f,4.89f,0), new Vector3(6.32f,0f,0), new Vector3(6.12f,-4.75f,0), new Vector3(0.15f,-5.55f,0), new Vector3(-5.77f,-4.81f,0), new Vector3(-5.92f,0f,0), new Vector3(-5.75f,4.86f,0), new Vector3(0.14f,5.57f,0) };
								for (int i = 1; i < numberF+1; i++) {
				scenePlates [i] = GameObject.Instantiate (plates[1], platePositionArray8[i-1], Quaternion.identity) as GameObject;
				}
					break;

		}


		}

//space 
	void LoadScene2 (int numberF)
	{
		spaceCoordinatesArray = new Vector3[] {new Vector3 (-3.852236f,3.519741f,0f), new Vector3 (0.2980204f,2.75679f,0f), new Vector3 (4.7626f,3.674817f,0f), new Vector3 (-5.007737f,0.8001435f,0f), new Vector3 (-2.534921f,-1.356382f,0f), new Vector3 (1.330779f,-2.177835f,0f), new Vector3 (5.939386f,-1.369833f,0f), new Vector3 (-3.846421f,-3.674136f,0f), new Vector3 (0.373147f,-4.332508f,0f), new Vector3 (4.802197f,-3.464654f,0f)};
		backSpace = GameObject.Instantiate (spaceObjects[11], Vector3.zero, Quaternion.identity) as GameObject;
		activeSpaceObjects = new GameObject[numberF+1];
		activeSpaceObjects[0] = GameObject.Instantiate (spaceObjects[0], rocketCoordinates, Quaternion.identity) as GameObject;
		currCoordinateIndex = Random.Range (0, 10);
		numChange.spriteRenderer.color = new Color(1f,1f,1f,0.3f);
		for (int i = 1; i <= numberF; i++) {
			while (usedCoordinates.Contains(currCoordinateIndex))
			{
				currCoordinateIndex = Random.Range (0, 10);
			}
			activeSpaceObjects[i] = GameObject.Instantiate(spaceObjects[i], spaceCoordinatesArray[currCoordinateIndex],Quaternion.identity) as GameObject;

			usedCoordinates.Add (currCoordinateIndex);
		}
		usedCoordinates.Clear ();
		
	}

//football
	void LoadScene3 (int numberF)
	{
		activeBalls = new GameObject[numberF];
		vorota =  GameObject.Instantiate (soccerObjects[0], Vector3.zero, Quaternion.identity) as GameObject;
		vratar =  GameObject.Instantiate (soccerObjects[1], Vector3.zero, Quaternion.identity) as GameObject;
		numChange.spriteRenderer.color = new Color(1f,1f,1f,1f);
		tablo =  GameObject.Instantiate (soccerObjects[2], soccerObjects[2].transform.position, Quaternion.identity) as GameObject;
		currCoordinateIndex = Random.Range (0, 10);
	for (int i = 0; i < numberF; i++) {
//			//	Debug.Log ("CurrCoorInd: " + currCoordinateIndex);
			while (usedCoordinates.Contains(currCoordinateIndex))
			{
				currCoordinateIndex = Random.Range (0, 10);
			}
//			//			Debug.Log (spaceObjects[i]);
//			//			Debug.Log ("SpaceCoord: " + spaceCoordinatesArray[currCoordinateIndex]);
		activeBalls[i] = GameObject.Instantiate(soccerObjects[i+3], ballPositionArray[currCoordinateIndex],Quaternion.identity) as GameObject;
//			
			usedCoordinates.Add (currCoordinateIndex);
	//		Debug.Log (usedCoordinates);
	}
		usedCoordinates.Clear ();
	}

	public void DestroySomeToys()
	{
		//Debug.Log ("I am destroying!");
		cakeEndMove = false;
		switch (currentSceneNum) {
		case 0:
			for (int i = 0; i < activeToys.Length; i++) {
				
				Destroy (activeToys [i]);
				
			}
			break;
			
		case 1: 
			
			for (int i = 0; i<9; i++) {
				if (i <scenePlates.Length)
				{
					Destroy (scenePlates[i]);
					if (touchController.usedPlates.Contains(scenePlates[i])) {
						touchController.usedPlates.Remove(scenePlates[i]);
					}
				}
				if (i < cakeScene.Length)
				{
					Destroy (cakeScene[i]);
					if (touchController.usedCakes.Contains(cakeScene[i])) {
						touchController.usedCakes.Remove(cakeScene[i]);
					}
				}				
			}
			
			break;

		case 2:
			Destroy(backSpace);
			for (int i = 0; i<activeSpaceObjects.Length; i++)
			{
				Destroy(activeSpaceObjects[i]);
				if (rocketScript.usedSpaceObjects.Contains(activeSpaceObjects[i])) {
					rocketScript.usedSpaceObjects.Remove(activeSpaceObjects[i]);
				}
			}

			break;

		case 3:

			Destroy(vorota);
			Destroy(vratar);
			Destroy(tablo);

			for (int i = 0; i<activeBalls.Length; i++)
			{
				Destroy(activeBalls[i]);
			}
			break;
		}
		
	}

}