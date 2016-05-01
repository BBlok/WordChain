using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WordHistory : MonoBehaviour
{

    public Text word1;
    public Text word2;
    public Text word3;
    public Text word4;
    public Text word5;
    public Text word6;
    public Text word7;
    public Text word8;
    public Text word9;
    public Text word10;
    public Text word11;
    public Text word12;

    // Use this for initialization
    void Start()
    {
        word1.text = "1: " + PlayerPrefs.GetString("WORD1");
        word2.text = "2: " + PlayerPrefs.GetString("WORD2");
        word3.text = "3: " + PlayerPrefs.GetString("WORD3");
        word4.text = "4: " + PlayerPrefs.GetString("WORD4");
        word5.text = "5: " + PlayerPrefs.GetString("WORD5");
        word6.text = "6: " + PlayerPrefs.GetString("WORD6");
        word7.text = "7: " + PlayerPrefs.GetString("WORD7");
        word8.text = "8: " + PlayerPrefs.GetString("WORD8");
        word9.text = "9: " + PlayerPrefs.GetString("WORD9");
        word10.text = "10: " + PlayerPrefs.GetString("WORD10");
        word11.text = "11: " + PlayerPrefs.GetString("WORD11");
        word12.text = "12: " + PlayerPrefs.GetString("WORD12");

    }

    // Update is called once per frame
    void Update()
    {

    }
}
