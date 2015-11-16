using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
	/* Member variables for managing input */
	/* Movement */
	#region movement input
	public string horizontalAxis;
	public string verticalAxis;
	public string horizontalRototation;
	public string verticalRototation;
	public string jump;
	#endregion

	/* Abilities */
	#region abilities input
	public string aString1;
	public string aString2;
	#endregion

	#region for the ease of component accessing
	//private Rigidbody rigidBody;
	private Player player;
	#endregion

	static public bool paused = false;
	// public bool jumping = false;

	// Use this for initialization
	void Start()
	{
		player = GetComponent<Player>();
		//rigidBody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		// large check list to go through every possible input key

		// Jump
		// if (!jumping)
		// {
		// 	jumping = Input.GetButtonDown(jump);
		// }

		if (paused) {
			return;
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

		if (paused) {
			return;
		}

		player.UpdateRotation (Input.GetAxis (horizontalRototation), Time.deltaTime);
		player.UpdateMovement (Input.GetAxis(horizontalAxis), Input.GetAxis(verticalAxis), Input.GetButtonDown(jump));

		/*
		float h = Input.GetAxis(horizontalAxis);
		float v = Input.GetAxis(verticalAxis);
		float mDeltaX = 0;

		transform.Rotate (transform.up, rotationSpeed * inputHorizontalRotationScale * deltaTime);

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
		*/
	}

}
