using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPoint : MonoBehaviour {

	public bool isHere;

	// Use this for initialization
	void Start () {
		isHere = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown () {
		for(int i = 0; i < 8; i++) {
			this.transform.parent.GetChild(i+1).GetComponent<LeverPoint>().isHere = false;
		}
		isHere = true;
	}
}
