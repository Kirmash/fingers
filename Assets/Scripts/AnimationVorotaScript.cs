using UnityEngine;
using System.Collections;

public class AnimationVorotaScript : MonoBehaviour {

	private BallTouchScript ballTouchScript;

	void Start () {
		
		ballTouchScript = (BallTouchScript)GameObject.Find("Main Camera").GetComponent(typeof(BallTouchScript));
	}

    void Update () {

		if (ballTouchScript.isStriked) {
			animation.Play ("vorota_strike");
			ballTouchScript.isStriked = false;
				}

	}
}