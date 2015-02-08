using UnityEngine;
using System.Collections;

public class NumChange : MonoBehaviour {
	public Sprite[] numbers;
	private SpriteRenderer spriteRenderer;
	private TouchNumbers touchNumbers;
	// Use this for initialization
	void Start () {
		spriteRenderer = renderer as SpriteRenderer;
		touchNumbers = GameObject.Find("shirmas").GetComponent<TouchNumbers>();
	}
	
	// Update is called once per frame
	void Update () {
	//if (Input.touchCount > 0) {
		if (Input.GetMouseButton(0)) {
						spriteRenderer.sprite = numbers [touchNumbers.numberFingers - 1];
				}
	}
}
