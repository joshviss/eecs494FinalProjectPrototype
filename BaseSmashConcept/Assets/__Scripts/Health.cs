using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	Text health;
	public Player S;

	// Use this for initialization
	void Start () {
		health = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		ShowText ();
	}

	void ShowText(){
		health.text = "HP: " + S.GetHealth ();
	}
}
