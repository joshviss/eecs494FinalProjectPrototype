using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {
	
	float timer = 5f;
	Canvas select;
	PlayerInput ability;
	public Image cursorA, cursorB;
	public string characterA, characterB;
	public Text counter;
	public GameObject p;
	public GameObject white, black;

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
			counter.text = timer.ToString ("0.00");

			if (Input.GetButtonDown (characterA)) {
				cursorA.enabled = true;
				cursorB.enabled = false;
				ability.ability1 = 4;
				ability.ability2 = 2;
				white.SetActive(true);
				black.SetActive(false);
			}
			if (Input.GetButtonDown (characterB)) {
				cursorA.enabled = false;
				cursorB.enabled = true;
				ability.ability1 = 3;
				ability.ability2 = 1;
				white.SetActive(false);
				black.SetActive(true);
			}
		} else {
			timer = 5f;
		}

	}
}
