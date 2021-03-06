﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {
	
	float timer = 15f;
	float timerMax = 15f;
	Canvas select;
	PlayerInput ability;
	Player type;
	Renderer rend;
	public Image cursorA, cursorB;
	public string characterA, characterB;
	public Image counter;
	public GameObject p;
	public GameObject white, black;
	public string horizontal;
	public Material law, bandit;

	// Use this for initialization
	void Awake () {
		select = GetComponent<Canvas> ();
		ability = p.GetComponent<PlayerInput> ();
		rend = p.GetComponent<Renderer> ();
		type = p.GetComponent<Player> ();

		select.enabled = true;
		cursorA.enabled = true;
		cursorB.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (select.isActiveAndEnabled && timer > 0) {
			timer -= Time.deltaTime;
			counter.fillAmount = timer / timerMax;

			if (Input.GetButtonDown (characterA) || Input.GetAxis (horizontal) < 0) {
				cursorA.enabled = true;
				cursorB.enabled = false;
				ability.ability1 = 4;
				ability.ability2 = 2;
				white.SetActive (true);
				black.SetActive (false);
				rend.material = law;
				type.law = true;
			}
			if (Input.GetButtonDown (characterB) || Input.GetAxis (horizontal) > 0) {
				cursorA.enabled = false;
				cursorB.enabled = true;
				ability.ability1 = 6;
				ability.ability2 = 5;
				white.SetActive (false);
				black.SetActive (true);
				rend.material = bandit;
				type.law = false;
			}
		} else if (Timer.paused && timer > 0) {
			select.enabled = true;
		} else {
			timer = 5f;
			timerMax = 5f;

			if (Timer.paused){
				Timer.paused = false;
				CharacterSelect.wait = false;
			}
		}

	}
}
