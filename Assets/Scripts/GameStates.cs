using UnityEngine;
using System.Collections;

public class GameState {
	public enum States {
		Start, Number_1, Number_2, Number_3, Number_4, Number_5, Number_6, Number_7, Number_8, Number_9, Number_10
	}
	public static States state = States.Start;
	
	public static void ChangeState(States stateTo) {
		if(state == stateTo) 
			return;  
		state = stateTo;  
	}
	
	public static bool IsState(States stateTo) {        
		if(state == stateTo)
			return true;
		return false;
	}
	
	public static bool Number_1 {
		get {
			return IsState(States.Number_1);
		}
	}
	
	public static bool Number_2 {
		get {
			return IsState(States.Number_2);
		}
	}

	public static bool Number_3 {
		get {
			return IsState(States.Number_3);
		}
	}

	public static bool Number_4 {
		get {
			return IsState(States.Number_4);
		}
	}

	public static bool Number_5 {
		get {
			return IsState(States.Number_5);
		}
	}

	public static bool Number_6 {
		get {
			return IsState(States.Number_6);
		}
	}

	public static bool Number_7 {
		get {
			return IsState(States.Number_7);
		}
	}

	public static bool Number_8 {
		get {
			return IsState(States.Number_8);
		}
	}

	public static bool Number_9 {
		get {
			return IsState(States.Number_9);
		}
	}

	public static bool Number_10 {
		get {
			return IsState(States.Number_10);
		}
	}
}
