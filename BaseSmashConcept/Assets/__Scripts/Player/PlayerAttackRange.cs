using UnityEngine;
using System.Collections;

public class PlayerAttackRange : MonoBehaviour {

	private GameObject attackingTarget;

	// Use this for initialization
	void Start () {
		attackingTarget = null;
	}

	void OnTriggerEnter(Collider other){
		attackingTarget = other.gameObject;
	}

	void OnTriggerExit(Collider other){
		attackingTarget = null;
	}

	public GameObject getAttackingTarget(){
		return attackingTarget;
	}

}
