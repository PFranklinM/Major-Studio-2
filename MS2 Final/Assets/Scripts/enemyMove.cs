using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour {

	public GameObject player;

	public GameObject enemy;

	public GameObject reset1;
	public GameObject reset2;

	public Vector3 startPos;
	public Vector3 endPos;
	public Vector3 dir;
	private float radius = 20f;

	private float moveAmount = 20f;

	public float moveCounter = 0f;

	Vector3 origin;

	private bool moveNormal;

	// Use this for initialization
	void Start () {

		origin = transform.position;

		moveNormal = true;

	}

	// Update is called once per frame
	void Update () {

		Vector3 moving = new Vector3 (transform.position.x,
			transform.position.y,
			transform.position.z);

		if (Vector3.Distance (enemy.transform.position, player.transform.position) < radius) {

			moveNormal = false;

			dir.Normalize ();

			Vector3 playerPos = player.transform.position;

			startPos = enemy.transform.position;

			endPos = playerPos;

			dir = endPos - startPos;

			transform.position += dir * Time.deltaTime * 4.5f;

		} else if(moveNormal == true) {

			moveCounter += Time.deltaTime;

			if (moveCounter > 1) {
				moveCounter = 0;
				moveAmount = -moveAmount;
			}

			moving.x += moveAmount * Time.deltaTime;

			transform.position = moving;
		}

		if (GameObject.Find ("Player").GetComponent<playerMove> ().bot) {

			moveNormal = true;

			moveCounter += Time.deltaTime;

			if (moveCounter > 1) {
				moveCounter = 0;
				moveAmount = -moveAmount;
			}

			moving.x += moveAmount * Time.deltaTime;

			transform.position = moving;
		}

		if (Vector3.Distance (enemy.transform.position, reset1.transform.position) < 30) {
				moveNormal = true;
				transform.position = origin;
			}

		if (Vector3.Distance (enemy.transform.position, reset2.transform.position) < 30) {
			moveNormal = true;
			transform.position = origin;
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "player") {
			enemy.SetActive (false);

			transform.position = origin;
		}
	}
}
