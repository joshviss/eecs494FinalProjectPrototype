using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public static bool paused = false;
	public GameObject GOScreen;
	public GameObject PlayerUI;
	public Text winner;
	public Text scores;
	float time = 180f;
	Text UI;

	// Use this for initialization
	void Start () {
		UI = GetComponent<Text> ();
		GOScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Timer.paused) {
			return;
		}

		time -= Time.deltaTime;
		showText ();
	}

	void showText(){
		int minutes = (int) time / 60;
		int seconds = (int) time % 60;

		if (time > 0) {
			UI.text = string.Format("{0:0} {1:00}", minutes, seconds);
		} else {
			Time.timeScale = 0;
			Timer.paused = true;

			int id = Points.getWinner();

			if (id == 0){
				winner.text = "Draw";
			} else {
				winner.text = "Player " + id.ToString() + " Wins!";
			}

			scores.enabled = true;
			PlayerUI.SetActive(false);
			GOScreen.SetActive(true);
		}
	}
}
