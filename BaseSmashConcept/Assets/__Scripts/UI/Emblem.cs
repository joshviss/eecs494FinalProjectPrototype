using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Emblem : MonoBehaviour {

	public GameObject p;
	public Sprite law, bandit;
	Player player;
	Image emblem;
	Text text;

	// Use this for initialization
	void Start () {
		emblem = GetComponent<Image> ();
		text = GetComponentInChildren<Text> ();
		player = p.GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.law) {
			emblem.sprite = law;
			text.text = "Lawbringer";
		} else {
			emblem.sprite = bandit;
			text.text = "Bandit";
		}
	}
}
