using UnityEngine;
using System.Collections;

public class PlayerHealthScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


	}

	void damage(float hit){
		GameControl.live -= hit;
		if (GameControl.live <= 0) {
			Application.LoadLevel(Application.loadedLevel);		
		}

	}
}
