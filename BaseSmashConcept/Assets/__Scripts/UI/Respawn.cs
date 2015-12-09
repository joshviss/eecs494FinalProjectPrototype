using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {
	
	float timer = 5f;
	Canvas select;
	PlayerInput ability;
	public Image cursorA, cursorB;
	public string characterA, characterB;
	public Image counter;
	public GameObject p;
	public GameObject white, black;
	public string horizontal;

	// Use this for initialization
	void Start () {
		select = GetComponent<Canvas> ();
		ability = p.GetComponent<PlayerInput> ();

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
			}
			if (Input.GetButtonDown (characterB) || Input.GetAxis (horizontal) > 0) {
				cursorA.enabled = false;
				cursorB.enabled = true;
				ability.ability1 = 5;
				ability.ability2 = 1;
				white.SetActive(false);
				black.SetActive(true);
			}
		} else {
			timer = 5f;
		}

	}
}
