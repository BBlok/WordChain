using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
//using System;

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
    
	public int chunkCounter;
	public bool window = false;

	private float selector;

	AudioSource audio;

    //public PlayerPrefsX savedWordHistory;
    public List<string> savedWordHistory;
    //public string[] savedWordHistory;
    public string[] savedWordHistoryArr;
    public ArrayList wordHistoryArray;

    /*  Unity API
     *  ========================================================================================*/
    void Start () {
	    wordHistory = new List<string>();
		dictionary = new WordDictionary(textAsset);
		audio = GetComponent<AudioSource> ();
        savedWordHistory = new List<string>(5);
        //savedWordHistory = new string[5];
        savedWordHistoryArr = new string[5];
        //wordHistoryArray = new ArrayList;
        //wordHistoryArray.Insert(0, "Hello");

    }

	void Update () {


		chunkCounter = GameObject.FindGameObjectsWithTag("Tower").Length;


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
        //if(savedWordHistory.)
        //savedWordHistory.Add(word);
        //savedWordHistory.ToArray();
        if (wordHistoryArray.Count == 5)
        {
            wordHistoryArray.RemoveAt(4);
            //wordHistoryArray.Insert(0, word);
        }
        wordHistoryArray.Insert(0, word);
        PlayerPrefs.SetString("WORD1", (string)wordHistoryArray[0]);
        PlayerPrefs.SetString("WORD2", (string)wordHistoryArray[1]);
        PlayerPrefs.SetString("WORD3", (string)wordHistoryArray[2]);
        PlayerPrefs.SetString("WORD4", (string)wordHistoryArray[3]);
        PlayerPrefs.SetString("WORD5", (string)wordHistoryArray[4]);
        GenerateTowerChunk(word);
	    wordInputField.text = "";
	}

	private TowerChunk GenerateTowerChunk(string word) {
		
		TowerChunk chunk;
		selector = Random.Range (0.0f, 4.0f);

		if (chunkCounter == 0)
			chunk = Instantiate (towerBottom, new Vector3 (towerX, Camera.main.transform.position.y + 10, 0), Quaternion.identity) as TowerChunk;
		else if (chunkCounter == winNumber)
			chunk = Instantiate (towerTop, new Vector3 (towerX, Camera.main.transform.position.y + 10, 0), Quaternion.identity) as TowerChunk;
		else if (selector >= 0 && selector < 1 && !window) {
			chunk = Instantiate (towerChunkToInstantiate, new Vector3 (towerX, Camera.main.transform.position.y + 10, 0), Quaternion.identity) as TowerChunk;
			window = true;	
		} else if (selector >= 1 && selector < 2 && !window) {
			chunk = Instantiate (towerChunkToInstantiate2, new Vector3 (towerX, Camera.main.transform.position.y + 10, 0), Quaternion.identity) as TowerChunk;
			window = true;	
		} else if (selector >= 2 && selector < 3 && !window) {
			chunk = Instantiate (towerChunkToInstantiate3, new Vector3 (towerX, Camera.main.transform.position.y + 10, 0), Quaternion.identity) as TowerChunk;
			window = true;	
		} else if (selector >= 3 && selector < 4 && !window) {
			chunk = Instantiate (towerChunkToInstantiate4, new Vector3 (towerX, Camera.main.transform.position.y + 10, 0), Quaternion.identity) as TowerChunk;
			window = true;	
		} else if (selector >= 0 && selector < 1 && window) {
			chunk = Instantiate (towerChunkToInstantiate5, new Vector3 (towerX, Camera.main.transform.position.y + 10, 0), Quaternion.identity) as TowerChunk;
			window = false;	
		} else if (selector >= 1 && selector < 2 && window) {
			chunk = Instantiate (towerChunkToInstantiate7, new Vector3 (towerX, Camera.main.transform.position.y + 10, 0), Quaternion.identity) as TowerChunk;
			window = false;	
		} else if (selector >= 2 && selector < 3 && window) {
			chunk = Instantiate (towerChunkToInstantiate8, new Vector3 (towerX, Camera.main.transform.position.y + 10, 0), Quaternion.identity) as TowerChunk;
			window = false;	
		} else {
			chunk = Instantiate (towerChunkToInstantiate8, new Vector3 (towerX, Camera.main.transform.position.y + 10, 0), Quaternion.identity) as TowerChunk;
			window = false;
		}

		chunk.SetWord(word);
		return chunk;
	}
	

}
