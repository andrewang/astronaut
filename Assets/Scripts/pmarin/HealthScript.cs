﻿using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	public float total_health = 100f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void damage(float hit){
		total_health -= hit;
		if(total_health<0) Destroy (gameObject);
	}
}
