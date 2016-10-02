using UnityEngine;
using System.Collections;

/*      File Name:              OceanController.cs
 *      Author's Name:          Jason Gunter
 *      Last Modified By:       Jason Gunter
 *      Date Last Modified:     Oct 2nd, 2016
 *      Program Description:    A 2D scrolling game
 *      File Description:       This script controls the oceans movements (scrolling effect)
 *      Revision History:       https://github.com/jgunter7/COMP305_ZombieTakeOver_As1
 */
public class OceanController : MonoBehaviour {
    // PRIVATE PROPERTY
    private int _speed;
    private Transform _transform;

    void Start() {
        this._transform = this.GetComponent<Transform>();
        this._speed = 2;
    }

    void Update() {
        this._move();
        this._checkBounds();
    }

    private void _move() {
        // Move the ocean accross the screen at it's 'speed'
        // This creates the scrolling effect.
        Vector2 newPosition = this._transform.position;
        newPosition.y -= this._speed;
        this._transform.position = newPosition;
    }

    private void _checkBounds() {
        // check to see when we should reset the ocean to create the endless scrolling effect.
        if (this._transform.position.y <= -240f) {
            this._reset();
        }
    }
    private void _reset() {
        // reset the ocean back to its original position
        this._transform.position = new Vector2(0f,615f);
    }
}
