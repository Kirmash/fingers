using UnityEngine;
using System.Collections;

public class butterflyBurst : MonoBehaviour {
    private RaycastHit2D hit;
    private GameObject tObject;
   
    void Update () {
        if (Input.touchCount > 0 && this.GetComponent<ParticleSystem>().emissionRate == 0)
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
            if (hit.transform != null && hit.collider != null && hit.collider.tag == "cake")
            {
                tObject = GameObject.Find(hit.transform.gameObject.name);
                tObject.GetComponent<ParticleSystem>().emissionRate = 100;

                Invoke("StopEmission", 1f);
            }
        }
    }

    void StopEmission ()
    {
       tObject.GetComponent<ParticleSystem>().emissionRate = 0;
    }
}
