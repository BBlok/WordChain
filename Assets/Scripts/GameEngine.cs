using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour {

    public InputField wordInputField;
    
	// Use this for initialization
	void Start () {
	    wordHistory = new List<string>();
	}
	
	// Update is called once per frame
	void Update () {
	//  Check if the Enter button is pressed (when submitted)
	//  When it is, check the input field againmst the word history (matches the last word and not in the rest of the history)
	//  if valid then we push into word history, make a block fall, and clear the field'
	    if(Input.GetButtonDown("SubmitWord"))
	        SubmitWord();
	}
	
	public void SubmitWord() {
	    string word = wordInputField.text.ToLower();
	    Debug.Log("");
	    if(IsValidWord(word))
	        CommitWordSubmission(word);
	    else
	        Debug.Log("INVALID WORD");
	}
	
	public string LastWord() {
	    return wordHistory.Count > 0 ? wordHistory[wordHistory.Count - 1] : null;
	}
	
	private List<string> wordHistory;
	
//  @TODO: We will need to implement a dictionary here at some point
	private bool IsValidWord(string word) {
	    string lastWord = LastWord();
	    if(lastWord == null)
	        return true;
	    else {
	        if(lastWord[lastWord.Length - 1] != word[0])
	            return false;
	        else
	            return wordHistory.IndexOf(word) < 0 && IsInDictionary(word);
	    }
	}
	
	private bool IsInDictionary(string word) {
	    return true;
	}
	
	private void CommitWordSubmission(string word) {
	    wordHistory.Add(word);
	//  Do the animation
	    wordInputField.text = "";
	}
}
