using UnityEngine;
using System.Collections;

public class Player01 : MonoBehaviour {

	#region rotation and movement attributes
	[SerializeField]
	private float speed;
	[SerializeField]
	private float rotationSpeed;
	[SerializeField]
	private float jumpPower;
	#endregion

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateRotation (float inputHorizontalRotationScale, float deltaTime)
	{
		transform.Rotate (transform.up, rotationSpeed * inputHorizontalRotationScale * deltaTime);
	}

	public void UpdateMovement (float inputHorizontalMovementScale, float inputVerticalMovementScale, bool startJumping)
	{
		if (startJumping && IsGrounded())
		{
			GetComponent<Rigidbody>().velocity = transform.TransformDirection(
				new Vector3(
					speed * inputHorizontalMovementScale,
			        jumpPower,
					speed * inputVerticalMovementScale)
				);
		}
		else
		{
			GetComponent<Rigidbody>().velocity = transform.TransformDirection(
				new Vector3(
					speed * inputHorizontalMovementScale,
			        GetComponent<Rigidbody>().velocity.y,
			        speed * inputVerticalMovementScale)
				);
		}
		
		Debug.DrawRay(transform.position, GetComponent<Rigidbody>().velocity, Color.gray);
	}

	bool IsGrounded()
	{
		return Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y + 0.1f);
	}
}
