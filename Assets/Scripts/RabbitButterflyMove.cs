using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class RabbitButterflyMove : MonoBehaviour {
    GameObject childObj1;
	GameObject childObj2;
	private float force = 12.0f;
    private bool offsetChange = false;
	
	void Start() {
	childObj1 = transform.GetChild(0).GetChild(5).gameObject;
	childObj2 = transform.GetChild(0).GetChild(6).gameObject;
	}

	void Update() {

		StartCoroutine(Nudge());
		}


	IEnumerator Nudge() {
	if (childObj1.active || childObj2.active ) {
            Debug.Log(force);
           if (!offsetChange)
            {
                this.GetComponent<CircleCollider2D>().offset = new Vector2(transform.GetChild(0).transform.position.x, transform.GetChild(0).transform.position.y);
                offsetChange = true;
            }
            while (true) {
                if (this.gameObject.transform.position.y < 0f) {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Abs(Random.insideUnitCircle.x) * force, Mathf.Abs(Random.insideUnitCircle.y) * force));
                    if (force >= 1.0f)
                    {
                        force = force - 0.5f;
                    }

                } else if (this.gameObject.transform.position.y > 4.9f)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.insideUnitCircle.x * force, -Mathf.Abs(Random.insideUnitCircle.y) * force));
                    if (force >= 1.0f)
                    { 
                        force = force - 0.5f;
                    }
                }
                else {
                    GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * force);
                    if (force >= 1.0f)
                    {
                        force = force - 0.3f;
                    }
                }
			yield return new WaitForSeconds(Random.Range(0f, 1f));
		}  
		}
	}

}
