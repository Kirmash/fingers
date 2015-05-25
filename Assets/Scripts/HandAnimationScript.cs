using UnityEngine;
using System.Collections;

public class HandAnimationScript : MonoBehaviour {


	public Sprite[] handFrames;
	public float framesPerSecondHands;
	private SpriteRenderer spriteRenderer;
	private bool isTutorialOn = true;

	// Use this for initialization
	void Start () {
	
		spriteRenderer = renderer as SpriteRenderer;

	}
	
	// Update is called once per frame
	void Update () {
	              if (isTutorialOn) {
						int index = (int)(Time.timeSinceLevelLoad * framesPerSecondHands);
						index = index % handFrames.Length;

		//	Debug.Log ("Index: " + index);
						spriteRenderer.sprite = handFrames [index];

				}
		//nbTouches = Input.touchCount;
		//		
		//		if (nbTouches > 0) {
		if (Input.GetMouseButton (0)) {
			isTutorialOn = false;
			spriteRenderer.enabled = false;
				}
	}
}
