using UnityEngine;
using System.Collections;

// reference to the UI namespace
using UnityEngine.UI;

// reference to manage my scenes
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour {
	// PRIVATE INSTANCE VARIABLES ++++++++++++++++++
	private int _livesValue;
    private int _scoreValue;
    
    [Header("UI Objects")]

    public Button StartButton;
    


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	
         

    public void StartButton_Click()
    {
        this._scoreValue = 0;
        PlayerPrefs.SetInt("HiScore", _scoreValue);
        SceneManager.LoadScene("MainScene");   
    }
    

}
