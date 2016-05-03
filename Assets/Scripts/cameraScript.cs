using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

	public int newCount = 0;
	public int prevCount = 0;
	public Vector3 startPoint;
	public Vector3 endPoint;
	public bool moving = false;
	public float move = 3.0f;
	public float moveCorrector = 3.0f;
	public int period = 3;
	public int moduloCorrector = 6;
	public Rigidbody2D marker;

	public float smooth = 1.5f;

	public int winNumber = 48;
	public bool winCondition = false;


	private AudioSource sonido;
	public AudioClip winClip;
	public AudioClip music;

	public GameEngine engine;


	// Use this for initialization
	void Start () {

		sonido = GetComponent<AudioSource>();

		//sonido.clip = winClip;
		//sonido.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		//Camera.current.transform.position(new Vector3 (0.0f,5.0f,0.0f));
		//newCount = GameObject.FindGameObjectsWithTag("Tower").Length;
		newCount = engine.NumOfWords;

		if (newCount == winNumber) {
			winCondition = true;

		}

		if (winCondition == true) {

			if (sonido.clip != winClip) {
				sonido.clip = winClip;
				sonido.loop = false;
				sonido.Play ();
			}
			Debug.Log("YOU WIN!");
		}
			
		if (newCount - prevCount == period && winCondition == false) {

		
			if (this.transform.position.y <= marker.transform.position.y) {

				//leave these points alone!
				startPoint = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
				endPoint = new Vector3 (this.transform.position.x, this.transform.position.y + move + moveCorrector, this.transform.position.z);

				this.transform.position = Vector3.Lerp (startPoint, endPoint, smooth * Time.deltaTime);
			} else {
				
				if (newCount % moduloCorrector == 0) {
					marker.transform.position = new Vector3 (marker.transform.position.x, marker.transform.position.y + move + moveCorrector, marker.transform.position.z);
					Debug.Log ("correcting shit");
				}
				else
					marker.transform.position = new Vector3 (marker.transform.position.x, marker.transform.position.y + move, marker.transform.position.z);

				prevCount = newCount;
			}


		}
			
	}
}
