using UnityEngine;
using System.Collections;

public class pilar_CorazonScript : MonoBehaviour {
	public AudioClip Corazon;
	public static bool dead;
	float resetTimer = 0 ; 
	public int vida =50;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (Time.time > resetTimer && !GameControl.dead){
			AudioSource.PlayClipAtPoint(Corazon, transform.position);
		    resetTimer = Time.time + 3;
			GameControl.score = GameControl.live + vida;
			//Debug.Log ("LevelUp;" + GameControl.score);
			Destroy (gameObject);
		}

	}

}
