using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

	public GameObject player;

	public float moveAmount = 40f;

	Rigidbody2D rb;

	public bool top;
	public bool bot;

	public bool grounded;
	public bool topGrounded;
	public bool specialGrounded;

	private int enemiesAttached;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D>();

		top = true;
		bot = false;

		grounded = true;
		topGrounded = false;
		specialGrounded = true;

		enemiesAttached = 0;

	}

	// Update is called once per frame
	void Update () {

		Vector3 moving = new Vector3 (transform.position.x,
			transform.position.y,
			transform.position.z);

		if (Input.GetKey (KeyCode.A)) {
			moving.x -= moveAmount * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.D)) {
			moving.x += moveAmount * Time.deltaTime;
		}

		if (Input.GetKeyDown (KeyCode.Space) && top == true && grounded == true) {
			rb.velocity = new Vector3(0, 75, 0);
			grounded = false;
			specialGrounded = true;
		}

		if (Input.GetKeyDown (KeyCode.Space) && top == true && topGrounded == true) {
			rb.velocity = new Vector3(0, 75, 0);
			topGrounded = false;
			specialGrounded = true;
		}

		if (Input.GetKeyDown (KeyCode.Space) && bot == true && grounded == true) {
			rb.velocity = new Vector3(0, -75, 0);
			grounded = false;
			specialGrounded = true;
		}

		if (Input.GetKeyDown (KeyCode.Space) && bot == true && topGrounded == true) {
			rb.velocity = new Vector3(0, -75, 0);
			topGrounded = false;
			specialGrounded = true;
		}

		if (Input.GetKeyDown (KeyCode.W) && grounded == true && specialGrounded == false) {
			moving.y = 2f;
			rb.gravityScale = 15;

			top = true;
			bot = false;
		}

		if (Input.GetKeyDown (KeyCode.S) && grounded == true && specialGrounded == false) {
			moving.y = -2f;
			rb.gravityScale = -15;

			top = false;
			bot = true;

			enemiesAttached = 0;
		}

		if (Input.GetKeyDown (KeyCode.W) && topGrounded == true && specialGrounded == false) {
			moving.y = 27f;
			rb.gravityScale = 15;

			top = true;
			bot = false;
		}

		if (Input.GetKeyDown (KeyCode.S) && topGrounded == true && specialGrounded == false) {
			moving.y = 23f;
			rb.gravityScale = -15;

			top = false;
			bot = true;

			enemiesAttached = 0;
		}

		if (enemiesAttached == 0) {
			moveAmount = 40;
		}

		if (enemiesAttached == 1) {
			moveAmount = 20;
		}

		if (enemiesAttached == 2) {
			moveAmount = 10;
		}

		transform.position = moving;

	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "ground") {
			grounded = true;
			specialGrounded = false;
			topGrounded = false;
		}

		if (coll.gameObject.tag == "ground2") {
			specialGrounded = true;
			grounded = true;
		}

		if (coll.gameObject.tag == "ground3") {
			topGrounded = true;
			specialGrounded = false;
			grounded = false;
		}

		if (coll.gameObject.tag == "enemy") {

			enemiesAttached++;
		}

		if (coll.gameObject.tag == "death") {
			Application.LoadLevel ("GameLose");
		}

		if (coll.gameObject.tag == "death1") {
			Application.LoadLevel ("GameLose1");
		}

		if (coll.gameObject.tag == "lvl1") {
			Application.LoadLevel ("Lvl1");
		}
//
//		if (coll.gameObject.tag == "win") {
//			Application.LoadLevel ("Win");
//		}
	}

//	void OnCollisionExit2D (Collision2D coll) {
//		grounded = false;
//	}
}
