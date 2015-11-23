using UnityEngine;
using System.Collections;

public class BaseDefense : MonoBehaviour {
	
	public int initialHealth = 3;
	public int health;

	// Use this for initialization
	void Start () {
		health = initialHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		GameObject collidedWith = other.gameObject;

		if(collidedWith.tag == "PlayerAttackRange") {
			if((collidedWith.layer - 4) != this.gameObject.layer) {
				//print (collidedWith.layer);
				//print (this.gameObject.layer);
				health -= 1;
			}
			if(health == 0) {
				this.gameObject.SetActive(false);
				resetHealth (); //might not be needed
			}
		}
	}

	public void resetHealth() {
		health = initialHealth;
	}

}
