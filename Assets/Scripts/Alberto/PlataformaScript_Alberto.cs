using UnityEngine;
using System.Collections;

public class PlataformaScript_Alberto : MonoBehaviour {
	public float ejeY = 2f;
	public float delay = 1f; 
	public float ejeX = 2f;
	private bool _right = true; 
	private float origeny;
	private float destinoy;
	private float destinox;
	private float origenx;
	private bool _up = true;
	public bool pausex = true;
	public bool pausey = true;
	private float waitTime = 0; 
	public bool auto =false;
	// Use this for initialization
	void Start () {
		origeny = transform.position.y;
		destinoy = transform.position.y + ejeY;
		origenx = transform.position.x;
		destinox = transform.position.x + ejeX;
	}
	// Update is called once per frame
	void Update () {
		//VERTICAL
		if (auto && pausey && Time.time < waitTime) {
			pausey = false;
		}

		if(_up && !pausey){
			transform.Translate (Vector3.up *Time.deltaTime);
		}else if ( !_up && !pausey){
			transform.Translate (Vector3.up *Time.deltaTime * -1);
		}
		if (Mathf.Abs(transform.position.y) > Mathf.Abs(destinoy) && !pausey) {
			_up = false;
			if(!auto) pausey = true;
			waitTime = Time.time + delay;
		}else if Mathf.Abs((transform.position.y) < (origeny) && !pausey){
			_up = true;
			if(!auto)pausey = true;
			waitTime = Time.time + delay;
		}
		//HORIZONTAL
		if (auto && pausex && Time.time < waitTime) {
			pausex = false;
		}
		
		if(_right && !pausex){
			transform.Translate (Vector3.right *Time.deltaTime);
		}else if ( !_right && !pausex){
			transform.Translate (Vector3.right *Time.deltaTime * -1);
		}
		if Mathf.Abs((transform.position.x) > (destinox) && !pausex) {
			_right = false;
			if(!auto)pausex = true;
			waitTime = Time.time + delay;
		}else if Mathf.Abs((transform.position.x) < (origenx) && !pausex){
			_right = true;
			if(!auto)pausex = true;
			waitTime = Time.time + delay;
		}
	}

  void activar(){
		pausex = false;
		pausey = false;
	}
}
