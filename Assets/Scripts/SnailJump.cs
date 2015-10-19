using UnityEngine;
using System.Collections;

public class SnailJump : MonoBehaviour {
    private RaycastHit2D hit;
    // Use this for initialization


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && !this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("snailJump"))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
            if (hit.transform != null && hit.collider != null && hit.collider.tag == "toy")
            {
                this.GetComponent<Animator>().Play("snailJump");
            }
        }
    }
}
