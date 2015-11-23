using UnityEngine;
using System.Collections;

public class ShockWave : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("Reset", 1f);
	}
	
	void Reset(){
		Destroy (gameObject);
	}
}
