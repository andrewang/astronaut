using UnityEngine;
using System.Collections;

public class pilar_VueloController : MonoBehaviour {

	public Vector2 speed = new Vector2(30, 30);
	public Vector2 direction = new Vector2(-1, 0);
	public AudioClip shotSound;
	public GameObject []item;
	public float timeloop = 3f;

	public float amplitudeY=5.0f;
	public float omegaY=5.0f;
	public GameObject explosion;
	public float velocidad = 5;
	public float goRight = -1f;
	private bool destruido = false;	
	private float index;
	private Vector2 movement;
	private Vector2 mov_old;
	private	float nextloop;
	//private ParticleSystem particle;
	//private ScoreController score;

	public bool destroyed = false;
	// Use this for initialization
	void Start () {
		nextloop = Time.time + timeloop;

		//var humo = transform.Find ("Humo");
		//particle = (ParticleSystem)humo.GetComponent ("ParticleSystem");
		//particle.enableEmission = false;
			//score = GameObject.Find ("Score").GetComponent<ScoreController> ();
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit2D hit = Physics2D.Raycast(transform.position, goRight * transform.right, Mathf.Abs(goRight),1 );
		Debug.DrawRay(transform.position, goRight * transform.right, Color.red);

		if (hit || Time.time > nextloop) { 
			nextloop = Time.time + timeloop;
			Vector3 localx = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z );
			transform.localScale = localx ;
			goRight *= -1;
			
		}

		index += Time.deltaTime;
		float x = speed.x * direction.x;
		float y = amplitudeY*Mathf.Sin (omegaY*index);
		mov_old = movement;
		movement = new Vector2 (x, y);
		}
	void FixedUpdate(){
		if (!destroyed) {
			rigidbody2D.velocity = movement;
			Vector2 v2 = new Vector2 (goRight * velocidad, 0);
			rigidbody2D.velocity = v2;
		} 
		 else {
			rigidbody2D.gravityScale = 1f;
				}

		}

		//if (col.gameObject.tag == "Limite") {
			//Debug.Log ("Choque");
			//direction *= -1;}

		}



