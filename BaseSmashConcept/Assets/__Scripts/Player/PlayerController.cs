using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	#region movement input
	[SerializeField]
	private string horizontalAxis;
	[SerializeField]
	private string verticalAxis;
	[SerializeField]
	private string horizontalRototation;
	[SerializeField]
	private string verticalRototation;
	[SerializeField]
	private string jumpKey;
	#endregion
	
	#region Controlled Objects
	public GameObject thridPersonCamera;
	public GameObject player;
	#endregion
		
	public float speed; /* Customize this in game editor */
	public float jumpSpeed;
	private Rigidbody rigidBody;
	// Use this for initialization
	void Start()
	{

	}
	
	// Update is called once per frame
	void Update()
	{
		// Update Rotation
		player.GetComponent<Player01> ().UpdateRotation (
			Input.GetAxis (horizontalRototation), Time.deltaTime);

		// Update Movement
		player.GetComponent<Player01> ().UpdateMovement (
			Input.GetAxis(horizontalAxis), Input.GetAxis(verticalAxis), Input.GetButton(jumpKey));

		// transform.Rotate (Vector3.up, 30.0f * Input.GetAxis (horizontalRototation) * Time.deltaTime);
		
		// rotation .
		// Debug.DrawRay(transform.position, transform.forward, Color.green);
		
		// Movement
		/*
		if (Input.GetButton(jump) && IsGrounded())
		{
			rigidBody.velocity = transform.TransformDirection(
				new Vector3(speed * Input.GetAxis(horizontalAxis), jumpSpeed, speed * Input.GetAxis(verticalAxis))
				);
			Debug.DrawRay(transform.position, rigidBody.velocity, Color.gray);
		}
		else
		{
			rigidBody.velocity = transform.TransformDirection(
				new Vector3(speed * Input.GetAxis(horizontalAxis), rigidBody.velocity.y, speed * Input.GetAxis(verticalAxis))
				);
			Debug.DrawRay(transform.position, rigidBody.velocity, Color.gray);
		}
		// Jump
		*/
		
		/*
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
		*/
	}
	
	// FixedUpdate is called once per physics update
	void FixedUpdate()
	{
		/*
		float h = Input.GetAxis(horizontalAxis);
		float v = Input.GetAxis(verticalAxis);
		float mDeltaX;

		if (this.gameObject.tag == "MainCamera" || player.id == 0)
		{
			mDeltaX = Input.GetAxis("CameraHorizontal_P1");
		}
		else
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
