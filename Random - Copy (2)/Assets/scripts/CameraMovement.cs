using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	private GameObject targetGO;
	Component targetCOTF;
	Transform targetTF;
	Component targetCORB;
	Rigidbody targetRB;
	float yDelta;
	float mainTimer;
	Vector3 ballPosition;
	Vector3 currentPosition;
	float Angle;
	float PI;
	float theta;
	float deltaZ;
	float deltaX;

	// Use this for initialization
	void Start () {
		targetGO = GameObject.FindGameObjectWithTag ("Player");
		targetCORB = targetGO.GetComponent ("Rigidbody");
		targetRB = (Rigidbody)targetCORB;
		targetCOTF = targetGO.GetComponent ("Transform");
		targetTF = (Transform)targetCOTF;
		yDelta = 2;
	}

	// Update is called once per frame
	void Update () {
		ballPosition = targetTF.position;
		transform.LookAt (ballPosition);
		Angle = Vector3.Angle (Vector3.forward, new Vector3 (targetRB.velocity.x, 0, targetRB.velocity.z)); 
		PI = Mathf.PI;
		if (Mathf.Pow (targetRB.velocity.x, 2) + Mathf.Pow (targetRB.velocity.z, 2) > .5f) {
			deltaZ = 10 * Mathf.Cos (theta);
			deltaX = 10 * Mathf.Sin (theta);
		}
		theta = (PI * Angle) / 180f;
		if (targetRB.velocity.x < 0) {
			currentPosition = new Vector3 (targetTF.position.x + deltaX, targetTF.position.y + yDelta, targetTF.position.z - deltaZ);
		} else {
			currentPosition = new Vector3 (targetTF.position.x - deltaX, targetTF.position.y + yDelta, targetTF.position.z - deltaZ);
		}
		transform.position = Vector3.Slerp (transform.position, currentPosition, Time.deltaTime);
	}
}





















