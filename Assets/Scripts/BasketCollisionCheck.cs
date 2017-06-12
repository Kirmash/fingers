using UnityEngine;
using System.Collections;

public class BasketCollisionCheck : MonoBehaviour
{
	private TouchController touchController;


	void Start () {
		touchController = (TouchController)GameObject.Find("Main Camera").GetComponent(typeof(TouchController));
		}


	void OnTriggerEnter2D(Collider2D coll) {

		if(coll.gameObject.GetComponent<Collider2D>().tag == "cakerocket" && !touchController.isDragging)
		{ 
			touchController.AppleDisappear(coll.gameObject);

		}
	}

 
}