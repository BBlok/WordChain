using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour {

    public InputField wordInputField;
	public TextAsset textAsset;
	public float towerX = 2.0f;

	public int winNumber = 50;

	public TowerChunk towerChunkToInstantiate;
	public TowerChunk towerChunkToInstantiate2;
	public TowerChunk towerChunkToInstantiate3;
	public TowerChunk towerChunkToInstantiate4;
	public TowerChunk towerChunkToInstantiate5;
	public TowerChunk towerChunkToInstantiate6;
	public TowerChunk towerChunkToInstantiate7;
	public TowerChunk towerChunkToInstantiate8;
	public TowerChunk towerBottom;
	public TowerChunk towerTop;

	public TowerChunk[] towerChunksToInstantiate;
    
	public float zValue = -3.0f;

	public int chunkCounter = 0;
	public bool window = false;

	private float selector;

	AudioSource audio;

/*  Unity API
 *  ========================================================================================*/
	void Start () {
	    wordHistory = new List<string>();
		dictionary = new WordDictionary(textAsset);
		audio = GetComponent<AudioSource> ();
	}

	void Awake() {
		//CommitWordSubmission ("trials");
	}

	void Update () {


		//chunkCounter = GameObject.FindGameObjectsWithTag("Tower").Length;
		chunkCounter = NumOfWords; // redundant, but I'm not sure where chunkCounter is being used

	    if(Input.GetButtonDown("SubmitWord")) {
	        SubmitWord();
			FocusOnInput();
		}

		if (wordInputField.text.Length <= 1 && wordHistory.Count > 0) {
			string lastWord = wordHistory [wordHistory.Count - 1];
			wordInputField.text = lastWord.Substring(lastWord.Length - 1);
		}
	}

/*  Access
 *  ========================================================================================*/
	public string ErrorMessage {
		get { return errorMessage; }
	}

	public int NumOfWords {
		get { return wordHistory.Count; }
	}

/*  Public Methods
 *  ========================================================================================*/
	public void SubmitWord() {
	    string word = wordInputField.text.ToLower();
	    Debug.Log("");
		if (IsValidWord (word))
			CommitWordSubmission(word);
		else {
			TowerChunk chunk = GenerateTowerChunk(word);
			chunk.hasValidWord = false;
			chunk.transform.position = new Vector3 (chunk.transform.position.x - 5, chunk.transform.position.y, chunk.transform.position.z);;
			Debug.Log (ErrorMessage);
		}
	}

	public void FocusOnInput() {
		wordInputField.Select();
		wordInputField.ActivateInputField();
	}
	
	public string LastWord() {
	    return wordHistory.Count > 0 ? wordHistory[wordHistory.Count - 1] : null;
	}

/*  Private Members
 *  ========================================================================================*/
	private List<string> wordHistory;
	private WordDictionary dictionary;
	private string errorMessage;

/*  Private Methods
 *  ========================================================================================*/
	private bool IsValidWord(string word) {
	    string lastWord = LastWord();
		if (lastWord == null) {
			errorMessage = "That isn't a word!";
			return dictionary.IsInDictionary (word);
		}
	    else {
			if (lastWord [lastWord.Length - 1] != word [0]) {
				errorMessage = "Your word should begin in " + lastWord [lastWord.Length - 1];
				return false;
			}
			else {
				if (wordHistory.IndexOf (word) >= 0) {
					errorMessage = "You already used that word!";
					return false;
				}
				else {
					errorMessage = "That isn't a word!";
					return dictionary.IsInDictionary (word);
				}
			}
	    }
	}
	
	private void CommitWordSubmission(string word) {
	    wordHistory.Add(word);
		GenerateTowerChunk(word);
	    wordInputField.text = "";
	}

	private TowerChunk GenerateTowerChunk(string word) {
		
		TowerChunk chunk;
		selector = Random.Range (0.0f, 4.0f);

		if (chunkCounter == 0) {
			chunk = Instantiate (towerBottom, new Vector3 (towerX, Camera.main.transform.position.y + 10, zValue), Quaternion.identity) as TowerChunk;
			chunk.frozen = true;
		}
		else if (chunkCounter == winNumber)
			chunk = Instantiate (towerTop, new Vector3 (towerX, Camera.main.transform.position.y + 10, zValue), Quaternion.identity) as TowerChunk;
		else if (selector >= 0 && selector < 1 && !window) {
			chunk = Instantiate (towerChunkToInstantiate, new Vector3 (towerX, Camera.main.transform.position.y + 10, zValue), Quaternion.identity) as TowerChunk;
			window = true;	
		} else if (selector >= 1 && selector < 2 && !window) {
			chunk = Instantiate (towerChunkToInstantiate2, new Vector3 (towerX, Camera.main.transform.position.y + 10, zValue), Quaternion.identity) as TowerChunk;
			window = true;	
		} else if (selector >= 2 && selector < 3 && !window) {
			chunk = Instantiate (towerChunkToInstantiate3, new Vector3 (towerX, Camera.main.transform.position.y + 10, zValue), Quaternion.identity) as TowerChunk;
			window = true;	
		} else if (selector >= 3 && selector < 4 && !window) {
			chunk = Instantiate (towerChunkToInstantiate4, new Vector3 (towerX, Camera.main.transform.position.y + 10, zValue), Quaternion.identity) as TowerChunk;
			window = true;	
		} else if (selector >= 0 && selector < 1 && window) {
			chunk = Instantiate (towerChunkToInstantiate5, new Vector3 (towerX, Camera.main.transform.position.y + 10, zValue), Quaternion.identity) as TowerChunk;
			window = false;	
		} else if (selector >= 1 && selector < 2 && window) {
			chunk = Instantiate (towerChunkToInstantiate7, new Vector3 (towerX, Camera.main.transform.position.y + 10, zValue), Quaternion.identity) as TowerChunk;
			window = false;	
		} else if (selector >= 2 && selector < 3 && window) {
			chunk = Instantiate (towerChunkToInstantiate8, new Vector3 (towerX, Camera.main.transform.position.y + 10, zValue), Quaternion.identity) as TowerChunk;
			window = false;	
		} else {
			chunk = Instantiate (towerChunkToInstantiate8, new Vector3 (towerX, Camera.main.transform.position.y + 10, zValue), Quaternion.identity) as TowerChunk;
			window = false;
		}

		chunk.SetWord(word);
		return chunk;
	}
	

}
