using UnityEngine;
using System.Collections;

public class UpgradeGenerator : MonoBehaviour {

	private static GameObject HpUpgrade =
		Resources.Load("Assets/_Prefabs/Upgrade/HpUpgrade.prefab") as GameObject;
	private static GameObject AtkUpgrade =
		Resources.Load("Assets/_Prefabs/Upgrade/AttackUpgrade.prefab") as GameObject;
	private static GameObject DefUpgrade =
		Resources.Load("Assets/_Prefabs/Upgrade/DefenseUpgrade.prefab") as GameObject;
	private static GameObject BdefUpgrade =
		Resources.Load("Assets/_Prefabs/Upgrade/BaseDefenseUpgrade.prefab") as GameObject;

	private float cumulativeTime = 0.0f;
	private const float generatingPeriod = 30.0f;
	
	private Vector3[] generatePosition = {
		new Vector3(18, 6, 0),
		new Vector3(0, 6, 18),
		new Vector3(-18, 6, 0),
		new Vector3(0, 6, -18),
	};

	private GameObject[] upgrades = {
		HpUpgrade, AtkUpgrade, DefUpgrade, BdefUpgrade
	};

	// Use this for initialization
	void Start () {
		if(HpUpgrade == null)
		{
			print("HpUpgrade Null");
		}

		if(AtkUpgrade == null)
		{
			print("AtkUpgrade Null");
		}

		if(DefUpgrade == null)
		{
			print("DefUpgrade Null");
		}

		if(BdefUpgrade == null)
		{
			print("BdefUpgrade Null");
		}
	}
	
	// Update is called once per frame
	void Update () {
		cumulativeTime += Time.deltaTime;
		if (cumulativeTime >= generatingPeriod)
		{
			cumulativeTime = 0.0f;
			spawnUpgrade();
		}
	}

	void spawnUpgrade()
	{
		Vector3 spawnLocation = generatePosition[Random.Range(0,4)];
		GameObject spawnUpgrade = upgrades[Random.Range(0,4)];

		Instantiate(spawnUpgrade, spawnLocation, Quaternion.identity);
	}
}
