using UnityEngine;
using System.Collections;

public class BackChange : MonoBehaviour {
	public Sprite[] backs;
	private SpriteRenderer spriteRenderer;
	private TouchNumbers touchNumbers;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
		touchNumbers = GameObject.Find("shirmas").GetComponent<TouchNumbers>();

	}
	
	// Update is called once per frame
	void Update () {
	//	if (Input.touchCount > 0) {
		if (Input.GetMouseButton (0)) {
			//Debug.Log("Back_num: " + touchNumbers.currentSceneNum);
			spriteRenderer.sprite = backs [touchNumbers.currentSceneNum];
	}


}
}