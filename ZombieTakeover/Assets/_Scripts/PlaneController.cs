using UnityEngine;
using System.Collections;

/*      File Name:              PlaneController.cs
 *      Author's Name:          Jason Gunter
 *      Last Modified By:       Jason Gunter
 *      Date Last Modified:     Oct 2nd, 2016
 *      Program Description:    A 2D scrolling game
 *      File Description:       This script controls the enemy plane which drops 
 *                              collectable items and enemy bombs that can destroy
 *                              the player's main ship!
 *      Revision History:       https://github.com/jgunter7/COMP305_ZombieTakeOver_As1
 */
public class PlaneController : MonoBehaviour {
    // PRIVATE VARIABLE
    private int _speed = 5;
    private Transform _transform;

    // PUBLIC VARIABLE
    public Transform enemy;
    public Transform supply;
    

    void Start() {
        //init private variables
        this._transform = this.GetComponent<Transform>();
        this._reset();
    }

    void Update() {
        this._move();
        this._checkBounds();
    }

    private void _move() {
        // Move plan to new position based on its speed.
        Vector2 newPosition = this._transform.position;
        newPosition.x -= this._speed;
        this._transform.position = newPosition;
        DropItems(); //Drop items for the game (bombs / gas tanks)
    }

    private void DropItems() {
        // If place is on one of the drop locations, drop an item.
        switch ((int)this._transform.position.x) {
            case 350:
            case 250:
            case 150:
            case 50:
            case -50:
            case -150:
            case -250:
            case -350:
                AddItemToScene();
                break;
            default:
                break;

        }
    }

    private void AddItemToScene() {
        // Randomly select an item to drop
        //true = gastank, false = bomb
        bool isGasTank = (Random.value > 0.5);
        if (isGasTank) {
            Instantiate(supply, this._transform.position, Quaternion.identity);
        } else {
            Instantiate(enemy, this._transform.position, Quaternion.identity);
        }
    }

    private void _checkBounds() {
        //if the plane moves out of the viewport, reset it back to the beginning of the viewport
        if (this._transform.position.x <= -375f) {
            this._reset();
        }
    }
    private void _reset() {
        //reset the planes position to the right side of the viewport
        this._transform.position = new Vector2(375f, 200f);
    }
}
