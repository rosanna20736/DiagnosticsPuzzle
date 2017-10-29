using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LightsController : MonoBehaviour {

	private List<List<int>> LightAssignments;
	private List<int> LeverAssignments;
	private List<List<GameObject>> L1_Buttons, L2_Buttons;
	public List<bool> Win_Conditions_Fulfilled;
	private List<bool> AllTrue;
	bool QuitNow;
	float timeCounter, TimeToWait;
	public GameObject WinText;

	// Use this for initialization
	void Start () {
		//Import controller script
		Controller2 ControllerScript = GameObject.Find("background").GetComponent<Controller2>();
		LightAssignments = ControllerScript.LightAssignments;
		LeverAssignments = ControllerScript.LeverAssignments;

		L1_Buttons = GameObject.Find("Lights").GetComponent<MakeLights>().L1_Buttons;
		L2_Buttons = GameObject.Find("Lights").GetComponent<MakeLights>().L2_Buttons;

		QuitNow = false;
		timeCounter = 0f;
		TimeToWait = 10f;

		Win_Conditions_Fulfilled = new List<bool> (8);
		AllTrue = new List<bool> (8);
		for (int i = 0; i <= 7; i++) {
			Win_Conditions_Fulfilled.Add (false);
			AllTrue.Add (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Win_Conditions_Fulfilled.SequenceEqual (AllTrue)) {
			AllLightsOn ();
			Instantiate(WinText, new Vector3 (0f,0f,-1f), Quaternion.identity);
			WaitAndQuit ();

		} else {

			int L1_Position = GameObject.Find ("left_lever").GetComponent<LeverScript> ().Lever_Position;
			int L2_Position = GameObject.Find ("right_lever").GetComponent<LeverScript> ().Lever_Position;

			Light_L1_Buttons (L1_Position);

			if (LeverAssignments [L1_Position] == L2_Position) {
				Win_Conditions_Fulfilled [L1_Position] = Check_Win_Conditions (L1_Position, L2_Position);
				if (Win_Conditions_Fulfilled [L1_Position]) {
					Disable_L2_Buttons (L1_Position);
				}
			}
		}


	}



	void Light_L1_Buttons (int L1_Position) {
		//Turn off lights in positions not selected by lever, if they have not yet been won. Turn on in the winning pattern if they have been won
		for (int i = 0; i <= 7; i++) {
			if (i != L1_Position) {
				if (Win_Conditions_Fulfilled [i]) {
					for (int j = 0; j <= 4; j++) {
						if (i != 10) {
							L1_Buttons [i] [LightAssignments [i] [j]].GetComponent<L1_Light_prefab> ().OnOff = true;
						}
					}
				} else {
					for (int j = 0; j <= 8; j++) {
						L1_Buttons [i] [j].GetComponent<L1_Light_prefab> ().OnOff = false;
					}
				}
			}
		}

		//Blink lights in pattern for panel selected by L1 lever.
		if (Time.fixedTime%1<.5){
			for (int j = 0; j <= 4; j++) {
				if (L1_Position != 10) {
					L1_Buttons [L1_Position] [LightAssignments [L1_Position] [j]].GetComponent<L1_Light_prefab> ().OnOff = true;
				}
			}
		} else {
			for (int j = 0; j <= 4; j++) {
				if (L1_Position != 10) {
					L1_Buttons [L1_Position] [LightAssignments [L1_Position] [j]].GetComponent<L1_Light_prefab> ().OnOff = false;
				}
			}
		}

	}
		
	void AllLightsOn(){
		for (int i = 0; i <= 7; i++) {
			for (int j = 0; j <= 8; j++) {
				L1_Buttons [i] [j].GetComponent<L1_Light_prefab> ().OnOff = true;
				L2_Buttons [i] [j].GetComponent<Light_prefab> ().OnOff = true;
			}
		}
	}

	void Disable_L2_Buttons (int L1_Position) {
		for (int i = 0; i <= 8; i++) {
			L2_Buttons [L1_Position] [i].GetComponent<Light_prefab> ().This_Panel_Won = true;
		}
	}


	bool Check_Win_Conditions (int L1_Position, int L2_Position) {

		List<bool> Checking_List = new List<bool> (9);
		for (int i = 0; i <= 8; i++) {
			Checking_List.Add (LightAssignments[L1_Position].IndexOf(i) != -1);
		}
			
		List<bool> Actual_List = new List<bool> (9);
		for (int i = 0; i <= 8; i++) {
			Actual_List.Add (L2_Buttons[L1_Position][i].GetComponent<Light_prefab> ().OnOff);
		}

		return Actual_List.SequenceEqual(Checking_List);
	}

	void WaitAndQuit () {
		if (QuitNow) {
			Application.Quit ();
		} else {
			timeCounter += Time.deltaTime;
			if (timeCounter >= TimeToWait) {
				QuitNow = true;
			}
		}
	}
		

}
