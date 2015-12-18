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
	public GameObject back2;
	public GameObject rule;
	public GameObject BG;
	public EventSystem e;

	void Start(){
		BG.SetActive (true);
		titleScreen.enabled = true;
		controlScreen.enabled = false;
		ruleScreen.enabled = false;
	}

	public void StartGame(){
		Application.LoadLevel ("_Scene_UI");
	}

	public void Controls(){
		BG.SetActive (false);
		titleScreen.enabled = false;
		controlScreen.enabled = true;
		e.SetSelectedGameObject (back);
	}

	public void ControlsClose(){
		BG.SetActive (true);
		titleScreen.enabled = true;
		controlScreen.enabled = false;
		e.SetSelectedGameObject (view);
	}

	public void Rules(){
		BG.SetActive (false);
		titleScreen.enabled = false;
		ruleScreen.enabled = true;
		e.SetSelectedGameObject (back2);
	}

	public void RulesClose(){
		BG.SetActive (true);
		titleScreen.enabled = true;
		ruleScreen.enabled = false;
		e.SetSelectedGameObject (rule);
	}

}
