using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	public KeyCode moveLeft = KeyCode.LeftArrow;
	public KeyCode moveRight = KeyCode.RightArrow;
	public KeyCode moveUp = KeyCode.UpArrow;
	public KeyCode moveDown = KeyCode.DownArrow;

	public float speed = 10.0f;
	public float touchSpeed = 0.05f;

	public GameObject shipCannon;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		shipCannon.transform.position = this.transform.position + new Vector3 (0.0f, 2.0f, 0.0f);

		// PC Controls
		if (Input.GetKeyDown (moveLeft)) {
			var vel = rigidbody2D.velocity;
			vel.x = -1 * speed;
			rigidbody2D.velocity = vel;
		} else if (Input.GetKeyDown (moveRight)) {
			var vel = rigidbody2D.velocity;
			vel.x = speed;
			rigidbody2D.velocity = vel;
		} else if (Input.GetKeyDown (moveDown)) {
			var vel = rigidbody2D.velocity;
			vel.y = -1 * speed;
			rigidbody2D.velocity = vel;
		} else if (Input.GetKeyDown (moveUp)) {
			var vel = rigidbody2D.velocity;
			vel.y = speed;
			rigidbody2D.velocity = vel;
		} else if (!Input.anyKey) {
			var vel = rigidbody2D.velocity;
			vel.x = 0;
			rigidbody2D.velocity = vel;
		}

		// Touch Controls
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			transform.Translate(touchDeltaPosition.x * touchSpeed, touchDeltaPosition.y * touchSpeed, 0);
		}

		// Limiting player's movement boundaries
		if (transform.position.x <= -4.0f)
			transform.position = new Vector2(-4.0f, transform.position.y);
		else if (transform.position.x >= 4.0f)
			transform.position = new Vector2(4.5f, transform.position.y);
		else if (transform.position.y >= 5.5f)
			transform.position = new Vector2(transform.position.x, 5.5f);
		else if (transform.position.y <= -6.5f)
			transform.position = new Vector2(transform.position.x, -6.5f);
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "EnemyBullet" || col.gameObject.tag == "Enemies") {
			Destroy(this.gameObject);
			Destroy(shipCannon.gameObject);
			Destroy(col.gameObject);
		}
	}
}	