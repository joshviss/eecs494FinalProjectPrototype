using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSwitch : MonoBehaviour {

	Canvas select;
	string characterA, characterB;
	float timer = 5;
	public Image cursorA, cursorB;
	public int id;
	public Text counter;

	// Use this for initialization
	void Start () {
		select = GetComponent<Canvas> ();
		cursorA.enabled = true;
		cursorB.enabled = false;
		counter.enabled = false;

		if (id == 0) {
			characterA = "CharacterA_P1";
			characterB = "CharacterB_P1";
		} else {
			characterA = "CharacterA_P2";
			characterB = "CharacterB_P2";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (select.isActiveAndEnabled) {
			counter.enabled = true;
			timer -= Time.deltaTime;
			counter.text = timer.ToString("0.00");

			if (Input.GetButtonDown (characterA)) {
				cursorA.enabled = true;
				cursorB.enabled = false;
			}
			if (Input.GetButtonDown (characterB)) {
				cursorA.enabled = false;
				cursorB.enabled = true;
			}
		} else {
			timer = 0f;
			counter.enabled = false;
		}
	}
}
