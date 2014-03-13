using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	[HideInInspector]
	           
	
	
	public float moveForce = 365f;            
	public float maxSpeed = 5f;            
	public float jumpForce = 1000f; 
	public float verticalv = 0;
	public bool grounded = false; 
	public bool doubleJump = false;
	public bool jump = false; 
	private float localScalex = 1f;

	Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
		localScalex = transform.localScale.x;
	}
	
	void Update()
	{



		if (Input.GetButtonDown ("Jump")&&!doubleJump) {
			if(!grounded){
				doubleJump = true;
			}
			jump = true;
			anim.SetBool("jump",true);
			grounded = false;
		}


		if(rigidbody2D.velocity.y == 0f) {
						anim.SetBool ("ground", true);
			grounded = true;
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
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			jump = false;
			anim.SetBool("jump",false);
		}

		if(haySuelo()){
			grounded = true;
			jump = false;
			doubleJump = false;
		}else{
			grounded = false;
		}

		/*if(onWater ){
			//rigidbody2D.AddForce(Vector2.up);
		}else{
			rigidbody2D.gravityScale =1f;
		}*/
		
		
	}

	bool haySuelo(){
	var rayPos = transform.position;
	var rayDir = transform.up * -0.5f;
	
	
	
	RaycastHit2D hit = Physics2D.Raycast(rayPos, rayDir, 1f, 1 << LayerMask.NameToLayer("Ground"));
	Debug.DrawRay(rayPos, rayDir, Color.yellow);
	if(hit){
			return true;
	}else{
			return false;
		}
	
	}

	//update the climbing animation
	

	

}
