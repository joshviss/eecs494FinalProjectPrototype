using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {
	
	float timer = 5f;
	public Canvas select;
	public Image cursorA, cursorB;
	public string characterA, characterB;
	public Text counter;

	// Use this for initialization
	void Start () {
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
			}
			if (Input.GetButtonDown (characterB)) {
				cursorA.enabled = false;
				cursorB.enabled = true;
			}
		}

	}
}
