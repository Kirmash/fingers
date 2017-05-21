using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaPouring : MonoBehaviour {

	private TouchController touchController;
	private Vector3 teaOffset;
	float speedTeapot = 12f;
	float lerpMoving = 0;
	// Use this for initialization
	void Start () {
		touchController = (TouchController)GameObject.Find("Main Camera").GetComponent(typeof(TouchController));
		teaOffset = new Vector3 (-0.5f, -0.5f, 0);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log ("Triggered!");
		if(coll.gameObject.GetComponent<Collider2D>().tag == "ball")
		{ 
			while (this.transform.position != (coll.gameObject.GetComponent<Collider2D> ().transform.position - teaOffset)) {
				Debug.Log (coll.gameObject.GetComponent<Collider2D> ().transform.position);
				Debug.Log (coll.gameObject.GetComponent<Collider2D> ());
				lerpMoving += Time.deltaTime;
				this.transform.position = Vector3.MoveTowards (this.transform.position, coll.gameObject.GetComponent<Collider2D> ().transform.position - teaOffset, lerpMoving*speedTeapot);
			}



		}
	}
}
