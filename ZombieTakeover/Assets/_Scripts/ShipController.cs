using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

    private Transform _transform;
    public Transform explosion;

	void Start () {
        this._transform = this.GetComponent<Transform>();
	}

	void Update () {
        this._move();     
	}

    private void _move() {
        this._transform.position = new Vector2(Mathf.Clamp(Input.mousePosition.x - 320f, -290, 290), -165f);
    }

    private void OnTriggerEnter2D(Collider2D theCol) {
        Debug.Log("Collision with: " + theCol.gameObject.tag);
        if (theCol.gameObject.CompareTag("Gas")) {
            Debug.Log("Add Gas!");
            // good sound
            // add some gas to gas Bar
        } else if (theCol.gameObject.CompareTag("Enemy")) {
            Debug.Log("Hit Bomb!");
            // explosion sound
            GameObject exploder = ((Transform)Instantiate(explosion, theCol.gameObject.transform.position, Quaternion.identity)).gameObject;
            Destroy(exploder, 2.0f);
            //large health hit          
        } else if (theCol.gameObject.CompareTag("Boat")) {
            Debug.Log("Hit Boat!");
            // explosion sound
            // big score bonus
            GameObject exploder = ((Transform)Instantiate(explosion, theCol.gameObject.transform.position, Quaternion.identity)).gameObject;
            Destroy(exploder, 2.0f);
            //small health hit
        }
        //regardless, the colliding object needs to be removed from the scene
        Destroy(theCol.gameObject);
    }
}
