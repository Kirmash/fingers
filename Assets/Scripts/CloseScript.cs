using UnityEngine;
using System.Collections;

public class CloseScript : MonoBehaviour {

	private TouchNumbers touchNumbers;
//	private TouchController touchController;
	[HideInInspector]public int touchCounter = 0;
	private int touchKey = 0;
//	public bool inputLocked = false;
	[HideInInspector]public bool closeProcessOnline;




	// Use this for initialization
	void Start () {
		touchNumbers = (TouchNumbers)GameObject.Find("shirmas").GetComponent(typeof(TouchNumbers));
	//	touchController = (TouchController)GameObject.Find("Main Camera").GetComponent(typeof(TouchController));
	}

  private void nullCounter () {

		touchCounter = 0;
		
	}

	public void Update() {
	
	int nbTouches = Input.touchCount;
		
	if (nbTouches > 0) {
						if (!touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo (0).IsName ("curtains_open_idle")) {
					//			if (Input.GetMouseButton(0) && !touchNumbers.isInputLocked && touchNumbers.animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_open_idle")) {
								RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position), Vector2.zero);
					//		RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

								if (hit.collider != null && hit.transform != null && hit.collider.tag == "cross") {
										touchKey += 1;
								}
	
								if (touchKey == 66) {
										CloseShirmas ();
										touchNumbers.InputLock ();
										touchKey = 0;

								}
						}	
				}

	//	if (!Input.GetMouseButton(0) && touchKey != 0) {
		if (Input.touchCount == 0 && touchKey != 0) {
			touchKey -= 1;
		}	
}

	//}
	
	
	
	public void startClosing() 
	{
		touchNumbers.cakeEndMove = true;
		touchNumbers.InputLock ();
		Invoke ("CloseShirmas", 1f);
		}


		
	void CloseShirmas()
	{
		touchNumbers.animator.SetFloat ("isOpen", 0);
		touchNumbers.animator.SetFloat ("isClosed", 2);
		Invoke ("nullCounter", 1f);
		closeProcessOnline = false;
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
