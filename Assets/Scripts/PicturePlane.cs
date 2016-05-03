using UnityEngine;
using System;
using System.Collections;

public class PicturePlane : MonoBehaviour {


	private SpriteRenderer renderer;
	private GameObject picture;
	// Use this for initialization
	void Awake () {
		picture = transform.Find("Picture").gameObject;
		renderer = picture.GetComponent<SpriteRenderer>();
	}
	
	public bool LoadImage(string word) {
		try {
			renderer.sprite = Resources.Load<Sprite>("Sprites/" + word);
			picture.transform.localScale = new Vector3(0.4f / renderer.sprite.bounds.max.x, 0.4f / renderer.sprite.bounds.max.y, 1.0f);
			return true;
		}
		catch(Exception err) {
			Debug.Log (err);
			return false;
		}
	}
}
