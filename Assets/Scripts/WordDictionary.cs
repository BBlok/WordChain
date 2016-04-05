using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class WordDictionary {

/*  Constructor
 *  ========================================================================================*/
	public WordDictionary(TextAsset textAsset) {
		this.textAsset = textAsset;
		this.wordList = new List<string>();
		buildWordList();
	}

/*  Public Methods
 *  ========================================================================================*/
	public bool IsInDictionary(string word) {
		return wordList.IndexOf(word) >= 0;
	}

/*  Private Members
 *  ========================================================================================*/
	private TextAsset textAsset;
	private List<string> wordList;

/*  Private Methods
 *  ========================================================================================*/
	private void buildWordList() {
		string[] words = textAsset.text.Split(new string[] { "\n", "\r\n"}, StringSplitOptions.None );
		foreach(string word in words)
			wordList.Add(word.Trim().ToLower());
	}
}
