﻿using UnityEngine;
using System.Collections;

public class SpawnerController_Alberto : MonoBehaviour {
	public GameObject spawnObject;
	
	void generaCaja(){
		var position = transform.position;

		Instantiate (spawnObject, position, transform.rotation);
		position.x += 1;
		Instantiate (spawnObject, position, transform.rotation);
		position.x += 1;
		Instantiate (spawnObject, position, transform.rotation);
	}
}