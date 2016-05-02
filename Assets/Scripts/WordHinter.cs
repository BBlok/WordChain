using UnityEngine;
using System.Collections;

public class WordHinter : MonoBehaviour {

	public TextAsset textAsset;
	public PicturePlane planeToInstantiate;

/*  Unity API
 *  ========================================================================================*/
	void Start () {
		
	}

	void Awake() {
		dictionary = new WordDictionary(textAsset);
		engine = GetComponent<GameEngine>();
		Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		++counter;
		if(counter >= 600) {
			SuggestWord(engine.LastWord().Substring(0, 1));
			counter = -999999999;
		}
	}

/*  Public Methods
 *  ========================================================================================*/
	public string SuggestWord(string letter) {
		string word = dictionary.RandomWordThatStartsWith(letter);
		Debug.Log (word);
		PicturePlane p = Instantiate(planeToInstantiate, new Vector3(-15, Camera.main.transform.position.y, 0), Quaternion.identity) as PicturePlane;
		if(!p.LoadImage(word)) {
			DestroyObject(p.gameObject);
			Debug.Log ("FAIL");
		}
		return word;
	}

	public void Reset() {
		counter = 0;
	}

/*  Private Members
 *  ========================================================================================*/
	private WordDictionary dictionary;
	private GameEngine engine;
	private int counter;
}
