using UnityEngine;
using System.Collections;

public class IslandController : MonoBehaviour {
    // PRIVATE PROPERTY
    private int _speed;
    private Transform _transform;

    void Start() {
        this._transform = this.GetComponent<Transform>();
        this._speed = 5;
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
            this._reset();
        }
    }
    private void _reset() {
        this._transform.position = new Vector2(Random.Range(-288f,288f), 270f);
    }
}
