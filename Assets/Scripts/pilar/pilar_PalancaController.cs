using UnityEngine;
using System.Collections;

public class pilar_PalancaController : MonoBehaviour {

	public float delay = 3f; 
	private float reactiveTime = 0f;
	private bool pulsate = false;
	Animator anim;
	public GameObject plataforma;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if((reactiveTime < Time.time) && pulsate){
			anim.SetBool ("activa", false);
			pulsate = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col){ 
		
		if (col.gameObject.transform.tag == "Player"){
			if(!pulsate){
				anim.SetBool ("activa", true);
				plataforma.SendMessage("activar",true);
				pulsate = true;
				reactiveTime = Time.time + delay;
			}
		}
	}
}
