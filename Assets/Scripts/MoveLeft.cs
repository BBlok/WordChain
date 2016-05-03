using UnityEngine;
using System.Collections;

//  THIS SCRIPT ACTUALLY GOES TO THE RIGHT.  SORRY.	
public class MoveLeft : MonoBehaviour {

	public float vel = 5.0f;

	void Awake() {
		GetComponent<Rigidbody2D>().velocity = new Vector3(vel, 0, 0);
	}

	void FixedUpdate() {
		if(transform.position.x > 100)
			Destroy (gameObject);
	}

}
