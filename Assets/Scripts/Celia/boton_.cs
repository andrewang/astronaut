using UnityEngine;
using System.Collections;

public class boton_ : MonoBehaviour {
	public GameObject boton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter2D(Collider2D other){
				var exp = Instantiate (boton, transform.position, transform.rotation);
				Destroy (gameObject);
		}
} 
