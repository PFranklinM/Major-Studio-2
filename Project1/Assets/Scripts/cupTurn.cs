using UnityEngine;
using System.Collections;

public class cupTurn : MonoBehaviour {

	//visual design (80's inspired)
	//graphical?
	//breakout of the visual aesthetics of sci fi or other genres

	//graphic design - visual theme of a decade

	//visual currency - SF super bowl, psychodelic 1960's

	//visual theme based on music choices?

	//vertical "Iphone" aspect ratio

	//casual game - addictive and easy to play, easy to learn hard to master

	//middle is optimal space where you get the most points - visual treatment supports gameplay (ball changes colors when it
	//gets close to top or bottom)

	public GameObject cup;

	public GameObject ball;

	private float degreesPerSecond = 720.00f;

	private int turnPressed = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.A)) {

			if (GameObject.Find ("Ball").GetComponent<ballWinCondition> ().isAlive) {
				StartCoroutine (cupRotateLeft ());

				turnPressed++;
			}
		}

		if (Input.GetKeyDown (KeyCode.D)) {

			if (GameObject.Find ("Ball").GetComponent<ballWinCondition> ().isAlive) {
				StartCoroutine (cupRotateRight ());

				turnPressed++;
			}
		}

	}

		IEnumerator cupRotateLeft(){

		float turnTimer = 0.00f;

		while (turnTimer < 0.25) {
			turnTimer += Time.deltaTime;

//			transform.RotateAround(Vector3.zero, Vector3.forward, degreesPerSecond * Time.deltaTime);
			transform.Rotate(Vector3.forward, degreesPerSecond * Time.deltaTime);

			yield return null;
		}

		if (turnPressed % 2 == 1) {

			cup.transform.rotation = Quaternion.AngleAxis (180, Vector3.forward);

		} else if (turnPressed % 2 == 0) {

			cup.transform.rotation = Quaternion.AngleAxis (0, Vector3.forward);

		}

	}


	IEnumerator cupRotateRight(){

		float turnTimer = 0.00f;

		while (turnTimer < 0.25) {
			turnTimer += Time.deltaTime;

//			transform.RotateAround(Vector3.zero, Vector3.forward, -degreesPerSecond * Time.deltaTime);
			transform.Rotate(Vector3.forward, -degreesPerSecond * Time.deltaTime);

			yield return null;
		}

		if (turnPressed % 2 == 1) {

			cup.transform.rotation = Quaternion.AngleAxis (180, Vector3.forward);

		} else if (turnPressed % 2 == 0) {

			cup.transform.rotation = Quaternion.AngleAxis (0, Vector3.forward);

		}

	}
}
