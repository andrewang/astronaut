using UnityEngine;
using System.Collections;

public class Teleporter2Script : MonoBehaviour {

	public GameObject T2;
	private Vector3 destino;
	public bool enterTrans = false;
	public bool teleport = false;
	private GameObject player;
	// Use this for initialization
	void Start () {
		destino = T2.transform.position;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.T)&&enterTrans){

			teletrans();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.transform.tag == "Player"){
			enterTrans = true;
			player = other.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		
		if (other.transform.tag == "Player"){
			enterTrans = false;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.transform.tag == "Player" && teleport){
			player = other.gameObject;

		}
	}

	void teletrans(){
		player.transform.position = destino;
		player.rigidbody2D.velocity = Vector3.zero;
		enterTrans = false;
	}
}
