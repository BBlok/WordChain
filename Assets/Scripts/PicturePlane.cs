using UnityEngine;
using System;
using System.Collections;

public class PicturePlane : MonoBehaviour {


	private SpriteRenderer renderer;
	// Use this for initialization
	void Start () {
		renderer = transform.Find ("Picture").GetComponent<SpriteRenderer>();
	}
	
	public bool LoadImage(string word) {
		try {
			renderer.sprite = Resources.Load<Sprite>("Sprites/" + word + ".jpg");
			return true;
		}
		catch(Exception err) {
			return false;
		}
	}
}
