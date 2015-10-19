using UnityEngine;
using System.Collections;

public class AnimationVorotaScript : MonoBehaviour {

	private TouchController ballTouchScript;

	void Start () {
		
		ballTouchScript = (TouchController)GameObject.Find("Main Camera").GetComponent(typeof(TouchController));
	}

    void Update () {

		if (ballTouchScript.isStriked) {
			GetComponent<Animation>().Play ("vorota_strike");
			ballTouchScript.isStriked = false;
				}

	}
}