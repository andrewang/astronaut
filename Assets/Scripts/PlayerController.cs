using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	[HideInInspector]
	public bool jump = false;            
	
	
	public float moveForce = 365f;            
	public float maxSpeed = 5f;            
	public float jumpForce = 1000f;    

	private bool grounded = false;            
	
	void Update()
	{
		
		if(Input.GetButtonDown("Jump"))
			jump = true;
		
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
		}
		
		
	}
}
