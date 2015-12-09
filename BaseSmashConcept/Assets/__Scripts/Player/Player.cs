using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

	#region for the ease of component accessing
	private Rigidbody rigid;
	#endregion

	#region abilities
	public GameObject fireball, shockwave, stun, slowbomb; //ability 1 and 2
	public bool reflectActive; //should not be changed by user
	private int numStuns, numSlows;
	//attach player specific gates and resourceDefense
	public GameObject gate, resourceDefense; //ability 3
	float abilitySpeed = 30f;
	#endregion

	#region movement
	public float moveSpeed = 5f;
	private float initialMS;
	public float rotationSpeed = 60.0f;
	public float horizMult = 5f;
	public float jumpPower = 7f;
	#endregion

	#region miscellaneous
	int groundPhysicsLayerMask;
	Vector3 startPos;
	Vector3 startRot;
	Sword sword;
	public bool isInBase;
	bool isStriking = false;
	bool canStrike = true;
	float strikeTime = 0f;
	public float strikeCooldown = 1;
	bool isDodging = false;
	bool canDodge = true;
	float dodgeTime = 0f;
	public float dodgeCooldown = 3;
	public Slider dodgeCool;
	//public Slider strikeCool;
	bool ability1Used = false;
	bool ability2Used = false;
	public float abilityTime = 0f;
	public Slider abilityCool;
	public float abilityCooldown = 5f;
	public Canvas playerUI;
	bool stunned = false;
	public bool law = true;
	Material mat;
	Color current;
	public Text carry;
	int lastHit;
	Vector3 dodgeStart;
	#endregion
	
	#region player stats
	public int id;
	public int Health = 15;
	public int healthCap = 15;
	public Slider hpBar;
	public int AttackDamage = 3;
	public int Defense = 1;
	public int BaseTowerDamage = 1;
	public int numResourcePiece = 0;
	#endregion

	#region character switch
	public Canvas select;
	#endregion

	// Use this for initialization
	void Start()
	{
		//character = GetComponent<GameObject> ();
		sword = GetComponentInChildren<Sword> ();
		rigid = GetComponent<Rigidbody>();
		groundPhysicsLayerMask = LayerMask.GetMask("Ground");

		hpBar.maxValue = healthCap;
		hpBar.value = Health;

		startPos = transform.position;
		startRot = transform.rotation.eulerAngles;

		select.enabled = false;

		dodgeCool.maxValue = dodgeCooldown;
		dodgeCool.value = dodgeCooldown;

		//sets the reflect ability to non-active
		reflectActive = false;
		initialMS = moveSpeed;
		//info for stuns and slows
		numStuns = 0;
		numSlows = 0;

		//strikeCool.maxValue = strikeCooldown;
		//strikeCool.value = strikeCooldown;
		//strikeCool.enabled = false;
		abilityCool.maxValue = abilityCooldown;
		abilityCool.value = abilityCooldown;

		mat = GetComponent<Renderer> ().material;
		current = mat.color;

		carry.text = "0";
		if (law) {
			carry.enabled = false;
		}
	}

	public void UpdateRotation (float inputHorizontalRotationScale, float deltaTime)
	{
		if (Timer.paused) {
			return;
		}
		transform.Rotate (transform.up, rotationSpeed * inputHorizontalRotationScale * Time.deltaTime);
	}

	public void UpdateMovement (float inputHorizontalMovementScale, float inputVerticalMovementScale, bool startJumping)
	{
		if (Timer.paused || stunned || isDodging) {
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
		        Physics.Raycast(transform.position - transform.right * 0.45f, Vector3.down, 1.1f) ||
				Physics.Raycast(transform.position + transform.forward * 0.45f + transform.right * 0.45f, Vector3.down, 1.1f) ||
				Physics.Raycast(transform.position + transform.forward * 0.45f - transform.right * 0.45f, Vector3.down, 1.1f) ||
				Physics.Raycast(transform.position - transform.forward * 0.45f + transform.right * 0.45f, Vector3.down, 1.1f) ||
				Physics.Raycast(transform.position - transform.forward * 0.45f - transform.right * 0.45f, Vector3.down, 1.1f));
	}

	void respawn()
	{
		transform.position = startPos;
		transform.rotation = Quaternion.Euler(startRot);
		Health = healthCap;
		hpBar.value = Health;

		playerUI.enabled = true;
		this.gameObject.SetActive(true);

		select.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{   
		if (law) {
			carry.enabled = false;
		} else {
			carry.enabled = true;
		}

		//checks if dead
		if (Health <= 0)
		{
			if (LayerMask.LayerToName(lastHit) == "AbilityPl" && !law){
				Points.givePoints(0, numResourcePiece);
				numResourcePiece = 0;
			} else if (LayerMask.LayerToName(lastHit) == "AbilityP2" && !law){
				Points.givePoints(1, numResourcePiece);
				numResourcePiece = 0;
			} else if (LayerMask.LayerToName(lastHit) == "AbilityP3" && !law){
				Points.givePoints(2, numResourcePiece);
				numResourcePiece = 0;
			} if (LayerMask.LayerToName(lastHit) == "AbilityP4" && !law){
				Points.givePoints(3, numResourcePiece);
				numResourcePiece = 0;
			} 

			playerUI.enabled = false;
			this.gameObject.SetActive(false);

			select.enabled = true;
			Invoke("respawn", 5f); 
		}

		dodgeTime += Time.deltaTime;
		if (dodgeCool.value < dodgeCooldown) {
			dodgeCool.value = dodgeTime;
		}

		if (isDodging)
		{
			if ((transform.position - dodgeStart).magnitude > 3)
			{
				isDodging = false;
				//dodgeTime = 0.0f;
			}
		}

		//strikeTime += Time.deltaTime;
		//strikeCool.value = strikeTime;

		if (isStriking)
		{
			strikeTime += Time.deltaTime;
			if (strikeTime >= 0.05f)
			{
				isStriking = false;
				sword.sheath();
				strikeTime = 0.0f;
			}
		}

		abilityTime += Time.deltaTime;
		if (abilityCool.value < abilityTime) {
			abilityCool.value = abilityTime;
		}

		carry.text = "" + numResourcePiece;

	}

	void resetAbility1(){
		ability1Used = false;
	}

	void deactivateReflect() {
		reflectActive = false;
		mat.color = current;
	}

	void resetAbility2(){
		ability2Used = false;
	}

	void resetStun(){
		numStuns -= 1;
		if (numStuns == 0) {
			stunned = false;
			mat.color = current;
		}
	}

	void damage(){
		mat.color = current;
	}

	void slowed() {
		numSlows -= 1;
		if (numSlows == 0) {
			moveSpeed = initialMS;
			mat.color = current;
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
				//if (FireBall.count >= 3){
				//	break;
				//}
				if (ability1Used == true) {break;}
				shot = Instantiate<GameObject>(fireball);
				FireBall.count++;
				ability1Used = true;
				//WARNING: 10 is the amount of layers forward AbilityP1 is from Player1
				shot.layer = this.gameObject.layer + 10;
				shot.transform.position = transform.position + transform.forward;
				shot.transform.rotation = transform.rotation;
				shot.GetComponent<Rigidbody>().velocity = new Vector3(xMag, 0, zMag) * abilitySpeed;
				Invoke ("resetAbility1", 0.4f);
				break;
			case 2: // stun projectile
				if (ability1Used == true) {break;}
				shot = Instantiate<GameObject>(stun);
				ability1Used = true;
				//WARNING: 10 is the amount of layers forward AbilityP1 is from Player1
				shot.layer = this.gameObject.layer + 10;
				shot.transform.position = transform.position + transform.forward + transform.up; 
				shot.transform.rotation = transform.rotation;
				shot.GetComponent<Rigidbody>().velocity = new Vector3(xMag, 0, zMag) * abilitySpeed;
				Invoke("resetAbility1", 1f);
				break;
			case 3: // Base Defenses (big ability def)
				if (ability2Used) {break;}
				ability2Used = true;
				abilityTime = 0f;
				abilityCool.value = abilityTime;
				//Stuff to set up the gate, resourceDefense
				gate.GetComponent<BaseDefense>().resetHealth();
				gate.SetActive(true);
				//things to start up the resource defense
				resourceDefense.GetComponent<ResourcePiece>().spawnShield();
				Invoke("resetAbility2", 5f);
				break;
			case 4:	// shockwave (big ability atk)
				if (ability2Used) {break;}
				ability2Used = true;
				abilityTime = 0f;
				abilityCool.value = abilityTime;
				shot = Instantiate<GameObject>(shockwave);
				shot.layer = this.gameObject.layer + 10;
				shot.transform.position = transform.position;
				Invoke("resetAbility2", 5f);
				break;
			case 5: // slowbomb
				if (ability2Used) { break; }
				ability2Used = true;
				abilityTime = 0f;
				abilityCool.value = abilityTime;
				shot = Instantiate<GameObject>(slowbomb);
				shot.layer = this.gameObject.layer + 10;
				shot.GetComponent<SlowBomb>().init(transform);
				Invoke("resetAbility2", 5f);
				break;
			case 6: // reflect
				if (ability1Used) { break; }
				reflectActive = true;
				//color changed to when reflecting
				mat.color = Color.white;
				//Needs added stuff if we want UI to track cooldown

				//causes the reflect ability to turn off after 1 second.
				Invoke("deactivateReflect", 1f);
				//Causes ability1 to go on cooldown for 5 seconds
				Invoke("resetAbility1", 5f);
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

		//for when collided with is reflected
		GameObject shot;

		switch (tag)
		{
			case "FireBall": //does damage to the player
				//-10 comes from moving layer 10 places to see if equal to player1
				
				if((collidedWith.layer-10) != this.gameObject.layer) {
					if (reflectActive == true) {
						//deactivates reflect
						deactivateReflect();

						//figures out what direction to fire based on y rotation of player
						float degreeY = this.transform.eulerAngles.y;
						float zMag = Mathf.Cos(degreeY * Mathf.Deg2Rad);
						float xMag = Mathf.Sin(degreeY * Mathf.Deg2Rad);

						//creates a object to be launched back
						shot = Instantiate<GameObject>(fireball);
						shot.layer = this.gameObject.layer + 10;
						shot.transform.position = transform.position + transform.forward;
						shot.transform.rotation = transform.rotation;

						//reflects in the direction the player is facing
						shot.GetComponent<Rigidbody>().velocity = new Vector3(xMag, 0, zMag) * abilitySpeed;

						/*
						//gets the velocity of the collided with fireball to send it back the opposite direction
						Vector3 cVelocity = collidedWith.GetComponent<Rigidbody>().velocity;
						shot.GetComponent<Rigidbody>().velocity = new Vector3(cVelocity.x, cVelocity.y, cVelocity.z);
						*/

					} else {
						Health = Health - collidedWith.GetComponent<FireBall>().damage;
						hpBar.value = Health;
						mat.color = Color.red;
						Invoke("damage", 0.5f);
						lastHit = collidedWith.layer;
					}
				}
				break;
			case "Stun": 
				//-10 is same reason as above
				if((collidedWith.layer-10) != this.gameObject.layer) {
					if (reflectActive == true) {
						//deactivates reflect
						deactivateReflect();

						//figures out what direction to fire based on y rotation of player
						float degreeY = this.transform.eulerAngles.y;
						float zMag = Mathf.Cos(degreeY * Mathf.Deg2Rad);
						float xMag = Mathf.Sin(degreeY * Mathf.Deg2Rad);

						//creates a object to be launched back
						shot = Instantiate<GameObject>(stun);
						shot.layer = this.gameObject.layer + 10;
						shot.transform.position = transform.position + transform.forward + transform.up;
						shot.transform.rotation = transform.rotation;

						//reflects in the direction the player is facing
						shot.GetComponent<Rigidbody>().velocity = new Vector3(xMag, 0, zMag) * abilitySpeed;

					} else {
						vel = Vector3.zero;
						stunned = true;
						mat.color = Color.yellow;
						numStuns += 1;
						Invoke("resetStun", 1f);
					}
				}
				break;
			case "ShockWave":
				if ((collidedWith.layer - 10) != this.gameObject.layer){
					if (reflectActive == true) {
						//deactivates reflect
						deactivateReflect();

						//makes this player use the ability
						shot = Instantiate<GameObject>(shockwave);
						shot.layer = this.gameObject.layer + 10;
						shot.transform.position = transform.position;

					} else {
						Health -= 5;
						hpBar.value = Health;
						mat.color = Color.red;
						Invoke("damage", 0.5f);
						lastHit = collidedWith.layer;
					}
				}
				break;
			case "Slow":
				if ((collidedWith.layer - 10) != this.gameObject.layer) {
					if (reflectActive == true) {
						//deactivates reflect
						deactivateReflect();

						//makes this player use the ability
						shot = Instantiate<GameObject>(slowbomb);
						shot.layer = this.gameObject.layer + 10;
						shot.GetComponent<SlowBomb>().init(transform);

					} else {
						Health -= 3;
						hpBar.value = Health;
						mat.color = Color.grey;
						numSlows += 1;
						Invoke("slowed", 1f);
						lastHit = collidedWith.layer;
					}
				}
				break;
			case "PlayerAttackRange":
				if ((collidedWith.layer-10) != this.gameObject.layer) {
					Health -= 3;
					hpBar.value = Health;
					mat.color = Color.red;
					Invoke ("damage", 0.5f);
					lastHit = collidedWith.layer;	
				}
				break;
			default:
				break;
		}

		if (collidedWith.layer == LayerMask.NameToLayer ("CastleTrigger") && !law) {
			Points.givePoints(id, numResourcePiece);
			numResourcePiece = 0;
		}

		rigid.velocity = vel;
	}

	public void Attack(){
		if (canStrike)
		{
			sword.strike();
			GameObject target = sword.getAttackingTarget ();
			if (target != null) {
				target.GetComponent<Player>().Health -= AttackDamage;
				target.GetComponent<Player>().hpBar.value -= AttackDamage;
			}
			isStriking = true;
			canStrike = false;
			//strikeCool.enabled = true;
			//strikeCool.value = 0f;
			strikeTime = 0f;
			Invoke("enableStrike", strikeCooldown);
		}
	}

	public void Dodge(){
		if (canDodge)
		{
			Vector3 direction = new Vector3(rigid.velocity.x, 0, rigid.velocity.z);
			direction = (direction != Vector3.zero) ? direction : - transform.forward;
			direction = new Vector3(direction.x, 0, direction.z);
			rigid.velocity = direction.normalized * 20;
			isDodging = true;
			canDodge = false;
			dodgeTime = 0f;
			dodgeCool.value = 0f;
			dodgeStart = transform.position;
			Invoke("enableDodge", dodgeCooldown);
		}
	}

	void enableStrike()
	{
		canStrike = true;
		//strikeCool.enabled = false;
	}

	void enableDodge()
	{
		canDodge = true;
	}

	public void takeDamage(int damage)
	{
		Health -= damage;
	}
	
	public void slow(float effect)
	{
		StartCoroutine(recoverSpeed(moveSpeed, 3.0f));
		moveSpeed *= effect;
	}
	
	IEnumerator recoverSpeed(float normalSpeed, float delayTime)
	{
		yield return new WaitForSeconds(delayTime);
		moveSpeed = normalSpeed;
	}
}
