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
	public string attack;
	public string dodge;
	#endregion

	#region for the ease of component accessing
	//private Rigidbody rigidBody;
	private Player player;
	#endregion

	static public bool paused = false;

	// Use this for initialization
	void Start()
	{
		player = GetComponent<Player>();
	}

	// Update is called once per frame
	void Update()
	{
		// large check list to go through every possible input key

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

		if (Input.GetButtonDown (attack)) {
			player.Attack();
		}

		if (Input.GetButtonDown (dodge)) {
			player.Dodge ();
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

	}

}
