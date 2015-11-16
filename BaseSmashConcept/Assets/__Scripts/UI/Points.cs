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

	static public int getWinner(){
		int winner = 0;

		for (int i = 0; i < 2; i++) {
			if (score[winner] < score[i]){
				winner = i;
			}
		}

		for (int i = 0; i < 2; i++) {
			if (i == winner){
				continue;
			}
			if (score[winner] == score[i]){
				winner = -1;
			}
		}

		return winner + 1;
	}

	// Use this for initialization
	void Start () {
		score = new int[2];
		score [0] = 0;
		score [1] = 0;

		label = GetComponent<Text> ();
		if (id >= 0){
			showText();
		}
	}

	void showText(){
		label.text = "" + score [id]; 
	}

	void updateScores(){
		label.text = string.Format("Player 1: {0,7}\n",score [0].ToString ());
		label.text += string.Format("Player 2: {0,7}\n",score [1].ToString ());
	}

	// Update is called once per frame
	void Update () {
		if (id >= 0) {
			showText ();
		} else {
			updateScores ();
		}
	}

}
