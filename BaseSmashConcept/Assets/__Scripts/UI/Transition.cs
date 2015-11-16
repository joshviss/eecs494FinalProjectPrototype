using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Transition : MonoBehaviour {

	public Canvas controlScreen;
	public Canvas titleScreen;
	public GameObject view;
	public GameObject back;
	public EventSystem e;

	void Start(){
		titleScreen.enabled = true;
		controlScreen.enabled = false;
	}

	public void StartGame(){
		Application.LoadLevel ("_Scene_Main");
	}

	public void Controls(){
		titleScreen.enabled = false;
		controlScreen.enabled = true;
		e.SetSelectedGameObject (back);
	}

	public void ControlsClose(){
		titleScreen.enabled = true;
		controlScreen.enabled = false;
		e.SetSelectedGameObject (view);
	}
	
}
