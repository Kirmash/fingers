using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundLevelDecrease : MonoBehaviour {

    private bool isActivated = false;
    private float volumeStep = 0.01f;
    private bool isDeceased = false;
    private RaycastHit2D hit;

    // Update is called once per frame
    void Update () {
        int nbTouches = Input.touchCount;
        if (nbTouches >0) { 
        if (Input.GetTouch(0).phase == TouchPhase.Began && Input.touchCount > 0 && !isActivated)
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
            if (hit.transform != null && hit.collider != null && hit.collider.tag == "cakerocket" && hit.transform == this.transform)
            {
                isActivated = true;
            }       
        }
        }
        if (isActivated)
        {
            Invoke("VolumeReduction", 1.5f);
        }
    }
    private void VolumeReduction ()
    {
        while (GetComponent<AudioSource>().volume > 0.25f)
        GetComponent<AudioSource>().volume -= 0.01f;
    }

}
