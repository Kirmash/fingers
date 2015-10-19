using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class BubbleMove : MonoBehaviour {

	void Update() {
		StartCoroutine(Nudge());
		}


	IEnumerator Nudge() {
		while (true) {
			GetComponent<Rigidbody2D>().AddForce(Random.insideUnitSphere * 1.0f);
			yield return new WaitForSeconds(Random.Range(0.5f, 2.5f));
		}  
	}

}
