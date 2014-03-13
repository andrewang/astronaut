using UnityEngine;
using System.Collections;

public class pilar_LiveController : MonoBehaviour {
	public int total_live = 1000;

	
	// Update is called once per frame
	void Update () {
		guiText.text = "TextVida: "+ total_live;
		if (total_live <= 0) {
			Application.LoadLevel ("Menuinicio");
		}
	
	}
}
