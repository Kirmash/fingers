﻿
using UnityEngine;
using System.Collections;
using System.Linq;


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

	int[] randomScene1 = new int[] {0};
	int[] randomScene2 = new int[] {0,1};
	int[] randomScene3 = new int[] {0,1};
	int[] randomScene4 = new int[] {0,1};
	int[] randomScene5 = new int[] {0,1};
	int[] randomScene6 = new int[] {0,1};
	int[] randomScene7 = new int[] {0,1};
	int[] randomScene8 = new int[] {0,1};
	int[] randomScene9 = new int[] {0};
	int[] randomScene10 = new int[] {0};

	public int currentSceneNum;

	private CloseScript closeScript;
	private NumChange numChange;

	[HideInInspector] public int numberFingers = 1;

	[HideInInspector] public bool isDoorOpen = false;

	[HideInInspector] public bool isInputLocked = false;
	[HideInInspector] public float inputLockingTime = 0.5f;

	//private float openingTime = 1f;

	[HideInInspector]public Animator animator;

	private int toyIndex;
	
	private float randomX;
	private float randomY;

	private int index;

	//arrays for testScene 0
	[HideInInspector] public Object[] toys;
	[HideInInspector] public GameObject[] activeToys;

	//arrays and assets for PlatesScene 1
	[HideInInspector] public Object[] plates;
	[HideInInspector] public GameObject[] scenePlates;
	[HideInInspector] public GameObject[] cake;
	[HideInInspector] public GameObject[] cakeScene;
	Vector3 centerPlatePosition;



	[HideInInspector] public int touchKey = 0;
	private int numTouch = 0;
	private int nbTouches = 0;

	public void DoorOpen ()
	{
		isDoorOpen = true;
	}

	public void DoorClosed ()
	{
		isDoorOpen = false;
	}


	void Start () 
	{
		animator = GetComponent<Animator>();
		toys = Resources.LoadAll ("toys", typeof(GameObject)).Cast<GameObject> ().ToArray ();
		plates = Resources.LoadAll("plates", typeof(GameObject)).Cast<GameObject> ().ToArray ();
		cake = Resources.LoadAll("cakes", typeof(GameObject)).Cast<GameObject> ().ToArray ();

		closeScript = (CloseScript)GameObject.Find("Redcross").GetComponent(typeof(CloseScript));
		numChange = (NumChange)GameObject.Find("numb_container").GetComponent(typeof(NumChange));

	}

	void Update () 
	{
//	nbTouches = Input.touchCount;
		
//		if (nbTouches > 0) {
//	
//				if (numTouch==nbTouches && !isInputLocked)
//
//				{
//					touchKey +=1;
//
//				}
//					}	
//		numTouch = nbTouches;
	if(Input.GetMouseButton(0) && !isInputLocked && !isDoorOpen &&!closeScript.inputLocked) {
		//if (touchKey == 6 && !isInputLocked && !isDoorOpen) {
			InputLock ();
			numChange.changeBack = true;
			touchKey = 0;
			openSesame ();
			
		}
	}


	void openSesame ()
	{
		numberFingers = Random.Range(1, 11);
		setNumber (numberFingers);
		animator.SetFloat ("isOpen", 2);
		animator.SetFloat ("isClosed", 0);
		DoorOpen ();
		}


 public	void InputUnlock()
	{
		isInputLocked = false;
	}

