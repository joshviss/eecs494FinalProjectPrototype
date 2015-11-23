using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour
{
	// Please set buff type in game editor
	// possible options are "HP", "ATK", "DEF", "BDEF"
	public string buffType;
	public int increaseAmount;
	private float lifeTime = 0.0f;
	private float maxLifeTime = 20.0f;

	void Update()
	{
		lifeTime += Time.deltaTime;
		if (lifeTime >= maxLifeTime)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		GameObject collideWith = other.gameObject;
		if (collideWith.tag == "Player1" ||
		    collideWith.tag == "Player2" ||
		    collideWith.tag == "Player3" ||
		    collideWith.tag == "Player4")
		{
			Player collidePlayer = collideWith.GetComponent<Player>();
			switch (buffType[0])
			{
			case 'H':
				collidePlayer.Health += increaseAmount;
				collidePlayer.Health = Mathf.Min(collidePlayer.Health, collidePlayer.healthCap);
				collidePlayer.hpBar.value = collidePlayer.Health;
				break;
			case 'A':
				collidePlayer.AttackDamage += increaseAmount;
				break;
			case 'D':
				collidePlayer.Defense += increaseAmount;
				break;
			case 'B':
				collidePlayer.BaseTowerDamage += increaseAmount;
				break;
			default:
				break;
			}
			Destroy(gameObject);
		}
	}
}
