using UnityEngine;
using System.Collections;

public class PlateController : MonoBehaviour {

	private TouchController touchController;
	private TouchNumbers touchNumbers;
	private Vector3 lastScale;
	int nbTouches;
	private RaycastHit2D hitPlate;

	void Start () {
		
		touchController = (TouchController)GameObject.Find("Main Camera").GetComponent(typeof(TouchController));
		touchNumbers = (TouchNumbers)GameObject.Find("shirmas").GetComponent(typeof(TouchNumbers));
	}

	void Update() {
		nbTouches = Input.touchCount;
		if (touchController.isDragging && (nbTouches > 0)) {
	//		hitPlate = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			hitPlate = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position), Vector2.zero);
			if (hitPlate != null && hitPlate.collider != null && hitPlate.collider.tag == "object") {
				if (!touchController.usedMainObjects.Contains(hitPlate.transform.gameObject)) {
			hitPlate.collider.gameObject.transform.localScale = new Vector3(1.1f,1.1f,1.1f);
					touchController.overMainObject = true;

					touchController.mainObjectCoordinates = hitPlate.collider.gameObject.transform.position;
					touchController.activeMainObject = hitPlate.collider.gameObject;

				}
								}
			else { 


				this.transform.localScale = new Vector3(1,1,1);	

				touchController.overMainObject = false;}
	}

		if (touchController.objectMove) {
			this.transform.localScale = new Vector3(1,1,1);	
		}

}

}
