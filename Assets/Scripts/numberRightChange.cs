using UnityEngine;
using System.Collections;

public class numberRightChange : MonoBehaviour {
	public Sprite[] numRight;
	[HideInInspector]public SpriteRenderer spriteNumberRight;
	private TouchNumbers touchNumbers;
	[HideInInspector]public bool numOpacity;
	private Color color;
	private float opacitySpeed = 0.05f;
	// Use this for initialization
	void Start () {
		spriteNumberRight = renderer as SpriteRenderer;
		touchNumbers = GameObject.Find("shirmas").GetComponent<TouchNumbers>();
	}
	
	// Update is called once per frame
	void Update () {
				if (numOpacity) {
			if (spriteNumberRight.material.color.a < 1) {
				color = spriteNumberRight.material.color;
				color.a += opacitySpeed;
				spriteNumberRight.material.color = color;
						}

				} else {
					
			if (spriteNumberRight.material.color.a > 0) {
				color = spriteNumberRight.material.color;
				color.a -= opacitySpeed;
				spriteNumberRight.material.color = color;
			}
				}
		}

public void ChangeNumber () {
		numOpacity = true;
	}
}
