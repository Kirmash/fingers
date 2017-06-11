using UnityEngine;
using System.Collections;

public class HandAnimationScript : MonoBehaviour {


	public Sprite[] handFrames;
	public float framesPerSecondHands;
	private SpriteRenderer spriteRenderer;
	[HideInInspector] public bool isTutorialOn = true;
    private int nbTouches;
    public GameObject shirmas;
    private bool hasOpened;
    private Animator animator;

    // Use this for initialization
    void Start () {
	
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
        shirmas = GameObject.Find("shirmas");
        animator = shirmas.gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	              if (isTutorialOn) {
						int index = (int)(Time.timeSinceLevelLoad * framesPerSecondHands);
						index = index % handFrames.Length;

		//	Debug.Log ("Index: " + index);
						spriteRenderer.sprite = handFrames [index];
				}
		nbTouches = Input.touchCount;
			
		if (nbTouches > 0 || !animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_idle")) {
			
	//	if (Input.GetMouseButton (0)) {
			isTutorialOn = false;
			spriteRenderer.enabled = false;
				}
			
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("curtains_idle") && nbTouches == 0 ) {
			spriteRenderer.enabled = true;
            isTutorialOn = true;
           hasOpened = false;
        }

    }
}
