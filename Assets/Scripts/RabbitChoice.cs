using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitChoice : MonoBehaviour {

	private int isDoubleJump = 0;
	private float randomizer;

	public void ChoiceOfJumps () {
		randomizer = Random.value;
		Debug.Log (randomizer);
		if (randomizer < 0.5f) {
			isDoubleJump = 0;
		} else
			isDoubleJump = 5;
		

	}
	

}
