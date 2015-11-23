using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	private GameObject attackingTarget;
	private MeshRenderer mesh;
	private Collider myCollider;

	// Use this for initialization
	void Start () {
		attackingTarget = null;
		mesh = GetComponent<MeshRenderer>();
		myCollider = this.GetComponent<Collider>();
		mesh.enabled = false;
		myCollider.enabled = false;
	}

	void OnTriggerEnter(Collider other){
		GameObject collideWith = other.gameObject;
		if (collideWith.tag == "Player1" ||
			collideWith.tag == "Player2" ||
			collideWith.tag == "Player3" ||
			collideWith.tag == "Player4") {
			if (collideWith.tag != this.gameObject.tag){
				attackingTarget = collideWith;
			}
		}
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
		myCollider.enabled = true;
	}

	public void sheath()
	{
		mesh.enabled = false;
		myCollider.enabled = false;
	}
}
