using UnityEngine;
using System.Collections;

public class ItemsController : MonoBehaviour {

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
        Vector2 newPosition = this._transform.position;
        newPosition.y -= this._speed;
        this._transform.position = newPosition;
    }

    private void _checkBounds() {
        if (this._transform.position.y <= -270f) {
            this._destroy();
        }
    }
    private void _destroy() {
        Destroy(this.gameObject); //remove the item from the screen once it has passed the player ship
    }
}
