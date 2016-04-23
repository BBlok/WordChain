using UnityEngine;
using System.Collections;

public class TowerChunk : MonoBehaviour {
	private static string TEXT_OBJECT_NAME = "Text";

/*  Unity API
 *  ========================================================================================*/
	void Start () {

	}

	void Awake() {
		this.text = transform.Find(TEXT_OBJECT_NAME).gameObject.GetComponent<TextMesh>();
		this.spriteRenderer = GetComponent<SpriteRenderer>();
		text.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

/*  Public Methods
 *  ========================================================================================*/
	public void SetWord(string word) {
		this.text.text = word;
	}

	public string Word() {
		return text.text;
	}

/*  Private Members
 *  ========================================================================================*/
	private TextMesh text;
	private SpriteRenderer spriteRenderer;
}
