using UnityEngine;
using System.Collections;

public class BaseDefense : MonoBehaviour {

	public int health = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		GameObject collidedWith = other.gameObject;

		if(collidedWith.tag == "PlayerAttackRange") {
			if((collidedWith.layer + 6) != this.gameObject.layer) {
				health -= 1;
			}
		}
		if(health == 0) {
			this.gameObject.SetActive(false);
			health = 3;
		}
	}

}
