using UnityEngine;
using System.Collections;

public class BallAnimation : MonoBehaviour {

	private BallTouchScript ballTouch;

	int index;
	string ballState;

	// Use this for initialization
	void Start () {
		ballTouch = (BallTouchScript)GameObject.Find("Main Camera").GetComponent(typeof(BallTouchScript));
	}
	
	// Update is called once per frame
	void Update () {
	
		if (ballTouch.ballAnimationIndex == 1) {
			playLeft ();
		}
		
		if (ballTouch.ballAnimationIndex == 2) {
			playRight ();
		}
		
	}

	void playLeft () {

		ballState = string.Format("ballLeftStrike{0}", Random.Range (1, 4));
		ballTouch.tObject.animation.Play (ballState);
		ballTouch.ballAnimationIndex = 0;

	}

	void playRight () {
		
		ballState = string.Format("ballLeftStrike{0}", Random.Range (4, 7));
		ballTouch.tObject.animation.Play (ballState);
		ballTouch.ballAnimationIndex = 0;
	}


}
