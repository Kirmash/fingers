using UnityEngine;
using System.Collections;

public class NumberChoice : MonoBehaviour {

	public Sprite[] sprites;
	private int toyIndex;

	private float randomX;
	private float randomY;

	private bool isMouseClicked;

    public GameObject[] toys;
	public GameObject[] activeToys;
	private SpriteRenderer spriteRenderer;
	private TouchNumbers touchNumbers;
	private int index;

	void Start () {
		spriteRenderer = renderer as SpriteRenderer;
		touchNumbers = GameObject.Find("shirmas").GetComponent<TouchNumbers>();
		toys = Resources.LoadAll("toys", typeof(GameObject)) as GameObject[];
		isMouseClicked = false;
	}

	// Update is called once per frame
	void Update () {
		index = touchNumbers.numberFingers;
		spriteRenderer.sprite = sprites[index];
		if (Input.GetMouseButton(0) && !isMouseClicked) {
			print ("yeah");
			activeToys = new GameObject[touchNumbers.numberFingers];

			GetTheToys ();
		}

	if (isMouseClicked) {
			isMouseClicked = true;
		}
	
	}

	void GetTheToys ()
	{
	
						toyIndex = Random.Range(0, 2);
						randomX = Random.Range(100, Screen.width-100);
						randomY = Random.Range(100, Screen.height-100);
		for (int i = 0; i < touchNumbers.numberFingers; i++) {
			activeToys [i] = Instantiate (toys [toyIndex], new Vector3 (randomX, randomY, 0), Quaternion.identity) as GameObject;
		}
			
					}
	}

