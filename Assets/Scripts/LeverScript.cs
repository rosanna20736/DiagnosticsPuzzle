using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour {

	public int Lever_Position;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < 8; i++) {
			Transform PositionChecking = this.transform.parent.GetChild (i + 1);
			if (PositionChecking.GetComponent<LeverPoint> ().isHere) {
				transform.position = PositionChecking.transform.position;
				Lever_Position = i;
			}
		}
	}
}
