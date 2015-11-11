using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	Transform playerCamera;

	public float vertMult = 0.5f, vertMin = -30, vertMax = 30;
	public float horizMult = 0.5f;

	public Vector3 rot;
	public Vector3 camRot;

	// Use this for initialization
	void Start () {
		playerCamera = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		rot = transform.localRotation.eulerAngles;
		camRot = playerCamera.localRotation.eulerAngles;
		if (camRot.x > 180) camRot.x -= 360;
		
		float mDeltaX = Input.GetAxis("CameraHorizontal_P1");
		float mDeltaY = Input.GetAxis("CameraVertical_P1");
		
		print ("mX:"+mDeltaX+"    mY:"+mDeltaY);
		
		camRot.x -= mDeltaY * vertMult;
		camRot.x = Mathf.Clamp(camRot.x, vertMin, vertMax);
		
		rot.y += mDeltaX * horizMult;
		
		transform.localRotation = Quaternion.Euler(rot);
		playerCamera.localRotation = Quaternion.Euler(camRot);
	}
}
