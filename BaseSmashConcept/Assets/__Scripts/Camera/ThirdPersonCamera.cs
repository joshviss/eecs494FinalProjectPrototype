using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{

	#region private variables

	[SerializeField]
	private float distanceAway;
	[SerializeField]
	private float distanceUp;
	[SerializeField]
	private float smooth;
	[SerializeField]
	private Transform follow;
	private Vector3 targetPosition;

	#endregion

	#region unity event functions

	void LateUpdate()
	{
		// calculate target position
		targetPosition = follow.position + follow.up * distanceUp - follow.forward * distanceAway;
		// debugging info
		Debug.DrawRay(follow.position, Vector3.up * distanceUp, Color.red);
		Debug.DrawRay(follow.position, -1.0f * follow.forward * distanceAway, Color.blue);
		Debug.DrawLine(follow.position, targetPosition, Color.magenta);
		// using linear interpolation to smooth out the camera movement
		// transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
		transform.position = targetPosition;
		// adjust camera direction
		transform.LookAt(follow);
	}

	#endregion
}
