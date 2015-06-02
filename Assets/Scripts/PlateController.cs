using UnityEngine;
using System.Collections;

public class PlateController : MonoBehaviour {

	private TouchController touchController;
	private RaycastHit2D hitPlate;

	void Start () {
		
		touchController = (TouchController)GameObject.Find("Main Camera").GetComponent(typeof(TouchController));
	}

	void Update() {

		if (touchController.isDragging) {
	//		hitPlate = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			hitPlate = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position), Vector2.zero);
			if (hitPlate != null && hitPlate.collider != null && hitPlate.collider.tag == "plate") {
				if (!touchController.usedPlates.Contains(hitPlate.transform.gameObject)) {
			hitPlate.collider.gameObject.transform.localScale = new Vector3(1.1f,1.1f,1.1f);
					touchController.overPlate = true;
					touchController.plateCoordinates = hitPlate.collider.gameObject.transform.position;
					touchController.activePlate = hitPlate.collider.gameObject;

				}
								}
			else { 
				this.transform.localScale = new Vector3(1,1,1);	
				touchController.overPlate = false;}
	}

		if (touchController.cakeMove) {
			this.transform.localScale = new Vector3(1,1,1);	
		}

}

}
