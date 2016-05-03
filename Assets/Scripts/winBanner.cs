using UnityEngine;
using System.Collections;

public class winBanner : MonoBehaviour {

	public float counter;
	public float blinkFrequency = 0.5f;
	private AudioSource sonido;
	private bool played = false;

	// Use this for initialization
	void Awake () {
		sonido = GetComponent<AudioSource>();
		sonido.loop = false;
		sonido.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;

		if (counter > blinkFrequency) {

			counter = 0.0f;
			GetComponent<MeshRenderer> ().enabled = !GetComponent<MeshRenderer> ().enabled;
		}

	}

}

