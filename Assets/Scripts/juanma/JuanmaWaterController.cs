using UnityEngine;
using System.Collections;

public class JuanmaWaterController : MonoBehaviour {

	public float waterGravity = 0.1f;
	private bool onWater = false;
	public float fforce = 0.2f;

	void FixedUpdate (){
		if(onWater && fforce > 0 ){

			rigidbody2D.AddForce(Vector2.up * fforce );
		}
	}

	public void OnTriggerEnter2D(Collider2D col)
		
	{
		
		
		if(col.gameObject.layer == LayerMask.NameToLayer("Water"))
			
		{
			Debug.Log("OnWater");
			if(!onWater){
				rigidbody2D.velocity = Vector2.zero;
			}
			onWater = true;

			rigidbody2D.gravityScale = waterGravity;
		}
		
	}
	
	
	
	//exit the trigger      
	
	public void OnTriggerExit2D(Collider2D col)
		
	{
		
		
		if(col.gameObject.layer == LayerMask.NameToLayer("Water"))
			
		{
			Debug.Log("ExitWater");
			onWater = false;
			
			rigidbody2D.gravityScale =1f;
			
		}
		
	}
}
