using UnityEngine;
using System.Collections;

public class SpawnerController : MonoBehaviour {
	public GameObject spawnObject;
	
	void generaCaja(){

		Instantiate (spawnObject, transform.position, transform.rotation);
	}
}