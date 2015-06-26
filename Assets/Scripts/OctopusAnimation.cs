using UnityEngine;
using System.Collections;

public class OctopusAnimation : MonoBehaviour {
	
	private TouchController ballTouch;

	// Use this for initialization
	void Start () {
	
		ballTouch = (TouchController)GameObject.Find("Main Camera").GetComponent(typeof(TouchController));
	}

	void Update () {
				if (ballTouch.animationIndex == 1) {
						playLeft ();
		}

		if (ballTouch.animationIndex == 2) {
						playRight ();
				}
		}

	private void playLeft () {

		animation.Play ("octopusCatchLeft");
		ballTouch.animationIndex = 0;
	}

	private void playRight () {

		animation.Play ("octopusCatchRight");
		ballTouch.animationIndex = 0;
	}



}
