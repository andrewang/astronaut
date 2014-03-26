using UnityEngine;
using System.Collections;

public class pilar_ialava : MonoBehaviour {

	public float velocidad = 1f;
	public float maxSpeed = 3f;
	public float jumpForce = 30f;
	public float enemyDamage = 10f;
	public float altura = 0.1f;
	private float right = 1f;

	// Use this for initialization
	void Start () {
		}
	
	// Update is called once per frame
	void Update () {
				}

	void OnCollisionEnter2D(Collision2D col){
		var colPos = col.transform.position;
		var enemyPos = transform.position;
		var _force = new Vector2(colPos.x - enemyPos.x, colPos.y - enemyPos.y);

		if (col.gameObject.tag == "Player") {
			col.transform.SendMessage("damage",enemyDamage);
			Debug.Log("babosa daño");
			col.gameObject.rigidbody2D.AddForce(_force*500f);
		}
	}

	}

	
	