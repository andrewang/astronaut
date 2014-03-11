using UnityEngine;
using System.Collections;

public class BotonController : MonoBehaviour {

	public float dalay = 3f; 
	private float reactiveTime = 0f;
	private bool pulsate = false;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if((reactiveTime < Time.time) && pulsate){
			anim.SetBool ("pulse", false);
			pulsate = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col){ 
		
		if (col.gameObject.transform.tag == "Player"){
			anim.SetBool ("pulse", true);
			pulsate = true;

			reactiveTime = Time.time + dalay;

			Debug.Log(reactiveTime);
		}
	}
}
