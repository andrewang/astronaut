using UnityEngine;
using System.Collections;

public class FlagController_Alberto : MonoBehaviour {
	public GameObject spawner;
	private bool cajagenerada = false;

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.transform.tag == "Player"){
			anim.SetBool ("active", false);
			Debug.Log(other.transform.name);
			if(!cajagenerada){
				spawner.transform.SendMessage("generaCaja");
				cajagenerada = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		
		if (other.transform.tag == "Player"){
			anim.SetBool ("active", true);
			Debug.Log(other.transform.name);
			//spawner.transform.SendMessage("createObject");
		}
	}
}
