using UnityEngine;
using System.Collections;
using SmartLocalization;

public class CloseScript : MonoBehaviour {

	private TouchNumbers touchNumbers;
//	private TouchController touchController;
	[HideInInspector]public int touchCounter = 0;
	private int touchKey = 0;
//	public bool inputLocked = false;
	[HideInInspector]public bool closeProcessOnline;
	private OptionsScript optionsScript;
	private Vector3 leftShirmaOpenedState = new Vector3 (-13.62f,5.14f,0);
	private Vector3 rightShirmaOpenedState = new Vector3 (13.73f,5.14f,0);
	private Vector3 leftShirmaClosedState = new Vector3 (-6.76f,5.14f,0);
	private Vector3 rightShirmaClosedState = new Vector3 (6.87f,5.14f,0);
	private int closeCounter = 60;
	private float rightShirmaStep;
	private float leftShirmaStep;
	private Vector3 positionVector;


	// Use this for initialization
	void Start () {
		touchNumbers = (TouchNumbers)GameObject.Find("shirmas").GetComponent(typeof(TouchNumbers));
		optionsScript = (OptionsScript)GameObject.Find("backOptions").GetComponent(typeof(OptionsScript));
		rightShirmaStep = (rightShirmaClosedState.x - rightShirmaOpenedState.x) / closeCounter; 
		leftShirmaStep = (leftShirmaClosedState.x - leftShirmaOpenedState.x) / closeCounter; 
		positionVector = leftShirmaClosedState;
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
					hit.collider.gameObject.layer = 0; 
					touchNumbers.shirmaRCollider.layer = 2;
					touchNumbers.animator.enabled = false;
					positionVector.x = touchNumbers.shirmaL.transform.position.x;
					positionVector.x +=  leftShirmaStep;
					touchNumbers.shirmaL.transform.position = positionVector;

					positionVector.x = touchNumbers.shirmaR.transform.position.x;
					positionVector.x += rightShirmaStep;
					touchNumbers.shirmaR.transform.position = positionVector;

								}
	
					if (touchNumbers.shirmaL.transform.position.x>= leftShirmaClosedState.x && touchNumbers.shirmaR.transform.position.x >= rightShirmaClosedState.x) {
					Debug.Log("Done");
					this.gameObject.layer = 9; 
					touchNumbers.shirmaRCollider.layer = 8;
					CloseShirmas ();
										touchNumbers.InputShortLock ();
										touchKey = 0;
									}
						}	
				}

	//	if (!Input.GetMouseButton(0) && touchKey != 0) {
		if (Input.touchCount == 0 && touchKey != 0) {
			touchKey -= 1;
			this.gameObject.layer = 9; 
			touchNumbers.shirmaRCollider.layer = 8;
			positionVector.x = touchNumbers.shirmaL.transform.position.x;
			positionVector.x -= leftShirmaStep;
			touchNumbers.shirmaL.transform.position = positionVector;

			positionVector.x = touchNumbers.shirmaR.transform.position.x;
			positionVector.x -= rightShirmaStep;
			touchNumbers.shirmaR.transform.position = positionVector;
		}	
}

	//}
	
	
	
	public void startClosing() 
	{
		touchNumbers.cakeEndMove = true;
		touchNumbers.InputLock ();
		if ( touchNumbers.currentSceneNum == 2 || touchNumbers.currentSceneNum == 10 || touchNumbers.currentSceneNum == 11) {
			Invoke ("CloseShirmasClean", 5.5f);
		} else if (touchNumbers.currentSceneNum == 8  ) {
				Invoke ("CloseShirmasClean", 4.5f);
				} 
				else
				{
						Invoke ("CloseShirmasClean", 2f);
				}
		}


	void CloseShirmasClean()
	{
		touchNumbers.animator.SetFloat ("isOpen", 0);
		touchNumbers.animator.SetFloat ("isClosed", 2);
		Invoke ("nullCounter", 1f);
		Invoke ("destroyToys", 1f);
		closeProcessOnline = false;
		touchNumbers.touchKey = 0;
		touchKey = 0;

	}

	void CloseShirmas()
	{
		touchNumbers.animator.SetFloat ("isOpen", 0);
		touchNumbers.animator.SetFloat ("isClosed", 2);
		touchNumbers.animator.enabled = true;
		touchNumbers.animator.Play ("curtains_idle");
		Invoke ("nullCounter", 1f);
		Invoke ("destroyToys", 1f);
		closeProcessOnline = false;
		touchNumbers.touchKey = 0;
		touchKey = 0;

	}

	public void PlaySound() {
		
		switch (touchCounter) {
			
		case 9: 
			//audio.PlayOneShot (touchNumbers.number10);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("ten"));
			break;
			
		case 0: 
			//audio.PlayOneShot (touchNumbers.number1);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("one"));
			break;
			
		case 1: 
			//audio.PlayOneShot (touchNumbers.number2);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("two"));
			break;
			
		case 2:
			//audio.PlayOneShot (touchNumbers.number3);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("three"));
			break;
			
		case 3:
			//audio.PlayOneShot (touchNumbers.number4);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("four"));
			break;
			
		case 4:
			//audio.PlayOneShot (touchNumbers.number5);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("five"));
			break;
			
		case 5:
			//audio.PlayOneShot (touchNumbers.number6);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("six"));
			break;
			
		case 6: 
			//audio.PlayOneShot (touchNumbers.number7);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("seven"));
			break;
			
		case 7: 
			//audio.PlayOneShot (touchNumbers.number8);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("eight"));
			break;
			
		case 8: 
			//audio.PlayOneShot (touchNumbers.number9);
			GetComponent<AudioSource>().PlayOneShot(optionsScript.languageManager.GetAudioClip("nine"));
			break;
		}
	}

	private void destroyToys() {

		touchNumbers.DestroySomeToys ();
	}

}
