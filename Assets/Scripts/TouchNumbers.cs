using UnityEngine;
using System.Collections;


public class TouchNumbers : MonoBehaviour 
{

	
	public AudioClip number1;
	public AudioClip number2;
	public AudioClip number3;
	public AudioClip number4;
	public AudioClip number5;
	public AudioClip number6;
	public AudioClip number7;
	public AudioClip number8;
	public AudioClip number9;
	public AudioClip number10;


	[HideInInspector] public int numberFingers = 1;

	
	[HideInInspector] public bool isMouseClicked = false;
	[HideInInspector] public bool isDoorOpen = false;

	protected Animator animator;

	public void DoorOpen ()
	{
		isDoorOpen = true;
	}

	public void DoorClosed ()
	{
		isDoorOpen = false;
	}



	void Start () 
	{
		animator = GetComponent<Animator>();
	}

	void Update () 
	{
		print ("All is " + (Input.GetMouseButton (0) && !isMouseClicked && !isDoorOpen));
		if(Input.GetMouseButton(0) && !isMouseClicked && !isDoorOpen) {
			numberFingers = Random.Range(0, 10);
			animator.SetFloat( "isOpen", 2 );
			animator.SetFloat( "isClosed", 0 );
			setNumber(numberFingers);
			isMouseClicked = true;
		}

		if (Input.GetMouseButtonUp(0) && isMouseClicked) 
		{
			isMouseClicked = false;
		}

		if(Input.GetMouseButton(0) && !isMouseClicked && isDoorOpen) {

			
			animator.SetFloat( "isOpen", 0 );
			animator.SetFloat( "isClosed", 2 );
			isMouseClicked = true;
		}

	}
	
	public void setNumber (int number)
	{
		
		switch (number)
		{
		case 0: 
			print(1);
			
			audio.PlayOneShot(number1);

			break;
			
		case 1: 
			print(2);
			
			audio.PlayOneShot(number2);
			break;
			
		case 2: 
			print(3);
			audio.PlayOneShot(number3);
			break;
			
		case 3: 
			print(4);
			audio.PlayOneShot(number4);
			break;
			
		case 4: 
			print(5);
			audio.PlayOneShot(number5);
			break;
			
		case 5: 
			print(6);
			audio.PlayOneShot(number6);
			break;
			
		case 6: 
			print(7);
			audio.PlayOneShot(number7);
			break;
			
		case 7: 
			print(8);
			audio.PlayOneShot(number8);
			break;
			
		case 8: 
			print(9);
			
			
			audio.PlayOneShot(number9);
			break;
			
		case 9: 
			print(10);
			audio.PlayOneShot(number10);
			break;
		}
		
	}

}