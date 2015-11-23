using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Transition : MonoBehaviour {

	public Canvas controlScreen;
	public Canvas titleScreen;
	public Canvas ruleScreen;
	public GameObject view;
	public GameObject back;
	public GameObject rule;
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

	public void Rules(){
		titleScreen.enabled = false;
		ruleScreen.enabled = true;
		e.SetSelectedGameObject (back);
	}

	public void RulesClose(){
		titleScreen.enabled = true;
		ruleScreen.enabled = false;
		e.SetSelectedGameObject (rule);
	}

}
