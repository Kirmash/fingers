using UnityEngine;
using System.Collections;

public class AnimationVorotaScript : MonoBehaviour {

	private Animator animator;
	//private BallTouchScript ballTouchScript;

	void Start () {

		animator = GetComponent<Animator>();
		//ballTouchScript = (BallTouchScript)GameObject.Find("Main Camera").GetComponent(typeof(BallTouchScript));
	}


public void hitClose ()
{
	animator.SetFloat("strike", 1f);
}

public void hitAnim ()
{
	animator.SetFloat("strike", 3f);
}
}