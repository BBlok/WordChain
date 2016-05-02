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

	public string RandomWord() {
		return wordList[UnityEngine.Random.Range(0, wordList.Count)];
	}

	public string RandomWordThatStartsWith(string c) {
		List<string> words = new List<string>();
		foreach(string word in wordList) {
			if(word.Length > 0 && word[0] == c[0])
				words.Add (word);
		}
		if(words.Count > 0)
			return words[UnityEngine.Random.Range(0, words.Count)];
		else
			return "";
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
