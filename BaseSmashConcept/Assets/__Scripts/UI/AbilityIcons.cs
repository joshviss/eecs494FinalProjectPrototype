using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityIcons : MonoBehaviour {

	public GameObject p;
	public Sprite law1, law2, bandit1, bandit2;
	public int number;
	Player player;
	Image icon;
	
	// Use this for initialization
	void Start () {
		icon = GetComponent<Image> ();
		player = p.GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.law && number == 1) {
			icon.sprite = law1;
		} else if (player.law && number == 2) {
			icon.sprite = law2;
		} else if (!player.law && number == 1) {
			icon.sprite = bandit1;
		} else {
			icon.sprite = bandit2;
		}
	}
}
