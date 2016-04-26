using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour {

    public InputField wordInputField;
	public TextAsset textAsset;
	public float towerX = 2.0f;

	public TowerChunk towerChunkToInstantiate;
	public TowerChunk[] towerChunksToInstantiate;
    
/*  Unity API
 *  ========================================================================================*/
	void Start () {
	    wordHistory = new List<string>();
		dictionary = new WordDictionary(textAsset);
	}

	void Update () {
	    if(Input.GetButtonDown("SubmitWord")) {
	        SubmitWord();
			FocusOnInput();
		}

		if (wordInputField.text.Length <= 1 && wordHistory.Count > 0) {
			string lastWord = wordHistory [wordHistory.Count - 1];
			wordInputField.text = lastWord.Substring(lastWord.Length - 1);
		}
	}

/*  Public Methods
 *  ========================================================================================*/
	public void SubmitWord() {
	    string word = wordInputField.text.ToLower();
	    Debug.Log("");
	    if(IsValidWord(word))
	        CommitWordSubmission(word);
	    else
	        Debug.Log("INVALID WORD");
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

/*  Private Methods
 *  ========================================================================================*/
	private bool IsValidWord(string word) {
	    string lastWord = LastWord();
	    if(lastWord == null)
	        return true;
	    else {
	        if(lastWord[lastWord.Length - 1] != word[0])
	            return false;
	        else
	            return wordHistory.IndexOf(word) < 0 && dictionary.IsInDictionary(word);
	    }
	}
	
	private void CommitWordSubmission(string word) {
	    wordHistory.Add(word);
		GenerateTowerChunk(word);
	    wordInputField.text = "";
	}

	private TowerChunk GenerateTowerChunk(string word) {
		TowerChunk chunk = Instantiate (towerChunkToInstantiate, new Vector3 (towerX, Camera.main.transform.position.y + 10, 0), Quaternion.identity) as TowerChunk;
	//  TowerChunk chunk = Instantiate(towerChunksToInstantiate[Random.Range(0, towerChunksToInstantiate.Length)], new Vector3(towerX, Camera.main.transform.position.y + 10, 0), Quaternion.identity) as TowerChunk;
		chunk.SetWord(word);
		return chunk;
	}
}
