using UnityEngine;
using System.Collections;

public class ia2 : MonoBehaviour {

	public float velocidad = 1f;
	public float maxSpeed = 3f;
	public float jumpForce = 30f;
	public float enemyDamage = 10f;
	public float altura = 0.1f;
	public float timeAutoFlip = 4f;
	private float right = 1;
	private float timedelay = 0;
	private float nextFlip; 

	// Use this for initialization
	void Start () {
		nextFlip = Time.time + timeAutoFlip;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Time.time > nextFlip){
			mediavuelta();
		}
		Vector2 v2 = new Vector2 (right * velocidad, 0);
		if(Mathf.Abs(rigidbody2D.velocity.x )< maxSpeed)            
			rigidbody2D.AddForce(v2);   




	}

	void OnCollisionEnter2D(Collision2D col){
		var colPos = col.transform.position;
		var enemyPos = transform.position;
		var _force = new Vector2(colPos.x - enemyPos.x, colPos.y - enemyPos.y);

		if (col.gameObject.tag == "Player") {
			col.transform.SendMessage("damage",enemyDamage);
			col.gameObject.rigidbody2D.AddForce(_force*500f);
		}else{
			mediavuelta();
		}
	}


	RaycastHit2D hayObstaculo(){
			var rayPos = transform.position;
			rayPos.x += altura * right;
			var rayDir = transform.right * right * 0.1f;

			RaycastHit2D hit = Physics2D.Raycast(rayPos, rayDir, altura, 1 );
			Debug.DrawRay(rayPos, rayDir, Color.green);
			
			return hit;
	}

	void mediavuelta(){
		if(timedelay < Time.time){
			Vector3 localx = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z );
			transform.localScale = localx ;
			right *= -	1f;
			rigidbody2D.velocity = Vector3.zero;
			timedelay = Time.time + 1;
			nextFlip = Time.time + timeAutoFlip;
		}
	}


}
