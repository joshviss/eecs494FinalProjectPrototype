using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public GameObject GOScreen;
	public Text winner;
	public Text scores;
	float time = 120f;
	Text UI;

	// Use this for initialization
	void Start () {
		UI = GetComponent<Text> ();
		GOScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerInput.paused) {
			return;
		}

		time -= Time.deltaTime;
		showText ();
	}

	void showText(){
		int minutes = (int) time / 60;
		int seconds = (int) time % 60;

		if (time > 0) {
			UI.text = string.Format("{0:0}:{1:00}", minutes, seconds);
		} else {
			Time.timeScale = 0;
			PlayerInput.paused = true;

			int id = Points.getWinner();

			if (id == 0){
				winner.text = "Draw";
			} else {
				winner.text = "Player " + id.ToString() + " Wins!";
			}

			scores.color = Color.white;
			GOScreen.SetActive(true);
		}
	}
}
