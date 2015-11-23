using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

	#region for the ease of component accessing
	private Rigidbody rigid;
	public GameObject select;
	//GameObject character;
	//private BoxCollider body;
	//public GameObject thisPlayer;
	#endregion

	#region abilities
	public GameObject fireball, windpush;
	public float abilitySpeed = 6;
	public float windSpeedUpMultiplier = 1;
	#endregion

	#region movement
	public float moveSpeed = 5f;
	public float rotationSpeed = 60.0f;
	public float horizMult = 5f;
	public float jumpPower = 7f;
	private bool isDodging = false;
	private float dodgeTime = 0f;
	#endregion

	#region miscellaneous
	public static bool paused = false;
	//bool grounded;
	float pushTime = 0f;
	bool pushed = false;
	int groundPhysicsLayerMask;
	Vector3 startPos;
	Vector3 startRot;
	PlayerAttackRange attackRange;
	#endregion
	
	#region player stats
	public int id;
	public int Health = 15;
	public int healthCap = 15;
	public Slider hpBar;
	public int AttackDamage = 1;
	public int Defense = 1;
	public int BaseTowerDamage = 1;
	public int numResourcePiece = 0;
	#endregion

	// Use this for initialization
	void Start()
	{
		//character = GetComponent<GameObject> ();
		attackRange = GetComponentInChildren<PlayerAttackRange> ();
		rigid = GetComponent<Rigidbody>();
		groundPhysicsLayerMask = LayerMask.GetMask("Ground");

		hpBar.maxValue = healthCap;
		hpBar.value = Health;

		startPos = transform.position;
		startRot = transform.rotation.eulerAngles;

		select.SetActive (false);

	}

	public void UpdateRotation (float inputHorizontalRotationScale, float deltaTime)
	{
		transform.Rotate (transform.up, rotationSpeed * inputHorizontalRotationScale * Time.deltaTime);
	}

	public void UpdateMovement (float inputHorizontalMovementScale, float inputVerticalMovementScale, bool startJumping)
	{
		if (pushed || isDodging) {
			return;
		}

		if (startJumping && IsGrounded ()) {
			rigid.velocity = transform.TransformDirection (
				new Vector3 (
					moveSpeed * inputHorizontalMovementScale,
					jumpPower,
					moveSpeed * inputVerticalMovementScale)
			);
		} else if (!IsGrounded ()) {
			rigid.velocity = transform.TransformDirection(
				new Vector3(
				moveSpeed * inputHorizontalMovementScale,
				rigid.velocity.y,
				moveSpeed * inputVerticalMovementScale)
				);

			Vector3 feetPos = transform.position + Vector3.down * 0.4f;
			bool hitWall = (Physics.Raycast (feetPos, transform.forward, 0.6f, groundPhysicsLayerMask) ||
			                Physics.Raycast (feetPos, -transform.forward, 0.6f, groundPhysicsLayerMask) ||
			                Physics.Raycast (feetPos, transform.right, 0.6f, groundPhysicsLayerMask) ||
			                Physics.Raycast (feetPos, -transform.right, 0.6f, groundPhysicsLayerMask) ||
			                Physics.Raycast (feetPos, transform.right + transform.forward, 0.85f, groundPhysicsLayerMask) ||
			                Physics.Raycast (feetPos, transform.right - transform.forward, 0.85f, groundPhysicsLayerMask) ||
			                Physics.Raycast (feetPos, -transform.right + transform.forward, 0.85f, groundPhysicsLayerMask) ||
			                Physics.Raycast (feetPos, -transform.right - transform.forward, 0.85f, groundPhysicsLayerMask));
			if (hitWall) {
				rigid.velocity = new Vector3(0, rigid.velocity.y, 0);
			}
		} else {
			rigid.velocity = transform.TransformDirection(
				new Vector3(
					moveSpeed * inputHorizontalMovementScale,
					rigid.velocity.y,
					moveSpeed * inputVerticalMovementScale)
				);
		}

	}
	
	bool IsGrounded()
	{
		return (Physics.Raycast(transform.position, Vector3.down, 1.1f) ||
		        Physics.Raycast(transform.position + transform.forward * 0.45f, Vector3.down, 1.1f) || 
		        Physics.Raycast(transform.position - transform.forward * 0.45f, Vector3.down, 1.1f) ||
		        Physics.Raycast(transform.position + transform.right * 0.45f, Vector3.down, 1.1f) ||
		        Physics.Raycast(transform.position - transform.right * 0.45f, Vector3.down, 1.1f));
	}

	void respawn()
	{
		transform.position = startPos;
		transform.rotation = Quaternion.Euler(startRot);
		Health = healthCap;
		hpBar.value = Health;
		hpBar.fillRect.gameObject.SetActive(true);
		this.gameObject.SetActive(true);
		select.SetActive (false);
	}

	// Update is called once per frame
	void Update()
	{                   
		//checks if dead
		if (Health <= 0)
		{
			hpBar.fillRect.gameObject.SetActive(false);
			this.gameObject.SetActive(false);
			select.SetActive(true);

			Invoke("respawn", 5f); 
		}

		pushTime += Time.deltaTime;
		if (pushTime > 0.5f) {
			pushed = false;
		}

		if (isDodging)
		{
			dodgeTime += Time.deltaTime;
			if (dodgeTime >= 0.05f)
			{
				isDodging = false;
				dodgeTime = 0.0f;
			}
		}

	}

	public void AbilityUsed(int abilityNum)
	{
		//figures out what direction to fire based on y rotation of player
		float degreeY = this.transform.eulerAngles.y;
		float zMag = Mathf.Cos(degreeY * Mathf.Deg2Rad);
		float xMag = Mathf.Sin(degreeY * Mathf.Deg2Rad);

		GameObject shot;

		//should be done in a better way (ie. not with var ability1 / 2)
		switch (abilityNum)
		{
			case 1: //fireball
				shot = Instantiate<GameObject>(fireball);
				shot.transform.position = transform.position + transform.forward;
				shot.transform.rotation = transform.rotation;
				shot.GetComponent<Rigidbody>().velocity = new Vector3(xMag, 0, zMag) * abilitySpeed;
				break;
			case 2: //windpush
				shot = Instantiate<GameObject>(windpush);
				shot.transform.position = transform.position + transform.forward; //if this not added and not trigger then you fly
				shot.transform.rotation = transform.rotation;
				shot.GetComponent<Rigidbody>().velocity = new Vector3(xMag, 0, zMag) * abilitySpeed;
				break;
			default:
				break;
		}

	}


	void OnTriggerEnter(Collider other)
	{
		GameObject collidedWith = other.gameObject;
		string tag = collidedWith.tag;
		Vector3 vel = rigid.velocity;

		switch (tag)
		{
			case "FireBall": //does damage to the player
				Health = Health - collidedWith.GetComponent<FireBall>().damage;
				hpBar.value = Health;
				break;
			case "WindPush": //pushes back the player
				vel = collidedWith.GetComponent<Rigidbody>().velocity * windSpeedUpMultiplier;
				pushed = true;
				pushTime = 0;
				break;
			default:
				break;
		}

		rigid.velocity = vel;
	}

	public void Attack(){
		GameObject target = attackRange.getAttackingTarget ();
		if (target != null) {
			target.GetComponent<Player>().Health -= AttackDamage;
		}
	}

	public void Dodge(){
		Vector3 direction = new Vector3(rigid.velocity.x, 0, rigid.velocity.z);
		direction = (direction != Vector3.zero) ? direction : - transform.forward;
		direction = new Vector3(direction.x, 0, direction.z);
		rigid.velocity = direction.normalized * (1 / Time.deltaTime);
		isDodging = true;
	}

}
