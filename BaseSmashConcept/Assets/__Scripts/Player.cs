using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Rigidbody rigid;
	public BoxCollider body;
	//public GameObject thisPlayer;

	public GameObject ability1, ability2;
	public int abilityIndex1 = 1, abilityIndex2 = 2;
	public float abilitySpeed = 6;
	public float windSpeedUpMultiplier = 1;

	public float moveSpeed = 5f;
	public float turnSpeed = 360f;
	public float jumpPower = 7f;

	bool grounded;
	int groundPhysicsLayerMask;

	//RigidbodyConstraints noRotY;

	//Player Stats
	public int health = 15;
	public int healthCap = 15;
	public Slider hpBar;

	//float MovementSpeed = 2.0f;
	//float JumpSpeed = 6f;

	public int BasicAttackDamage = 1;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
		groundPhysicsLayerMask = LayerMask.GetMask ("Ground");
		body = GetComponent<BoxCollider> ();

		grounded = false;
		hpBar.maxValue = healthCap;
		hpBar.value = health;
		hpBar.transform.position = Camera.main.WorldToScreenPoint (transform.position + Vector3.up);

	}

	public void Move(Vector3 move, bool jumping){

		Vector3 vel = rigid.velocity;

		if (move.magnitude > 1f) {
			move.Normalize();
		}

		// Jump
		if (jumping && grounded) {
			//rigid.velocity = new Vector3(rigid.velocity.x, jumpPower, rigid.velocity.z);
			vel.y = jumpPower;
			grounded = false;
		}

		// Movement
		if (move.x != 0 || move.z != 0) {
			// Rotation
			Quaternion targetRotation = Quaternion.LookRotation (move);
			//Quaternion newRotation = Quaternion.Lerp (rigid.rotation, targetRotation, Time.deltaTime * turnSpeed);

			//rigid.MoveRotation (newRotation);
			rigid.MoveRotation(targetRotation);

			/*
			Vector3 newPosition = Vector3.Lerp (rigid.position, rigid.position + move, Time.deltaTime * moveSpeed);
			rigid.MovePosition (newPosition);
			*/

			// Forward movement
			vel.x = move.x * moveSpeed;
			vel.z = move.z * moveSpeed;

			rigid.velocity = vel;
		}

	}

	// Update is called once per frame
	void Update () {
		/*
		if(Input.GetKey (KeyCode.W)) {
			moveForward = true;
		}
		*/

		//use of abilities
		//if(Input.GetKeyDown (KeyCode.F)) {
		//	AbilityUsed (abilityIndex1);
		//} else if (Input.GetKeyDown (KeyCode.R)) {
		//	AbilityUsed (abilityIndex2);
		//}                              

		//checks if dead
		if(health <= 0) {
			hpBar.fillRect.gameObject.SetActive(false);
			Destroy(this.gameObject);
		}

		grounded = Physics.Raycast (transform.position, Vector3.down, 1.1f);
		hpBar.transform.position = Camera.main.WorldToScreenPoint (transform.position + Vector3.up);

		/*
		// Jumping
		Vector3 vel = rigid.velocity;
		if (Input.GetKeyDown (KeyCode.A) && grounded && !onLadder) {
			vel.y = speedJump;
		}
		rigid.velocity = vel;
		*/


	}

	void FixedUpdate () {
		/*
		Vector3 vel = rigid.velocity;

		if(moveForward) {
			//take out of if statement if ever needed outside of it.
			//figures out what direction to fire based on y rotation of player
			float degreeY = this.transform.eulerAngles.y;
			//print(degreeY);
			float zMag = Mathf.Cos (degreeY * Mathf.Deg2Rad);
			float xMag = Mathf.Sin (degreeY * Mathf.Deg2Rad);

			vel = vel + new Vector3(xMag, 0, zMag) * forwardMovement;
			moveForward = false;
		}
		*/

		/*
		Vector3 vel = rigid.velocity;
		
		Vector3 loc = transform.position;
		Debug.DrawRay (loc, Vector3.down * 1.25f, Color.blue);
		grounded = (Physics.Raycast (loc, Vector3.down, 1.25f, groundPhysicsLayerMask)) ||
			(Physics.Raycast (loc, Vector3.down, 1.25f, boxPhysicsLayerMask));
		
		// Left and Right Movement
		if (Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow)) {
			vel.x = -speedX;
		} else if (Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.LeftArrow)) {
			vel.x = speedX;
		} else if (Input.GetKey (KeyCode.DownArrow) && !collideWithLadder) {
			vel.x = 0;
		} else {
			vel.x = 0;
		}
		*/
	}

	public void AbilityUsed (int abilityNum) {
		//figures out what direction to fire based on y rotation of player
		float degreeY = this.transform.eulerAngles.y;
		//print(degreeY);
		float zMag = Mathf.Cos (degreeY * Mathf.Deg2Rad);
		float xMag = Mathf.Sin (degreeY * Mathf.Deg2Rad);
		//print(zMag);
		//print(xMag);
		GameObject shot;

		//should be done in a better way (ie. not with var ability1 / 2)
		switch (abilityNum) {
		case 1: //fireball
			shot = Instantiate<GameObject>(ability1);
			shot.transform.position = transform.position + transform.forward;
			shot.transform.rotation = transform.rotation;
			shot.GetComponent<Rigidbody>().velocity = new Vector3(xMag, 0, zMag) * abilitySpeed;
			//print ("1");
			break;
		case 2: //windpush
			shot = Instantiate<GameObject>(ability2);
			shot.transform.position = transform.position + transform.forward; //if this not added and not trigger then you fly
			shot.transform.rotation = transform.rotation;
			shot.GetComponent<Rigidbody>().velocity = new Vector3(xMag, 0, zMag) * abilitySpeed;
			//print ("2");
			break;
		default:
			break;
		}

	}


	void OnTriggerEnter(Collider other) {
		GameObject collidedWith = other.gameObject;
		string tag = collidedWith.tag;
		Vector3 vel = rigid.velocity;

		switch (tag) {
		case "FireBall": //does damage to the player
			health = health - collidedWith.GetComponent<FireBall>().damage;
			hpBar.value = health;
			break;
		case "WindPush": //pushes back the player
			vel = collidedWith.GetComponent<Rigidbody>().velocity * windSpeedUpMultiplier;
			break;
		default:
			break;
		}

		rigid.velocity = vel;
	}

}
