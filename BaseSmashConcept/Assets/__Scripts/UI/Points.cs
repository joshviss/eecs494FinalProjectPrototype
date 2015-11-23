using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Points : MonoBehaviour {
	
	static public int[] score;
	public int id;
	Text label;

	static public void givePoints(int pid){
		score[pid] += 1;
	}

	static public int getWinner(){
		int winner = 0;

		for (int i = 0; i < 4; i++) {
			if (score[winner] < score[i]){
				winner = i;
			}
		}

		for (int i = 0; i < 4; i++) {
			if (i == winner){
				continue;
			}
			if (score[winner] == score[i]){
				winner = -1;
				break;
			}
		}

		return winner + 1;
	}

	// Use this for initialization
	void Start () {
		score = new int[4];
		score [0] = 0;
		score [1] = 0;
		score [2] = 0;
		score [3] = 0;

		label = GetComponent<Text> ();
		if (id >= 0){
			showText();
		}
	}

	void showText(){
		label.text = "" + score [id]; 
	}

	void updateScores(){
		label.text = string.Format("Player 1: {0,2}\n",score [0].ToString ());
		label.text += string.Format("Player 2: {0,2}\n",score [1].ToString ());
		label.text += string.Format("Player 3: {0,2}\n",score [2].ToString ());
		label.text += string.Format("Player 4: {0,2}\n",score [3].ToString ());
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
