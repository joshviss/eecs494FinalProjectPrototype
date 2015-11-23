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
	public int ability1 = 1;
	public int ability2 = 2;
	#endregion

	#region for the ease of component accessing
	//private Rigidbody rigidBody;
	private Player player;
	#endregion

	#region for character switching
	float timer = 5;
	public string characterA, characterB;
	public Canvas select;
	public Image cursorA, cursorB;
	public int id;
	public Text counter;
	#endregion

	static public bool paused = false;

	// Use this for initialization
	void Start()
	{
		player = GetComponent<Player>();

		cursorA.enabled = true;
		cursorB.enabled = false;
		counter.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		// large check list to go through every possible input key

		if (paused) {
			return;
		}
		/*
		if (select.isActiveAndEnabled) {
			counter.enabled = true;
			timer -= Time.deltaTime;
			counter.text = timer.ToString("0.00");
			
			if (Input.GetButtonDown (characterA)) {
				cursorA.enabled = true;
				cursorB.enabled = false;
			}
			if (Input.GetButtonDown (characterB)) {
				cursorA.enabled = false;
				cursorB.enabled = true;
			}

			return;
		} else {
			timer = 5f;
			counter.enabled = false;
		}
		*/
		if (Input.GetButtonDown(aString1))
		{
			player.AbilityUsed(ability1);
		}
		if (Input.GetButtonDown(aString2))
		{
			player.AbilityUsed(ability2);
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
