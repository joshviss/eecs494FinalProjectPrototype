using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	private GameObject attackingTarget;
	private MeshRenderer mesh;
	private CapsuleCollider collider;

	// Use this for initialization
	void Start () {
		attackingTarget = null;
		mesh = GetComponent<MeshRenderer>();
		mesh.enabled = false;
		collider = GetComponent<CapsuleCollider>();
		collider.enabled = false;
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

	public void strike()
	{
		mesh.enabled = true;
		collider.enabled = true;
	}

	public void sheath()
	{
		mesh.enabled = false;
		collider.enabled = false;
	}
}
