using UnityEngine;
using System.Collections;

public class TowerChunk : MonoBehaviour {
	private static string TEXT_OBJECT_NAME = "Text";
	public bool hasValidWord = true;

/*  Unity API
 *  ========================================================================================*/
	void Start () {
		frozen = false;
	}

	void Awake() {
		this.text = transform.Find(TEXT_OBJECT_NAME).gameObject.GetComponent<TextMesh>();
		this.spriteRenderer = GetComponent<SpriteRenderer>();
		this.rb = GetComponent<Rigidbody2D>();
		text.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -10)
			DestroyObject(gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.gameObject.tag == "Tower" && !frozen && hasValidWord) {
			frozen = true;
			rb.constraints = RigidbodyConstraints2D.FreezeAll;
		}
	}

	void OnCollisionStay2D(Collision2D collision) {
		if (collision.collider.gameObject.tag == "Tower" && !frozen && !hasValidWord) {
			GetComponent<BoxCollider2D> ().enabled = false;
		}
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
	private Rigidbody2D rb;
	private bool frozen;
}
