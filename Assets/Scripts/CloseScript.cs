using UnityEngine;
using System.Collections;

public class CloseScript : MonoBehaviour {

	private float destroyingTime = 1f;
	private TouchNumbers touchNumbers;
//	private NumChange numChange;
	[HideInInspector]public int touchCounter = 0;
	private int touchKey = 0;
	public bool inputLocked = false;
	private float time = 1f;

	//CakeScene
	public bool cakeEndMove = false;


	// Use this for initialization
	void Start () {
		touchNumbers = (TouchNumbers)GameObject.Find("shirmas").GetComponent(typeof(TouchNumbers));
		
	}
	
	// Update is called once per frame
	//void OnMouseDown () {
	
	//	startClosing ();
	
	//			}
	
	void InputUnlock()
	{
		inputLocked = false;
	}
	
	void InputLock()
	{
		inputLocked = true;
		Invoke("InputUnlock",2.5f);
	}
	
	public void DoorClosed ()
	{
		touchNumbers.isDoorOpen = false;
	}
	
	void DestroySomeToys()
	{
		//Debug.Log ("I am destroying!");
		cakeEndMove = false;
		switch (touchNumbers.currentSceneNum) {
				case 0:
						for (int i = 0; i < touchNumbers.activeToys.Length; i++) {
			
								Destroy (touchNumbers.activeToys [i]);
			
						}
						break;

		case 1: 
			for (int i = 0; i<9; i++) {
				if (i <touchNumbers.scenePlates.Length)
				{
				Destroy (touchNumbers.scenePlates[i]);
				}
				if (i <touchNumbers.cakeScene.Length)
				{
					Destroy (touchNumbers.cakeScene[i]);
				}


			}
		break;
				}
		
	}
	public void Update() {
	
	//int nbTouches = Input.touchCount;
		
	//if (nbTouches > 0) {
			//if (!touchNumbers.isInputLocked && touchNumbers.isDoorOpen) {
			if (Input.GetMouseButton(0) && !inputLocked && !touchNumbers.isInputLocked && touchNumbers.isDoorOpen) {
	//RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position), Vector2.zero);
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

				if ( hit.collider != null && hit.transform != null && hit.collider.tag == "cross" )
				{
					touchKey +=1;
			       }
	
					if (touchKey == 66)
					{
				CloseShirmas();
				InputLock ();
				touchKey = 0;

					}
				}	
			//}
		if (!Input.GetMouseButton(0) && touchKey != 0) {
		//if (Input.touchCount == 0 && touchKey != 0) {
			touchKey -= 1;
		}
				//    Debug.Log("TouchKey: " + touchKey);
		
}

	//}
	
	
	
	public void startClosing() 
	{

		InputLock ();

		switch (touchNumbers.currentSceneNum) {
			
		case 0:
		
			break;
			
		case 1:
			cakeEndMove = true;
			break;
		}

		//CloseShirmas ();
		//Debug.Log ("Invoking closing!");
		Invoke ("CloseShirmas", 1f);


	}

	void CloseShirmas()
	{
		touchNumbers.animator.SetFloat ("isOpen", 0);
		touchNumbers.animator.SetFloat ("isClosed", 2);
		Invoke ("DestroySomeToys", 0.9f);
		DoorClosed ();
		touchCounter = 0;
		touchNumbers.touchKey = 0;
		touchKey = 0;
	}

	public void PlaySound() {
		
		switch (touchCounter) {
			
		case 9: 
			audio.PlayOneShot (touchNumbers.number10);
			
			break;
			
		case 0: 
			audio.PlayOneShot (touchNumbers.number1);
			
			break;
			
		case 1: 
			audio.PlayOneShot (touchNumbers.number2);
			
			break;
			
		case 2:
			audio.PlayOneShot (touchNumbers.number3);
			
			break;
			
		case 3:
			audio.PlayOneShot (touchNumbers.number4);
			
			break;
			
		case 4:
			audio.PlayOneShot (touchNumbers.number5);
			
			break;
			
		case 5:
			audio.PlayOneShot (touchNumbers.number6);
			
			break;
			
		case 6: 
			audio.PlayOneShot (touchNumbers.number7);
			
			break;
			
		case 7: 
			audio.PlayOneShot (touchNumbers.number8);
			
			break;
			
		case 8: 
			audio.PlayOneShot (touchNumbers.number9);
			
			break;
		}
	}


}
