using UnityEngine;
using System.Collections;

public class planeScript : MonoBehaviour {

	public Rigidbody2D rb;
	public float xSpeed = 2.0f;
	public float ySpeed = 0;
	public float flightdistance = 100f;

	private Vector3 currPos;
	private Vector3 spawnPoint;

	private float initialX;
	private float initialY;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();

		initialX = rb.position.x;
		initialY = rb.position.y;


	}
	
	// Update is called once per frame
	void Update () {
		if (rb.position.x <= initialX + flightdistance)
			rb.velocity = new Vector3 (xSpeed, ySpeed, 0);
		else
			transform.position = new Vector3 (initialX, initialY, 0);
			
		
	}
}
