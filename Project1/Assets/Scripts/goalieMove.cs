using UnityEngine;
using System.Collections;

public class goalieMove : MonoBehaviour {

	public GameObject goalie;

	public int xMin = -90;

	public int xMax = 90;

	public float moveAmount = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 moving = new Vector3 (transform.position.x,
			transform.position.y,
			transform.position.z);

		if (Input.GetKey("left")) {
			moving.x -= moveAmount * Time.deltaTime;
		}

		if (Input.GetKey("right")) {
			moving.x += moveAmount * Time.deltaTime;
		}

		if (moving.x > xMax) {
			moving.x = xMin;
		}

		if (moving.x < xMin){
			moving.x = xMax;
		}

		transform.position = moving;
	}
}
