﻿using UnityEngine;
using System.Collections;

// reference to the UI namespace
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*      File Name:              GameController.cs
 *      Author's Name:          Jason Gunter
 *      Last Modified By:       Jason Gunter
 *      Date Last Modified:     Oct 2nd, 2016
 *      Program Description:    A 2D scrolling game
 *      File Description:       This script controls the HUD, and the game over screen
 *      Revision History:       https://github.com/jgunter7/COMP305_ZombieTakeOver_As1
 */
public class GameController : MonoBehaviour {
    [Header("UI Labels")]
    public Text LivesLabel;
    public Text ScoreLabel;
    public Text GameOverLabel;
    public Text FinalScoreLabel;
    public Button RestartButton;

    [Header("Game Objects")]
    public GameObject PlayerShip;
    public GameObject EnemyPlane;
    public GameObject EnemyBoat1;
    public GameObject EnemyBoat2;

    // PRIVATE VARIABLES
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
    void Start() {
        // init the scoreboard UI components with starting values
        this.ScoreValue = 0;
        this.LivesValue = 5;
        this.GameOverLabel.gameObject.SetActive(false); // initially hide the gameover label.
        this.FinalScoreLabel.gameObject.SetActive(false); //hidden initially	
        this.RestartButton.gameObject.SetActive(false);
        this._endGameSound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

    }

    void _endGame() {
        // Show Game Over Screen & hide all other items except the ocean.
        this.GameOverLabel.gameObject.SetActive(true); // unhide the gameover label.
        this.FinalScoreLabel.text = "FINAL SCORE: " + this._scoreValue;
        this.FinalScoreLabel.gameObject.SetActive(true);
        this.RestartButton.gameObject.SetActive(true);
        this.LivesLabel.gameObject.SetActive(false); // hide lives object - no longer needed;
        this.ScoreLabel.gameObject.SetActive(false); // hide
        this.PlayerShip.gameObject.SetActive(false); // hide
        this.EnemyPlane.gameObject.SetActive(false); // hide
        this.EnemyBoat1.gameObject.SetActive(false); // hide
        this.EnemyBoat2.gameObject.SetActive(false); // hide

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
        //Play the aweseme game over sound I found!
        this._endGameSound.Play();
    }

    public void RestartButton_Click() {
        //simply reload the scene as if you jsut started the game.. jgunter
        SceneManager.LoadScene("Main");
    }
}
