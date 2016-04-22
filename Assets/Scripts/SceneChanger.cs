using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToWordHistory()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToAbout()
    {
        SceneManager.LoadScene(3);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
