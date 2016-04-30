using UnityEngine;
using System.Collections;

public class nubeScript : MonoBehaviour {

	public float distanceScroll = 3.0f;
	public float speed = 0.23f;


	private Vector3 startPos; 
	private Vector3 endPos; 


	// Use this for initialization
	void Start () {

		startPos = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
		endPos = new Vector3(this.transform.position.x + distanceScroll, this.transform.position.y, this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.position = new Vector3(Mathf.PingPong(Time.time * speed, distanceScroll )+ startPos.x ,this.transform.position.y, this.transform.position.z);

	}
}
