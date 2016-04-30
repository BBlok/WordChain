using UnityEngine;
using System.Collections;

public class spinningStar : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed = 5.0f;

	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.MoveRotation (rb.rotation + speed * Time.fixedDeltaTime);
		
	}
}
