using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{

	public Player player;
	public Vector3 move;

	/* Member variables for managing input */
	/* Movement */
	public string horizontalAxis;
	public string verticalAxis;
	public string jump;

	/* Abilities */
	public string aString1;
	public string aString2;

	/* Movement */
	private Rigidbody rigidBody;
	public float speed; /* Customize this in game editor */
	public float jumpSpeed;

	public bool jumping = false;

	// Use this for initialization
	void Start()
	{
		player = GetComponent<Player>();
		rigidBody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		// large check list to go through every possible input key

		/*
		// This script shouldn't modify the player at all - it just gets inputs
		// Movement
		if (Input.GetButton(jump) && IsGrounded())
		{
			rigidBody.velocity =
				new Vector3(speed * Input.GetAxis(horizontalAxis), jumpSpeed, speed * Input.GetAxis(verticalAxis));
		}
		else
		{
			rigidBody.velocity =
				new Vector3(speed * Input.GetAxis(horizontalAxis), rigidBody.velocity.y, speed * Input.GetAxis(verticalAxis));
		}
		*/

		// Jump
		if (!jumping)
		{
			jumping = Input.GetButtonDown(jump);
		}

		if (Input.GetButtonDown(aString1))
		{
			player.AbilityUsed(1);
		}
		else if (Input.GetButtonDown(aString2))
		{
			player.AbilityUsed(2);
		}

	}

	// FixedUpdate is called once per physics update
	void FixedUpdate()
	{

		float h = Input.GetAxis(horizontalAxis);
		float v = Input.GetAxis(verticalAxis);
		float mDeltaX = 0;

		if (this.gameObject.tag == "MainCamera" || player.id == 0)
		{
			mDeltaX = Input.GetAxis("CameraHorizontal_P1");
		}
		else if (this.gameObject.tag == "MainCamera")
		{
			mDeltaX = Input.GetAxis("CameraHorizontal_P2");
		}


		//move = v * Vector3.forward + h * Vector3.right;
		move = v * transform.forward + h * transform.right;

		player.Move(move, jumping, mDeltaX);
		jumping = false;

	}

	// helper functions
	private bool IsGrounded()
	{
		return Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y + 0.1f);
	}
}
