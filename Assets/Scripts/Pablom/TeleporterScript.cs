using UnityEngine;
using System.Collections;

public class TeleporterScript : MonoBehaviour {

	public GameObject T2;
	private Vector3 destino;
	// Use this for initialization
	void Start () {
		destino = T2.transform.position;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.transform.tag == "Player"){
			other.transform.position = destino;
			other.rigidbody2D.velocity = Vector3.zero;
		}
	}
}
