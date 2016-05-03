using UnityEngine;
using System.Collections;

public class airBannerScript : MonoBehaviour {
	private static string TEXT_OBJECT_NAME = "Text";
	public bool hasValidWord = true;

	/*  Unity API
 *  ========================================================================================*/
	void Start () {

	}

	void Awake() {
		this.text = transform.Find(TEXT_OBJECT_NAME).gameObject.GetComponent<TextMesh>();
		this.spriteRenderer = GetComponent<SpriteRenderer>();
		this.rb = GetComponent<Rigidbody2D>();
		this.rectransform = GetComponent<RectTransform> ();
		text.text = "";
	}

	// Update is called once per frame
	void Update () {
		if ( rectransform.position.x >= GetComponent<planeScript>().flightdistance - 20.0f)
			DestroyObject(gameObject);
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
	private RectTransform rectransform;
	private Rigidbody2D rb;
}
