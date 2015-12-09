﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {
	
	float timer = 5f;
	Canvas select;
	PlayerInput ability;
	Renderer rend;
	public Image cursorA, cursorB;
	public string characterA, characterB;
	public Image counter;
	public GameObject p;
	public GameObject white, black;
	public string horizontal;
	public Material law, bandit;

	// Use this for initialization
	void Start () {
		select = GetComponent<Canvas> ();
		ability = p.GetComponent<PlayerInput> ();
		rend = p.GetComponent<Renderer> ();

		select.enabled = false;
		cursorA.enabled = true;
		cursorB.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (select.isActiveAndEnabled) {
			timer -= Time.deltaTime;
			counter.fillAmount = timer/5f;

			if (Input.GetButtonDown (characterA) || Input.GetAxis (horizontal) < 0) {
				cursorA.enabled = true;
				cursorB.enabled = false;
				ability.ability1 = 4;
				ability.ability2 = 2;
				white.SetActive(true);
				black.SetActive(false);
				rend.material = law;

			}
			if (Input.GetButtonDown (characterB) || Input.GetAxis (horizontal) > 0) {
				cursorA.enabled = false;
				cursorB.enabled = true;
				ability.ability1 = 5;
				ability.ability2 = 1;
				white.SetActive(false);
				black.SetActive(true);
				rend.material = bandit;
			}
		} else {
			timer = 5f;
		}

	}
}
