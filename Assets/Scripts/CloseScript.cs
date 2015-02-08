using UnityEngine;
using System.Collections;

public class CloseScript : MonoBehaviour {
	
	private TouchNumbers touchNumbers;
	[HideInInspector]public int touchCounter = 0;
	private int touchKey = 0;
	
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
		touchNumbers.isInputLocked = false;
	}
	
	void InputLock()
	{
		touchNumbers.isInputLocked = true;
		Invoke("InputUnlock",touchNumbers.inputLockingTime);
	}
	
	public void DoorClosed ()
	{
		touchNumbers.isDoorOpen = false;
	}
	
	void DestroySomeToys()
	{
		for (int i = 0; i < touchNumbers.activeToys.Length; i++) {
			
			Destroy(touchNumbers.activeToys[i]);
			
		}
	}
	public void Update() {
		
	//int nbTouches = Input.touchCount;
		
	//if (nbTouches > 0) {
			//if (!touchNumbers.isInputLocked && touchNumbers.isDoorOpen) {
			if (Input.GetMouseButton(0) && !touchNumbers.isInputLocked && touchNumbers.isDoorOpen) {
	//RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position), Vector2.zero);
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

				if ( hit.collider != null && hit.transform != null && hit.collider.tag == "cross" )
				{
					touchKey +=1;
				//Debug.Log("TouchKey: " + touchKey);
			       }
	
					if (touchKey == 66)
					{
						startClosing ();
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
		touchNumbers.animator.SetFloat ("isOpen", 0);
		touchNumbers.animator.SetFloat ("isClosed", 2);
		InputLock ();
		DoorClosed ();
		Invoke ("DestroySomeToys", touchNumbers.destroyingTime);
		touchCounter = 0;
		touchNumbers.touchKey = 0;
		touchKey = 0;
		
		// Here you can check hitInfo to see which collider has been hit, and act appropriately.
	}
	
}
