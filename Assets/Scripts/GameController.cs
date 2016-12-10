using UnityEngine;
using System.Collections;

// reference to the UI namespace
using UnityEngine.UI;

// reference to manage my scenes
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	// PRIVATE INSTANCE VARIABLES ++++++++++++++++++
	private int _livesValue;
    private int _scoreValue;
    
    [Header("UI Objects")]
	public Text LivesLabel;
	public Text ScoreLabel;
    public Text GameOverLabel;
    public Text FinalScoreLabel;
    public Text youWon;
    public Button RestartButton;
    public Button RestartButton2;
    public GameObject Hero;

	// PUBLIC PROPERTIES +++++++++++++++++++++++++++
	public int LivesValue {
		get {
			return this._livesValue;
		}

		set {
			this._livesValue = value;
			if (this._livesValue <= 0) {
                this.LivesLabel.text = "Lives: " + 0;
                this._endGame();
			} else {
				this.LivesLabel.text = "Lives: " + this._livesValue;
			}
		}
	}

	public int ScoreValue {
		get {
			return this._scoreValue;
		}

		set {
			this._scoreValue = value;
			this.ScoreLabel.text = "Score: " + this._scoreValue;
		}
	}

	// Use this for initialization
	void Start () {
		this.LivesValue = 5;
		this.ScoreValue = PlayerPrefs.GetInt("HiScore");
        this.GameOverLabel.gameObject.SetActive(false);
        this.FinalScoreLabel.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(false);
        this.RestartButton2.gameObject.SetActive(false);
        this.youWon.gameObject.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
	}

    private void _endGame(){
        this.GameOverLabel.gameObject.SetActive(true);
        this.FinalScoreLabel.text = "Final Score: " + this.ScoreValue;
        this.FinalScoreLabel.gameObject.SetActive(true);
        this.RestartButton.gameObject.SetActive(true);
        this.RestartButton2.gameObject.SetActive(true);
        this.Hero.SetActive(false);
        this._scoreValue = 0;
        PlayerPrefs.SetInt("HiScore", _scoreValue);
    }

    public void _wonGame()
    {
        this.youWon.gameObject.SetActive(true);
        this.FinalScoreLabel.text = "Final Score: " + this.ScoreValue;
        this.FinalScoreLabel.gameObject.SetActive(true);
        this.RestartButton.gameObject.SetActive(true);
        this.RestartButton2.gameObject.SetActive(true);
        this.Hero.SetActive(false);
    }

    public void _level2()
    {
        PlayerPrefs.SetInt("HiScore", _scoreValue);
        SceneManager.LoadScene("Level_2");
    }

    public void _level3()
    {
        PlayerPrefs.SetInt("HiScore", _scoreValue);
        SceneManager.LoadScene("Level_3");
    }

    public void RestartButton_Click()
    {
        this._scoreValue = 0;
        PlayerPrefs.SetInt("HiScore", _scoreValue);
        SceneManager.LoadScene("MainScene");   
    }
    public void RestartLevel2Button_Click()
    {
        this._scoreValue = 0;
        PlayerPrefs.SetInt("HiScore", _scoreValue);
        SceneManager.LoadScene("Level_2");
    }

}
