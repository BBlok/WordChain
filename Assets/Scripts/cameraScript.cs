using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

	private int newCount = 0;
	private int prevCount = 0;
	private Vector3 startPoint;
	private Vector3 endPoint;
	private bool moving = false;


	public float smooth = 1.5f;
	public float moveBy = 3.0f;
	public int frequency = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Camera.current.transform.position(new Vector3 (0.0f,5.0f,0.0f));
		newCount = GameObject.FindGameObjectsWithTag("Tower").Length;



		if (newCount - prevCount == frequency) {

			//if (moving == false) {
				//startPoint = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
				//endPoint = new Vector3 (this.transform.position.x, this.transform.position.y + 3.0f, this.transform.position.z);
			//}

			//moving = true;

			//if (this.transform.position.y >= endPoint.y) {
			//	prevCount = newCount;
			//	moving = false;
			//}
				
				//this.transform.position = Vector3.Lerp (startPoint, endPoint, smooth * Time.deltaTime);
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + moveBy, this.transform.position.z);
			prevCount = newCount;




				//prevCount = newCount;
		}
	}
}
