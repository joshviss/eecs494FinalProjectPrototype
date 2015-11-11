using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public Player player;
	public Vector3 move;
	public string horizontalAxis = "Horizontal_P1";
	public string verticalAxis = "Vertical_P1";
	public string aString1 = "Ability1_P1";
	public string aString2 = "Ability2_P1";
	public string jump = "Jump_P1";
	public bool jumping = false;

	// Use this for initialization
	void Start () {

		player = GetComponent<Player> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (!jumping) {
			jumping = Input.GetButtonDown (jump);
		}

		if (Input.GetButtonDown (aString1)) {
			player.AbilityUsed (1);
		} else if (Input.GetButtonDown (aString2)) {
			player.AbilityUsed (2);
		}

	}

	// FixedUpdate is called once per physics update
	void FixedUpdate(){

		float h = Input.GetAxis (horizontalAxis);
		float v = Input.GetAxis (verticalAxis);
		float mDeltaX = Input.GetAxis("CameraHorizontal_P1");

		//move = v * Vector3.forward + h * Vector3.right;
		move = v * transform.forward + h * transform.right;

		player.Move (move, jumping, mDeltaX);
		jumping = false;

	}
}
