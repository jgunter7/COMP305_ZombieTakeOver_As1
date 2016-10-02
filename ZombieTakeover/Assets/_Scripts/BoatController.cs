using UnityEngine;
using System.Collections;

/*      File Name:              BoatController.cs
 *      Author's Name:          Jason Gunter
 *      Last Modified By:       Jason Gunter
 *      Date Last Modified:     Oct 2nd, 2016
 *      Program Description:    A 2D scrolling game
 *      File Description:       This script controls the two enemy boats.
 *      Revision History:       https://github.com/jgunter7/COMP305_ZombieTakeOver_As1
 */
public class BoatController : MonoBehaviour {
    // PRIVATE PROPERTY
    private int _speed;
    private Transform _transform;

    // PUBLIC PROPERTIES
    public bool offset;

    void Start() {
        // init private variables and set the object position.
        this._transform = this.GetComponent<Transform>();
        this._speed = 3;
        this._reset();
    }

    void Update() {
        this._move();
        this._checkBounds();
    }

    private void _move() {
        // move boat on ocean, determined by it's speed
        Vector2 newPosition = this._transform.position;
        newPosition.y -= this._speed;
        this._transform.position = newPosition;
    }

    private void _checkBounds() {
        // check if boat has left the viewport
        if (this._transform.position.y <= -275f) {
            this._reset();
        }
    }
    private void _reset() {
        // In order to not have the boats spawn at the same time
        // one of them is offset for the first spawn.

        if (this.offset) {
            this._transform.position = new Vector2(Random.Range(-288f, 288f), 500f);
            this.offset = false; //only runs this a max of 1 time.
        } else {
            this._transform.position = new Vector2(Random.Range(-288f, 288f), 275f);
        }        
    }
}
