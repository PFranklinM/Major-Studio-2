using UnityEngine;
using System.Collections;

public class minotaurMove : MonoBehaviour {

	public GameObject player;

	public GameObject minotaur;

	public Vector3 startPos;
	public Vector3 endPos;
	public Vector3 dir;

	public bool playerIsSmelled;

	private int moveDirection;

	public float moveAmount = 10f;

	private float radius = 10f;

	// Use this for initialization
	void Start () {

		InvokeRepeating ("movement", 0.5f, 0.25f);

//		moveDirection = Random.Range (0, 4);

		moveDirection = 0;

		playerIsSmelled = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = new Vector3 (transform.position.x,
			transform.position.y,
			transform.position.z);

		if (Vector3.Distance (minotaur.transform.position, player.transform.position) < radius) {
			
			dir.Normalize ();

			Vector3 playerPos = player.transform.position;

			startPos = minotaur.transform.position;

			endPos = playerPos;

			dir = endPos - startPos;

			transform.position += dir * Time.deltaTime * 3f;

			playerIsSmelled = true;

		} else {

			if (moveDirection == 0) {
				pos.x += moveAmount * Time.deltaTime;
			}

			if (moveDirection == 1) {
				pos.x -= moveAmount * Time.deltaTime;
			}

			if (moveDirection == 2) {
				pos.y += moveAmount * Time.deltaTime;
			}

			if (moveDirection == 3) {
				pos.y -= moveAmount * Time.deltaTime;
			}

			//camera size 5

			transform.position = pos;

			playerIsSmelled = false;
		}
	
	}


	void movement(){
		if (moveDirection == 0) {
			int element = Random.Range (0, 9);

			if (element == 0) {
				moveDirection = 1;
			}

			if (element == 1) {
				moveDirection = 2;
			}

			if (element == 2) {
				moveDirection = 3;
			}

			if (element == 3) {
				moveDirection = 2;
			}

			if (element == 4) {
				moveDirection = 3;
			}

			if (element == 5) {
				moveDirection = 0;
			}

			if (element == 6) {
				moveDirection = 2;
			}

			if (element == 7) {
				moveDirection = 3;
			}

			if (element == 8) {
				moveDirection = 0;
			}
		}

		if (moveDirection == 1) {
			int element = Random.Range (0, 9);

			if (element == 0) {
				moveDirection = 0;
			}

			if (element == 1) {
				moveDirection = 2;
			}

			if (element == 2) {
				moveDirection = 3;
			}

			if (element == 3) {
				moveDirection = 2;
			}

			if (element == 4) {
				moveDirection = 3;
			}

			if (element == 5) {
				moveDirection = 1;
			}

			if (element == 6) {
				moveDirection = 2;
			}

			if (element == 7) {
				moveDirection = 3;
			}

			if (element == 8) {
				moveDirection = 1;
			}
		}

		if (moveDirection == 2) {
			int element = Random.Range (0, 9);

			if (element == 0) {
				moveDirection = 0;
			}

			if (element == 1) {
				moveDirection = 1;
			}

			if (element == 2) {
				moveDirection = 3;
			}

			if (element == 3) {
				moveDirection = 0;
			}

			if (element == 4) {
				moveDirection = 1;
			}

			if (element == 5) {
				moveDirection = 2;
			}

			if (element == 6) {
				moveDirection = 0;
			}

			if (element == 7) {
				moveDirection = 1;
			}

			if (element == 8) {
				moveDirection = 2;
			}
		}

		if (moveDirection == 3) {
			int element = Random.Range (0, 9);

			if (element == 0) {
				moveDirection = 0;
			}

			if (element == 1) {
				moveDirection = 1;
			}

			if (element == 2) {
				moveDirection = 2;
			}

			if (element == 3) {
				moveDirection = 0;
			}

			if (element == 4) {
				moveDirection = 1;
			}

			if (element == 5) {
				moveDirection = 3;
			}

			if (element == 6) {
				moveDirection = 0;
			}

			if (element == 7) {
				moveDirection = 1;
			}

			if (element == 8) {
				moveDirection = 3;
			}
		}
	}
}
