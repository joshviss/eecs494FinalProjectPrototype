using UnityEngine;
using System.Collections;

public class WindPush : MonoBehaviour {

	Vector3 abilityOrigin;
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
		}
	}
	
	void OnTriggerEnter(Collider other){
		Destroy (gameObject);
	}
}
