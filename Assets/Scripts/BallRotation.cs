using UnityEngine;
using System.Collections;

public class BallRotation : MonoBehaviour {
    private TouchController ballTouch;
    private int rotationSpeed;
    private bool isRotation = true;
    private Vector3 startPosition;
    private Vector3 currentPosition;

    // Use this for initialization
    void Start () {
        ballTouch = (TouchController)GameObject.Find("Main Camera").GetComponent(typeof(TouchController));
        rotationSpeed = Random.Range(-10, 10);
        startPosition = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (isRotation)
        {
            if ((this.transform.rotation.z >= -90) || (this.transform.rotation.z <= 90)) {
                this.transform.Rotate(Vector3.forward, Time.deltaTime * rotationSpeed);
            }
            else this.transform.Rotate(Vector3.back, Time.deltaTime * rotationSpeed);
        }
        currentPosition = this.transform.position;
        if (currentPosition != startPosition)
            isRotation = false;

    }
}
