using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
	public string attack;
	public string dodge;
	public int ability1 = 4;
	public int ability2 = 2;
	#endregion

	#region for the ease of component accessing
	//private Rigidbody rigidBody;
	private Player player;
	private ThirdPersonCamera tpcamera;
	#endregion

	// Use this for initialization
	void Start()
	{
		player = GetComponent<Player>();
		tpcamera = GetComponentInChildren<ThirdPersonCamera>();
	}

	// Update is called once per frame
	void Update()
	{
		// large check list to go through every possible input key

		if (Timer.paused)
		{
			return;
		}

		if (Input.GetButtonDown(aString1))
		{
			player.AbilityUsed(ability1);
		}
		if (Input.GetButtonDown(aString2))
		{
			player.AbilityUsed(ability2);
		}

		if (Input.GetButtonDown(attack))
		{
			player.Attack();
		}

		if (Input.GetButtonDown(dodge))
		{
			player.Dodge();
		}

	}

	// FixedUpdate is called once per physics update
	void FixedUpdate()
	{

		if (Timer.paused)
		{
			return;
		}

		player.UpdateRotation(Input.GetAxis(horizontalRototation), Time.deltaTime);
		player.UpdateMovement(Input.GetAxis(horizontalAxis), Input.GetAxis(verticalAxis), Input.GetButtonDown(jump));
		tpcamera.cameraMoveVert(Input.GetAxis(verticalRototation));

	}

}
