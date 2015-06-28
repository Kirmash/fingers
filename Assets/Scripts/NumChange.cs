using UnityEngine;
using System.Collections;

public class NumChange : MonoBehaviour {
	public Sprite[] numbers;
	[HideInInspector] public SpriteRenderer spriteRenderer;
	private TouchNumbers touchNumbers;
	private CloseScript closeScript;
	[HideInInspector] public bool changeBack = false;
	//private BallTouchScript ballTouchScript;
	// Use this for initialization
	void Start () {
		spriteRenderer = renderer as SpriteRenderer;
		touchNumbers = GameObject.Find("shirmas").GetComponent<TouchNumbers>();
		closeScript = GameObject.Find ("Redcross").GetComponent<CloseScript> ();
	//	ballTouchScript = (BallTouchScript)GameObject.Find("Main Camera").GetComponent(typeof(BallTouchScript));


	}
	
	// Update is called once per frame
	void Update () {


		if (changeBack) {
		//	Debug.Log("ChangeBack " + touchNumbers.numberFingers);
						spriteRenderer.sprite = numbers [touchNumbers.numberFingers - 1];
			changeBack = false;

				}
		
				}
		
	public void BackChange () {
	//	Debug.Log (closeScript.touchCounter);
		spriteRenderer.sprite = numbers [closeScript.touchCounter];

	}
}
