﻿using UnityEngine;
using System.Collections;

public class pilar_vida : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Vida " + GameControl.live;
	}
}
