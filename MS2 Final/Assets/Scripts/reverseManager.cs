using UnityEngine;
using System.Collections;

public class reverseManager : MonoBehaviour {

	public GameObject reverse;

	// Use this for initialization
	void Start () {

		reverse.SetActive (true);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "player") {
			reverse.SetActive (false);

		}
	}
}
