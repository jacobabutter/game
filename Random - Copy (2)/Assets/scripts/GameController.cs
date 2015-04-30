using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public static int gemCount;
	static bool pick_up_1 = false;
	static bool pick_up_2 = false;
	static bool pick_up_3 = false;
	static bool pick_up_4 = false;
	static bool pick_up_5 = false;
	static bool pick_up_6 = false;

	// Use this for initialization
	void Start () {
		if (pick_up_1 == true) {
			Destroy (GameObject.Find ("gem 1"));
			gemCount++;
		}
		if (pick_up_2 == true) {
			Destroy (GameObject.Find ("gem 1"));
			gemCount++;
		}
		if (pick_up_3 == true) {
			Destroy (GameObject.Find ("gem 1"));
			gemCount++;
		}
		if (pick_up_4 == true) {
			Destroy (GameObject.Find ("gem 1"));
			gemCount++;
		}
		if (pick_up_5 == true) {
			Destroy (GameObject.Find ("gem 1"));
			gemCount++;
		}
		if (pick_up_6 == true) {
			Destroy (GameObject.Find ("gem 1"));
			gemCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Gem"){
			if (collision.collider.name == "gem 1") {
				gemCount++;
				pick_up_1 = true;
				Destroy (collision.gameObject, .0001f);
				Debug.Log ("destroyed gem 1");
			}
			if (collision.collider.name == "gem 2") {
				gemCount++;
				pick_up_1 = true;
				Destroy (collision.gameObject, .0001f);
				Debug.Log ("destroyed gem 2");
			}
			if (collision.collider.name == "gem 3") {
				gemCount++;
				pick_up_1 = true;
				Destroy (collision.gameObject, .0001f);
				Debug.Log ("destroyed gem 3");
			}
			if (collision.collider.name == "gem 4") {
				gemCount++;
				pick_up_1 = true;
				Destroy (collision.gameObject, .0001f);
				Debug.Log ("destroyed gem 4");
			}
			if (collision.collider.name == "gem 5") {
				gemCount++;
				pick_up_1 = true;
				Destroy (collision.gameObject, .0001f);
				Debug.Log ("destroyed gem 5");
			}
			if (collision.collider.name == "gem 6") {
				gemCount++;
				pick_up_1 = true;
				Destroy (collision.gameObject, .0001f);
				Debug.Log ("destroyed gem 6");
			}
		}
	}
}
