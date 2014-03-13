using UnityEngine;
using System.Collections;

public class Juanmaia1 : MonoBehaviour {

	public float velocidad = 1f;
	public float maxSpeed = 3f;
	public float jumpForce = 30f;
	public float enemyDamage = 10f;
	private int right = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!haySuelo()) { 
			mediavuelta();
		}else{
			Vector2 v2 = new Vector2 (right * velocidad, 0);
			if(Mathf.Abs(rigidbody2D.velocity.x )< maxSpeed)            
				rigidbody2D.AddForce(v2);   
		}

		if(hayObstaculo()){
			salta();
		}

	}

	void OnCollisionEnter2D(Collision2D col){
		var colPos = col.transform.position;
		var enemyPos = transform.position;
		var _force = new Vector2(colPos.x - enemyPos.x, colPos.y - enemyPos.y);

		if (col.gameObject.tag == "Player") {
			col.transform.SendMessage("damage",enemyDamage);
			col.gameObject.rigidbody2D.AddForce(_force*500f);
		}
	}

	RaycastHit2D haySuelo(){
		var rayPos = transform.position;
		rayPos.x += 1f * right;
		var rayDir = transform.up * -1;
		
		
		
		RaycastHit2D hit = Physics2D.Raycast(rayPos, rayDir, 1f, 1 << LayerMask.NameToLayer("Ground"));
		Debug.DrawRay(rayPos, rayDir, Color.red);

		return hit;
	}

	RaycastHit2D hayObstaculo(){
			var rayPos = transform.position;
			rayPos.x += 1 * right;
			var rayDir = transform.right * right * 0.2f;

			RaycastHit2D hit = Physics2D.Raycast(rayPos, rayDir, 0.2f, 1 << LayerMask.NameToLayer("Item"));
			Debug.DrawRay(rayPos, rayDir, Color.green);
			
			return hit;
	}

	void mediavuelta(){
		Vector3 localx = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z );
		transform.localScale = localx ;
		right *= -1;
	}

	void salta(){
		Vector2 vjump = new Vector2(1*right,jumpForce );
		rigidbody2D.AddForce(vjump); 
	}
}
