using UnityEngine;
using System.Collections;

public class pilar_PlataformaScript : MonoBehaviour {
	public float ejeY = 2f;
	public float delay = 1f; 
	private float origen;
	private float destino;
	private bool _up = true;
	public bool pause = true;
	private float waitTime = 0; 
	public bool auto =false;
	// Use this for initialization
	void Start () {
		origen = transform.position.y;
		destino = transform.position.y + ejeY;
	}
	// Update is called once per frame
	void Update () {
		if (auto && pause && Time.time < waitTime) {
			pause = false;
		}

		if(_up && !pause){
			transform.Translate (Vector3.up *Time.deltaTime);
		}else if ( !_up && !pause){
			transform.Translate (Vector3.up *Time.deltaTime * -1);
		}
		if (transform.position.y > destino && !pause) {
			_up = false;
			pause = true;
			waitTime = Time.time + delay;
		}else if (transform.position.y < origen && !pause){
			_up = true;
			pause = true;
			waitTime = Time.time + delay;
		}
	}

  void activar(){
		pause = false;
	}
}
