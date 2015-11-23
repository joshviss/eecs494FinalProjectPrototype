using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	private GameObject attackingTarget;
	private MeshRenderer mesh;

	// Use this for initialization
	void Start () {
		attackingTarget = null;
		mesh = GetComponent<MeshRenderer>();
		mesh.enabled = false;
	}

	void OnTriggerEnter(Collider other){
		GameObject collideWith = other.gameObject;
		if (collideWith.tag == "Player1" ||
		    collideWith.tag == "Player2" ||
		    collideWith.tag == "Player3" ||
		    collideWith.tag == "Player4")
		attackingTarget = other.gameObject;
	}

	void OnTriggerExit(Collider other){
		attackingTarget = null;
	}

	public GameObject getAttackingTarget(){
		return attackingTarget;
	}

	public void strike()
	{
		mesh.enabled = true;
	}

	public void sheath()
	{
		mesh.enabled = false;
	}
}
