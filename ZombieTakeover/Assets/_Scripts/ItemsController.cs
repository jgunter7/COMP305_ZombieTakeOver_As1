using UnityEngine;
using System.Collections;

/*      File Name:              ItemsController.cs
 *      Author's Name:          Jason Gunter
 *      Last Modified By:       Jason Gunter
 *      Date Last Modified:     Oct 2nd, 2016
 *      Program Description:    A 2D scrolling game
 *      File Description:       This script controls the items that are 
 *                              dropped by the enemy ship
 *      Revision History:       https://github.com/jgunter7/COMP305_ZombieTakeOver_As1
 */
public class ItemsController : MonoBehaviour {
    // --------------------- PRIVATE VARIABLES
    private int _speed;
    private Transform _transform;

    void Start() {
        //init private variables
        this._transform = this.GetComponent<Transform>();
        this._speed = 2;
    }

    void Update() {
        this._move();
        this._checkBounds();
    }

    private void _move() {
        //update the item position based on its speed.
        Vector2 newPosition = this._transform.position;
        newPosition.y -= this._speed;
        this._transform.position = newPosition;
    }

    private void _checkBounds() {
        // destroy items that scroll past the screens viewport
        if (this._transform.position.y <= -270f) {
            this._destroy();
        }
    }
    private void _destroy() {
        Destroy(this.gameObject); //remove the item from the screen once it has passed the player ship
    }
}
