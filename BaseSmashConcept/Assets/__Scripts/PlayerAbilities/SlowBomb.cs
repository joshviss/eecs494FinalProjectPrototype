using UnityEngine;
using System.Collections;

public class SlowBomb : MonoBehaviour {

	public GameObject explosionObject;
	private float initImpulse = 10.0f;
	private float aoeRange = 3.0f;
	float effect = 0.5f;
	private int damage = 2;
	private Transform owner;
	
	public void init(Transform _owner)
	{
		owner = _owner;
		transform.position = owner.position;
		transform.rotation = owner.rotation;
		transform.position = transform.position + transform.forward;
		GetComponent<Rigidbody>().AddForce(Quaternion.AngleAxis(-45, transform.right) * transform.forward * initImpulse, ForceMode.Impulse);
	}
	
	void OnTriggerEnter(Collider coll)
	{
		GameObject collideWith = coll.gameObject;
		if(collideWith.layer == LayerMask.NameToLayer("Ground") ||
		   collideWith.layer == LayerMask.NameToLayer("Player1") ||
		   collideWith.layer == LayerMask.NameToLayer("Player2") ||
		   collideWith.layer == LayerMask.NameToLayer("Player3") ||
		   collideWith.layer == LayerMask.NameToLayer("Player4"))
		{
			explode(transform.position, aoeRange, damage);
			Destroy (gameObject);
		}
	}
	
	void explode(Vector3 location, float radius, int damage)
	{
		GameObject explosion;
		explosion = Instantiate<GameObject>(explosionObject);
		explosion.layer = this.gameObject.layer;
		explosion.transform.position = transform.position;

		/*
		Collider[] objectsInRange = Physics.OverlapSphere(location, radius);
		foreach (Collider col in objectsInRange)
		{
			Player opponent = col.GetComponent<Player>();
			if (opponent != null && col.transform != owner)
			{
				// linear falloff of effect
				//float proximity = (location - opponent.transform.position).magnitude;
				//float effect = 1 - (proximity / radius);
				//opponent.takeDamage(damage * effect);
				opponent.takeDamage(damage);
				opponent.slow(effect);
			}
		}
		*/
	}
}