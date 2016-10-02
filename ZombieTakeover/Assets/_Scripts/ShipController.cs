using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

    private Transform _transform;
    public Transform explosion;
    public GameController gameController;
    public AudioSource evilLaughSound;
    public AudioSource collectSound;
    public AudioSource explosionSound;

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
            this.gameController.ScoreValue += 50;
            this.collectSound.Play();
        } else if (theCol.gameObject.CompareTag("Enemy")) {
            this.gameController.LivesValue -= 1;
            this.explosionSound.Play();
            GameObject exploder = ((Transform)Instantiate(explosion, theCol.gameObject.transform.position, Quaternion.identity)).gameObject;
            Destroy(exploder, 2.0f);        
        } else if (theCol.gameObject.CompareTag("Boat")) {
            this.gameController.ScoreValue += 50;
            this.explosionSound.Play();
            this.evilLaughSound.Play();
            GameObject exploder = ((Transform)Instantiate(explosion, theCol.gameObject.transform.position, Quaternion.identity)).gameObject;
            Destroy(exploder, 1.5f);
        }
        //regardless, the colliding object needs to be removed from the scene
        Destroy(theCol.gameObject);
    }
}
