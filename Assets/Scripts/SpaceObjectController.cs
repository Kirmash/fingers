using UnityEngine;
using System.Collections;

public class SpaceObjectController : MonoBehaviour {

	private RocketScript rocketScript;
	private RaycastHit2D hitSpaceObject;
	private GameObject flag;

	// Use this for initialization
	void Start () {
	
		rocketScript = (RocketScript)GameObject.Find("Main Camera").GetComponent(typeof(RocketScript));

	}
	
	// Update is called once per frame
	void Update () {
	
		if (rocketScript.isDragging) {
			int nbTouches = Input.touchCount;
			if (nbTouches > 0) {
				//hitSpaceObject = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				hitSpaceObject = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position), Vector2.zero);
				if (hitSpaceObject != null && hitSpaceObject.collider != null && hitSpaceObject.collider.tag == "spaceObject") {
					if (!rocketScript.usedSpaceObjects.Contains (hitSpaceObject.transform.gameObject)) {
						hitSpaceObject.collider.gameObject.transform.localScale = new Vector3 (1.1f, 1.1f, 1.1f);
						rocketScript.overSpaceObject = true;
						rocketScript.hoveredOverSpaceObjectCoordinates = hitSpaceObject.collider.gameObject.transform.position;
						rocketScript.hoveredOverSpaceObject = hitSpaceObject.collider.gameObject;
					
					}
				} else { 
					this.transform.localScale = new Vector3 (1, 1, 1);	
					rocketScript.overSpaceObject = false;
				}
			}
		}
		
		if (rocketScript.rocketMove) {
			this.transform.localScale = new Vector3(1,1,1);	
		}



	}
}
