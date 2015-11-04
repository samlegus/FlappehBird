using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour 
{
	//Field is another term for variable
	#region Fields
	
	public float upForce;						//upward force of the "flap" , measured in NEWTONS
	public float forwardSpeed;					//forward movement speed, measured in meters per second per second
	public bool isDead = false;					//has the player collided with a wall?
	
	//Animator anim;							//reference to the animator component
	Rigidbody2D rb;								//reference to the rigidbody2d component
	bool flapTriggered = false;					//has the player triggered a "flap"?
	
	#endregion
	
	//Messages are functions that are AUTOMATICALLY called by Unity
	#region Messages
	
	void Awake()								//Awake is called before Start(), use it to store component references.										
	{
		rb = GetComponent<Rigidbody2D>(); 		//Store a reference to our Rigidbody2D so we can access it easily 
	}
	
	void Start()								//Start is called after Awake(), use it for initialization logic								
	{
		rb.velocity = new Vector2 (forwardSpeed, 0);	//Object will move to the right until something stops it											
	}

	//Update is called every frame. Faster CPU = More function calls.
	void Update()
	{
		if (isDead == true)						// Don't update if we're dead
		{
			return;								// Did you know you can make a void function return early?
		}
		
		if (Input.anyKeyDown == true)		
		{	
			SetFlapTrigger();						
		}
	}

	//We used FixedUpdate primarily for Physics Stuff
	//FixedUpdate gets called 200 times per second w/ default project settings.
	void FixedUpdate()							
	{
		if (flapTriggered == true) 
		{
			flapTriggered = false;							//Set back to false so the stuff below only happens once per flap!
			rb.velocity = new Vector2(rb.velocity.x, 0);	//Remove y velocity
			rb.AddForce(new Vector2(0, upForce));			//Use AddForce to jump!									
		}
	}
	
	void OnCollisionEnter2D(Collision2D other)				//This will get called whenever we hit another Collider2D
	{											
		isDead = true;						
		//anim.SetTrigger ("Die");
	}
	
	#endregion
	
	//Method is another term for function
	#region My Methods
	
	void SetFlapTrigger()
	{
		flapTriggered = true;
		//anim.SetTrigger("Flap");
	}
	

	
	#endregion
}
