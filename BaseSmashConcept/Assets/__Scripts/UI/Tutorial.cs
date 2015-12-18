using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Tutorial : MonoBehaviour {
	
	public Sprite[] screenshots = new Sprite[6];
	public GameObject transitions;
	Transition t;
	Image screen;
	int index = -1;

	// Use this for initialization
	void Start () {
		screen = GetComponent<Image> ();
		screen.sprite = screenshots [0];
		t = transitions.GetComponent<Transition> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Submit")) {
			index++;
			if (index > 5) {
				index = 0;
				t.RulesClose ();
			}

			screen.sprite = screenshots [index];
		} else if (Input.GetButtonDown ("Cancel")) {
			index--;
			if (index < 0) {
				index = 0;
				t.RulesClose ();
			}

			screen.sprite = screenshots [index];
		} else if (Input.GetButtonDown ("Start")) {
			index = 0;
			t.RulesClose();
		}
	}
}
