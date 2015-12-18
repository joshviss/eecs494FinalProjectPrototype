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
	public Image ab1, ab2;
	float timer1 = 0;
	float timer2 = 0;
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

		if (ab1.fillAmount < 1) {
			timer1 += Time.deltaTime;
			ab1.fillAmount = timer1 / 5;
		} else {
			timer1 = 0;
			ab1.fillAmount = 1;
		}

		if (player.law && ab2.fillAmount < 1) {
			timer2 += Time.deltaTime;
			ab2.fillAmount = timer2 / 1;
		} else if (!player.law && ab2.fillAmount < 1) {
			timer2 += Time.deltaTime;
			ab2.fillAmount = timer2/5;
		} else {
			timer2 = 0;
			ab2.fillAmount = 1;
		}

		if (Input.GetButtonDown(aString1))
		{
			player.AbilityUsed(ability1);
			ab1.fillAmount = 0;
		}
		if (Input.GetButtonDown(aString2))
		{
			player.AbilityUsed(ability2);
			ab2.fillAmount = 0;
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
