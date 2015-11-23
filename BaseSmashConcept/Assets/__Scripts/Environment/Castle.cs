using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour {

	// Player # of the owner of this base
	public int ownerNumber;
	// Set this in game editor to owner object
	public GameObject ownerObject;
	private Player owner;
	// corresponds to whether player 1 ~ 4 is in this base
	private bool[] isPlayerIn = {false, false, false, false};

	// Use this for initialization
	void Start () {
		isPlayerIn[ownerNumber] = true;
		owner = ownerObject.GetComponent<Player>();
		owner.isInBase = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		GameObject collideWith = other.gameObject;
		int playerNum = 0;
		if (collideWith.tag == "Player1" ||
		    collideWith.tag == "Player2" ||
		    collideWith.tag == "Player3" ||
		    collideWith.tag == "Player4")
		{
			playerNum = (int)char.GetNumericValue(collideWith.tag[6]);
			if (playerNum == ownerNumber)
			{
				owner.isInBase = true;
			}
			isPlayerIn[playerNum] = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		GameObject collideWith = other.gameObject;
		int playerNum = 0;
		if (collideWith.tag == "Player1" ||
		    collideWith.tag == "Player2" ||
		    collideWith.tag == "Player3" ||
		    collideWith.tag == "Player4")
		{
			playerNum = (int)char.GetNumericValue(collideWith.tag[6]);
			if (playerNum == ownerNumber)
			{
				owner.isInBase = false;
			}
			isPlayerIn[playerNum] = false;
		}
	}
}
