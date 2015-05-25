using UnityEngine;
using System.Collections;

public class AnimationVorotaScript : MonoBehaviour {

	private Animator animator;
	private BallTouchScript ballTouchScript;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator>();
		ballTouchScript = (BallTouchScript)GameObject.Find("Main Camera").GetComponent(typeof(BallTouchScript));
	}
	
	// Update is called once per frame

public void hitClose ()
{
	animator.SetFloat("strike", 1f);
}

public void hitAnim ()
{
	animator.SetFloat("strike", 3f);
}
}