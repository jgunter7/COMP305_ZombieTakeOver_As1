using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {
    // PRIVATE PROPERTY
    private int _speed = 5;
    private Transform _transform;
    public Transform enemy;
    public Transform supply;
    

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
        DropItems(); //Drop items for the game (bombs / gas tanks)
    }

    private void DropItems() {
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
        //true = gastank, false = bomb
        bool isGasTank = (Random.value > 0.5);
        if (isGasTank) {
            Instantiate(supply, this._transform.position, Quaternion.identity);
        } else {
            Instantiate(enemy, this._transform.position, Quaternion.identity);
        }
    }

    private void _checkBounds() {
        if (this._transform.position.x <= -375f) {
            this._reset();
        }
    }
    private void _reset() {
        this._transform.position = new Vector2(375f, 200f);
    }
}
