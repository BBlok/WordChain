using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestTextInput : MonoBehaviour {

	private InputField inputTextbox;

	// Use this for initialization
	void Start () {
		inputTextbox = GetComponent<InputField> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (inputTextbox.text);
	
	}
}
