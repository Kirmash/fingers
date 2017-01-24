using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitChoice : MonoBehaviour {

	//[HideInInspector] public int isDoubleJump = 0;
	private float randomizer;
	Animator animator;

	void Start () {
		animator = GetComponent<Animator>();
	}

	public void ChoiceOfJumps () {
		randomizer = Random.value;
//		Debug.Log (randomizer);
		if (randomizer < 0.5f) {
			animator.SetInteger("isDoubleJump",0);
		} else
			animator.SetInteger("isDoubleJump",5);

	}
	

}
