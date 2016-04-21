using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

	public GameObject player;

	public GameObject topCover;
	public GameObject bottomCover;

	private float moveAmount = 50f;

	Rigidbody2D rb;

	public bool top;
	public bool bot;

	public bool grounded;
	public bool topGrounded;
	public bool specialGrounded;

	private int enemiesAttached;

	private SpriteRenderer spriteRenderer;

	public Sprite standingLeftA;
	public Sprite standingRightA;
	public Sprite jumpingLeftA;
	public Sprite jumpingRightA;
	public Sprite runningLeft1A;
	public Sprite runningLeft2A;
	public Sprite runningRight1A;
	public Sprite runningRight2A;

	public Sprite standingLeftH;
	public Sprite standingRightH;
	public Sprite jumpingLeftH;
	public Sprite jumpingRightH;
	public Sprite runningLeft1H;
	public Sprite runningLeft2H;
	public Sprite runningRight1H;
	public Sprite runningRight2H;

	private bool facingLeft;
	private bool facingRight;

	public bool airborn;

	public SpriteRenderer renderer;

	private float runAnimation;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D>();

		renderer = GetComponent<SpriteRenderer>();

//		SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();

		top = true;
		bot = false;

		grounded = true;
		topGrounded = false;
		specialGrounded = true;

		enemiesAttached = 0;

		topCover.SetActive (false);
		bottomCover.SetActive (true);

		runAnimation = 0.0f;

		facingLeft = false;
		facingRight = true;

		airborn = false;

		spriteRenderer = GetComponent<SpriteRenderer> ();
		if (spriteRenderer.sprite == null) {
			spriteRenderer.sprite = standingRightA;

		}
	}

	// Update is called once per frame
	void Update () {

		Vector3 moving = new Vector3 (transform.position.x,
			transform.position.y,
			transform.position.z);

		if (top == true && facingLeft == true && airborn == false) {
			spriteRenderer.sprite = standingLeftA;
		}

		if (top == true && facingRight == true && airborn == false) {
			spriteRenderer.sprite = standingRightA;
		}

		if (bot == true && facingLeft == true && airborn == false) {
			spriteRenderer.sprite = standingLeftH;
		}

		if (bot == true && facingRight == true && airborn == false) {
			spriteRenderer.sprite = standingRightH;
		}




		if (Input.GetKey (KeyCode.A) && airborn == false) {
			moving.x -= moveAmount * Time.deltaTime;

			facingRight = false;
			facingLeft = true;
		}

		if (Input.GetKey (KeyCode.A) && top == true && airborn == false) {

			runningLeftTop();

		} else if (Input.GetKeyUp (KeyCode.A) && airborn == false && facingLeft == true && top == true) {
			spriteRenderer.sprite = standingLeftA;

			runAnimation = 0;
		}

		if (Input.GetKey (KeyCode.A) && bot == true && airborn == false) {

			runningLeftBot();

		} else if (Input.GetKeyUp (KeyCode.A) && airborn == false && facingLeft == true && bot == true) {
			spriteRenderer.sprite = standingLeftH;

			runAnimation = 0;
		}



		if (Input.GetKey (KeyCode.D) && airborn == false) {
			moving.x += moveAmount * Time.deltaTime;

			facingRight = true;
			facingLeft = false;
		}

		if (Input.GetKey (KeyCode.D) && top == true && airborn == false){

			runningRightTop();

		}else if (Input.GetKeyUp (KeyCode.D) && airborn == false && facingRight == true && top == true) {
			spriteRenderer.sprite = standingRightA;

			runAnimation = 0;
		}

		if (Input.GetKey (KeyCode.D) && bot == true && airborn == false){

			runningRightBot();

		}else if (Input.GetKeyUp (KeyCode.D) && airborn == false && facingRight == true && bot == true) {
			spriteRenderer.sprite = standingRightH;

			runAnimation = 0;
		}




		if (Input.GetKeyDown (KeyCode.Space) && grounded == true) {
			airborn = true;
		}

		if (Input.GetKeyDown (KeyCode.Space) && topGrounded == true) {
			airborn = true;
		}



		if (Input.GetKey (KeyCode.A) && airborn == true && top == true) {

			moving.x -= moveAmount * Time.deltaTime;

			facingRight = false;
			facingLeft = true;

			spriteRenderer.sprite = jumpingLeftA;
		}

		if (Input.GetKey (KeyCode.A) && airborn == true && bot == true) {

			moving.x -= moveAmount * Time.deltaTime;

			facingRight = false;
			facingLeft = true;

			spriteRenderer.sprite = jumpingLeftH;
		}



		if (Input.GetKey (KeyCode.D) && airborn == true && top == true) {

			moving.x += moveAmount * Time.deltaTime;

			facingRight = true;
			facingLeft = false;

			spriteRenderer.sprite = jumpingRightA;
		}

		if (Input.GetKey (KeyCode.D) && airborn == true && bot == true) {

			moving.x += moveAmount * Time.deltaTime;

			facingRight = true;
			facingLeft = false;

			spriteRenderer.sprite = jumpingRightH;
		}


		if (Input.GetKeyDown (KeyCode.Space) && top == true
			&& grounded == true && facingLeft == true && airborn == true) {

			rb.velocity = new Vector3(0, 80, 0);
			grounded = false;
			specialGrounded = true;

			spriteRenderer.sprite = jumpingLeftA;
		}

		if (Input.GetKeyDown (KeyCode.Space) && top == true
			&& grounded == true && facingRight == true && airborn == true) {

			rb.velocity = new Vector3(0, 80, 0);
			grounded = false;
			specialGrounded = true;

			spriteRenderer.sprite = jumpingRightA;
		}

		if (Input.GetKeyDown (KeyCode.Space) && top == true
			&& topGrounded == true && facingLeft == true && airborn == true) {

			rb.velocity = new Vector3(0, 80, 0);
			topGrounded = false;
			specialGrounded = true;

			spriteRenderer.sprite = jumpingLeftA;
		}

		if (Input.GetKeyDown (KeyCode.Space) && top == true
			&& topGrounded == true && facingRight == true && airborn == true) {

			rb.velocity = new Vector3(0, 80, 0);
			topGrounded = false;
			specialGrounded = true;

			spriteRenderer.sprite = jumpingRightA;
		}

		if (Input.GetKeyDown (KeyCode.Space) && bot == true
			&& grounded == true && facingLeft == true && airborn == true) {

			rb.velocity = new Vector3(0, -80, 0);
			grounded = false;
			specialGrounded = true;

			spriteRenderer.sprite = jumpingLeftH;
		}

		if (Input.GetKeyDown (KeyCode.Space) && bot == true
			&& grounded == true && facingRight == true && airborn == true) {

			rb.velocity = new Vector3(0, -80, 0);
			grounded = false;
			specialGrounded = true;

			spriteRenderer.sprite = jumpingRightH;
		}

		if (Input.GetKeyDown (KeyCode.Space) && bot == true
			&& topGrounded == true && facingLeft == true && airborn == true) {

			rb.velocity = new Vector3(0, -80, 0);
			topGrounded = false;
			specialGrounded = true;

			spriteRenderer.sprite = jumpingLeftH;
		}

		if (Input.GetKeyDown (KeyCode.Space) && bot == true &&
			topGrounded == true && facingRight == true && airborn == true) {

			rb.velocity = new Vector3(0, -80, 0);
			topGrounded = false;
			specialGrounded = true;

			spriteRenderer.sprite = jumpingRightH;
		}

		if (Input.GetKeyDown (KeyCode.W) && grounded == true && specialGrounded == false) {
			moving.y = 2f;
			rb.gravityScale = 15;

			top = true;
			bot = false;

			topCover.SetActive (false);
			bottomCover.SetActive (true);
		}

		if (Input.GetKeyDown (KeyCode.S) && grounded == true && specialGrounded == false) {
			moving.y = -2f;
			rb.gravityScale = -15;

			top = false;
			bot = true;

			topCover.SetActive (true);
			bottomCover.SetActive (false);

			enemiesAttached = 0;
		}

		if (Input.GetKeyDown (KeyCode.W) && topGrounded == true && specialGrounded == false) {
			moving.y = 27f;
			rb.gravityScale = 15;

			top = true;
			bot = false;

			topCover.SetActive (false);
			bottomCover.SetActive (true);
		}

		if (Input.GetKeyDown (KeyCode.S) && topGrounded == true && specialGrounded == false) {
			moving.y = 23f;
			rb.gravityScale = -15;

			top = false;
			bot = true;

			topCover.SetActive (true);
			bottomCover.SetActive (false);

			enemiesAttached = 0;
		}

		if (enemiesAttached == 0) {
			moveAmount = 50;
			renderer.color = new Color (255.0f, 255.0f, 255.0f, 1f);
		}

		if (enemiesAttached == 1) {
			moveAmount = 25;
			renderer.color = new Color (255.0f, 255.0f, 255.0f, 0.75f);
		}

		if (enemiesAttached == 2) {
			moveAmount = 10;
			renderer.color = new Color (0f, 255.0f, 0f, 1f);
		}

		transform.position = moving;

//		if (top == true) {
//			player.transform.rotation = Quaternion.Euler (0, 0, 0);
//		}

//		if (bot == true) {
//			player.transform.rotation = Quaternion.Euler (0, 0, 180);
//		}

	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "ground") {
			grounded = true;
			specialGrounded = false;
			topGrounded = false;
			airborn = false;
		}

		if (coll.gameObject.tag == "ground2") {
			specialGrounded = true;
			grounded = true;
			airborn = false;
		}

		if (coll.gameObject.tag == "ground3") {
			topGrounded = true;
			specialGrounded = false;
			grounded = false;
			airborn = false;
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

		if (coll.gameObject.tag == "reverse") {
			rb.gravityScale = -rb.gravityScale;
		}
//
//		if (coll.gameObject.tag == "win") {
//			Application.LoadLevel ("Win");
//		}
	}

