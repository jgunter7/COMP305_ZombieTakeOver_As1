using UnityEngine;
using System.Collections;

public class BoatController : MonoBehaviour {
    // PRIVATE PROPERTY
    private int _speed;
    public bool offset;
    private Transform _transform;

    void Start() {
        this._transform = this.GetComponent<Transform>();
        this._speed = 3;
        this._reset();
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
        if (this._transform.position.y <= -275f) {
            this._reset();
        }
    }
    private void _reset() {
        if (this.offset) {
            this._transform.position = new Vector2(Random.Range(-288f, 288f), 500f);
            this.offset = false; //only runs this a max of 1 time.
        } else {
            this._transform.position = new Vector2(Random.Range(-288f, 288f), 275f);
        }        
    }
}
