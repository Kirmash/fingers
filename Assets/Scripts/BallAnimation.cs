using UnityEngine;
using System.Collections;

public class BallAnimation : MonoBehaviour {

	private BallTouchScript ballTouch;

	int ballStateIndex;
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
		ballStateIndex = Random.Range (1, 6);

		while (ballTouch.usedBallsAnimation.Contains (ballStateIndex)) {
			ballStateIndex = Random.Range (1, 6);
		}		
		ballState = string.Format("ballLeftStrike{0}", ballStateIndex);
		ballTouch.tObject.animation.Play (ballState);
		ballTouch.usedBallsAnimation.Add (ballStateIndex);
		ballTouch.ballAnimationIndex = 0;
	}

	void playRight () {
		ballStateIndex = Random.Range (6, 11);
		
		while (ballTouch.usedBallsAnimation.Contains (ballStateIndex)) {
			ballStateIndex = Random.Range (6, 11);
		}		
		ballState = string.Format("ballLeftStrike{0}", ballStateIndex);
		ballTouch.tObject.animation.Play (ballState);
		ballTouch.usedBallsAnimation.Add (ballStateIndex);
		ballTouch.ballAnimationIndex = 0;
	}


}
