using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterSelect : MonoBehaviour {

	static public bool wait;
	public GameObject inGame;
	public Canvas shared, p1, p2, p3, p4;
	Canvas bg;

	// Use this for initialization
	void Awake () {
		bg = GetComponent<Canvas> ();

		Timer.paused = true;
		CharacterSelect.wait = true;
		bg.enabled = true;
		p1.enabled = true;
		p2.enabled = true;
		p3.enabled = true;
		p4.enabled = true;
		inGame.SetActive(false);
	}

	void Update(){
		if (!wait) {
			Debug.Log ("wait");
			CharacterSelect.wait = true;
			bg.enabled = false;
			p1.enabled = false;
			p2.enabled = false;
			p3.enabled = false;
			p4.enabled = false;
			inGame.SetActive(true);
		}
	}

}