//	void OnCollisionExit2D (Collision2D coll) {
//		grounded = false;
//	}


	void runningRightTop(){

		if (enemiesAttached == 0) {
			runAnimation += Time.deltaTime * 14;


			if ((int)runAnimation % 2 == 1) {
				spriteRenderer.sprite = runningRight1A;
			}

			if ((int)runAnimation % 2 == 0) {
				spriteRenderer.sprite = runningRight2A;
			}
		}

		if (enemiesAttached == 1) {
			runAnimation += Time.deltaTime * 7;


			if ((int)runAnimation % 2 == 1) {
				spriteRenderer.sprite = runningRight1A;
			}

			if ((int)runAnimation % 2 == 0) {
				spriteRenderer.sprite = runningRight2A;
			}
		}

		if (enemiesAttached == 2) {
			runAnimation += Time.deltaTime * 3.5f;


			if ((int)runAnimation % 2 == 1) {
				spriteRenderer.sprite = runningRight1A;
			}

			if ((int)runAnimation % 2 == 0) {
				spriteRenderer.sprite = runningRight2A;
			}
		}
	}

	void runningLeftTop(){

		if (enemiesAttached == 0) {
			runAnimation += Time.deltaTime * 14;


			if ((int)runAnimation % 2 == 1) {
				spriteRenderer.sprite = runningLeft1A;
			}

			if ((int)runAnimation % 2 == 0) {
				spriteRenderer.sprite = runningLeft2A;
			}
		}

		if (enemiesAttached == 1) {
			runAnimation += Time.deltaTime * 7;


			if ((int)runAnimation % 2 == 1) {
				spriteRenderer.sprite = runningLeft1A;
			}

			if ((int)runAnimation % 2 == 0) {
				spriteRenderer.sprite = runningLeft2A;
			}
		}

		if (enemiesAttached == 2) {
			runAnimation += Time.deltaTime * 3.5f;


			if ((int)runAnimation % 2 == 1) {
				spriteRenderer.sprite = runningLeft1A;
			}

			if ((int)runAnimation % 2 == 0) {
				spriteRenderer.sprite = runningLeft2A;
			}
		}
	}


	void runningRightBot(){
		runAnimation += Time.deltaTime*14;


		if((int)runAnimation%2==1){
			spriteRenderer.sprite = runningRight1H;
		}

		if((int)runAnimation%2==0){
			spriteRenderer.sprite = runningRight2H;
		}
	}

	void runningLeftBot(){
		runAnimation += Time.deltaTime*14;


		if((int)runAnimation%2==1){
			spriteRenderer.sprite = runningLeft1H;
		}

		if((int)runAnimation%2==0){
			spriteRenderer.sprite = runningLeft2H;
		}
	}
}
