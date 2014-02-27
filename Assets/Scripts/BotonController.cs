using UnityEngine;
using System.Collections;

public class BotonController : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){ 
		
		if (col.gameObject.transform.tag == "Player")
			anim.SetBool ("pulse", true);
	}
}
