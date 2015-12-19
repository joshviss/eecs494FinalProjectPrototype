using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public static bool paused = true;
	public GameObject characterSelect;
	public GameObject GOScreen;
	public GameObject PlayerUI;
	public Text winner;
	public Text scores;
	float time = 180f;
	float time2 = 5f;
	Text UI;
    bool endGame = false;

	void Awake(){
		Timer.paused = true;
	}

	// Use this for initialization
	void Start () {
		UI = GetComponent<Text> ();
		GOScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (endGame) {
			time2 -= Time.deltaTime;

			if (Input.anyKeyDown && time2 < 0){
				Timer.paused = false;
				Application.LoadLevel("_Scene_Title");
			}

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
			Timer.paused = true;
            endGame = true;

			int id = Points.getWinner();

			if (id == 0){
				winner.text = "Draw";
			} else {
				winner.text = "Player " + id.ToString() + " Wins!";
			}

			scores.enabled = true;
			PlayerUI.SetActive(false);
			characterSelect.SetActive(false);
			GOScreen.SetActive(true);
		}
	}
}
