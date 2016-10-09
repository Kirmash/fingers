using UnityEngine;
using System.Collections;

public class SunShineScript : MonoBehaviour {

   private TouchNumbers touchNumbers;
    private CloseScript closeScript;
	
	// Use this for initialization
	void Start () {
		touchNumbers = GameObject.Find("shirmas").GetComponent<TouchNumbers>();
    	closeScript = (CloseScript)GameObject.Find("Redcross").GetComponent(typeof(CloseScript));
	}
	
	// Update is called once per frame
	void Update () {
	 if (closeScript.touchCounter == touchNumbers.numberFingers)
            {
	Invoke ("SunShine", 0.5f);
	}
	}
	
	void SunShine () {
		
	  this.GetComponent<Animator>().SetFloat ("SunShines", 3.0f);

	}
	
}
