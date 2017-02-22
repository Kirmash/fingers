using UnityEngine;
using System.Collections;

public class footballTabloScript : MonoBehaviour {

	public Sprite[] numbers;
	private CloseScript closeScript;
	private SpriteRenderer spriteRenderer;


	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
		closeScript = (CloseScript)GameObject.Find ("Redcross").GetComponent (typeof(CloseScript));

	}
	
	// Update is called once per frame
	void Update () {
	
		spriteRenderer.sprite = numbers [closeScript.touchCounter];

	}

	void OnDestroy() {

		spriteRenderer.sprite = null;
		spriteRenderer = null;
		closeScript = null;

	}
}
