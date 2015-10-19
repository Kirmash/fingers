using UnityEngine;
using System.Collections;

public class numberLeftChange : MonoBehaviour {
	public Sprite[] numLeft;
	[HideInInspector]public SpriteRenderer spriteNumberLeft;
	private TouchNumbers touchNumbers;
	[HideInInspector]public bool numOpacity;
	private float opacitySpeed = 0.1f;
	private Color color;


	// Use this for initialization
	void Start () {
		spriteNumberLeft = GetComponent<Renderer>() as SpriteRenderer;
		touchNumbers = GameObject.Find("shirmas").GetComponent<TouchNumbers>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (numOpacity) {
			if (spriteNumberLeft.material.color.a < 1) {
				color = spriteNumberLeft.material.color;
				color.a += opacitySpeed;
				spriteNumberLeft.material.color = color;
			}
			
		} else {
			if (spriteNumberLeft.material.color.a > 0) {
				color = spriteNumberLeft.material.color;
				color.a -= opacitySpeed;
				spriteNumberLeft.material.color = color;
			}
		}
			}

public void ChangeNumber () {
		numOpacity = true;
	}
}
