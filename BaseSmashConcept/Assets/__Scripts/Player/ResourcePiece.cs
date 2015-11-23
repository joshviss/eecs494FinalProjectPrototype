using UnityEngine;
using System.Collections;

public class ResourcePiece : MonoBehaviour {

	//editable variables
	public float spawnTime = 20;
	public bool publicResource = false; //any player can get it

	//can't edit (for viewability)
	public bool pieceTaken;

	// Use this for initialization
	void Start () {
		pieceTaken = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Respawn() {
		pieceTaken = false;
		//reactivates the resource
		this.gameObject.SetActive(true);
		
	}

	void OnTriggerEnter(Collider other) {
		GameObject collidedWith = other.gameObject;

		//checks if collided with a player other than the owner of the piece
		if(collidedWith.tag != this.gameObject.tag) {
			if(collidedWith.tag == "Player1" || collidedWith.tag == "Player2" || 
			   collidedWith.tag == "Player3" || collidedWith.tag == "Player4") {
				//gives the player a resource and makes the object disappear for a
				//select time period (spawnTime).
				pieceTaken = true;
				this.gameObject.SetActive(false);

				Player p = collidedWith.GetComponent<Player>();
				p.numResourcePiece++;
				Points.givePoints(p.id);

				Invoke ("Respawn", spawnTime);
			}
		}

	}

}
