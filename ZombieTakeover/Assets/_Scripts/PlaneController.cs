using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {
    // PRIVATE PROPERTY
    private int _speed;
    private Transform _transform;

    void Start() {
        this._transform = this.GetComponent<Transform>();
        this._reset();
    }

    void Update() {
        this._move();
        this._checkBounds();
    }

    private void _move() {
        Vector2 newPosition = this._transform.position;
        newPosition.x -= this._speed;
        this._transform.position = newPosition;
    }

    private void _checkBounds() {
        if (this._transform.position.x <= -375f) {
            this._reset();
        }
    }
    private void _reset() {
        this._transform.position = new Vector2(Random.Range(375f, 450f), 200f);
        this._speed = 5;
    }
}
