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
	private Rigidbody rigid;
	private Transform follow;
	private Vector3 targetPosition;
	private float vertMult = 0.5f;
	private float vertLowerbound = -0.5f;
	private float vertUpperbound = 4.0f;

	#endregion

	#region unity event functions

	void Start()
	{
		// component init
		rigid = GetComponent<Rigidbody>();
		follow = transform.parent;
		// transform init
		transform.position = follow.position + follow.up * distanceUp - follow.forward * distanceAway;
		transform.LookAt(follow);
		// zero target pos
		targetPosition = Vector3.zero;
	}

	void LateUpdate()
	{
		Vector3 currentPosition = transform.position;
		// calculate target position
		targetPosition = follow.position + follow.up * distanceUp - follow.forward * distanceAway;
		// using linear interpolation to smooth out the camera movement
		Vector3 moveToPosition = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * smooth);
		rigid.velocity = (moveToPosition - currentPosition) / Time.deltaTime;
		// adjust camera direction
		transform.LookAt(follow);
	}

	#endregion

	public void cameraMoveVert(float vertInput)
	{
		if (distanceUp > vertLowerbound + 0.05f && distanceUp < vertUpperbound - 0.05f)
		{
			distanceUp += vertInput * vertMult;
		}
		else if (distanceUp <= vertLowerbound + 0.05f)
		{
			if (vertInput > 0.0f) distanceUp += vertInput * vertMult;
		}
		else
		{
			if (vertInput < 0.0f) distanceUp += vertInput * vertMult;
		}
	}
}
