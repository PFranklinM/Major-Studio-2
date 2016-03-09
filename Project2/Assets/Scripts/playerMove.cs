using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerMove : MonoBehaviour {

	public GameObject exit;

	public GameObject treasureRemainingText;

	public GameObject ghostText;

	private float ghostCooldown;

	private bool ghostOnCooldown;

	public float moveAmount = 10f;

	private int remainingTreasure = 64;

	Rigidbody2D rb;

	public SpriteRenderer renderer;

//	List<GameObject> treasure = new List<GameObject>();

	// Use this for initialization
	void Start () {

		ghostOnCooldown = false;

		exit.SetActive(false);

		rb = GetComponent<Rigidbody2D>();

		renderer = GetComponent<SpriteRenderer>();
	
	}
	
	// Update is called once per frame
	void Update () {

		Text treasureText = treasureRemainingText.GetComponent<Text>();
		treasureText.text = "Remaining Treasure: " + remainingTreasure;

		Text cooldownText = ghostText.GetComponent<Text>();

		if (ghostOnCooldown == false) {
			cooldownText.text = "Ghost: Ready";
		} else {
			cooldownText.text = "Ghost: " + (int)ghostCooldown;
		}



		Vector3 moving = new Vector3 (transform.position.x,
			transform.position.y,
			transform.position.z);

		if (Input.GetKey (KeyCode.D)) {
			moving.x += moveAmount * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.A)) {
			moving.x -= moveAmount * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.W)) {
			moving.y += moveAmount * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.S)) {
			moving.y -= moveAmount * Time.deltaTime;
		}
	
		transform.position = moving;

		if (Input.GetKeyDown (KeyCode.Space) && ghostOnCooldown == false) {
			StartCoroutine(throughWalls());
		}

		if (moving.y > 21 ||
			moving.y < -21 ||
			moving.x > 30 ||
			moving.x < -30) {
			Application.LoadLevel ("Lose");
		}

		if (GameObject.Find ("Minotaur").GetComponent<minotaurMove> ().playerIsSmelled) {
			renderer.color = new Color (255.0f, 0.0f, 0.0f, 1f);
		} else {
			renderer.color = new Color (255.0f, 255.0f, 255.0f, 1f);
		}

		if (remainingTreasure == 0) {
			exit.SetActive (true);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "treasure") {
			remainingTreasure--;
		}

		if (coll.gameObject.tag == "stairs" && remainingTreasure == 0) {
			Application.LoadLevel ("Win");
		}

		if (coll.gameObject.tag == "minotaur") {
			Application.LoadLevel ("Lose");
		}
	}

	IEnumerator throughWalls(){
		float abilityCounter = 0.0f;

		while (abilityCounter < 0.5f) {
			abilityCounter += Time.deltaTime;

			rb.isKinematic = true;

			renderer.color = new Color (0.0f, 0.0f, 255.0f, 1f);

			yield return null;
		}
		rb.isKinematic = false;
		renderer.color = new Color (255.0f, 255.0f, 255.0f, 1f);

		StartCoroutine(cooldown());
	}

	IEnumerator cooldown(){
		ghostCooldown = 5;

		while (ghostCooldown > 0) {
			ghostCooldown -= Time.deltaTime;

			ghostOnCooldown = true;

			yield return null;
		}
		ghostOnCooldown = false;
	}
}
