using UnityEngine;
using System.Collections;

public class butterflyBurst : MonoBehaviour {
    private RaycastHit2D hit;
    private GameObject tObject;
    private ParticleSystem ps;
    
 private ParticleSystem.EmissionModule EmissionButterfly;
    
    void Start () {
   //   ps = GetComponent<ParticleSystem>();
   //     var em = ps.emission;
    //    em.enabled = true;
    }
      
    void Update () {
        if (Input.touchCount > 0)
        { 
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
            if (hit.transform != null && hit.collider != null && hit.collider.tag == "cake")
            {
                GameObject.Find(hit.transform.gameObject.name).GetComponent<ParticleSystem>().Emit(30);
            // new ParticleSystem.Burst(2.0f, 100);
              }
        }
       
    }
}
