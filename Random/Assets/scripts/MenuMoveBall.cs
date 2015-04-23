using UnityEngine;
using System.Collections;
using System;

public class MenuMoveBall : MonoBehaviour {

	static float mainTimer;
	static float moveY;
	public Rigidbody rb;
	public int groundLayer = 8;
	public int ballAcceleration;

	float distToGround;
	public Collider colballIsGrounded;

	
	void Start(){
		// get the distance to ground
		distToGround = colballIsGrounded.bounds.extents.y;
	}

	bool IsGrounded() {
		return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.05f);
	}
	bool IsGroundedSlant(){
		float rayCastSlantZ = .5f;
		bool isNotGrounded = true;
		int layerMask = 1 << groundLayer;
		for (float rayCastSlantX = 0; rayCastSlantX < 1f; rayCastSlantX = rayCastSlantX + .01f) {
			rayCastSlantZ = Mathf.Pow (distToGround * distToGround + rayCastSlantX * rayCastSlantX, .5f);
			Vector3 vGroundedSlant = new Vector3 (rayCastSlantX, 0f, rayCastSlantZ);
			if (Physics.Raycast (transform.position + vGroundedSlant, Vector3.down, distToGround - 0.1f, layerMask)) {
				isNotGrounded = false;
			}
		}
		if (isNotGrounded == true) {
			return false;
		} else {
			return true;
		}
	}

	// see if the user input and responf
	void OnGUI() {

		float timer01 = 0;

		mainTimer = Time.time;
		Event e = Event.current;
		if (e.isKey)
			Debug.Log ("Detected key code: " + e.keyCode);
		if (e.keyCode == KeyCode.Space) {
			Debug.Log ("space pressed");
			if (mainTimer > timer01 + .5){
				Debug.Log (".25 secs passed");
				if(IsGrounded()) {
					Debug.Log ("on object");
					timer01 = mainTimer;
					moveY = ballAcceleration;
				}else if(IsGroundedSlant()){
					Debug.Log ("on object slanted");
					timer01 = mainTimer;
					moveY = ballAcceleration;
				}else{
					moveY = 0;
				}
			}
		}
	}

	// Update is called once per frame
	void FixedUpdate () {

		float moveX = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (moveX, moveY, 0);
		moveY = 0;

		rb.AddForce(movement * 10);
	
	}
}
