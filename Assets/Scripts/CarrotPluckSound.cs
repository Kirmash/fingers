using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotPluckSound : MonoBehaviour {
	public AudioClip[] carrotPluck;
	private bool isCarrotPlucked;
	private int carrotSoundRandom;


	
	// Update is called once per frame
	 void Update () {
		if (this.transform.Find ("insideCarrot").gameObject.layer == 12) {
			if (!isCarrotPlucked) {
				carrotSoundRandom = Random.Range (0, 2);
				GetComponent<AudioSource> ().PlayOneShot (carrotPluck [carrotSoundRandom]);
				isCarrotPlucked = true;
			}
		}
	}
}
