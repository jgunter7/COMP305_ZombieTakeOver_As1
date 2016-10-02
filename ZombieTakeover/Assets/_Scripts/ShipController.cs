using UnityEngine;
using System.Collections;

/*      File Name:              ShipController.cs
 *      Author's Name:          Jason Gunter
 *      Last Modified By:       Jason Gunter
 *      Date Last Modified:     Oct 2nd, 2016
 *      Program Description:    A 2D scrolling game
 *      File Description:       This script controls the player ship's movements, 
 *                              actions, collsions, score, lives, and sound
 *      Revision History:       https://github.com/jgunter7/COMP305_ZombieTakeOver_As1
 */
public class ShipController : MonoBehaviour {
    //PRIVATE VARIABLES
    private Transform _transform;
    private Vector2 _currentPos;
    private float _playerInput;
    private float _speed;

    // PUBLIC VARIABLES
    public Transform explosion;
    public GameController gameController;
    public AudioSource evilLaughSound;
    public AudioSource collectSound;
    public AudioSource explosionSound;

	void Start () {
        this._speed = 2;
        this._transform = this.GetComponent<Transform>();
	}

	void Update () {
        this._move();     
	}

    private void _move() {
        // Move the main ship with the keyboard controls.
        this._currentPos = this._transform.position;
        this._playerInput = Input.GetAxis("Horizontal");

        if (this._playerInput > 0) {
            this._currentPos += new Vector2(this._speed, 0);
        } else if (this._playerInput < 0) {
            this._currentPos -= new Vector2(this._speed, 0);
        }

        this._transform.position = new Vector2(Mathf.Clamp(this._currentPos.x, -290f, 290f), -165f);
    }

    private void OnTriggerEnter2D(Collider2D theCol) {
        // ** //\\ ** \\--- Collision Detection - Gas Tanks / Boats / Enemies (bombs) ---// ** //\\ ** \\
        if (theCol.gameObject.CompareTag("Gas")) {
            this.gameController.ScoreValue += 50;
            this.collectSound.Play();
        } else if (theCol.gameObject.CompareTag("Enemy")) {
            this.gameController.LivesValue -= 1;
            this.explosionSound.Play();
            GameObject exploder = ((Transform)Instantiate(explosion, theCol.gameObject.transform.position, Quaternion.identity)).gameObject;
            Destroy(exploder, 2.0f);        
        } else if (theCol.gameObject.CompareTag("Boat")) {
            this.gameController.ScoreValue += 50;
            this.explosionSound.Play();
            this.evilLaughSound.Play();
            GameObject exploder = ((Transform)Instantiate(explosion, theCol.gameObject.transform.position, Quaternion.identity)).gameObject;
            Destroy(exploder, 1.5f);
        }
        //regardless, the colliding object needs to be removed from the scene
        theCol.gameObject.transform.position = new Vector3(theCol.gameObject.transform.position.x, -300);
    }
}
