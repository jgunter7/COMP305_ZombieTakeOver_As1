using UnityEngine;
using System.Collections;

// reference to the UI namespace
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    [Header("UI Labels")]
    public Text LivesLabel;
    public Text ScoreLabel;
    public Text GameOverLabel;
    public Text FinalScoreLabel;
    public Button RestartButton;

    [Header("Game Objects")]
    public GameObject PlayerShip;
    public GameObject EnemyShip1;
    public GameObject EnemyShip2;
    public GameObject EnemyPlane;


    private int _livesValue;
    private int _scoreValue;
    private AudioSource _endGameSound;

    public int LivesValue {
        get {
            return this._livesValue;
        }

         set {
            this._livesValue = value;
            if (this._livesValue == 0) {
                this._endGame();
            } else {
                this.LivesLabel.text = "LIVES: " + this._livesValue;
            }
        }
    }

    public int ScoreValue {
        get {
            return this._scoreValue;
        }

        set {
            this._scoreValue = value;
            this.ScoreLabel.text = "SCORE: " + this._scoreValue;
        }
    }

    // Use this for initialization
    void Start () {
        // init the scoreboard UI components with starting values
        this.ScoreValue = 0;
        this.LivesValue = 5;
        this.GameOverLabel.gameObject.SetActive(false); // initially hide the gameover label.
        this.FinalScoreLabel.gameObject.SetActive(false); //hidden initially	
        this.RestartButton.gameObject.SetActive(false);
        this._endGameSound = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void _endGame() {

        this.GameOverLabel.gameObject.SetActive(true); // unhide the gameover label.
        this.FinalScoreLabel.text = "FINAL SCORE: " + this._scoreValue;
        this.FinalScoreLabel.gameObject.SetActive(true);
        this.RestartButton.gameObject.SetActive(true);
        this.LivesLabel.gameObject.SetActive(false); // hide live sobject - no longer needed;
        this.ScoreLabel.gameObject.SetActive(false); //hide

        this.PlayerShip.gameObject.SetActive(false);
        if (this.EnemyShip1 != null && this.EnemyShip1.gameObject != null) {
            this.EnemyShip1.gameObject.SetActive(false);
        } 
        if (this.EnemyShip2 != null && this.EnemyShip2.gameObject != null) {
            this.EnemyShip2.gameObject.SetActive(false);
        }
        if (this.EnemyPlane != null && this.EnemyPlane.gameObject != null) {
            this.EnemyPlane.gameObject.SetActive(false);
        }       
        

        // destroy all enemy bomb boouys
        var objects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject o in objects) {
            if (o != null) {
                o.gameObject.SetActive(false);
            }
        }

        // destroy all pickup gas boouys
        var objects2 = GameObject.FindGameObjectsWithTag("Gas");
        foreach (GameObject o in objects2) {
            if (o != null) {
                o.gameObject.SetActive(false);
            }
        }
        this._endGameSound.Play();
    }

    public void RestartButton_Click() {
        //simply reload the scene as if you jsut started the game.. jgunter
        SceneManager.LoadScene("Main");
    }
}
