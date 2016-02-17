using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public GameObject TimeText;

	float Stopwatch = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		timerKeep ();
	
	}

	void timerKeep (){

		if (GameObject.Find ("Ball").GetComponent<ballWinCondition> ().isAlive) {
			Stopwatch += Time.deltaTime;
		}


		Text text = TimeText.GetComponent<Text>();
		text.text = "" + (int)Stopwatch;
	}

}
