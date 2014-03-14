using UnityEngine;
using System.Collections;

public class Plataforma2Script : MonoBehaviour {

	private Transform P1;

	public bool pause = true;
	public float waitTime = 0; 
	public bool auto =false;
	public float speed = 1f;

	private Vector3 origen;
	private Vector3 destino;
	private float startTime;
	public float distancia;
	public bool adestino = true;
	public float distCovered;
	// Use this for initialization
	void Start () {
		P1 = transform.Find("P1");

		origen = transform.position;
		destino = P1.position;
		startTime = Time.time;
		distancia = Vector3.Distance(origen, destino);
	}
	// Update is called once per frame
	void Update () {
		 
		if (!pause) distCovered += Time.deltaTime * speed * 0.1f;

		if(adestino && !pause){
			transform.position = Vector3.Lerp(origen, destino, distCovered);
			if(transform.position == destino){
				adestino = false;
				distCovered = 0;
				startTime = Time.time;
				if(!auto) pause = true;
			}

		}else if(!adestino && !pause){
			transform.position = Vector3.Lerp(destino, origen, distCovered);
			if(transform.position == origen){
				adestino = true;
				distCovered = 0;
				startTime = Time.time;
				if(!auto) pause = true;
			}

		}
	}

  void activar(){
		pause = !pause;

	}
}
