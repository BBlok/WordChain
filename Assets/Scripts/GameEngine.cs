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
	public airBannerScript plane;
	public airBannerScript ufoBanner;
	public TowerChunk[] towerChunksToInstantiate;
	public float zValue = -3.0f;
	public int chunkCounter = 0;
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
        savedWordHistory = new List<string>(5);
        //savedWordHistory = new string[5];
        savedWordHistoryArr = new string[5];
        wordHistoryArray = new ArrayList();
        //wordHistoryArray.Insert(0, "Hello");
    }

    void Awake() {
		wordHistory = new List<string>();
		dictionary = new WordDictionary(textAsset);
		audio = GetComponent<AudioSource> ();
		hinter = GetComponent<WordHinter>();

		string w = dictionary.RandomWord();
		wordHistory.Add(w);
		GenerateTowerChunk(w);
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
		if (IsValidWord (word)) {
			CommitWordSubmission (word);
			window = !window;
		}
		
		else {
			TowerChunk chunk = GenerateTowerChunk(word);
			airBannerScript planeInstance;
			chunk.hasValidWord = false;
			chunk.transform.position = new Vector3 (chunk.transform.position.x - 5.0f, chunk.transform.position.y, chunk.transform.position.z);
			Debug.Log (ErrorMessage);
			if (Camera.main.transform.position.y >= 40.0f) {	//spawn UFO banner, else spawn plane
				planeInstance = Instantiate (ufoBanner, new Vector3 (-15.0f, Camera.main.transform.position.y + 1, zValue + 1), Quaternion.identity) as airBannerScript;
			}
			else
				planeInstance = Instantiate (plane, new Vector3 (-15.0f, Camera.main.transform.position.y + 1, zValue + 1), Quaternion.identity) as airBannerScript;
			planeInstance.SetWord(ErrorMessage);
		}
	}

	public void FocusOnInput() {
		wordInputField.Select();
		wordInputField.ActivateInputField();
	}
	
	public string LastWord() {
	    return wordHistory.Count > 0 ? wordHistory[wordHistory.Count - 1] : null;
	}

	public bool IsInHistory(string word) {
		return wordHistory.IndexOf(word) >= 0;
	}

/*  Private Members
 *  ========================================================================================*/
	private List<string> wordHistory;
	private WordDictionary dictionary;
	private string errorMessage;
	private WordHinter hinter;

/*  Private Methods
 *  ========================================================================================*/
	private bool IsValidWord(string word) {
	    string lastWord = LastWord();
		if (lastWord == null) {
			errorMessage = "That isn't \na word!";
			return dictionary.IsInDictionary (word);
		}
	    else {
			if (lastWord [lastWord.Length - 1] != word [0]) {
				errorMessage = "Your word \nshould \nbegin in " + lastWord [lastWord.Length - 1];
				return false;
			}
			else {
				if (IsInHistory(word)) {
					errorMessage = "You already \nused \nthat word!";
					return false;
				}
				else {
					errorMessage = "That isn't \na word!";
					return dictionary.IsInDictionary (word);
				}
			}
	    }
	}
	
	public void CommitWordSubmission(string word) {
	    wordHistory.Add(word);

        string wordNum;

        /*for(int i = 0; i < savedWordHistory.Count-1; i++)
        {
            wordNum = "WORD" + (i+1);
            PlayerPrefs.SetString(wordNum, (string)wordHistoryArray[i]);
        }*/

        if (wordHistoryArray.Count >= 12)
        {
            wordHistoryArray.RemoveAt(11);
            //wordHistoryArray.Insert(0, word);
            /*PlayerPrefs.SetString("WORD1", (string)wordHistoryArray[0]);
            PlayerPrefs.SetString("WORD2", (string)wordHistoryArray[1]);
            PlayerPrefs.SetString("WORD3", (string)wordHistoryArray[2]);
            PlayerPrefs.SetString("WORD4", (string)wordHistoryArray[3]);*/
            //PlayerPrefs.SetString("WORD5", (string)wordHistoryArray[4]);
        }
        wordHistoryArray.Insert(0, word);

        for (int i = 0; i < wordHistoryArray.Count; i++)
        {
            wordNum = "WORD" + (i + 1);
            PlayerPrefs.SetString(wordNum, (string)wordHistoryArray[i]);
        }

        GenerateTowerChunk(word);
	    wordInputField.text = "";
		hinter.Reset();
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
			//window = true;	
		} else if (selector >= 1 && selector < 2 && !window) {
			chunk = Instantiate (towerChunkToInstantiate2, new Vector3 (towerX, Camera.main.transform.position.y + 10, zValue), Quaternion.identity) as TowerChunk;
			//window = true;	
		} else if (selector >= 2 && selector < 3 && !window) {
			chunk = Instantiate (towerChunkToInstantiate3, new Vector3 (towerX, Camera.main.transform.position.y + 10, zValue), Quaternion.identity) as TowerChunk;
			//window = true;	
		} else if (selector >= 3 && selector < 4 && !window) {
			chunk = Instantiate (towerChunkToInstantiate4, new Vector3 (towerX, Camera.main.transform.position.y + 10, zValue), Quaternion.identity) as TowerChunk;
			//window = true;	
		} else if (selector >= 0 && selector < 1 && window) {
			chunk = Instantiate (towerChunkToInstantiate5, new Vector3 (towerX, Camera.main.transform.position.y + 10, zValue), Quaternion.identity) as TowerChunk;
			//window = false;	
		} else if (selector >= 1 && selector < 2 && window) {
			chunk = Instantiate (towerChunkToInstantiate7, new Vector3 (towerX, Camera.main.transform.position.y + 10, zValue), Quaternion.identity) as TowerChunk;
			//window = false;	
		} else if (selector >= 2 && selector < 3 && window) {
			chunk = Instantiate (towerChunkToInstantiate8, new Vector3 (towerX, Camera.main.transform.position.y + 10, zValue), Quaternion.identity) as TowerChunk;
			//window = false;	
		} else {
			chunk = Instantiate (towerChunkToInstantiate8, new Vector3 (towerX, Camera.main.transform.position.y + 10, zValue), Quaternion.identity) as TowerChunk;
			//window = false;
		}

		chunk.SetWord(word);
		return chunk;
	}
	

}
