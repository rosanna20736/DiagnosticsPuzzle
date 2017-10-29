using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_prefab : MonoBehaviour {

	public Sprite lit, unlit;
	public bool OnOff;
	public bool This_Panel_Won;


	// Use this for initialization
	void Start () {
		This_Panel_Won = false;
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

	void OnMouseDown () {
		if (!This_Panel_Won) {		
			OnOff = !OnOff;
		}
	}
}
