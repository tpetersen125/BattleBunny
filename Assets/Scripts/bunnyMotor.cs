using UnityEngine;
using System.Collections;

public class bunnyMotor : MonoBehaviour {

	private Animator anim;

	public Rigidbody2D bunnyBody;

	public float moveSpeed;
	public float jumpSpeed;
	public float someNumber = 0;
	public float jumpState;

	public bool canShoot;
	public bool facingLeft;
	public bool pronePosition;
	public bool grounded;


	// Use this for initialization
	void Start () 
	{
		anim = GetComponentInChildren<Animator>();
		bunnyBody = GetComponent<Rigidbody2D>(); 
		facingLeft = true;
		pronePosition = false;
		jumpState = 0;
	}

	// Update is called once per frame
	void Update () 
	{

		// - XBOX CONTROLS - /////////////////////

		if(pronePosition == false)
		{
			// - Left MOVEMENT - ///////////////////
			if(Input.GetAxis("LeftJoystickX")<-0.1)
			{
				if(facingLeft == false)
				{
					Flip();
					facingLeft = true;
				}

				BunnyRunLeft();
				anim.SetBool("IsRunning", true);
				print ("Monkeys");
		}
		


			// - Right MOVEMENT - ///////////////////
			if(Input.GetAxis("LeftJoystickX")>0.1)
			{
				if(facingLeft == true)
				{
					Flip();
					facingLeft = false;
				}

				BunnyRunRight();
				anim.SetBool("IsRunning", true);
			}

			// - No Input for Left Stick X - //
			if(Input.GetAxis("LeftJoystickX")<=0.1)
			{
				if(Input.GetAxis("LeftJoystickX")>=-0.1)
				{
					anim.SetBool("IsRunning", false);
				}
			}

		}// End of things disabled if pronePosition is true


	
			
	

		// JUMPING /////////
		if(Input.GetButtonDown("A"))
		{
			if(jumpState < 1)
			{
				BunnyJump();
			}
		}

		// - Prone Position - //////////
		if(Input.GetAxis("LeftJoystickY")>0.6)
		{
			if(grounded == true)
			{
				anim.SetBool("IsProne", true);
				pronePosition = true;
			}
		}
		else if(Input.GetAxis("LeftJoystickY")<=0.6)
		{
			if(grounded == true)
			{
				anim.SetBool("IsProne", false);
				pronePosition = false;
			}
		}


	}// End of Update

	void FixedUpdate ()
	{
		if(grounded == true)
		{
			jumpState = 0;
		}
	}




	// Fires gun
	void FireShot ()
	{
		
	}




	public void BunnyJump () //Makes Bunny jump
	{
		bunnyBody.velocity = new Vector2 (bunnyBody.velocity.x, jumpSpeed);
		jumpState += 1;
	}




	public void BunnyRunRight () //Makes Bunny move right
	{
		bunnyBody.velocity = new Vector2 (moveSpeed, bunnyBody.velocity.y);
	}




	void BunnyRunLeft () //Makes Bunny move left
	{
		bunnyBody.velocity = new Vector2 (-moveSpeed, bunnyBody.velocity.y);
	}
		




	void Flip ()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}



	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Ground")
		{
			grounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Ground")
		{
			grounded = false;
		}
	}

}//End Monodevelop
