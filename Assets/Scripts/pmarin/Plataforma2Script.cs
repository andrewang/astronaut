using UnityEngine;
using System.Collections;

public class Plataforma2Script : MonoBehaviour {

	private GameObject P1;
	private GameObject P2;
	public bool pause = true;
	public float waitTime = 0; 
	public bool auto =false;
	// Use this for initialization
	void Start () {
		origen = transform.position.y;
		destino = transform.position.y + ejeY;
	}
	// Update is called once per frame
	void Update () {

	}

  void activar(){
		pause = false;
	}
}
