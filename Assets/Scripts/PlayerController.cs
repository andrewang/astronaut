using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	[HideInInspector]
	public bool jump = false;            
	
	
	public float moveForce = 365f;            
	public float maxSpeed = 5f;            
	public float jumpForce = 1000f; 
	public float verticalv = 0;
	private bool grounded = false; 

	private float localScalex = 1f;

	Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
		localScalex = transform.localScale.x;


	}

	
	void Update()
	{
		
		if (Input.GetButtonDown ("Jump")) {
			jump = true;
			anim.SetBool("jump",true);

		}

		if (rigidbody2D.velocity.y == 0f) {
						anim.SetBool ("ground", true);
		} else {
				anim.SetBool("ground",false);
		}

		if (rigidbody2D.velocity.x > 0f) {
			anim.SetFloat ("velocity", Mathf.Abs(rigidbody2D.velocity.x));
			Vector3 localx = new Vector3(localScalex ,transform.localScale.y,transform.localScale.z );
			transform.localScale = localx ;
		} else if (rigidbody2D.velocity.x < 0f) {
			Vector3 localx = new Vector3(localScalex * -1,transform.localScale.y,transform.localScale.z );
				transform.localScale = localx ;
				anim.SetFloat ("velocity", Mathf.Abs(rigidbody2D.velocity.x));
				
		}else{
				anim.SetFloat ("velocity", 0);
		}
		
	}
	
	void FixedUpdate ()
	{
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");
		
		
		if(h * rigidbody2D.velocity.x < maxSpeed)             
			rigidbody2D.AddForce(Vector2.right * h * moveForce);                  
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		
		// If the player should jump...
		if(jump)
		{    
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			jump = false;
			anim.SetBool("jump",false);
		}
		
		
	}
}
