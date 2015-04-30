using UnityEngine;
using System.Collections;
using System;

public class MoveBall : MonoBehaviour {

	static float mainTimer;
	static float moveY;
	float move;
	float moveRotationYBoostPad;
	float speed;
	static float health;
	float moveX;
	Rigidbody rb;
	public int groundLayer;
	int ballAccelerationY;
	float Angle;
	float distToGround;
	private GameObject targetGO;
	SphereCollider colBallIsGrounded;
	float AngleRad;
	Vector3 movement;
	Vector3 movement02;
	bool invincible;
	bool boost;
	float healthInvincible;
	float magnitude;
	float timer02;
	float timer03;
	float timer04;
	float timer05;
	float timer06;
	float timer07;
	float timer08;
	float timer09;
	float moveX01;
	float moveX02;
	float moveX03;
	float moveX04;
	float moveZ01;
	float moveZ02;
	float moveZ03;
	float moveZ04;
	public float maxSpeed;
	public float maxRegSpeed;
	int gemCountMoveBall;
	
	public GameController gameController01;
	
	void Start(){
		// get the distance to ground
		transform.position = new Vector3 (-5, 5, -100);
		timer06 = mainTimer;
		health = 5;
		ballAccelerationY = 40;
		boost = false;
		maxSpeed = 25;
		maxRegSpeed = 10;
		speed = 10;
		targetGO = GameObject.FindGameObjectWithTag ("Player");
		colBallIsGrounded = targetGO.GetComponent<SphereCollider> ();
		distToGround = colBallIsGrounded.bounds.extents.y;
		rb = targetGO.GetComponent<Rigidbody> ();
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
		if (Input.GetKey(KeyCode.Space)) {
			if (mainTimer > timer01 + .5) {
				if (IsGrounded ()) {
					timer01 = mainTimer;
					moveY = ballAccelerationY;
				} else if (IsGroundedSlant ()) {
					timer01 = mainTimer;
					moveY = ballAccelerationY;
				} else {
					moveY = 0;
				}
			}
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			moveX01 = Mathf.Sin (AngleRad);
			moveZ01 = Mathf.Cos (AngleRad);
			Debug.Log ("up arrow");
		} else {
			moveX01 = 0;
			moveZ01 = 0;
		}
		if (Input.GetKey(KeyCode.DownArrow) ) {
			moveX02 = -Mathf.Sin (AngleRad);
			moveZ02 = -Mathf.Cos (AngleRad);
		} else {
			moveX02 = 0;
			moveZ02 = 0;
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			moveX04 = -Mathf.Cos (AngleRad);
			moveZ04 = Mathf.Sin (AngleRad);
			Debug.Log ("left arrow");
		} else {
			moveX04 = 0;
			moveZ04 = 0;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			moveX03 = Mathf.Cos (AngleRad);
			moveZ03 = -Mathf.Sin (AngleRad);
		} else {
			moveX03 = 0;
			moveZ03 = 0;
		}
		if (Input.GetKey(KeyCode.Z) && GameController.gemCount == 6) {
			boost = true;
			timer08 = mainTimer - 1f;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		Angle = Vector3.Angle(Vector3.forward, new Vector3 (rb.velocity.x, 0, rb.velocity.z)); 
		if (rb.velocity.x < 0) {
			Angle = 360 - Angle;
		}
		AngleRad = (Mathf.PI * Angle) / 180f;
		movement = new Vector3 (moveX01*speed + moveX02*speed + moveX03*speed + moveX04*speed, moveY * speed, moveZ01*speed + moveZ02*speed + moveZ03*speed + moveZ04*speed);
		magnitude = movement.magnitude;

		if ( !boost && Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.z, 2) > Mathf.Pow (maxRegSpeed, 2)) {
			movement.z =  0;
			movement.x = 0;
		}
		if (boost && Mathf.Pow (rb.velocity.x, 2) + Mathf.Pow (rb.velocity.z, 2) > Mathf.Pow (maxSpeed, 2)) {
			movement.z = 0;
			movement.x = 0;
		}
		if (mainTimer > timer08 + 1.2f) {
			boost = false;
		}
		if (!boost) {
			rb.AddForce (movement);
		}
		if (boost){
			Debug.Log ("sped up");
			rb.AddForce (movement * 3);
		}
		moveY = 0;


		if (invincible && mainTimer > timer07 + .5f) {
			invincible = true;
		} else {
			invincible = false;
		}
		if (health == 5) {
			Renderer rend = GetComponent<Renderer> ();
			rend.material.shader = Shader.Find ("Bumped Diffuse");
			rend.material.SetColor ("_Color", Color.cyan);
		}
		if (health == 4) {
			Renderer rend = GetComponent<Renderer> ();
			rend.material.shader = Shader.Find ("Bumped Diffuse");
			rend.material.SetColor ("_Color", Color.blue);
		}
		if (health == 3) {
			Renderer rend = GetComponent<Renderer> ();
			rend.material.shader = Shader.Find ("Bumped Diffuse");
			rend.material.SetColor ("_Color", Color.green);
		}
		if (health == 2) {
			Renderer rend = GetComponent<Renderer> ();
			rend.material.shader = Shader.Find ("Bumped Diffuse");
			rend.material.SetColor ("_Color", Color.yellow);
		}
		if (health == 1) {
			Renderer rend = GetComponent<Renderer> ();
			rend.material.shader = Shader.Find ("Bumped Diffuse");
			rend.material.SetColor ("_Color", Color.red);
		}
		if (IsGrounded () || IsGroundedSlant ()) {
			timer06 = mainTimer;
		}
		if (!IsGrounded() && !IsGroundedSlant() && mainTimer > timer06 + 6){
			health = 0;
		}
		if (health < .01f) {
			Application.LoadLevel ("DeadMenu");
		}
	}
	void OnCollisionEnter(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			Debug.DrawRay(contact.point, contact.normal, Color.white);
		}
		if (collision.collider.tag == "Enemy") {
			health--;
			invincible = true;
			timer07 = mainTimer;
			Debug.Log ("Health: " + health);
		}
		if (collision.collider.tag == "Boost") {
			boost = true;
			timer08 = mainTimer;
			Debug.Log ("ran over boost pad");
		}
		if (collision.collider.tag == "Finish") {
			Application.LoadLevel ("VictoryMenu");
			Debug.Log ("you won");
		} 
	}
}





















