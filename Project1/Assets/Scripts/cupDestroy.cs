using UnityEngine;
using System.Collections;

public class cupDestroy : MonoBehaviour {

	public GameObject cup;

	public float yMax = 125;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 moving = new Vector3 (transform.position.x,
			transform.position.y,
			transform.position.z);

		if (moving.y > yMax) {
			Destroy (cup);
		}
	
	}
}
