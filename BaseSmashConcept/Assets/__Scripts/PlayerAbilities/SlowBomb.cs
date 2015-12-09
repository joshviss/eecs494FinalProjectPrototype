﻿using UnityEngine;
using System.Collections;

public class SlowBomb : MonoBehaviour {
	
	private float initImpulse = 10.0f;
	private float aoeRange = 6.0f;
	private float damage = 5.0f;
	private Transform owner;
	
	public void init(Transform _owner)
	{
		owner = _owner;
		transform.position = owner.position;
		transform.rotation = owner.rotation;
		transform.position = transform.position + transform.forward;
		GetComponent<Rigidbody>().AddForce(Quaternion.AngleAxis(-45, transform.right) * transform.forward * initImpulse, ForceMode.Impulse);
	}
	
	void OnCollisionEnter(Collision coll)
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
	
	void explode(Vector3 location, float radius, float damage)
	{
		Collider[] objectsInRange = Physics.OverlapSphere(location, radius);
		foreach (Collider col in objectsInRange)
		{
			Player opponent = col.GetComponent<Player>();
			if (opponent != null && col.transform != owner)
			{
				// linear falloff of effect
				float proximity = (location - opponent.transform.position).magnitude;
				float effect = 1 - (proximity / radius);
				opponent.takeDamage(damage * effect);
				opponent.slow(effect);
			}
		}
	}
}