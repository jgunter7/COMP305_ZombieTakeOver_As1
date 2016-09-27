using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {

    private Transform _transform;

	void Start () {
        this._transform = this.GetComponent<Transform>();
	}

	void Update () {
        this._move();     
	}

    private void _move() {
        this._transform.position = new Vector2(Mathf.Clamp(Input.mousePosition.x - 320f, -290, 290), -200f);
    }

    private void OnTriggerEnter2D(Collider2D theCol) {
        if (theCol.gameObject.CompareTag("Island")) {
            Debug.Log("Hit Island!");
        } else if (theCol.gameObject.CompareTag("Enemy")) {
            Debug.Log("Hit Cloud!");
        }        
    }
}
