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


	// Use this for initialization
	void Start () {
		touchNumbers = (TouchNumbers)GameObject.Find("shirmas").GetComponent(typeof(TouchNumbers));
		optionsScript = (OptionsScript)GameObject.Find("backOptions").GetComponent(typeof(OptionsScript));
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
		if (touchNumbers.currentSceneNum == 3 ||  touchNumbers.currentSceneNum == 2 || touchNumbers.currentSceneNum == 10) {
			Invoke ("CloseShirmas", 5.5f);
				} else if (touchNumbers.currentSceneNum == 8) {
				Invoke ("CloseShirmas", 4.5f);
				} 
				else
				{
						Invoke ("CloseShirmas", 3.5f);
				}
		}


		
	void CloseShirmas()
	{
		touchNumbers.animator.SetFloat ("isOpen", 0);
		touchNumbers.animator.SetFloat ("isClosed", 2);
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
