using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	float time = 300f;
	Text UI;

	// Use this for initialization
	void Start () {
		UI = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		showText ();
	}

	void showText(){
		int minutes = (int) time / 60;
		int seconds = (int) time % 60;

		if (time > 0) {
			UI.text = string.Format("{0:0}:{1:00}", minutes, seconds);
		} else {
			Application.LoadLevel ("_Scene_End");
		}
	}
}
