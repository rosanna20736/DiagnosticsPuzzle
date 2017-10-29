using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1_Light_prefab : MonoBehaviour {

	public Sprite lit, unlit;
	public bool OnOff;

	// Use this for initialization
	void Start () {
		OnOff = false;
	}

	// Update is called once per frame
	void Update () {
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		if (OnOff) {
			sr.sprite = lit;
		}
		else{
			sr.sprite = unlit;
		}
	}
		
}


