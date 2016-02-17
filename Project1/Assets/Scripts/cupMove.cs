using UnityEngine;
using System.Collections;

public class cupMove : MonoBehaviour {

	public GameObject cup;

	public GameObject gameManager;

	public float moveSpeed = 10;
	public float yMax = 125;
	public float yMin = -105;
	public float amplitude = 1;
	public float frequency = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 moving = new Vector3 (transform.position.x,
			transform.position.y,
			transform.position.z);

		moving.y += moveSpeed * Time.deltaTime;

		moving.x = Mathf.Cos (moving.y * frequency) * amplitude;

		if (GameObject.Find ("gameManager").GetComponent<gameManager> ().even) {
			//change something back
		}

		if (GameObject.Find ("gameManager").GetComponent<gameManager> ().odd) {
			//change something
		}

		transform.position = moving;

//		if (moving.y > yMax) {
//			GameObject cup = Instantiate (Resources.Load ("Cup")) as GameObject;
//
//			cup.transform.position = new Vector3 (0, yMin, 0);
//		}
	
	}
}
