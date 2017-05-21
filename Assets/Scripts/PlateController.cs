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
			if (hitPlate != null && hitPlate.collider != null && hitPlate.collider.tag == "spacestuff") {
				
				if (!touchController.usedMainObjects.Contains(hitPlate.transform.gameObject)) {
					//Debug.Log ("Here!");
			
					touchController.overMainObject = true;
				
					if (touchNumbers.currentSceneNum == 11) {
						touchController.mainObjectCoordinates.x = hitPlate.collider.gameObject.transform.position.x + hitPlate.collider.gameObject.GetComponent<BoxCollider2D>().offset.x;
						touchController.mainObjectCoordinates.y = hitPlate.collider.gameObject.transform.position.y + hitPlate.collider.gameObject.GetComponent<BoxCollider2D>().offset.y;
					} else {
						hitPlate.collider.gameObject.transform.localScale = new Vector3(1.1f,1.1f,1.1f);
						touchController.mainObjectCoordinates = hitPlate.collider.gameObject.transform.position;
					}
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


	public void TeaStopToIdle () {
		touchController.tObject.GetComponent<Animator> ().SetInteger ("TeaFlows", 1);
		touchController.tObject.GetComponent<Animator> ().SetInteger ("isWaiting", 1);
	}


	public void TeaStop () {
		touchController.tObject.GetComponent<Animator> ().SetInteger ("TeaFlows", 1);
		touchController.tObject.GetComponent<Animator> ().SetInteger ("isWaiting", 3);
	}

}


