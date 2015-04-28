using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	static int gemCount;
	static bool pick_up_1 = false;

	// Use this for initialization
	void Start () {
		if (pick_up_1 == true) {
			Destroy (GameObject.Find ("gem 1"));
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Gem" && collision.collider.name == "gem 1") {
			gemCount++;
			pick_up_1 = true;
			Destroy (collision.gameObject, .0001f);
			Debug.Log ("destroyed gem 1");
		}
	}
}
