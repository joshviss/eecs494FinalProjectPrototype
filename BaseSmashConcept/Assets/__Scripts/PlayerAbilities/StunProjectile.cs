using UnityEngine;
using System.Collections;

public class StunProjectile : MonoBehaviour {

	Vector3 origin;
	float stopDistance = 30f;
	public int count = 0;

	// Use this for initialization
	void Start () {
		origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float distTraveled = (transform.position - origin).magnitude;

		if (distTraveled >= stopDistance) {
			Destroy (gameObject);
			count --;
		}
	}

	void OnTriggerEnter(Collider other){
		GameObject collidedWith = other.gameObject;
		
		//needed because layer physics is not working right away
		if(this.gameObject.layer != collidedWith.layer) {
			Destroy (gameObject);
		}
	}
}
