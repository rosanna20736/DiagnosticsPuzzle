using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLights : MonoBehaviour {

	public GameObject L1_Green_prefab, L1_Red_prefab, L1_Yellow_prefab, L1_Blue_prefab;
	public GameObject L2_Green_prefab, L2_Red_prefab, L2_Yellow_prefab, L2_Blue_prefab;
	public List<List<GameObject>> L1_Buttons, L2_Buttons;

	// Use this for initialization
	void Start () {
		//Import controller script
		Controller2 ControllerScript = GameObject.Find("background").GetComponent<Controller2>();

		//Button separation distances
		float xsep1 = 2f, xsep2 = 3.4f,xsep3 = 6.9f;
		float ysep1 = 3.3f * xsep1 / 5f;
		float ysep2 = 3.3f * xsep2 / 5f;

		//Make lists of positions of buttons
		List<Vector3> L1_Positions = MakeL1Positions (xsep2, xsep3, ysep2);
		List<Vector3> L2_Positions = MakeL2Positions (xsep2, xsep3, ysep2);
		List<Vector3> RelativeButtonPositions = MakeRelativePositions (xsep1, ysep1);

		//import various assignments from controller script
		List<List<int>> ColorAssignments = ControllerScript.ColorAssignments;
		List<int> LeverAssignments = ControllerScript.LeverAssignments;

		L1_Buttons = new List<List<GameObject>> (8);
		L2_Buttons = new List<List<GameObject>> (8);


		RenderLights (ColorAssignments, L1_Positions, L2_Positions, RelativeButtonPositions, LeverAssignments);

	}
	
	// Update is called once per frame
	void FixedUpdate () {



	}

	List<Vector3> MakeL1Positions (float xsep2, float xsep3, float ysep2) {
		// {xpos, ypos} for centre of each of 8 sets of lights corresponding to lever 1 operation
		List<Vector3> Positions = new List<Vector3>(){
			new Vector3 (-xsep3 - xsep2, 3f * ysep2),
			new Vector3 (xsep3 - xsep2, 3f * ysep2),
			new Vector3 (-xsep3 + xsep2, ysep2),
			new Vector3 (xsep3 + xsep2, ysep2),
			new Vector3 (-xsep3 - xsep2, -ysep2),
			new Vector3 (xsep3 - xsep2, -ysep2),
			new Vector3 (-xsep3 + xsep2, - 3f * ysep2),
			new Vector3 (xsep3 + xsep2, - 3f * ysep2)
		};
				return Positions;
	}

	List<Vector3> MakeL2Positions(float xsep2, float xsep3, float ysep2) {
		// {xpos, ypos} for centre of each of 8 sets of lights corresponding to lever 2 operation
		List<Vector3> Positions = new List<Vector3>(){
			new Vector3 (-xsep3 + xsep2, 3f * ysep2),
			new Vector3 (xsep3 + xsep2, 3f * ysep2),
			new Vector3 (-xsep3 - xsep2, ysep2),
			new Vector3 (xsep3 - xsep2, ysep2),
			new Vector3 (-xsep3 + xsep2, -ysep2),
			new Vector3 (xsep3 + xsep2, -ysep2),
			new Vector3 (-xsep3 - xsep2, - 3f * ysep2),
			new Vector3 (xsep3 - xsep2, - 3f * ysep2)
		};
		return Positions;
	}

	List<Vector3> MakeRelativePositions(float x, float y) {
		// {xpos, ypos} of each button from centre of set
		List<Vector3> Positions = new List<Vector3> () {
			new Vector3 ( -x, y ),
			new Vector3 ( 0, y ),
			new Vector3 ( x, y ),
			new Vector3 (-x, 0 ),
			new Vector3 ( 0, 0 ),
			new Vector3 ( x, 0 ),
			new Vector3 ( -x, -y ),
			new Vector3 ( 0, -y ),
			new Vector3 ( x, -y )
		};
			return Positions;
	}
		
	void RenderLights (List<List<int>> ColorAssignments, List<Vector3> L1_Positions, List<Vector3> L2_Positions, List<Vector3> RelativeButtonPositions, List<int> LeverAssignments){
		for (int i = 0; i <= 7; i++) {
			
			L1_Buttons.Add (new List<GameObject> (9));
			L2_Buttons.Add (new List<GameObject> (9));

			for (int j = 0; j <= 8; j++) {
				switch (ColorAssignments [i] [j]) {
				case 1:
					L1_Buttons[i].Add(Instantiate (L1_Red_prefab, L1_Positions [i] + RelativeButtonPositions [j], Quaternion.identity, transform));
					L2_Buttons[i].Add(Instantiate (L2_Red_prefab, L2_Positions [LeverAssignments[i]] + RelativeButtonPositions [j], Quaternion.identity, transform));
					break;
				case 2:
					L1_Buttons[i].Add(Instantiate (L1_Green_prefab, L1_Positions [i] + RelativeButtonPositions [j], Quaternion.identity, transform));
					L2_Buttons[i].Add(Instantiate (L2_Green_prefab, L2_Positions [LeverAssignments[i]] + RelativeButtonPositions [j], Quaternion.identity, transform));
					break;
				case 3:
					L1_Buttons[i].Add(Instantiate (L1_Yellow_prefab, L1_Positions [i] + RelativeButtonPositions [j], Quaternion.identity, transform));
					L2_Buttons[i].Add(Instantiate (L2_Yellow_prefab, L2_Positions [LeverAssignments[i]] + RelativeButtonPositions [j], Quaternion.identity, transform));
					break;
				case 4:
					L1_Buttons[i].Add(Instantiate (L1_Blue_prefab, L1_Positions [i] + RelativeButtonPositions [j], Quaternion.identity, transform));
					L2_Buttons[i].Add(Instantiate (L2_Blue_prefab, L2_Positions [LeverAssignments[i]] + RelativeButtonPositions [j], Quaternion.identity, transform));
					break;
				default:
					Debug.Log("RenderLights switch default");
					break;
				}
			}
		}
	}

}
