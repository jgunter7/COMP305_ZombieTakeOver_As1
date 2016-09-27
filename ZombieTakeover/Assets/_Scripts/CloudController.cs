using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {
    // PRIVATE PROPERTY
    private int _speed;
    private int _drift;
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
        newPosition.y -= this._speed;
        newPosition.x += this._drift;
        this._transform.position = newPosition;
    }

    private void _checkBounds() {
        if (this._transform.position.y <= -330f) {
            this._reset();
        }
    }
    private void _reset() {
        this._transform.position = new Vector2(Random.Range(-205f, 205f), 330f);
        this._speed = Random.Range(5, 10);
        this._drift = Random.Range(-2, 2);
    }
}
