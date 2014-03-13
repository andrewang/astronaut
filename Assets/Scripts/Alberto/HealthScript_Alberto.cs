using UnityEngine;
using System.Collections;

public class HealthScript_Alberto : MonoBehaviour {
	public float total_health = 100f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//guiText.text = "Vida " + total_health;
		if (total_health <= 0) {
			Application.LoadLevel(Application.loadedLevel);		
		}
	}

	void damage(float hit){
		total_health -= hit;
	}
}
