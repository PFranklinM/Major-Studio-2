using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	public float yMin = -105;

	int invokeCounter = 0;

	public bool even;
	public bool odd;

	// Use this for initialization
	void Start () {

		Invoke ("spawnNewCup", 1.5f);
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	void spawnNewCup(){

		GameObject cup = Instantiate (Resources.Load ("Cup")) as GameObject;

		cup.transform.position = new Vector3 (0, yMin, 0);

		invokeCounter++;

		if (invokeCounter % 2 == 0) { //is even
			even = true;
			odd = false;
		}

		if (invokeCounter % 2 == 1) { //is odd
			even = false;
			odd = true;
		}

		Invoke ("spawnNewCup", Random.Range(2.5f, 8.5f));
	}
}
