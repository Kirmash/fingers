using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplauseAnimation : MonoBehaviour {
	private TouchController choirTouch;
	private Animator animator;

	// Use this for initialization
	void Start () {
		choirTouch = (TouchController)GameObject.Find("Main Camera").GetComponent(typeof(TouchController));
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (choirTouch.isChoirFinish) {
			animator.Play ("choir11applause");
			choirTouch.isChoirFinish = false;
		}
	}
}
