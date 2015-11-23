using UnityEngine;
using System.Collections;

public class UpgradeGenerator : MonoBehaviour {

	public GameObject HpUpgrade;
	public GameObject AtkUpgrade;
	public GameObject DefUpgrade;
	public GameObject BdefUpgrade;

	private float cumulativeTime = 0.0f;
	private const float generatingPeriod = 30.0f;
	
	private Vector3[] generatePosition = {
		new Vector3(18, 6, 0),
		new Vector3(0, 6, 18),
		new Vector3(-18, 6, 0),
		new Vector3(0, 6, -18),
	};

	private GameObject[] upgrades = new GameObject[4];

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

		upgrades[0] = HpUpgrade;
		upgrades[1] = AtkUpgrade;
		upgrades[2] = DefUpgrade;
		upgrades[3] = BdefUpgrade;
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
