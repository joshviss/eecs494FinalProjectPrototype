using UnityEngine;
using System.Collections;

public class HpUpgrade : MonoBehaviour
{

	public int increaseHp;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		GameObject collideWith = other.gameObject;
		if (collideWith.tag == "Player1" ||
		    collideWith.tag == "Player2" ||
		    collideWith.tag == "Player3" ||
		    collideWith.tag == "Player4")
		{
			collideWith.GetComponent<Player>().health += increaseHp;
			Destroy(gameObject);
		}
	}
}
