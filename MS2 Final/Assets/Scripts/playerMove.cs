using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

	public GameObject player;

	public GameObject topCover;
	public GameObject bottomCover;

	public float moveAmount = 40f;

	//pants not gray

	//inverted (elements of the photo) photo for where the gravity flips

	Rigidbody2D rb;

	public bool top;
	public bool bot;

	public bool grounded;
	public bool topGrounded;
	public bool specialGrounded;

	private int enemiesAttached;

	private SpriteRenderer spriteRenderer;

	public Sprite standingLeft;
	public Sprite standingRight;
	public Sprite jumpingLeft;
	public Sprite jumpingRight;
	public Sprite runningLeft1;
	public Sprite runningLeft2;
	public Sprite runningRight1;
	public Sprite runningRight2;

	private bool facingLeft;
	private bool facingRight;

	private bool airborn;

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
			spriteRenderer.sprite = standingRight;

		}


	}

	// Update is called once per frame
	void Update () {

		Vector3 moving = new Vector3 (transform.position.x,
			transform.position.y,
			transform.position.z);



		if (Input.GetKey (KeyCode.A) && airborn == false) {
			moving.x -= moveAmount * Time.deltaTime;

			facingRight = false;
			facingLeft = true;
		}

		if (Input.GetKey (KeyCode.A) && top == true) {

			runningLeftTop();

		} else if (airborn == false && facingLeft == true) {
			spriteRenderer.sprite = standingLeft;

			runAnimation = 0;
		}

//		if (Input.GetKey (KeyCode.A) && bot == true) {
//
//			runningLeftBot();
//
//		} else if (airborn == false && facingLeft == true) {
//			spriteRenderer.sprite = standingLeft;
//
//			runAnimation = 0;
//		}



		if (Input.GetKey (KeyCode.D) && airborn == false) {
			moving.x += moveAmount * Time.deltaTime;

			facingRight = true;
			facingLeft = false;
		}

		if (Input.GetKey (KeyCode.D) && top == true){

			runningRightTop();

		}else if (airborn == false && facingRight == true) {
			spriteRenderer.sprite = standingRight;

			runAnimation = 0;
		}

//		if (Input.GetKey (KeyCode.D) && bot == true){
//
//			runningRightBot();
//
//		}else if (airborn == false && facingRight == true) {
//			spriteRenderer.sprite = standingRight;
//
//			runAnimation = 0;
//		}




		if (Input.GetKeyDown (KeyCode.Space) && grounded == true) {
			airborn = true;
		}

		if (Input.GetKey (KeyCode.A) && airborn == true) {

			moving.x -= moveAmount * Time.deltaTime;

			facingRight = false;
			facingLeft = true;

			spriteRenderer.sprite = jumpingLeft;
		}

		if (Input.GetKey (KeyCode.D) && airborn == true) {

			moving.x += moveAmount * Time.deltaTime;

			facingRight = true;
			facingLeft = false;

			spriteRenderer.sprite = jumpingRight;
		}


		if (Input.GetKeyDown (KeyCode.Space) && top == true
			&& grounded == true && facingLeft == true && airborn == true) {

			rb.velocity = new Vector3(0, 75, 0);
			grounded = false;
			specialGrounded = true;

			spriteRenderer.sprite = jumpingLeft;
		}

		if (Input.GetKeyDown (KeyCode.Space) && top == true
			&& grounded == true && facingRight == true && airborn == true) {

			rb.velocity = new Vector3(0, 75, 0);
			grounded = false;
			specialGrounded = true;

			spriteRenderer.sprite = jumpingRight;
		}

		if (Input.GetKeyDown (KeyCode.Space) && top == true
			&& topGrounded == true && facingLeft == true && airborn == true) {

			rb.velocity = new Vector3(0, 75, 0);
			topGrounded = false;
			specialGrounded = true;

			spriteRenderer.sprite = jumpingLeft;
		}

		if (Input.GetKeyDown (KeyCode.Space) && top == true
			&& topGrounded == true && facingRight == true && airborn == true) {

			rb.velocity = new Vector3(0, 75, 0);
			topGrounded = false;
			specialGrounded = true;

			spriteRenderer.sprite = jumpingRight;
		}

		if (Input.GetKeyDown (KeyCode.Space) && bot == true
			&& grounded == true && facingLeft == true && airborn == true) {

			rb.velocity = new Vector3(0, -75, 0);
			grounded = false;
			specialGrounded = true;

//			spriteRenderer.sprite = jumpingLeftBot;
		}

		if (Input.GetKeyDown (KeyCode.Space) && bot == true
			&& grounded == true && facingRight == true && airborn == true) {

			rb.velocity = new Vector3(0, -75, 0);
			grounded = false;
			specialGrounded = true;

//			spriteRenderer.sprite = jumpingRightBot;
		}

		if (Input.GetKeyDown (KeyCode.Space) && bot == true
			&& topGrounded == true && facingLeft == true && airborn == true) {

			rb.velocity = new Vector3(0, -75, 0);
			topGrounded = false;
			specialGrounded = true;

//			spriteRenderer.sprite = jumpingLeftBot;
		}

		if (Input.GetKeyDown (KeyCode.Space) && bot == true &&
			topGrounded == true && facingRight == true && airborn == true) {

			rb.velocity = new Vector3(0, -75, 0);
			topGrounded = false;
			specialGrounded = true;

//			spriteRenderer.sprite = jumpingRightBot;
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
		runAnimation += Time.deltaTime*14;


		if((int)runAnimation%2==1){
			spriteRenderer.sprite = runningRight1;
		}

		if((int)runAnimation%2==0){
			spriteRenderer.sprite = runningRight2;
		}
	}

	void runningLeftTop(){
		runAnimation += Time.deltaTime*14;


		if((int)runAnimation%2==1){
			spriteRenderer.sprite = runningLeft1;
		}

		if((int)runAnimation%2==0){
			spriteRenderer.sprite = runningLeft2;
		}
	}
}
