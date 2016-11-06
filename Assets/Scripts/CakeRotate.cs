using UnityEngine;
using System.Collections;

public class CakeRotate : MonoBehaviour {
    private int rotationSpeed = 1;
    private bool isRotation = true;
    private bool rotateCounterClock = true;
    private Vector3 startPosition;
    private Vector3 currentPosition;
    // Use this for initialization
    void Start () {

        startPosition = this.transform.position;
    }
	
	// Update is called once per frame
	/// <summary>
    /// 
    /// </summary>
    void Update () {
        if (isRotation)
        {
            if (this.transform.position.x >= 0)
            {
                if (this.transform.rotation.z <= 0.07 && rotateCounterClock)
                {
                    this.transform.Rotate(Vector3.forward, Time.deltaTime * rotationSpeed);
                    if (this.transform.rotation.z >= 0.065)
                    {
                        rotateCounterClock = false;
                    }
                }
                else if (this.transform.rotation.z >= -0.07 && !rotateCounterClock)
                {
                    this.transform.Rotate(Vector3.back, Time.deltaTime * rotationSpeed);
                    if (this.transform.rotation.z <= -0.065)
                    {
                        rotateCounterClock = true;
                    }
                }

            }
        }
        currentPosition = this.transform.position;
        if (currentPosition != startPosition)
            isRotation = false;

    }
}
