using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	//Transform playerCamera;

	public float vertMult = 0.5f, vertMin = -30, vertMax = 30;
	public float horizMult = 0.5f;

	//public Vector3 rot;
	public Vector3 camRot;

	// Use this for initialization
	void Start () {
		//playerCamera = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		float mDeltaY;

		//rot = transform.localRotation.eulerAngles;
		//camRot = playerCamera.localRotation.eulerAngles;
		camRot = transform.localRotation.eulerAngles;
		if (camRot.x > 180) camRot.x -= 360;

		if(this.gameObject.tag == "MainCamera") {
			mDeltaY = Input.GetAxis("CameraVertical_P1");
		} else { //if (this.gameObject.tag == "Player2") {
			mDeltaY = Input.GetAxis("CameraVertical_P2");
		}

		camRot.x -= mDeltaY * vertMult;
		camRot.x = Mathf.Clamp(camRot.x, vertMin, vertMax);
		
		//rot.y += mDeltaX * horizMult;
		
		transform.localRotation = Quaternion.Euler(camRot);
		//playerCamera.localRotation = Quaternion.Euler(camRot);
	}
}
