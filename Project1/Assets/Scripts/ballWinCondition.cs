using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ballWinCondition : MonoBehaviour {

	public int yMax = 110;
	public int yMin = -110;

	public GameObject loseText;

	public GameObject ball;

	public bool isAlive;

	// Use this for initialization
	void Start () {

		loseText.SetActive (false);

		isAlive = true;
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 moving = new Vector3 (transform.position.x,
			transform.position.y,
			transform.position.z);

		if (moving.y >= yMax) {
			
			loseText.SetActive (true);

			isAlive = false;

			Debug.Log ("you lose");
		}

		if (moving.y <= yMin) {
			
			loseText.SetActive (true);

			isAlive = false;

			Debug.Log ("you lose");
		}
	
	}
}
