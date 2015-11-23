using UnityEngine;
using System.Collections;

public class ResourcePiece : MonoBehaviour {


	public bool pieceTaken;
	

	// Use this for initialization
	void Start () {
		pieceTaken = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(pieceTaken) {
			Respawn ();
		}
	}

	IEnumerator Respawn() {
		pieceTaken = false;
		yield return new WaitForSeconds(20);
		this.gameObject.SetActive(true);

	}

	void OnTriggerEnter(Collider other) {
		GameObject collidedWith = other.gameObject;

		//checks if collided with someone other than the owner of the piece
		if(collidedWith.tag != this.gameObject.tag) {
			if(collidedWith.tag == "Player1" || collidedWith.tag == "Player2" || 
			   collidedWith.tag == "Player4" || collidedWith.tag == "Player4") {
					pieceTaken = true;
					this.gameObject.SetActive(false);
			}
		}

	}

}
