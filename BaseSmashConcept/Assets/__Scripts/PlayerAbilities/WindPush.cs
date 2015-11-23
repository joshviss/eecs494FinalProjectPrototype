using UnityEngine;
using System.Collections;

public class WindPush : MonoBehaviour {

	Vector3 abilityOrigin;
	static public int count = 0;
	public float abilityStopDist = 50;
	public int damage = 0;
	
	// Use this for initialization
	void Start () {
		abilityOrigin = transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
		float dist = (transform.position - abilityOrigin).magnitude;
		
		if(dist >= abilityStopDist) {
			Destroy (gameObject);
			count--;
		}
	}
	
	void OnTriggerEnter(Collider other){
		GameObject collidedWith = other.gameObject;

		//needed because layer physics not working right away
		if(this.gameObject.layer != collidedWith.layer) {
			Destroy (gameObject);
			count--;
		}
	}
}
