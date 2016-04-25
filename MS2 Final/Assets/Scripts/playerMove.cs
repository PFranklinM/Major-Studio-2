using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerMove : MonoBehaviour {

	public GameObject player;

	public AudioSource AudioSource1;
	public AudioSource AudioSource2;

	public GameObject stressText;
	public GameObject gameTimer;
	public float stress = 0f;
	private float stressFlash = 0.0f;

	private float gameTime = 151f;

	public GameObject topCover1;
	public GameObject bottomCover1;

	public GameObject topCover2;
	public GameObject bottomCover2;

	public GameObject topCover3;
	public GameObject bottomCover3;

	public GameObject topCover4;
	public GameObject bottomCover4;

	public GameObject topCover5;
	public GameObject bottomCover5;

	public GameObject topCover6;
	public GameObject bottomCover6;

	public GameObject topCover7;
	public GameObject bottomCover7;

	public GameObject topCover8;
	public GameObject bottomCover8;

	public GameObject topCover9;
	public GameObject bottomCover9;

	public GameObject topCover10;
	public GameObject bottomCover10;

	public GameObject topCover11;
	public GameObject bottomCover11;

	public GameObject topBackground;
	public GameObject bottomBackground;

	private float moveAmount = 50f;

	Rigidbody2D rb;

	public bool top;
	public bool bot;

	public bool grounded;
	public bool topGrounded;
	public bool botGrounded;
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

		AudioSource1.Play();

//		SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();

		top = true;
		bot = false;

		grounded = true;
		topGrounded = false;
		botGrounded = false;
		specialGrounded = true;

		enemiesAttached = 0;

		topCover1.SetActive (false);
		topCover2.SetActive (false);
		topCover3.SetActive (false);
		topCover4.SetActive (false);
		topCover5.SetActive (false);
		topCover6.SetActive (false);
		topCover7.SetActive (false);
		topCover8.SetActive (false);
		topCover9.SetActive (false);
		topCover10.SetActive (false);
		topCover11.SetActive (false);

		topBackground.SetActive (true);

		bottomCover1.SetActive (true);
		bottomCover2.SetActive (true);
		bottomCover3.SetActive (true);
		bottomCover4.SetActive (true);
		bottomCover5.SetActive (true);
		bottomCover6.SetActive (true);
		bottomCover7.SetActive (true);
		bottomCover8.SetActive (true);
		bottomCover9.SetActive (true);
		bottomCover10.SetActive (true);
		bottomCover11.SetActive (true);

		bottomBackground.SetActive (false);

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

		gameTime -= Time.deltaTime;

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

		if (Input.GetKeyDown (KeyCode.Space) && botGrounded == true) {
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

		if (Input.GetKeyDown (KeyCode.Space) && top == true
			&& botGrounded == true && facingLeft == true && airborn == true) {

			rb.velocity = new Vector3(0, 80, 0);
			botGrounded = false;
			specialGrounded = true;

			spriteRenderer.sprite = jumpingLeftA;
		}

		if (Input.GetKeyDown (KeyCode.Space) && top == true
			&& botGrounded == true && facingRight == true && airborn == true) {

			rb.velocity = new Vector3(0, 80, 0);
			botGrounded = false;
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

		if (Input.GetKeyDown (KeyCode.Space) && bot == true
			&& botGrounded == true && facingLeft == true && airborn == true) {

			rb.velocity = new Vector3(0, -80, 0);
			botGrounded = false;
			specialGrounded = true;

			spriteRenderer.sprite = jumpingLeftH;
		}

		if (Input.GetKeyDown (KeyCode.Space) && bot == true &&
			botGrounded == true && facingRight == true && airborn == true) {

			rb.velocity = new Vector3(0, -80, 0);
			botGrounded = false;
			specialGrounded = true;

			spriteRenderer.sprite = jumpingRightH;
		}

		if (Input.GetKeyDown (KeyCode.W) && grounded == true && specialGrounded == false) {
			moving.y = 2f;
			rb.gravityScale = 15;

			top = true;
			bot = false;

			topCover1.SetActive (false);
			topCover2.SetActive (false);
			topCover3.SetActive (false);
			topCover4.SetActive (false);
			topCover5.SetActive (false);
			topCover6.SetActive (false);
			topCover7.SetActive (false);
			topCover8.SetActive (false);
			topCover9.SetActive (false);
			topCover10.SetActive (false);
			topCover11.SetActive (false);

			topBackground.SetActive (true);

			bottomCover1.SetActive (true);
			bottomCover2.SetActive (true);
			bottomCover3.SetActive (true);
			bottomCover4.SetActive (true);
			bottomCover5.SetActive (true);
			bottomCover6.SetActive (true);
			bottomCover7.SetActive (true);
			bottomCover8.SetActive (true);
			bottomCover9.SetActive (true);
			bottomCover10.SetActive (true);
			bottomCover11.SetActive (true);

			bottomBackground.SetActive (false);

			if (AudioSource2 == true) {
				AudioSource2.Pause ();
				AudioSource1.Play ();
			} else {
				AudioSource1.Play ();
			}
		}

		if (Input.GetKeyDown (KeyCode.S) && grounded == true && specialGrounded == false) {
			moving.y = -2f;
			rb.gravityScale = -15;

			top = false;
			bot = true;

			topCover1.SetActive (true);
			topCover2.SetActive (true);
			topCover3.SetActive (true);
			topCover4.SetActive (true);
			topCover5.SetActive (true);
			topCover6.SetActive (true);
			topCover7.SetActive (true);
			topCover8.SetActive (true);
			topCover9.SetActive (true);
			topCover10.SetActive (true);
			topCover11.SetActive (true);

			topBackground.SetActive (false);

			bottomCover1.SetActive (false);
			bottomCover2.SetActive (false);
			bottomCover3.SetActive (false);
			bottomCover4.SetActive (false);
			bottomCover5.SetActive (false);
			bottomCover6.SetActive (false);
			bottomCover7.SetActive (false);
			bottomCover8.SetActive (false);
			bottomCover9.SetActive (false);
			bottomCover10.SetActive (false);
			bottomCover11.SetActive (false);

			bottomBackground.SetActive (true);

			enemiesAttached = 0;

			if (AudioSource1 == true) {
				AudioSource1.Pause ();
				AudioSource2.Play ();
			} else {
				AudioSource2.Play ();
			}
		}

		if (Input.GetKeyDown (KeyCode.W) && topGrounded == true && specialGrounded == false) {
			moving.y = 37f;
			rb.gravityScale = 15;

			top = true;
			bot = false;

			topCover1.SetActive (false);
			topCover2.SetActive (false);
			topCover3.SetActive (false);
			topCover4.SetActive (false);
			topCover5.SetActive (false);
			topCover6.SetActive (false);
			topCover7.SetActive (false);
			topCover8.SetActive (false);
			topCover9.SetActive (false);
			topCover10.SetActive (false);
			topCover11.SetActive (false);

			topBackground.SetActive (true);

			bottomCover1.SetActive (true);
			bottomCover2.SetActive (true);
			bottomCover3.SetActive (true);
			bottomCover4.SetActive (true);
			bottomCover5.SetActive (true);
			bottomCover6.SetActive (true);
			bottomCover7.SetActive (true);
			bottomCover8.SetActive (true);
			bottomCover9.SetActive (true);
			bottomCover10.SetActive (true);
			bottomCover11.SetActive (true);

			bottomBackground.SetActive (false);

			if (AudioSource2 == true) {
				AudioSource2.Pause ();
				AudioSource1.Play ();
			} else {
				AudioSource1.Play ();
			}
		}

		if (Input.GetKeyDown (KeyCode.S) && topGrounded == true && specialGrounded == false) {
			moving.y = 33f;
			rb.gravityScale = -15;

			top = false;
			bot = true;

			topCover1.SetActive (true);
			topCover2.SetActive (true);
			topCover3.SetActive (true);
			topCover4.SetActive (true);
			topCover5.SetActive (true);
			topCover6.SetActive (true);
			topCover7.SetActive (true);
			topCover8.SetActive (true);
			topCover9.SetActive (true);
			topCover10.SetActive (true);
			topCover11.SetActive (true);

			topBackground.SetActive (false);

			bottomCover1.SetActive (false);
			bottomCover2.SetActive (false);
			bottomCover3.SetActive (false);
			bottomCover4.SetActive (false);
			bottomCover5.SetActive (false);
			bottomCover6.SetActive (false);
			bottomCover7.SetActive (false);
			bottomCover8.SetActive (false);
			bottomCover9.SetActive (false);
			bottomCover10.SetActive (false);
			bottomCover11.SetActive (false);

			bottomBackground.SetActive (true);

			enemiesAttached = 0;

			if (AudioSource1 == true) {
				AudioSource1.Pause ();
				AudioSource2.Play ();
			} else {
				AudioSource2.Play ();
			}
		}

		if (Input.GetKeyDown (KeyCode.W) && botGrounded == true && specialGrounded == false) {
			moving.y = -33f;
			rb.gravityScale = 15;

			top = true;
			bot = false;

			topCover1.SetActive (false);
			topCover2.SetActive (false);
			topCover3.SetActive (false);
			topCover4.SetActive (false);
			topCover5.SetActive (false);
			topCover6.SetActive (false);
			topCover7.SetActive (false);
			topCover8.SetActive (false);
			topCover9.SetActive (false);
			topCover10.SetActive (false);
			topCover11.SetActive (false);

			topBackground.SetActive (true);

			bottomCover1.SetActive (true);
			bottomCover2.SetActive (true);
			bottomCover3.SetActive (true);
			bottomCover4.SetActive (true);
			bottomCover5.SetActive (true);
			bottomCover6.SetActive (true);
			bottomCover7.SetActive (true);
			bottomCover8.SetActive (true);
			bottomCover9.SetActive (true);
			bottomCover10.SetActive (true);
			bottomCover11.SetActive (true);

			bottomBackground.SetActive (false);

			if (AudioSource2 == true) {
				AudioSource2.Pause ();
				AudioSource1.Play ();
			} else {
				AudioSource1.Play ();
			}
		}

		if (Input.GetKeyDown (KeyCode.S) && botGrounded == true && specialGrounded == false) {
			moving.y = -37f;
			rb.gravityScale = -15;

			top = false;
			bot = true;

			topCover1.SetActive (true);
			topCover2.SetActive (true);
			topCover3.SetActive (true);
			topCover4.SetActive (true);
			topCover5.SetActive (true);
			topCover6.SetActive (true);
			topCover7.SetActive (true);
			topCover8.SetActive (true);
			topCover9.SetActive (true);
			topCover10.SetActive (true);
			topCover11.SetActive (true);

			topBackground.SetActive (false);

			bottomCover1.SetActive (false);
			bottomCover2.SetActive (false);
			bottomCover3.SetActive (false);
			bottomCover4.SetActive (false);
			bottomCover5.SetActive (false);
			bottomCover6.SetActive (false);
			bottomCover7.SetActive (false);
			bottomCover8.SetActive (false);
			bottomCover9.SetActive (false);
			bottomCover10.SetActive (false);
			bottomCover11.SetActive (false);

			bottomBackground.SetActive (true);

			enemiesAttached = 0;

			if (AudioSource1 == true) {
				AudioSource1.Pause ();
				AudioSource2.Play ();
			} else {
				AudioSource2.Play ();
			}
		}

		if (enemiesAttached == 0) {
			moveAmount = 50;
			renderer.color = new Color (255.0f, 255.0f, 255.0f, 1f);
		}

		if (enemiesAttached == 1) {
			moveAmount = 25;
			renderer.color = new Color (255.0f, 255.0f, 255.0f, 0.50f);

			stress += Time.deltaTime;
		}

		if (enemiesAttached == 2) {
			moveAmount = 10;
			renderer.color = new Color (0f, 255/2f, 0f, 0.50f);

			stress += Time.deltaTime * 2;
		}

		if (enemiesAttached == 3) {
			moveAmount = 5;
			renderer.color = new Color (0f, 255.0f, 0f, 0.25f);

			stress += Time.deltaTime * 4;
		}

		if (bot == true && stress > 0) {
			stress -= Time.deltaTime;
		}

		transform.position = moving;

//		if (top == true) {
//			player.transform.rotation = Quaternion.Euler (0, 0, 0);
//		}

//		if (bot == true) {
//			player.transform.rotation = Quaternion.Euler (0, 0, 180);
//		}

		if (stress >= 100 && Application.loadedLevel == 0) {
			Application.LoadLevel ("GameLose");
		}

		if (stress >= 100 && Application.loadedLevel == 2) {
			Application.LoadLevel ("GameLose1");
		}

		if (gameTime <= 0 && Application.loadedLevel == 0) {
			Application.LoadLevel ("GameLose");
		}

		if (gameTime <= 0 && Application.loadedLevel == 2) {
			Application.LoadLevel ("GameLose1");
		}

		Text stressMeter = stressText.GetComponent<Text>();
		stressMeter.text = "Stress: " + (int)stress;

		Text timeMeter = gameTimer.GetComponent<Text>();
		timeMeter.text = "Time: " + (int)gameTime;

		if (stress >= 90) {

			stressFlash += Time.deltaTime*5;


			if((int)stressFlash%2==1){
				stressMeter.color = new Color (1f, 0f, 0f);
			}

			if((int)stressFlash%2==0){
				stressMeter.color = new Color (1f, 1f, 1f);
			}

		} else {
			stressMeter.color = new Color (1f, 1f, 1f);
		}

	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "ground") {
			grounded = true;
			specialGrounded = false;
			topGrounded = false;
			botGrounded = false;
			airborn = false;
		}

		if (coll.gameObject.tag == "ground2") {
			specialGrounded = true;
			grounded = true;
			topGrounded = false;
			botGrounded = false;
			airborn = false;
		}

		if (coll.gameObject.tag == "ground3") {
			topGrounded = true;
			botGrounded = false;
			specialGrounded = false;
			grounded = false;
			airborn = false;
		}

		if (coll.gameObject.tag == "ground4") {
			topGrounded = false;
			botGrounded = true;
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

		if (enemiesAttached == 3) {
			runAnimation += Time.deltaTime;


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

		if (enemiesAttached == 3) {
			runAnimation += Time.deltaTime;


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
