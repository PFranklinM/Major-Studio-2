using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		foreach (Transform child in this.transform) {

			if (GameObject.Find ("Player").GetComponent<playerMove> ().bot) {

				child.gameObject.SetActive (true);
			}
		}
	}
}
