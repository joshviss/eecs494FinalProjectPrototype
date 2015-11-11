using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour {


	void Update(){
		if (Input.GetButtonDown("Start")){
			Application.LoadLevel ("_TestScene(1)");
		}
	}

}
