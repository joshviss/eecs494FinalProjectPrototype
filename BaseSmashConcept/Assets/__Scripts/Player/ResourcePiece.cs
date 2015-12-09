using UnityEngine;
using System.Collections;

public class ResourcePiece : MonoBehaviour {

	//editable variables
	public float spawnTime = 20;
	public bool publicResource = false; //any player can get it
	public GameObject resourceDefender;
	//the following is always true if it does not have a defense
	public bool activeResource; //resource can be taken (defense is down)

	//can't edit (for viewability)
	public bool pieceTaken;

	// Use this for initialization
	void Start () {
		activeResource = true;
		pieceTaken = false;
		if(publicResource) {
			resourceDefender.SetActive(true);
			activeResource = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Respawn() {
		pieceTaken = false;
		//reactivates the resource
		this.gameObject.SetActive(true);

		if(publicResource) {
			//resourceDefender.GetComponent<BaseDefense>().resetHealth (); //might not be needed
			resourceDefender.SetActive (true);
			activeResource = false;
		}

	}

	void OnTriggerEnter(Collider other) {
		GameObject collidedWith = other.gameObject;

		if(!activeResource) {
			if(!resourceDefender.activeSelf) {
				activeResource = true;
			}
		}

		//checks if collided with a player other than the owner of the piece
		if(collidedWith.tag != this.gameObject.tag && activeResource) {
			if(collidedWith.tag == "Player1" || collidedWith.tag == "Player2" || 
			   collidedWith.tag == "Player3" || collidedWith.tag == "Player4") {
				//gives the player a resource and makes the object disappear for a
				//select time period (spawnTime).
				pieceTaken = true;
				this.gameObject.SetActive(false);

				Player p = collidedWith.GetComponent<Player>();
				p.numResourcePiece++;

				Invoke ("Respawn", spawnTime);
			}
		}

	}

	//called when defense ability is called
	public void spawnShield() {
		print (this.gameObject.tag);
		resourceDefender.SetActive (true);
		resourceDefender.GetComponent<BaseDefense>().resetHealth ();
		activeResource = false;
	}

}
