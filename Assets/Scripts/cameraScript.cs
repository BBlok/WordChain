using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

	public int newCount = 0;
	public int prevCount = 0;
	public Vector3 startPoint;
	public Vector3 endPoint;
	public bool moving = false;
	public float move = 3.0f;
	public int period = 3;

	public Rigidbody2D marker;


	public float smooth = 1.5f;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		//Camera.current.transform.position(new Vector3 (0.0f,5.0f,0.0f));
		newCount = GameObject.FindGameObjectsWithTag("Tower").Length;


			
			//this.transform.position = endpoint;


		if (newCount - prevCount == period) {


			if (this.transform.position.y <= marker.transform.position.y) {
				startPoint = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
				endPoint = new Vector3 (this.transform.position.x, this.transform.position.y + 3.0f, this.transform.position.z);
				this.transform.position = Vector3.Lerp (startPoint, endPoint, smooth * Time.deltaTime);
			} else {
				prevCount = newCount;
				marker.transform.position = new Vector3 (marker.transform.position.x, marker.transform.position.y + move, marker.transform.position.z);
			}


			//moving = true;

			//if (this.transform.position.y >= endPoint.y) {
			//	prevCount = newCount;
			//	moving = false;
			//}




				//prevCount = newCount;
		}

		if (moving == true)
			this.transform.position = endPoint;
	}
}
