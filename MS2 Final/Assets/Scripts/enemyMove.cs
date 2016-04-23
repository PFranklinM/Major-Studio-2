using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour {

	public GameObject player;

	public GameObject enemy;

	public GameObject reset1;
	public GameObject reset2;
	public GameObject reset3;
	public GameObject reset4;

	public Vector3 startPos;
	public Vector3 endPos;
	public Vector3 dir;
	private float radius = 25f;

	private float moveAmount = 20f;

	public float moveCounter = 0f;

	Vector3 origin;

	private bool moveNormal;

	Rigidbody2D rb;

	private SpriteRenderer spriteRenderer;

	public Sprite regularRight;
	public Sprite regularLeft;

	public Sprite chasingRight1;
	public Sprite chasingRight2;
	public Sprite chasingRight3;
	public Sprite chasingRight4;
	public Sprite chasingRight5;

	public Sprite chasingLeft1;
	public Sprite chasingLeft2;
	public Sprite chasingLeft3;
	public Sprite chasingLeft4;
	public Sprite chasingLeft5;


	public SpriteRenderer renderer;

	private float blinkAnimation;

	private bool facingLeft;
	private bool facingRight;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D>();

		renderer = GetComponent<SpriteRenderer>();

		origin = transform.position;

		blinkAnimation = 0.0f;

		moveNormal = true;

		enemy.SetActive (true);

		spriteRenderer = GetComponent<SpriteRenderer> ();
		if (spriteRenderer.sprite == null) {
			spriteRenderer.sprite = regularRight;

		}

	}

	// Update is called once per frame
	void Update () {

		Vector3 moving = new Vector3 (transform.position.x,
			transform.position.y,
			transform.position.z);

		if (moveAmount > 0) {
			facingLeft = false;
			facingRight = true;
		}

		if (moveAmount < 0) {
			facingLeft = true;
			facingRight = false;
		}


		if (Vector3.Distance (enemy.transform.position, player.transform.position) < radius) {

			if (enemy.transform.position.x < player.transform.position.x) {
				chasingRight ();
			}

			if (enemy.transform.position.x > player.transform.position.x) {
				chasingLeft ();
			}

			moveNormal = false;

			dir.Normalize ();

			Vector3 playerPos = player.transform.position;

			startPos = enemy.transform.position;
			endPos = playerPos;

			dir = endPos - startPos;

			moving.z = 0f;

			transform.position += dir * Time.deltaTime * 4f;

		} else if(moveNormal == true) {

			moveCounter += Time.deltaTime;

			if (moveCounter > 2) {
				moveCounter = 0;
				moveAmount = -moveAmount;
			}

			moving.x += moveAmount * Time.deltaTime;

			moving.z = 0f;

			transform.position = moving;
		}

		if (GameObject.Find ("Player").GetComponent<playerMove> ().bot) {

			moveNormal = true;

			moveCounter += Time.deltaTime;

			if (moveCounter > 2) {
				moveCounter = 0;
				moveAmount = -moveAmount;
			}

			moving.x += moveAmount * Time.deltaTime;

			moving.z = 1f;

			transform.position = moving;
		}

		if (Vector3.Distance (enemy.transform.position, reset1.transform.position) < 20) {
				moveNormal = true;
				transform.position = origin;
			}

		if (Vector3.Distance (enemy.transform.position, reset2.transform.position) < 20) {
			moveNormal = true;
			transform.position = origin;
		}

		if (Vector3.Distance (enemy.transform.position, reset3.transform.position) < 20) {
			moveNormal = true;
			transform.position = origin;
		}

		if (Vector3.Distance (enemy.transform.position, reset4.transform.position) < 20) {
			moveNormal = true;
			transform.position = origin;
		}

		if (facingLeft == true && moveNormal == true) {
			spriteRenderer.sprite = regularLeft;
		}

		if (facingRight == true && moveNormal == true) {
			spriteRenderer.sprite = regularRight;
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "player") {
			enemy.SetActive (false);

			transform.position = origin;
		}
	}

	void chasingRight(){
		blinkAnimation += Time.deltaTime * 5;


		if ((int)blinkAnimation % 2 == 4) {
			spriteRenderer.sprite = chasingRight1;
		}

		if ((int)blinkAnimation % 2 == 3) {
			spriteRenderer.sprite = chasingRight2;
		}

		if ((int)blinkAnimation % 2 == 2) {
			spriteRenderer.sprite = chasingRight3;
		}

		if ((int)blinkAnimation % 2 == 1) {
			spriteRenderer.sprite = chasingRight4;
		}

		if ((int)blinkAnimation % 2 == 0) {
			spriteRenderer.sprite = chasingRight5;
		}
	}

	void chasingLeft(){
		blinkAnimation += Time.deltaTime * 5;


		if ((int)blinkAnimation % 2 == 4) {
			spriteRenderer.sprite = chasingLeft1;
		}

		if ((int)blinkAnimation % 2 == 3) {
			spriteRenderer.sprite = chasingLeft2;
		}

		if ((int)blinkAnimation % 2 == 2) {
			spriteRenderer.sprite = chasingLeft3;
		}

		if ((int)blinkAnimation % 2 == 1) {
			spriteRenderer.sprite = chasingLeft4;
		}

		if ((int)blinkAnimation % 2 == 0) {
			spriteRenderer.sprite = chasingLeft5;
		}
	}
}
