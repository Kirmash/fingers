using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class RabbitButterflyMove : MonoBehaviour {
    GameObject childObj1;
	GameObject childObj2;
	
	void Start() {
	childObj1 = transform.GetChild(0).GetChild(5).gameObject;
	childObj2 = transform.GetChild(0).GetChild(6).gameObject;
	}

	void Update() {
		StartCoroutine(Nudge());
		}


	IEnumerator Nudge() {
	if (childObj1.active || childObj2.active ) {
		while (true) {
			GetComponent<Rigidbody2D>().AddForce(Random.insideUnitSphere * 1.0f);
			yield return new WaitForSeconds(0f);
		}  
		}
	}

}
