using UnityEngine;
using System.Collections;

public class OctopusAnimation : MonoBehaviour {
	
	private TouchController ballTouch;
	private Animator animator;
    private RaycastHit2D hit;

    // Use this for initialization
    void Start () {
	
		ballTouch = (TouchController)GameObject.Find("Main Camera").GetComponent(typeof(TouchController));
		animator = GetComponent<Animator>();
	}

	void Update () {
        int nbTouches = Input.touchCount;

        if (nbTouches > 0 && this.animator.GetCurrentAnimatorStateInfo(0).IsName("octopus_idle"))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
            if (hit.transform != null && hit.collider != null && hit.collider.tag == "toy")
            {
                animator.Play("octopust_idleTap");
            }
            }
        if (ballTouch.animationIndex == 1) {
						playLeft ();
		}

		if (ballTouch.animationIndex == 2) {
						playRight ();
				}

		if (ballTouch.isFinishingFootball) {
			animator.Play ("octopus_jump");
			ballTouch.isFinishingFootball = false;
		}
		}

	private void playLeft () {
		animator.Play ("octopus_strike_left");
		ballTouch.animationIndex = 0;
	}

	private void playRight () {
		animator.Play ("octopus_strike_right");
		ballTouch.animationIndex = 0;
	}


}
