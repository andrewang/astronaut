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
	private bool isClimbing = false;

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

		if(isClimbing ){
			UpdateClimb();
		}else{
			rigidbody2D.gravityScale =1f;
		}
		
		
	}

	//update the climbing animation
	
	public void UpdateClimb()
		
	{
		
		//condition evaluated if true
		
		//call the correct button and perform the animations.
		
		if(isClimbing )
			
		{
			
			//this is up
			
			if(Input.GetAxis("Vertical") > 0)
				
			{
				
				//turn off gravity
				
				rigidbody2D.gravityScale = 0;
				
				//move up the ladder at a slow pace
				
				//did that for testing
				
				transform.Translate(0,1 * Time.deltaTime,0);
				
				SendMessage("onClimb",SendMessageOptions.DontRequireReceiver);
				
			}
			
			//this is down
			
			else if(Input.GetAxis("Vertical") < 0)
				
			{
				
				rigidbody2D.gravityScale = 0;
				
				transform.Translate(0,-1 * Time.deltaTime,0);
				
				SendMessage("onClimb",SendMessageOptions.DontRequireReceiver);
				
			}
			
			else
				
				//if you are not moving then just go idle on the ladder
				
				SendMessage("onClimbIdle",SendMessageOptions.DontRequireReceiver);
			
		}
		
	}
	
	//enter the trigger
	
	public void OnTriggerEnter2D(Collider2D col)
		
	{

		
		if(col.gameObject.tag == "Ladder")
			
		{
			
			isClimbing = true;
			rigidbody2D.velocity = Vector2.zero;
			
		}
		
	}
	
	
	
	//exit the trigger      
	
	public void OnTriggerExit2D(Collider2D col)
		
	{
		Debug.Log("Exit Climb");
		
		if(col.gameObject.tag == "Ladder")
			
		{
			
			isClimbing = false;

			rigidbody2D.gravityScale =1f;
			
		}
		
	}
}
