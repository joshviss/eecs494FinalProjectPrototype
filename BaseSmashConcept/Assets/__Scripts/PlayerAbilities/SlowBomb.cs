using UnityEngine;
using System.Collections;

public class SlowBomb : MonoBehaviour {

	private float initImpulse = 100.0f;
	private Vector3 initDir = Vector3(2, 1, 0).normalized;
	private float aoeRange = 4.0f;
	private float damage = 5.0f;
	private float slowTime = 3.0f;
	private Transform owner;

	public void init(Transform _owner)
	{
		owner = _owner;
		initDir = owner.TransformDirection(initDir);
		initDir = initDir.normalized;
		GetComponent<Rigidbody>().AddForce(initDir * initImpulse, ForceMode.Impulse);
	}

	void OnCollisionEnter(Collision coll)
	{

	}

	void AreaDamageEnemies(Vector3 location, float radius, float damage)
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