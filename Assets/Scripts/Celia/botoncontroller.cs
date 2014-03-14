using UnityEngine;
using System.Collections;

public class botoncontroller : MonoBehaviour {
	
	public float delay = 3f; 
	private float reactiveTime = 0f;
	private bool pulsado = false;
	Animator anim;
	//public GameObject plataforma;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if((reactiveTime < Time.time) && pulsado){
			anim.SetBool ("pulsado", false);
			pulsado = true;
		}
	}
	

}