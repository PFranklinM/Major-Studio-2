using UnityEngine;
using System.Collections;

public class musicViz : MonoBehaviour {
	
	public AudioSource music;

	public int detail = 500;
	public float amplitude = 0.1f;

	void Start() {
		
	}

	void Update() {

		Vector3 moving = new Vector3 (transform.position.x,
			transform.position.y,
			transform.position.z);

		float[] info = new float[detail];

		AudioListener.GetOutputData(info, 0); 

		float packagedData = 0.0f;

			for(int i = 0; i < info.Length; i++){
			
				packagedData += System.Math.Abs(info[i]);
			}

		moving.x = packagedData * amplitude;

		moving.y = packagedData * amplitude;

		transform.localScale = moving;

		if (!GameObject.Find ("Ball").GetComponent<ballWinCondition> ().isAlive) {
			music.Stop ();
		}
	}
}