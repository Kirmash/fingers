using UnityEngine;
using System.Collections;

public class StarFall : MonoBehaviour {

    private RaycastHit2D hit;
    private TouchNumbers touchNumbers;
    private CloseScript closeScript;
    private bool isTouched;
    // Use this for initialization

void Start() {
	touchNumbers = GameObject.Find("shirmas").GetComponent<TouchNumbers>();
    	closeScript = (CloseScript)GameObject.Find("Redcross").GetComponent(typeof(CloseScript));
}

    // Update is called once per frame
    void Update()
    {// Debug.Log("At least we are here");
        if (Input.touchCount > 0 && this.GetComponent<Animator>() && !touchNumbers.isInputLocked)
        { Debug.Log("Hit the star");
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
         
            if (hit.transform != null && hit.collider != null && hit.collider.tag == "cakerocket" && this.GetComponent<BoxCollider2D>() == hit.collider && !isTouched)
            {
               this.GetComponent<Animator>().SetFloat ("fallTime", 3.0f);
                Debug.Log(hit.transform);
               isTouched = true;        
             touchNumbers.InputShortLock();
			closeScript.touchCounter += 1;
            }
        }
    }
}