public	void InputLock()
	{
		isInputLocked = true;
		Invoke("InputUnlock",1f);
	}



	public void setNumber (int number)
	{
		
		switch (number)
		{
		case 10: 
			print(10);
			audio.PlayOneShot(number10);
			currentSceneNum = randomScene10[Random.Range(0, randomScene10.Length)];
			GetTheToys10();
		    break;
			
		case 1: 
			print(1);
			
			audio.PlayOneShot(number1);
			currentSceneNum = randomScene1[Random.Range(0, randomScene1.Length)];
			GetTheToys1();
			break;
			
		case 2: 
			print(2);
			audio.PlayOneShot(number2);
			//currentSceneNum = randomScene2[Random.Range(0, randomScene2.Length)];
			currentSceneNum = 1;
			GetTheToys2();
			break;
			
		case 3: 
			print(3);
			audio.PlayOneShot(number3);
		//	currentSceneNum = randomScene3[Random.Range(0, randomScene3.Length)];
			currentSceneNum = 1;
			GetTheToys3();
			break;
			
		case 4: 
			print(4);
			audio.PlayOneShot(number4);
			//currentSceneNum = randomScene4[Random.Range(0, randomScene4.Length)];
			currentSceneNum = 1;
			GetTheToys4();
			break;
			
		case 5: 
			print(5);
			audio.PlayOneShot(number5);
			//currentSceneNum = randomScene5[Random.Range(0, randomScene5.Length)];
			currentSceneNum = 1;
			GetTheToys5();
			break;
			
		case 6: 
			print(6);
			audio.PlayOneShot(number6);
			//currentSceneNum = randomScene6[Random.Range(0, randomScene6.Length)];
			currentSceneNum = 1;
			GetTheToys6();
			break;
			
		case 7: 
			print(7);
			audio.PlayOneShot(number7);
			//currentSceneNum = randomScene7[Random.Range(0, randomScene7.Length)];
			currentSceneNum = 1;
			GetTheToys7();
			break;
			
		case 8: 
			print(8);
			audio.PlayOneShot(number8);
			//currentSceneNum = randomScene8[Random.Range(0, randomScene8.Length)];
			currentSceneNum = 1;
			GetTheToys8();
			break;
			
		case 9: 
			print(9);
			audio.PlayOneShot(number9);
			currentSceneNum = randomScene9[Random.Range(0, randomScene9.Length)];
			GetTheToys9 ();
			break;
		}
		
	}


	//Choosing the scene for particular numbers
	void GetTheToys1 () {
				switch (currentSceneNum) {
				case 0:
			LoadScene0(numberFingers);
						break;
				}
		}
	void GetTheToys2 () {
			switch (currentSceneNum)
			{
			case 0:
			LoadScene0(numberFingers);
				break;

		case 1:
			LoadScene1(numberFingers);
			break;
			}
	}
	void GetTheToys3 () {
			switch (currentSceneNum)
			{
			case 0:
			LoadScene0(numberFingers);
				break;

			case 1:
			LoadScene1(numberFingers);
				break;
			}
	}
	void GetTheToys4 () {
			switch (currentSceneNum)
			{
			case 0:
			LoadScene0(numberFingers);
				break;

			case 1:
			LoadScene1(numberFingers);
				break;
			}
	}
	void GetTheToys5 () {
			switch (currentSceneNum)
			{
			case 0:
			LoadScene0(numberFingers);
				break;

			case 1:
			LoadScene1(numberFingers);
				break;
			}
	}
	void GetTheToys6 () {
			switch (currentSceneNum)
			{
			case 0:
			LoadScene0(numberFingers);
				break;

			case 1:
			LoadScene1(numberFingers);
				break;
			}
	}
	void GetTheToys7 () {
			switch (currentSceneNum)
			{
			case 0:
			LoadScene0(numberFingers);
				break;

			case 1:
			LoadScene1(numberFingers);
				break;
			}
	}
	void GetTheToys8 () {
			switch (currentSceneNum)
			{
			case 0:
			LoadScene0(numberFingers);
				break;

			case 1:
			LoadScene1(numberFingers);
				break;
			}
	}
	void GetTheToys9 () {
			switch (currentSceneNum)
			{
			case 0:
			LoadScene0(numberFingers);
				break;

			case 1:
			LoadScene1(numberFingers);
				break;

			}
	}
	void GetTheToys10 () {
			switch (currentSceneNum)
			{
			case 0:
			LoadScene0(numberFingers);
				break;

			case 1:
			LoadScene1(numberFingers);
				break;
			}
	}


	//Handler for loading the scenes

	//testscene
	void LoadScene0 (int numberF)
	{

		activeToys = new GameObject[numberF];
		for (int i = 0; i < numberF; i++) {
			toyIndex = Random.Range(0, toys.Length);
			Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50,Screen.width-50), Random.Range(50,Screen.height-50), 10));
			activeToys [i] = GameObject.Instantiate (toys [toyIndex], screenPosition, Quaternion.identity) as GameObject;
		}

	}
//tort
	void LoadScene1 (int numberF)
	{

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

}