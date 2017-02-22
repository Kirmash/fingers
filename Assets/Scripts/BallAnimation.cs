using UnityEngine;
using System.Collections;

public class BallAnimation : MonoBehaviour {

	private TouchController ballTouch;

	int ballStateIndex;
	string ballState;

	// Use this for initialization
	void Start () {
		ballTouch = (TouchController)GameObject.Find("Main Camera").GetComponent(typeof(TouchController));
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
		ballState = string.Format("ballLeftStrike{0}", ballStateIndex);
		ballTouch.tObject.GetComponent<Animation>().Play (ballState);
		ballTouch.ballAnimationIndex = 0;
		ballTouch.tObject = null;
	}

	void playRight () {
		ballStateIndex = Random.Range (6, 11);
		ballState = string.Format("ballLeftStrike{0}", ballStateIndex);
		ballTouch.tObject.GetComponent<Animation>().Play (ballState);
		ballTouch.ballAnimationIndex = 0;
		ballTouch.tObject = null;
	}


}
