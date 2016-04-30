using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WordHistory : MonoBehaviour {

    public Text word1;
    public Text word2;
    public Text word3;

    // Use this for initialization
    void Start () {
        word1.text = PlayerPrefs.GetString("WORD1");
        word2.text = PlayerPrefs.GetString("WORD2");
        word3.text = PlayerPrefs.GetString("WORD3");

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
