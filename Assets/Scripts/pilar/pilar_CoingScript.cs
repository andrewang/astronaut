using UnityEngine;
using System.Collections;

public class pilar_CoingScript : MonoBehaviour {
	public AudioClip LevelUp;
	public static bool dead;
	float resetTimer = 0 ; 
	public int puntos =1;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (Time.time > resetTimer && !GameControl.dead){
			AudioSource.PlayClipAtPoint(LevelUp, transform.position);
		    resetTimer = Time.time + 3;
			GameControl.score = GameControl.score + puntos;
			//Debug.Log ("LevelUp;" + GameControl.score);
			Destroy (gameObject);
		}

	}

}
