using UnityEngine;
using System.Collections;

public class WormJump : MonoBehaviour {
    private RaycastHit2D hit;
  
	void Update () {
        if (Input.touchCount > 0 && !this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("wormJump"))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
            if (hit.transform != null && hit.collider != null && hit.collider.tag == "toy")
            {
                this.GetComponent<Animator>().Play("wormJump");
            }
        }
    }
}
