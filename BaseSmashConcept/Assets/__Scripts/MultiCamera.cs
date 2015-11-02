using UnityEngine;
using System.Collections;

public class MultiCamera : MonoBehaviour {

	public int initialNumPlayers = 1;
	public Camera player1Camera, player2Camera, player3Camera, player4Camera;

	// Use this for initialization
	void Start () {
		if(initialNumPlayers == 1) {
			Use1Camera();
		} else if (initialNumPlayers == 2) {
			Use2Camera();
		} else if (initialNumPlayers == 3) {
			Use3Camera();
		} else if (initialNumPlayers == 4) {
			Use4Camera();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Alpha1)) {
			Use1Camera ();
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Use2Camera ();
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			Use3Camera ();
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			Use4Camera ();
		}
	}

	void Use1Camera () {

	}

	void Use2Camera () {

	}

	void Use3Camera () {

	}

	void Use4Camera () {

	}
}
