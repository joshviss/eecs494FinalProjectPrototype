using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Points : MonoBehaviour {
	
	static public int[] score;
	public int id;
	Text label;

	static public void givePoints(int pid){
		score[pid] += 100;
	}

	// Use this for initialization
	void Start () {
		score = new int[2];
		score [0] = 0;
		score [1] = 0;

		label = GetComponent<Text> ();
		showText();
	}

	void showText(){
		label.text = "" + score[id];
	}

	// Update is called once per frame
	void Update () {
		showText();
	}

}
