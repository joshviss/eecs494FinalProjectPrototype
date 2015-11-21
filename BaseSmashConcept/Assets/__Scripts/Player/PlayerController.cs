using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	#region movement input
	[SerializeField]
	private string xLeftStick;
	[SerializeField]
	private string yLeftStick;
	[SerializeField]
	private string xRightStick;
	[SerializeField]
	private string yRightStick;
	[SerializeField]
	private string jumpKeybind;
	#endregion

	#region Controlled Objects
	private Player player;
	public GameObject thridPersonCamera;
	#endregion

	// Use this for initialization
	void Start()
	{
		player = GetComponent<Player>();
	}

	// Update is called once per frame
	void Update()
	{
		// Update Rotation
		player.UpdateRotation(
			Input.GetAxis(xRightStick), Time.deltaTime);

		// Update Movement
		player.UpdateMovement(
			Input.GetAxis(xLeftStick), Input.GetAxis(yLeftStick), Input.GetButton(jumpKeybind));
	}

	// FixedUpdate is called once per physics update
	void FixedUpdate()
	{
	}

}
